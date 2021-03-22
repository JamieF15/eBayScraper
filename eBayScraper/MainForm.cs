using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.IO;

namespace eBayScraper
{
    //code refrenced from: https://www.youtube.com/watch?v=BE708X6r24o
    public partial class MainForm : Form
    {
        public const string URLPROMPT = "Enter an eBay URL";

        public String url = "";

        public static char[] elementsToTrim = new char[] { '\r', '\n', '\t' };

        public MainForm()
        {
            InitializeComponent();
            searchBx.Text = URLPROMPT;
            minPricebx.Text = "Minimum Price: £" + minPricebar.Value;
            maxPricebx.Text = "Maximum Price: £" + maxPricebar.Value;
        }

        /// <summary>
        /// Gets all needed html for the search
        /// </summary>
        private async void GetHTML()
        {
            //clears the results box
            resultsBx.Text = "";

            //check if the url is valid 
            if (URLIsValid(url))
            {
                HttpClient httpClient = new HttpClient();

                string html = await httpClient.GetStringAsync(url);

                var htmldocument = new HtmlAgilityPack.HtmlDocument();

                htmldocument.LoadHtml(html);

                //loads the ebay listings into a list   
                var products = htmldocument.DocumentNode.Descendants("ul").
                    Where(node => node.GetAttributeValue("id", "").
                    Equals("ListViewInner")).ToList();

                //returns all needed products based on the clicked radio buttons
                RetreiveAllNeededItems(products);
            }
            else
            {
                statustxtbx.Text = "Enter a valid eBay URL";
            }
        }

        /// <summary>
        /// Obtains all items 
        /// </summary>
        /// <param name="products"></param>
        private void RetreiveAllNeededItems(List<HtmlAgilityPack.HtmlNode> products)
        {
            var productListItems = new List<HtmlAgilityPack.HtmlNode>();

      
                //MessageBox.Show("Only 'advanced' eBay searches can be used. Follow the directions for help.");
                //searchBx.Text = URLPROMPT;
                //statustxtbx.Text = "";
           

                productListItems = products[0].Descendants("li")
                 .Where(node => node.GetAttributeValue("id", "")
                 .Contains("item")).ToList();
                var productListItem = products[0].Descendants();

            

            if (auctionOnlyrb.Checked && freeAndPaidrb.Checked)
            {
                IterateThroughItemsForAuctions(productListItems);
            }
            else if (auctionAndBuyrb.Checked && freeOnlyrb.Checked)
            {
                IterateThroughItemsForAllFreeShipping(productListItems);

            }else if(auctionAndBuyrb.Checked && paidOnlyrb.Checked)
            {
                IterateThroughItemsForAllPaid(productListItems);
            }
            else if (buyNowOnlyrb.Checked && freeAndPaidrb.Checked)
            {
                IterateThroughItemsForBuyNow(productListItems);
            }
            else if (auctionAndBuyrb.Checked && freeAndPaidrb.Checked)
            {
                IterateForAllItems(productListItems);
            }
            else if (auctionOnlyrb.Checked && freeOnlyrb.Checked)
            {
                IterateThroughItemsForAuctionsAndFreeShipping(productListItems);
            }
            else if (buyNowOnlyrb.Checked && freeOnlyrb.Checked ) // buy now free postage
            {
                IterateThroughItemsForBuyNowAndFreeShipping(productListItems);
            }
            else if (auctionOnlyrb.Checked && paidOnlyrb.Checked)
            {
                IterateThroughItemsForAuctionAndPaidShipping(productListItems);
            }
            else if (buyNowOnlyrb.Checked && paidOnlyrb.Checked) //buy now and paid shippping
            {
                IterateThroughItemsForBuyNowAndPaidShipping(productListItems);
            }
        }

        /// <summary>
        /// Only returns items that are being auctioned 
        /// </summary>
        /// <param name="_productListItems"></param>
        private void IterateThroughItemsForAuctions(List<HtmlAgilityPack.HtmlNode> _productListItems)
        {
            int amountOfItems = 0;
            string buyingFormat = "";
            string id = "";
            string price = "";
            string title = "";
            string shippingPrice = "";

            foreach (var Item in _productListItems)
            {
                //check if item is set as a auction by checking if the html element contains the word 'bid'
                if (Item.Descendants("li").Where(node => node.GetAttributeValue("class", "").
                    Equals("lvformat")).FirstOrDefault().InnerText.Trim(elementsToTrim).Contains("bid"))
                {
                    //product id
                    id = Item.GetAttributeValue("listingid", "");

                    //product title
                    title = Item.Descendants("h3").Where(node => node.GetAttributeValue("class", "").
                    Equals("lvtitle")).FirstOrDefault().InnerText.Trim(elementsToTrim);

                    //product price
                    price = "" + Regex.Match(Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvprice prc")).FirstOrDefault().
                    InnerText.Trim('\r', '\n', '\t'), @"\d+.\d+");

                    //shippping format
                    shippingPrice = Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvshipping")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim);

                    //buying format
                    buyingFormat = Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvformat")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim);

                    PrintAllData(id, title, buyingFormat, price, shippingPrice);
                    amountOfItems++;
                }

                statustxtbx.Text = "Search complete " + amountOfItems + " items found.";
            }
        }

        private void IterateForAllItems(List<HtmlAgilityPack.HtmlNode> _productListItems)
        {
            int amountOfItems = 0;
            string buyingFormat = "";
            string id = "";
            string price = "";
            string title = "";
            string shippingPrice = "";

            foreach (var Item in _productListItems)
            {
                if (ItemIsInPriceRange(Item))
                {
                    //check if item is set as a auction by checking if the html element contains the word 'bid'
                    {
                        //product id
                        id = Item.GetAttributeValue("listingid", "");

                        //product title
                        title = Item.Descendants("h3").Where(node => node.GetAttributeValue("class", "").
                        Equals("lvtitle")).FirstOrDefault().InnerText.Trim(elementsToTrim);

                        //product price
                        price = "" + Regex.Match(Item.Descendants("li").
                        Where(node => node.GetAttributeValue("class", "").
                        Equals("lvprice prc")).FirstOrDefault().
                        InnerText.Trim('\r', '\n', '\t'), @"\d+.\d+");

                        //shippping format
                        shippingPrice = Item.Descendants("li").
                        Where(node => node.GetAttributeValue("class", "").
                        Equals("lvshipping")).FirstOrDefault().
                        InnerText.Trim(elementsToTrim);

                        //buying format
                        buyingFormat = Item.Descendants("li").
                        Where(node => node.GetAttributeValue("class", "").
                        Equals("lvformat")).FirstOrDefault().
                        InnerText.Trim(elementsToTrim);

                        PrintAllData(id, title, buyingFormat, price, shippingPrice);
                        amountOfItems++;
                    }

                    statustxtbx.Text = "Search complete " + amountOfItems + " items found.";
                }
                else
                {
                    statustxtbx.Text = "Search failed, no items in that price range exist in that page.";
                }
            }
        }

        private void IterateThroughItemsForBuyNow(List<HtmlAgilityPack.HtmlNode> _productListItems)
        {
            int amountOfItems = 0;
            string buyingFormat = "";
            string id = "";
            string price = "";
            string title = "";
            string shippingPrice = "";

            foreach (var Item in _productListItems)
            {
                //check if item is set as a auction by checking if the html element contains the word 'bid'
                if (!Item.Descendants("li").Where(node => node.GetAttributeValue("class", "").
                    Equals("lvformat")).FirstOrDefault().InnerText.Trim(elementsToTrim).Contains("bid"))
                {
                    //product id
                    id = Item.GetAttributeValue("listingid", "");

                    //product title
                    title = Item.Descendants("h3").Where(node => node.GetAttributeValue("class", "").
                    Equals("lvtitle")).FirstOrDefault().InnerText.Trim(elementsToTrim);

                    //product price
                    price = "" + Regex.Match(Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvprice prc")).FirstOrDefault().
                    InnerText.Trim('\r', '\n', '\t'), @"\d+.\d+");

                    //shippping format
                    shippingPrice = Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvshipping")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim);

                    //buying format
                    buyingFormat = Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvformat")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim);

                    PrintAllData(id, title, buyingFormat, price, shippingPrice);
                    amountOfItems++;
                }

                statustxtbx.Text = "Search complete " + amountOfItems + " items found.";
            }
        }
        private void IterateThroughItemsForAllFreeShipping(List<HtmlAgilityPack.HtmlNode> _productListItems)
        {
            int amountOfItems = 0;
            string buyingFormat = "";
            string id = "";
            string price = "";
            string title = "";
            string shippingPrice = "";

            foreach (var Item in _productListItems)
            {
                //check if item is set as a auction by checking if the html element contains the word 'bid'
                if (!Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvshipping")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim).Contains("£"))
                {
                    //product id
                    id = Item.GetAttributeValue("listingid", "");

                    //product title
                    title = Item.Descendants("h3").Where(node => node.GetAttributeValue("class", "").
                    Equals("lvtitle")).FirstOrDefault().InnerText.Trim(elementsToTrim);

                    //product price
                    price = "" + Regex.Match(Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvprice prc")).FirstOrDefault().
                    InnerText.Trim('\r', '\n', '\t'), @"\d+.\d+");

                    //shippping format
                    shippingPrice = Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvshipping")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim);

                    //buying format
                    buyingFormat = Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvformat")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim);

                    PrintAllData(id, title, buyingFormat, price, shippingPrice);
                    amountOfItems++;
                }

                statustxtbx.Text = "Search complete " + amountOfItems + " items found.";
            }
        }
        private void IterateThroughItemsForAllPaid(List<HtmlAgilityPack.HtmlNode> _productListItems)
        {
            int amountOfItems = 0;
            string buyingFormat = "";
            string id = "";
            string price = "";
            string title = "";
            string shippingPrice = "";

            foreach (var Item in _productListItems)
            {
                //check if item is set as a auction by checking if the html element contains the word 'bid'
                if (Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvshipping")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim).Contains("£"))
                {
                    //product id
                    id = Item.GetAttributeValue("listingid", "");

                    //product title
                    title = Item.Descendants("h3").Where(node => node.GetAttributeValue("class", "").
                    Equals("lvtitle")).FirstOrDefault().InnerText.Trim(elementsToTrim);

                    //product price
                    price = "" + Regex.Match(Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvprice prc")).FirstOrDefault().
                    InnerText.Trim('\r', '\n', '\t'), @"\d+.\d+");

                    //shippping format
                    shippingPrice = Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvshipping")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim);

                    //buying format
                    buyingFormat = Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvformat")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim);

                    PrintAllData(id, title, buyingFormat, price, shippingPrice);
                    amountOfItems++;
                }

                statustxtbx.Text = "Search complete " + amountOfItems + " items found.";
            }
        }
        private void IterateThroughItemsForAuctionsAndFreeShipping(List<HtmlAgilityPack.HtmlNode> _productListItems)
        {
            int amountOfItems = 0;
            string buyingFormat = "";
            string id = "";
            string price = "";
            string title = "";
            string shippingPrice = "";

            foreach (var Item in _productListItems)
            {
                //check if item is set as a auction by checking if the html element contains the word 'bid'
                if (Item.Descendants("li").Where(node => node.GetAttributeValue("class", "").
                    Equals("lvformat")).FirstOrDefault().InnerText.Trim(elementsToTrim).Contains("bid") && !Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvshipping")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim).Contains("£"))
                {
                    //product id
                    id = Item.GetAttributeValue("listingid", "");

                    //product title
                    title = Item.Descendants("h3").Where(node => node.GetAttributeValue("class", "").
                    Equals("lvtitle")).FirstOrDefault().InnerText.Trim(elementsToTrim);

                    //product price
                    price = "" + Regex.Match(Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvprice prc")).FirstOrDefault().
                    InnerText.Trim('\r', '\n', '\t'), @"\d+.\d+");

                    //shippping format
                    shippingPrice = Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvshipping")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim);

                    //buying format
                    buyingFormat = Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvformat")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim);

                    PrintAllData(id, title, buyingFormat, price, shippingPrice);
                    amountOfItems++;
                }

                statustxtbx.Text = "Search complete " + amountOfItems + " items found.";
            }
        }
        private void IterateThroughItemsForBuyNowAndFreeShipping(List<HtmlAgilityPack.HtmlNode> _productListItems)
        {
            int amountOfItems = 0;
            string buyingFormat = "";
            string id = "";
            string price = "";
            string title = "";
            string shippingPrice = "";

            foreach (var Item in _productListItems)
            {
                //check if item is set as a auction by checking if the html element contains the word 'bid'
                if (!Item.Descendants("li").Where(node => node.GetAttributeValue("class", "").
                    Equals("lvformat")).FirstOrDefault().InnerText.Trim(elementsToTrim).Contains("bid") && Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvshipping")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim).Contains("£"))
                {
                    //product id
                    id = Item.GetAttributeValue("listingid", "");

                    //product title
                    title = Item.Descendants("h3").Where(node => node.GetAttributeValue("class", "").
                    Equals("lvtitle")).FirstOrDefault().InnerText.Trim(elementsToTrim);

                    //product price
                    price = "" + Regex.Match(Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvprice prc")).FirstOrDefault().
                    InnerText.Trim('\r', '\n', '\t'), @"\d+.\d+");

                    //shippping format
                    shippingPrice = Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvshipping")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim);

                    //buying format
                    buyingFormat = Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvformat")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim);

                    PrintAllData(id, title, buyingFormat, price, shippingPrice);
                    amountOfItems++;
                }

                statustxtbx.Text = "Search complete " + amountOfItems + " items found.";
            }
        }
        private void IterateThroughItemsForBuyNowAndPaidShipping(List<HtmlAgilityPack.HtmlNode> _productListItems)
        {
            int amountOfItems = 0;
            string buyingFormat = "";
            string id = "";
            string price = "";
            string title = "";
            string shippingPrice = "";

            foreach (var Item in _productListItems)
            {
                //check if item is set as a auction by checking if the html element contains the word 'bid'
                if (!Item.Descendants("li").Where(node => node.GetAttributeValue("class", "").
                    Equals("lvformat")).FirstOrDefault().InnerText.Trim(elementsToTrim).Contains("bid") && Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvshipping")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim).Contains("£"))
                {
                    //product id
                    id = Item.GetAttributeValue("listingid", "");

                    //product title
                    title = Item.Descendants("h3").Where(node => node.GetAttributeValue("class", "").
                    Equals("lvtitle")).FirstOrDefault().InnerText.Trim(elementsToTrim);

                    //product price
                    price = "" + Regex.Match(Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvprice prc")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim), @"\d+.\d+");

                    //shippping format
                    shippingPrice = Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvshipping")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim);

                    //buying format
                    buyingFormat = Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvformat")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim);

                    PrintAllData(id, title, buyingFormat, price, shippingPrice);
                    amountOfItems++;
                }

                statustxtbx.Text = "Search complete " + amountOfItems + " items found.";
            }
        }

        private void IterateThroughItemsForAuctionAndPaidShipping(List<HtmlAgilityPack.HtmlNode> _productListItems)
        {
            int amountOfItems = 0;
            string buyingFormat = "";
            string id = "";
            string price = "";
            string title = "";
            string shippingPrice = "";

            foreach (var Item in _productListItems)
            {
                if (ItemIsInPriceRange(Item))
                {
                    //check if item is set as a auction by checking if the html element contains the word 'bid'
                    if (!Item.Descendants("li").Where(node => node.GetAttributeValue("class", "").
                        Equals("lvformat")).FirstOrDefault().InnerText.Trim(elementsToTrim).Contains("bid") && Item.Descendants("li").
                        Where(node => node.GetAttributeValue("class", "").
                        Equals("lvshipping")).FirstOrDefault().
                        InnerText.Trim(elementsToTrim).Contains("£"))
                    {
                        //product id
                        id = Item.GetAttributeValue("listingid", "");

                        //product title
                        title = Item.Descendants("h3").Where(node => node.GetAttributeValue("class", "").
                        Equals("lvtitle")).FirstOrDefault().InnerText.Trim(elementsToTrim);

                        //product price
                        price = "" + Regex.Match(Item.Descendants("li").
                        Where(node => node.GetAttributeValue("class", "").
                        Equals("lvprice prc")).FirstOrDefault().
                        InnerText.Trim('\r', '\n', '\t'), @"\d+.\d+");

                        //shippping format
                        shippingPrice = Item.Descendants("li").
                        Where(node => node.GetAttributeValue("class", "").
                        Equals("lvshipping")).FirstOrDefault().
                        InnerText.Trim(elementsToTrim);

                        //buying format
                        buyingFormat = Item.Descendants("li").
                        Where(node => node.GetAttributeValue("class", "").
                        Equals("lvformat")).FirstOrDefault().
                        InnerText.Trim(elementsToTrim);

                        PrintAllData(id, title, buyingFormat, price, shippingPrice);
                        amountOfItems++;
                    }

                    statustxtbx.Text = "Search complete " + amountOfItems + " items found.";
                }
            }
        }

        /// <summary>
        /// Prints all parsed in data to the results box 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="buyingFormat"></param>
        /// <param name="price"></param>
        /// <param name="shippingPrice"></param>
        private void PrintAllData(String id, string title, string buyingFormat, string price, string shippingPrice)
        {
            resultsBx.Text += "ID: " + id;
            resultsBx.Text += Environment.NewLine;

            if (title.Contains("listing"))
            {
                resultsBx.Text += "TITLE: " + title.Replace("New listing", "").Replace("		", "").Replace("\n", "");
            }
            else
            {
                resultsBx.Text += "TITLE: " + title;


            }
            resultsBx.Text += Environment.NewLine;

            resultsBx.Text += "PRICE: £" + price;
            resultsBx.Text += Environment.NewLine;

            if (shippingPrice.Contains("£"))
            {
                resultsBx.Text += "SHIPPING: " + shippingPrice.Substring(2, 6);
            }
            else
            {
                resultsBx.Text += "SHIPPING: " + shippingPrice;
            }

            resultsBx.Text += Environment.NewLine;

            //fixes a bug where if the item was 'buy it now' it would not display anything
            if (!buyingFormat.Contains("bid"))
            {
                buyingFormat += "Buy It Now";
            }

            resultsBx.Text += "BUYING FORMAT: " + buyingFormat.Replace("			", " ");
            resultsBx.Text += Environment.NewLine;

            resultsBx.Text += Environment.NewLine;
            resultsBx.Text += Environment.NewLine;
        }

        private bool ItemIsInPriceRange(HtmlAgilityPack.HtmlNode item)
        {

            var itemPrice =  Regex.Match(item.Descendants("li").
                  Where(node => node.GetAttributeValue("class", "").
                  Equals("lvprice prc")).FirstOrDefault().
                  InnerText.Trim(elementsToTrim), @"\d+.\d+").ToString();

          


            if ((double.Parse( itemPrice) >= minPricebar.Value && double.Parse(itemPrice) <= maxPricebar.Value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
        /// <summary>
        /// Triggers on clicking of the search button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goBtn_Click(object sender, EventArgs e)
        {
            url = searchBx.Text;

            //if the url is empty, inform the user
            if (!URLIsValid(url))
            {
                statustxtbx.Text = "Invalid Search.";
            }
            else if (URLIsValid(url))
            {
                statustxtbx.Text = "Scraping in progress, please wait...";
                GetHTML();
            }
        }

        /// <summary>
        /// Checks if the url is a valid, searchable URL
        /// </summary>
        /// <param name="url">The URL being checked</param>
        /// <returns></returns>
        public bool URLIsValid(string url)
        {
            Uri result;

            bool tryCreateResult = Uri.TryCreate(url, UriKind.Absolute, out result);

            if (tryCreateResult == true && result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void searchBx_Click(object sender, EventArgs e)
        {
            if (searchBx.Text == URLPROMPT || !URLIsValid(url))
            {
                searchBx.Text = "";
            }
        }

        private void searchBx_Leave(object sender, EventArgs e)
        {
            if (searchBx.Text.Length == 0)
            {
                searchBx.Text = URLPROMPT;
            }
        }

        private void helpPicbx_Click(object sender, EventArgs e)
        {
            InstructionsForm instructionsForm = new InstructionsForm();
            instructionsForm.Show();
        }

        private void exportbtn_Click(object sender, EventArgs e)
        {
            if (resultsBx.Text.Length != 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.DefaultExt = "txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (Stream s = File.Open(saveFileDialog.FileName, FileMode.CreateNew))
                    using (StreamWriter streamWriter = new StreamWriter(s))
                    {
                        streamWriter.Write(resultsBx.Text);
                    }
                }
            }
            else
            {
                MessageBox.Show("To export, perform a search first.");
            }
        }

        private void minPricebar_Scroll(object sender, EventArgs e)
        {
            minPricebx.Text = "Minimum Price: £" + minPricebar.Value;

        }

        private void maxPricebar_Scroll(object sender, EventArgs e)
        {
            maxPricebx.Text = "Maximum Price: £" + maxPricebar.Value;
        }

        private void helpPicbx_MouseEnter(object sender, EventArgs e)
        {
            
        }
    }
}