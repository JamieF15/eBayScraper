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
        public String url = "";

        public Form1()
        {
            InitializeComponent();
        }

        public void GetHTTP()
        {
            HttpClient httpClient = new HttpClient();
            var html = httpClient.GetAsync(url);
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

        private void goBtn_Click(object sender, EventArgs e)
        {
            url = searchBx.Text;

            if (URLIsEmpty(url))
            {
                resultsBx.Text = "ffdssd";
            }

            else
            {
                GetHTTP();
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
    }
}