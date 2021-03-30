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
        //propts the user to enter an ebay url 
        public const string URLPROMPT = "Enter an eBay URL";

        //the ebay url that's being scraped for data
        public String url;

        //stores the hiddin formatting to be trimmed from the html node's data 
        public static char[] elementsToTrim = new char[] { '\r', '\n', '\t' };

        public MainForm()
        {
            InitializeComponent();

            //on form load, set the text of the search text box to the url prompt
            tbsearch.Text = URLPROMPT;
        }

        /// <summary>
        /// Gets all needed html for the search
        /// </summary>
        private async void GetHTML()
        {
            string html = "";

            //clears the results box
            tbresult.Text = "";

            //check if the url is valid 
            if (URLIsValid(url))
            {
                //instantiate a httpclient 
                HttpClient httpClient = new HttpClient();

                try
                {
                    //gets the html of the inputted url's webpage and stores it 
                    html = await httpClient.GetStringAsync(url);
                }
                catch (IOException)
                {
                    //gets the html of the inputted url's webpage and stores it 
                    GetHTML();
                }

                //html document to load the webpage's html
                var htmldocument = new HtmlAgilityPack.HtmlDocument();

                //load the webpages html
                htmldocument.LoadHtml(html);

                //loads the ebay listings into a list   
                var products = htmldocument.DocumentNode.Descendants("ul").
                    Where(node => node.GetAttributeValue("id", "").
                    Equals("ListViewInner")).ToList();

                //returns all needed products based on the clicked radio buttons
                RetreiveAllNeededItems(products);
            }
            //if the url is not valid, inform the user
            else
            {
                tbstatus.Text = "Enter a valid eBay URL";
            }
        }

        /// <summary>
        /// Obtains all items based on the combination of checked radio buttons 
        /// </summary>
        /// <param name="products"></param>
        private void RetreiveAllNeededItems(List<HtmlAgilityPack.HtmlNode> products)
        {
            //list of html nodes
            List<HtmlAgilityPack.HtmlNode> productListItems = new List<HtmlAgilityPack.HtmlNode>();

            //populate the list with html nodes that have attributes values that contaim the term "item"
            productListItems = products[0].Descendants("li").Where(node => node.GetAttributeValue("id", "").Contains("item")).ToList();

            //   var productListItem = products[0].Descendants();

            //based on the radio button's clicked, perform the appropriate search
            if (rbauctiononly.Checked && rbfreeandpaid.Checked)
            {
                FindAllAuctions(productListItems);
            }
            else if (rbauctionandbuy.Checked && rbfreeonly.Checked)
            {
                FindAllFreeShipping(productListItems);
            }
            else if (rbauctionandbuy.Checked && rbpaidonly.Checked)
            {
                FindAllPaidShipping(productListItems);
            }
            else if (rbbuyitnow.Checked && rbfreeandpaid.Checked)
            {
                FindAllBuyNow(productListItems);
            }
            else if (rbauctionandbuy.Checked && rbfreeandpaid.Checked)
            {
                FindAllItems(productListItems);
            }
            else if (rbauctiononly.Checked && rbfreeonly.Checked)
            {
                FindAllAuctionsWithFreeShipping(productListItems);
            }
            else if (rbbuyitnow.Checked && rbfreeonly.Checked) // buy now free postage
            {
                FindAllBuyNowWithFreeShipping(productListItems);
            }
            else if (rbauctiononly.Checked && rbpaidonly.Checked)
            {
                FindAllAuctionsWithPaidShipping(productListItems);
            }
            else if (rbbuyitnow.Checked && rbpaidonly.Checked) //buy now and paid shippping
            {
                FindAllBuyNowWithPaidShipping(productListItems);
            }
        }

        /// <summary>
        /// Only returns items that are being auctioned 
        /// </summary>
        /// <param name="_productListItems"></param>
        private void FindAllAuctions(List<HtmlAgilityPack.HtmlNode> _productListItems)
        {
            //amount of items in a particular search
            int amountOfItems = 0;

            //loop through each item in the product list
            foreach (var Item in _productListItems)
            {
                //check if the item is in the price range
                if (ItemIsInPriceRange(Item))
                {
                    //check if item is set as a auction by checking if the html element contains the word 'bid'
                    if (Item.Descendants("li").Where(node => node.GetAttributeValue("class", "").
                        Equals("lvformat")).FirstOrDefault().InnerText.Trim(elementsToTrim).Contains("bid"))
                    {
                        //retrive the item 
                        RetreiveItems(Item);

                        //increment the item counter
                        amountOfItems++;
                    }

                    //display the amount of items in the search
                    tbstatus.Text = "Search complete " + amountOfItems + " items found.";
                }
                //if there are no items, state that there are none in that search
                else if (amountOfItems == 0)
                {
                    tbstatus.Text = "Search failed, no items were found in that search";
                }
            }
        }

        /// <summary>
        /// Gets all items regardless of their details
        /// </summary>
        /// <param name="_productListItems"></param>
        private void FindAllItems(List<HtmlAgilityPack.HtmlNode> _productListItems)
        {
            int amountOfItems = 0;

            foreach (var Item in _productListItems)
            {
                if (ItemIsInPriceRange(Item))
                {
                    //check if item is set as a auction by checking if the html element contains the word 'bid'
                    {
                        RetreiveItems(Item);

                        amountOfItems++;
                    }

                    tbstatus.Text = "Search complete " + amountOfItems + " items found.";
                }
                else if (amountOfItems == 0)
                {
                    tbstatus.Text = "Search failed, no items in that price range exist in that page.";
                }
            }
        }

        /// <summary>
        /// Finds all items that are listed as buy it now
        /// </summary>
        /// <param name="_productListItems"></param>
        private void FindAllBuyNow(List<HtmlAgilityPack.HtmlNode> _productListItems)
        {
            int amountOfItems = 0;

            foreach (var Item in _productListItems)
            {
                if (ItemIsInPriceRange(Item))
                {
                    //check if item is set as a auction by checking if the html element contains the word 'bid'
                    if (!Item.Descendants("li").Where(node => node.GetAttributeValue("class", "").
                        Equals("lvformat")).FirstOrDefault().InnerText.Trim(elementsToTrim).Contains("bid"))
                    {
                        RetreiveItems(Item);

                        amountOfItems++;
                    }

                    tbstatus.Text = "Search complete " + amountOfItems + " items found.";
                }
                else if (amountOfItems == 0)
                {
                    tbstatus.Text = "Search failed, no items in that price range exist in that page.";
                }
            }
        }

        /// <summary>
        /// Finds all items that have free shipping
        /// </summary>
        /// <param name="_productListItems"></param>
        private void FindAllFreeShipping(List<HtmlAgilityPack.HtmlNode> _productListItems)
        {
            int amountOfItems = 0;

            foreach (var Item in _productListItems)
            {
                if (ItemIsInPriceRange(Item))
                {
                    //check if item is set as a auction by checking if the html element contains the word 'bid'
                    if (!Item.Descendants("li").
                        Where(node => node.GetAttributeValue("class", "").
                        Equals("lvshipping")).FirstOrDefault().
                        InnerText.Trim(elementsToTrim).Contains("£"))
                    {
                        RetreiveItems(Item);

                        amountOfItems++;
                    }

                    tbstatus.Text = "Search complete " + amountOfItems + " items found.";
                }
                else if (amountOfItems == 0)
                {
                    tbstatus.Text = "Search failed, no items in that price range exist in that page.";
                }
            }
        }

        /// <summary>
        /// Finds all items that do not have free shipping
        /// </summary>
        /// <param name="_productListItems"></param>
        private void FindAllPaidShipping(List<HtmlAgilityPack.HtmlNode> _productListItems)
        {
            int amountOfItems = 0;

            foreach (var Item in _productListItems)
            {
                if (ItemIsInPriceRange(Item))
                {
                    //check if item is set as a auction by checking if the html element contains the word 'bid'
                    if (Item.Descendants("li").
                        Where(node => node.GetAttributeValue("class", "").
                        Equals("lvshipping")).FirstOrDefault().
                        InnerText.Trim(elementsToTrim).Contains("£"))
                    {
                        RetreiveItems(Item);

                        amountOfItems++;
                    }

                    tbstatus.Text = "Search complete " + amountOfItems + " items found.";
                }
                else if (amountOfItems == 0)
                {
                    tbstatus.Text = "Search failed, no items in that price range exist in that page.";
                }
            }
        }

        /// <summary>
        /// Finds all items that are auctions that have free shipping
        /// </summary>
        /// <param name="_productListItems"></param>
        private void FindAllAuctionsWithFreeShipping(List<HtmlAgilityPack.HtmlNode> _productListItems)
        {
            int amountOfItems = 0;

            foreach (var Item in _productListItems)
            {
                if (ItemIsInPriceRange(Item))
                {
                    //check if item is set as a auction by checking if the html element contains the word 'bid'
                    if (Item.Descendants("li").Where(node => node.GetAttributeValue("class", "").
                        Equals("lvformat")).FirstOrDefault().InnerText.Trim(elementsToTrim).Contains("bid") && !Item.Descendants("li").
                        Where(node => node.GetAttributeValue("class", "").
                        Equals("lvshipping")).FirstOrDefault().
                        InnerText.Trim(elementsToTrim).Contains("£"))
                    {
                        RetreiveItems(Item);

                        amountOfItems++;
                    }

                    tbstatus.Text = "Search complete " + amountOfItems + " items found.";

                }
                else if (amountOfItems == 0)
                {
                    tbstatus.Text = "Search failed, no items in that price range exist in that page.";
                }
            }
        }

        /// <summary>
        /// Finds all items hat have free shipping and are listed as buy it now
        /// </summary>
        /// <param name="_productListItems"></param>
        private void FindAllBuyNowWithFreeShipping(List<HtmlAgilityPack.HtmlNode> _productListItems)
        {
            int amountOfItems = 0;

            foreach (var Item in _productListItems)
            {
                if (ItemIsInPriceRange(Item))
                {
                    //check if item is set as a auction by checking if the html element contains the word 'bid'
                    if (!Item.Descendants("li").Where(node => node.GetAttributeValue("class", "").
                        Equals("lvformat")).FirstOrDefault().InnerText.Trim(elementsToTrim).Contains("bid") && !Item.Descendants("li").
                        Where(node => node.GetAttributeValue("class", "").
                        Equals("lvshipping")).FirstOrDefault().
                        InnerText.Trim(elementsToTrim).Contains("£"))
                    {
                        RetreiveItems(Item);
                        amountOfItems++;
                    }

                    tbstatus.Text = "Search complete " + amountOfItems + " items found.";

                }
                else if (amountOfItems == 0)
                {
                    tbstatus.Text = "Search failed, no items in that price range exist in that page.";
                }
            }
        }

        /// <summary>
        /// Finds all items that are listed as buy it now and have paid shipping
        /// </summary>
        /// <param name="_productListItems"></param>
        private void FindAllBuyNowWithPaidShipping(List<HtmlAgilityPack.HtmlNode> _productListItems)
        {
            int amountOfItems = 0;

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
                        RetreiveItems(Item);

                        amountOfItems++;
                    }

                    tbstatus.Text = "Search complete " + amountOfItems + " items found.";
                }
                else if (amountOfItems == 0)
                {
                    tbstatus.Text = "Search failed, no items in that price range exist in that page.";
                }
            }
        }

        /// <summary>
        /// Finds all items that are auctions and have paid shipping
        /// </summary>
        /// <param name="_productListItems"></param>
        private void FindAllAuctionsWithPaidShipping(List<HtmlAgilityPack.HtmlNode> _productListItems)
        {
            int amountOfItems = 0;

            foreach (var Item in _productListItems)
            {
                if (ItemIsInPriceRange(Item))
                {
                    //check if item is set as a auction by checking if the html element contains the word 'bid'
                    if (Item.Descendants("li").Where(node => node.GetAttributeValue("class", "").
                        Equals("lvformat")).FirstOrDefault().InnerText.Trim(elementsToTrim).Contains("bid") && Item.Descendants("li").
                        Where(node => node.GetAttributeValue("class", "").
                        Equals("lvshipping")).FirstOrDefault().
                        InnerText.Trim(elementsToTrim).Contains("£"))
                    {
                        RetreiveItems(Item);

                        amountOfItems++;
                    }

                    tbstatus.Text = "Search complete " + amountOfItems + " items found.";
                }
                else if (amountOfItems == 0)
                {
                    tbstatus.Text = "Search failed, no items in that price range exist in that page.";
                }
            }
        }

        /// <summary>
        /// Loops through the list of items and returns items in the form of a number of strings and prints them to the text box
        /// </summary>
        /// <param name="Item"></param>
        public void RetreiveItems(HtmlAgilityPack.HtmlNode Item)
        {
            //the buying format of the item
            string buyingFormat = "";

            //the id of the item
            string id = "";

            //the price of the item
            string price = "";

            //the title of the item
            string title = "";

            //the shipping price of the item
            string shippingPrice = "";

            //set the id
            id = Item.GetAttributeValue("listingid", "");

            //set the title
            title = Item.Descendants("h3").Where(node => node.GetAttributeValue("class", "").
            Equals("lvtitle")).FirstOrDefault().InnerText.Trim(elementsToTrim);

            //set the price
            price = "" + Regex.Match(Item.Descendants("li").
            Where(node => node.GetAttributeValue("class", "").
            Equals("lvprice prc")).FirstOrDefault().
            InnerText.Trim(elementsToTrim), @"\d+.\d+");

            //set the shippping format
            shippingPrice = Item.Descendants("li").
            Where(node => node.GetAttributeValue("class", "").
            Equals("lvshipping")).FirstOrDefault().
            InnerText.Trim(elementsToTrim);

            //set the buying format
            buyingFormat = Item.Descendants("li").
            Where(node => node.GetAttributeValue("class", "").
            Equals("lvformat")).FirstOrDefault().
            InnerText.Trim(elementsToTrim);

            //print all the data for this item
            PrintAllData(id, title, buyingFormat, price, shippingPrice);
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
            //print the id
            tbresult.Text += "ID: " + id;
            tbresult.Text += Environment.NewLine;

            /*
             * if the item was a new listing, it would and cause formatting issues, 
             * this code replaces the words that cuase the issues with empty strings
             */
            if (title.Contains("listing"))
            {
                tbresult.Text += "TITLE: " + title.Replace("New listing", string.Empty).Replace("		", string.Empty).Replace(Environment.NewLine, string.Empty);
            }
            else
            {
                tbresult.Text += "TITLE: " + title;
            }
            tbresult.Text += Environment.NewLine;

            //print the price 
            tbresult.Text += "PRICE: £" + price;
            tbresult.Text += Environment.NewLine;

            //if the item's price contains a "£", it means that the shipping is NOT free
            if (shippingPrice.Contains("£"))
            {
                //this code isolates the price from the relevant html element
                tbresult.Text += "SHIPPING: " + shippingPrice.Substring(2, 6);
            }
            else
            {
                tbresult.Text += "SHIPPING: " + shippingPrice;
            }
            tbresult.Text += Environment.NewLine;

            //fixes a bug where if the item was 'buy it now' it would not display anything
            if (!buyingFormat.Contains("bid"))
            {
                tbresult.Text += "BUYING FORMAT: Buy It Now";
            }
            else
            {
                tbresult.Text += "BUYING FORMAT: Auction, " + buyingFormat.Replace("			", " ");
            }
            tbresult.Text += Environment.NewLine;

            tbresult.Text += Environment.NewLine;
            tbresult.Text += Environment.NewLine;
        }


        private bool StringHasSpecialChars(String s)
        {
            string specialChars = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";

            foreach (var letter in specialChars)
            {
                if (s.Contains(letter))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if an item's price is within a designated range
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ItemIsInPriceRange(HtmlAgilityPack.HtmlNode item)
        {
            //the price of the item
            string itemPrice = Regex.Match(item.Descendants("li").
                  Where(node => node.GetAttributeValue("class", "").
                  Equals("lvprice prc")).FirstOrDefault().
                  InnerText.Trim(elementsToTrim), @"\d+.\d+").ToString();

            //checks if the price of the item is greater than the min
            if (tbMinPrice.Text != "" &&
                tbMaxPrice.Text != "")
            {

                if (!Regex.Match(tbMaxPrice.Text, "[a-zA-Z]").Success ||
                !Regex.Match(tbMinPrice.Text, "[a-zA-Z]").Success ||
                !Regex.Match(tbMaxPrice.Text, "[$&+,:;=?@#|'<>.^*()%!-]").Success)
                {

                    tbMaxPrice.Text = Regex.Replace(tbMaxPrice.Text, @"\s+", "");
                    tbMinPrice.Text = Regex.Replace(tbMinPrice.Text, @"\s+", "");

                    if ((Math.Truncate(decimal.Parse(itemPrice)) >= decimal.Parse(tbMinPrice.Text) && decimal.Parse(itemPrice) <= Math.Truncate(Convert.ToDecimal(tbMaxPrice.Text))))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
            return true;
        }

        /// <summary>
        /// Triggers on clicking of the search button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goBtn_Click(object sender, EventArgs e)
        {
            //the entered url
            url = tbsearch.Text;

            if (Regex.Match(tbMinPrice.Text, @"[a-zA-z]+").Success ||
            Regex.Match(tbMaxPrice.Text, @"[a-zA-Z]+").Success ||
            !StringHasSpecialChars(tbMaxPrice.Text) ||
            !StringHasSpecialChars(tbMinPrice.Text))
            {
                MessageBox.Show("Letters or special characters cannot be in the price filters.");
                return;
            }
            else if (Math.Truncate(Convert.ToDecimal(tbMaxPrice.Text)) <= Math.Truncate(Convert.ToDecimal(tbMinPrice.Text)))
            {
                MessageBox.Show("The filter for the maximum price cannot be lower than the minimum price.");
                return;
            }

            //if the url is empty, inform the user
            if (!URLIsValid(url))
            {
                tbstatus.Text = "Invalid Search.";
            }
            //in the ebay url, the characters 'itm' are within a link for a product listing
            else if (url.Contains("itm"))
            {
                tbstatus.Text = "Only enter an advanced eBay search, not a specific listing.";
            }
            //checks if the url is from a normal search
            else if (!url.Contains("ipg"))
            {
                tbstatus.Text = "Only enter an advanced eBay search, not a normal search.";
            }
            //if the url is valid, begin the search
            else if (URLIsValid(url))
            {
                tbstatus.Text = "Scraping in progress, please wait...";
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
            //checks if the url is valid 
            bool tryCreateResult = Uri.TryCreate(url, UriKind.Absolute, out Uri result);

            //if the result is null and the bool above is true, the url is valid
            if (tryCreateResult == true && result != null && url.Contains("https://www.ebay.co.uk/"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Triggers when the search textbox is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbsearch_Click(object sender, EventArgs e)
        {
            //if the search text box's text is equal to the url prompt or is invalided, clear it
            if (tbsearch.Text == URLPROMPT || !URLIsValid(url))
            {
                tbsearch.Text = "";
            }
        }

        /// <summary>
        /// Triggers when focus leaves the search text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbsearch_Leave(object sender, EventArgs e)
        {
            //if the string in the text box is empty, reset it to the url prompt
            if (tbsearch.Text.Length == 0)
            {
                tbsearch.Text = URLPROMPT;
            }
        }

        private void helpPicbx_Click(object sender, EventArgs e)
        {
            InstructionsForm instructionsForm = new InstructionsForm();
            instructionsForm.Show();
        }

        /// <summary>
        /// Triggers when the export button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportbtn_Click(object sender, EventArgs e)
        {
            //if a search has been performed, allow the user to export
            if (tbresult.Text.Length != 0)
            {
                //create a save dialog object
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                //set the default file extention to txt
                saveFileDialog.DefaultExt = "txt";

                //'ok' button is clicked
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //stream to open the option to save a file
                        using (Stream s = File.Open(saveFileDialog.FileName, FileMode.CreateNew))

                        //when a file is saved, write the content of the search results to it
                        using (StreamWriter streamWriter = new StreamWriter(s))
                        {
                            streamWriter.Write(tbresult.Text);
                        }
                    }
                    //if the file already exists, allow the user to replace it
                    catch (IOException)
                    {
                        //get the file path of the needed file
                        string filePath = Path.GetFullPath(saveFileDialog.FileName);

                        //check if the file exists
                        bool fileExists = File.Exists(filePath);

                        //if the file exists, overwrite it with new contents
                        if (fileExists)
                        {
                            using (StreamWriter streamWriter = new StreamWriter(filePath))
                            {
                                streamWriter.Write(tbresult.Text);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("To export, perform a search first.");
            }
        }

        /// <summary>
        /// Triggers when the mouse enters the help icon's picture box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpPicbx_MouseEnter(object sender, EventArgs e)
        {
            //change it's image to show it is highlighted
            helpPicbx.Image = Properties.Resources.selectedqhelpicon;
        }

        /// <summary>
        /// Triggers when the mosue leaves the help icon's picture box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpPicbx_MouseLeave(object sender, EventArgs e)
        {
            //change its image to show it is not highlighted
            helpPicbx.Image = Properties.Resources.notselectedqhelpicon;
        }

        /// <summary>
        /// Resets all adjustable elements in the form when the reset button is clicked 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetbtn_Click(object sender, EventArgs e)
        {
            rbauctionandbuy.Checked = true;
            rbfreeandpaid.Checked = true;

            tbMaxPrice.Text = "";
            tbMinPrice.Text = "";
        }
    }
}