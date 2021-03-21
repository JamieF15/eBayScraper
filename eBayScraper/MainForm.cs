using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static char[] trimChars = new char[] { '\r', '\n', '\t' };

        public MainForm()
        {
            InitializeComponent();
            searchBx.Text = URLPROMPT;
        }

        public async void GetHTML()
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

                RetreiveData(products);
            }
            else
            {
                statustxtbx.Text = "Enter a valid eBay URL";
            }
        }

        private void RetreiveData(List<HtmlAgilityPack.HtmlNode> products)
        {
            string buyingFormat = "";
            string id = "";
            string price = "";
            string title = "";
            string shippingPrice = "";

            var productListItems = new List<HtmlAgilityPack.HtmlNode>();

            productListItems = products[0].Descendants("li")
             .Where(node => node.GetAttributeValue("id", "")
             .Contains("item")).ToList();

            var productListItem = products[0].Descendants();

            foreach (var Item in productListItems)
            {
                ////product id
                id = "ID: " + Item.GetAttributeValue("listingid", "");

                //product title
                title = "TITLE: " + Item.Descendants("h3").Where(node => node.GetAttributeValue("class", "").
                Equals("lvtitle")).FirstOrDefault().InnerText.Trim(trimChars).Replace("New listing", "").Replace("		", "");

                //product price
                price = "PRICE: £" + Regex.Match(Item.Descendants("li").
                Where(node => node.GetAttributeValue("class", "").
                Equals("lvprice prc")).FirstOrDefault().
                InnerText.Trim('\r', '\n', '\t'), @"\d+.\d+");

                //shippping format
                shippingPrice = "SHIPPING: " + Item.Descendants("li").
                Where(node => node.GetAttributeValue("class", "").
                Equals("lvshipping")).FirstOrDefault().
                InnerText.Trim(trimChars);

                //buying format
                //fixes a bug where if the item was 'buy it now' it would not display anything
                if (Item.Descendants("li").
                Where(node => node.GetAttributeValue("class", "").
                Equals("lvformat")).FirstOrDefault().
                InnerText.Trim(trimChars).Contains("bid"))
                {
                    buyingFormat = "BUYING FORMAT: " + Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvformat")).FirstOrDefault().
                    InnerText.Trim(trimChars);
                }
                else
                {
                    buyingFormat = "BUYING FORMAT: " + Item.Descendants("li").
                    Where(node => node.GetAttributeValue("class", "").
                    Equals("lvformat")).FirstOrDefault().
                    InnerText.Trim(trimChars) + "Buy It Now";
                }

                resultsBx.Text += id;
                resultsBx.Text += Environment.NewLine;

                resultsBx.Text += title;
                resultsBx.Text += Environment.NewLine;

                resultsBx.Text += price;
                resultsBx.Text += Environment.NewLine;

                if (shippingPrice.Contains("£"))
                {
                    resultsBx.Text += "SHIPPING: " + shippingPrice.Substring(12, 5);
                }
                else
                {
                    resultsBx.Text += shippingPrice;
                }

                resultsBx.Text += Environment.NewLine;

                resultsBx.Text += buyingFormat;
                resultsBx.Text += Environment.NewLine;


                //url
                //   resultsBx.Text += "URL: " + Item.Descendants("a").FirstOrDefault().GetAttributeValue("href", "");

                resultsBx.Text += Environment.NewLine;
                resultsBx.Text += Environment.NewLine;
            }

            statustxtbx.Text = "Search complete " + productListItems.Count + " items found.";
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

        private bool URLIsEmpty(String url)
        {
            if (url.Length == 0)
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
    }
}