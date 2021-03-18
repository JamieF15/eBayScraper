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

        public void GetHTTP()
        {
            if (URLIsValid(url))
            {
                HttpClient httpClient = new HttpClient();
                var html = httpClient.GetStringAsync(url);
                if (!html.IsCompleted)
                {
                    resultsBx.Text = "SCAPING IN PROGESS...";

                    if (html.IsCompleted)
                    {
                        return;
                    }
                }

                resultsBx.Text = html.Result.ToString();
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
                GetHTTP();
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