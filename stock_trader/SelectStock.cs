using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using System.Runtime.InteropServices;

namespace stock_trader
{
    public partial class SelectStock : Form
    {
        public SelectStock()
        {
            InitializeComponent();
            Populate();
        }

        private void SendNewSymbol(object sender, EventArgs e)
        {
            CurrentSymbol.Text = DropDown.SelectedItem.ToString();
            UpdateAPI();
        }

        private void Populate()
        {
            //send request to return all available symbols and then autofill the dropdown box with text symbols
            var client = new RestSharp.RestClient("https://cloud.iexapis.com");
            var request = new RestSharp.RestRequest($"/ref-data/iex/symbols");
            request.AddParameter("token", "pk_423ad25e4bc94c58a425030b2d6edcfa"); //change this for security measures
            var response = client.Get(request);
            //Console.WriteLine(response.Content);
            DropDown.Items.Add("twtr");
        }

        private float PollLatestPrice()
        {
            var client = new RestSharp.RestClient("https://cloud.iexapis.com");
            var request = new RestSharp.RestRequest($"/stable/stock/{CurrentSymbol.Text}/quote/latestPrice"); //change this for security measures
            request.AddParameter("token", "pk_423ad25e4bc94c58a425030b2d6edcfa"); //change this for security measures
            var response = client.Get(request);
            float latest_price = float.Parse(response.Content, System.Globalization.CultureInfo.InvariantCulture);
            LatestPrice.Text = latest_price.ToString();
            return latest_price;
        }

        private void SendOverSerial(float slope)
        {
            float servo = 0;
            //calculate correct servo value using slope
            using (System.IO.Ports.SerialPort port = new System.IO.Ports.SerialPort("/dev/ttyACM0", 9600))
            {
                port.Open();
                if (port.IsOpen) CurrentSymbol.Text = "port opened!";
                port.Write("!" + servo.ToString());
            }
        }

        private void UpdateAPI()
        {
            PollLatestPrice();
            float slope = 0;
            //calculate slope... if less than 2 values in quote array, just send 0 to servo
            //SendOverSerial(slope);
        }
    }
}
