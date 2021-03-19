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

namespace eBayScraper
{
    public partial class Form1 : Form
    {
        public const string URLPROMPT = "Enter an eBay URL";

        public String url = "";

        public Form1()
        {
            InitializeComponent();
            searchBx.Text = URLPROMPT;
        }

        public async void GetHTML()
        {
            if (URLIsValid(url))
            {
                HttpClient httpClient = new HttpClient();

                string html = await httpClient.GetStringAsync(url);

                var htmldocument = new HtmlAgilityPack.HtmlDocument();

                htmldocument.LoadHtml(html);

                var products = htmldocument.DocumentNode.Descendants("ul").
                    Where(node => node.GetAttributeValue("id", "").
                    Equals("ListViewInner")).ToList();

                var productListItems = products[0].Descendants("li")
                    .Where(node => node.GetAttributeValue("id", "")
                    .Contains("item")).ToList();

                resultsBx.Text = productListItems.Count.ToString();

                var productList = products[0].Descendants();

                //https://www.ebay.co.uk/sch/i.html?_from=R40&_nkw=pc&_in_kw=1&_ex_kw=&_sacat=0&_udlo=&_udhi=&_ftrt=901&_ftrv=1&_sabdlo=&_sabdhi=&_samilow=&_samihi=&_sadis=15&_stpos=Cb12aw&_sargn=-1%26saslc%3D1&_salic=3&_sop=12&_dmd=1&_ipg=100&_fosrp=1

                //if (()html.IsCompleted)
                //{
                //    resultsBx.Text = "SCRAPING IN PROGESS...";

                //    if (html.IsCompleted)
                //    {
                //        return;
                //    }
                //}

                //resultsBx.Text = html.Result.ToString();

            }
            else
            {
                resultsBx.Text = "Enter a valid URL";
            }
        }

        private void goBtn_Click(object sender, EventArgs e)
        {
            url = searchBx.Text;

            if (URLIsEmpty(url))
            {
                resultsBx.Text = "Search is empty.";
            }
            else
            {
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