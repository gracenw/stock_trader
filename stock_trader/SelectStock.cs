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

        private void AlteredDropdown(object sender, EventArgs e)
        {

        }

        private void Populate()
        {
            //send request to return all available symbols and then autofill the dropdown box with text symbols
            SymbolBox.Items.Add("twtr");
        }

        private void SendNewSymbol(object sender, EventArgs e)
        {
            using (System.IO.Ports.SerialPort port = new System.IO.Ports.SerialPort("/dev/ttyACM0", 9600))
            {
                port.Open();
                if(port.IsOpen) CurrentSymbol.Text = "port opened";
            }

            //upon clicking the Select button, a request sets the current symbol to the one selected
            //var client = new RestSharp.RestClient("https://cloud.iexapis.com");
            //var request = new RestSharp.RestRequest($"/stable/stock/{SymbolBox.SelectedItem}/quote/latestPrice"); //change this for security measures
            //request.AddParameter("token", "pk_423ad25e4bc94c58a425030b2d6edcfa"); //change this for security measures
            //var response = client.Get(request);
            //float latest_price = float.Parse(response.Content, System.Globalization.CultureInfo.InvariantCulture);
            //CurrentSymbol.Text = $"Current stock value: {latest_price}";
        }
    }
}
