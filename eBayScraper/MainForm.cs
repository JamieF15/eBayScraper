using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.RegularExpressions;

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
        }

        /// <summary>
        /// Gets all needed html for the search
        /// </summary>
        private async void GetHTML()
        {
            resultsBx.Text = "";

            if (URLIsValid(url))
            {
                HttpClient httpClient = new HttpClient();

                string html = await httpClient.GetStringAsync(url);

                var htmldocument = new HtmlAgilityPack.HtmlDocument();

                htmldocument.LoadHtml(html);

                var products = htmldocument.DocumentNode.Descendants("ul").
                    Where(node => node.GetAttributeValue("id", "").
                    Equals("ListViewInner")).ToList();

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

            productListItems = products[0].Descendants("li")
             .Where(node => node.GetAttributeValue("id", "")
             .Contains("item")).ToList();

            var productListItem = products[0].Descendants();

            if (auctionOnlyrb.Checked)
            { 
                IterateThroughItemsForAuctions(productListItems);
            }
            else if (buyNowOnlyrb.Checked)
            {
                IterateThroughItemsForBuyNow(productListItems);
            }
            else if (auctionAndBuyrb.Checked)
            {
                IterateForAllItems(productListItems);
            }
        }

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
                    id = "ID: " + Item.GetAttributeValue("listingid", "");

                    //product title
                    title = "TITLE: " + Item.Descendants("h3").Where(node => node.GetAttributeValue("class", "").
                    Equals("lvtitle")).FirstOrDefault().InnerText.Trim(elementsToTrim).Replace("New listing", "").Replace("		", "");

                    //product price
                    price = "PRICE: £" + Regex.Match(Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvprice prc")).FirstOrDefault().
                    InnerText.Trim('\r', '\n', '\t'), @"\d+.\d+");

                    //shippping format
                    shippingPrice = "SHIPPING: " + Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvshipping")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim);

                    //buying format
                    buyingFormat = "BUYING FORMAT: " + Item.Descendants("li").
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
                //check if item is set as a auction by checking if the html element contains the word 'bid'
                {
                    //product id
                    id = "ID: " + Item.GetAttributeValue("listingid", "");

                    //product title
                    title = "TITLE: " + Item.Descendants("h3").Where(node => node.GetAttributeValue("class", "").
                    Equals("lvtitle")).FirstOrDefault().InnerText.Trim(elementsToTrim).Replace("New listing", "").Replace("		", "");

                    //product price
                    price = "PRICE: £" + Regex.Match(Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvprice prc")).FirstOrDefault().
                    InnerText.Trim('\r', '\n', '\t'), @"\d+.\d+");

                    //shippping format
                    shippingPrice = "SHIPPING: " + Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvshipping")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim);

                    //buying format
                    buyingFormat = "BUYING FORMAT: " + Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvformat")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim);

                    PrintAllData(id, title, buyingFormat, price, shippingPrice);
                    amountOfItems++;
                }

                statustxtbx.Text = "Search complete " + amountOfItems + " items found.";
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
                    id = "ID: " + Item.GetAttributeValue("listingid", "");

                    //product title
                    title = "TITLE: " + Item.Descendants("h3").Where(node => node.GetAttributeValue("class", "").
                    Equals("lvtitle")).FirstOrDefault().InnerText.Trim(elementsToTrim).Replace("New listing", "").Replace("		", "");

                    //product price
                    price = "PRICE: £" + Regex.Match(Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvprice prc")).FirstOrDefault().
                    InnerText.Trim('\r', '\n', '\t'), @"\d+.\d+");

                    //shippping format
                    shippingPrice = "SHIPPING: " + Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvshipping")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim);

                    //buying format
                    buyingFormat = "BUYING FORMAT: " + Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvformat")).FirstOrDefault().
                    InnerText.Trim(elementsToTrim);

                    PrintAllData(id, title, buyingFormat, price, shippingPrice);
                    amountOfItems++;
                }

                statustxtbx.Text = "Search complete " + amountOfItems + " items found.";
            }
        }

        private void PrintAllData(String id, string title, string buyingFormat, string price, string shippingPrice)
        {
            resultsBx.Text += id;
            resultsBx.Text += Environment.NewLine;

            resultsBx.Text += title;
            resultsBx.Text += Environment.NewLine;

            resultsBx.Text += price;
            resultsBx.Text += Environment.NewLine;

            if (shippingPrice.Contains("£"))
            {
                resultsBx.Text += "SHIPPING: " + shippingPrice.Substring(12, 6);
            }
            else
            {
                resultsBx.Text += shippingPrice;
            }

            resultsBx.Text += Environment.NewLine;

            //fixes a bug where if the item was 'buy it now' it would not display anything
            if (!buyingFormat.Contains("bid"))
            {
                buyingFormat += "Buy It Now";
            }

            resultsBx.Text += buyingFormat.Replace("			", " ");
            resultsBx.Text += Environment.NewLine;

            resultsBx.Text += Environment.NewLine;
            resultsBx.Text += Environment.NewLine;
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
                statustxtbx.Text = "SCRAPING IN PROGRESS";
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
    }
}