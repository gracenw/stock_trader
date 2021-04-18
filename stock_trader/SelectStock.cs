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
                var request = new RestRequest($"/stable/stock/{CurrentSymbol.Text}/quote/changePercent"); //change this for security measures
                request.AddParameter("token", "pk_423ad25e4bc94c58a425030b2d6edcfa"); //change this for security measures
                var response = client.Get(request);
                double change_perc = double.Parse(response.Content, System.Globalization.CultureInfo.InvariantCulture);
                LatestPrice.Text = change_perc.ToString();
                double servo = (change_perc + 1.0) / 2.0; //change from (-1, 1) to (0, 1) for servo
                if (System.Environment.OSVersion.Platform.ToString().Equals("Unix"))
                {
                    using (System.IO.Ports.SerialPort port = new System.IO.Ports.SerialPort("/dev/ttyACM0", 9600))
                    {
                        port.Open();
                        if (port.IsOpen) CurrentSymbol.Text = "port opened!";
                        port.Write("!" + servo.ToString());
                    }
                }
                else Console.WriteLine(servo.ToString());
            }
        }
    }
}
