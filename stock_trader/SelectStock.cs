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
        private Timer t; 

        public SelectStock()
        {
            InitializeComponent();
            Populate();

            t = new Timer();
            t.Interval = 15000;
            t.Tick += new EventHandler(UpdateAPI);
        }

        private void SendNewSymbol(object sender, EventArgs e)
        {
            CurrentSymbol.Text = DropDown.SelectedItem.ToString();
            UpdateAPI(null, null);
            t.Enabled = false;
            t.Enabled = true;
        }

        private void Populate()
        {
            //load all nasdaq stocks into dropdown 
            string loc;
            if (System.Environment.OSVersion.Platform.ToString().Equals("Unix")) loc = @"/home/pi/stock_trader/stock_trader/symbols.txt";
            else loc = @"..\..\symbols.txt";
            string[] lines = System.IO.File.ReadAllLines(loc);
            for(int i = 0; i < lines.Length; i++)
            {
                DropDown.Items.Add(lines[i]);
            }
        }

        private void UpdateAPI(object sender, EventArgs e)
        {
            if (!CurrentSymbol.Text.Equals("")) {
                var client = new RestClient("https://cloud.iexapis.com");
                var request = new RestRequest($"/stable/stock/{CurrentSymbol.Text}/quote/changePercent");
                string loc;
                if (System.Environment.OSVersion.Platform.ToString().Equals("Unix")) loc = @"/home/pi/stock_trader/stock_trader/token.txt";
                else loc = @"..\..\token.txt";
                string token = System.IO.File.ReadAllLines(loc)[0];
                request.AddParameter("token", token);
                var response = client.Get(request);
                double change_perc = double.Parse(response.Content, System.Globalization.CultureInfo.InvariantCulture);
                LatestPrice.Text = change_perc.ToString();
                double servo;
                if (change_perc <= 1.0 && change_perc >= -1.0) servo = (change_perc + 1.0) / 2.0;
                else
                {
                    if (change_perc > 1.0) servo = 1.0;
                    else servo = -1.0;
                }
                if (System.Environment.OSVersion.Platform.ToString().Equals("Unix"))
                {
                    using (System.IO.Ports.SerialPort port = new System.IO.Ports.SerialPort("/dev/ttyACM0", 9600))
                    {
                        port.Open();
                        port.Write("!" + servo.ToString());
                    }
                }
                Console.WriteLine(servo.ToString());
            }
        }
    }
}
