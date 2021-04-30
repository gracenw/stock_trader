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
            // initialize page
            InitializeComponent();

            // populate dropdown menu with nasdaq symbols in text file
            Populate();

            // create timer to trigger an update event every 15 seconds
            t = new Timer();
            t.Interval = 15000;
            t.Tick += new EventHandler(UpdateAPI);
        }

        // updates the form with the newly selected symbol and calls update function
        private void SendNewSymbol(object sender, EventArgs e)
        {
            // set read-only textbox to new symbol value
            CurrentSymbol.Text = DropDown.SelectedItem.ToString();
            // call update function
            UpdateAPI(null, null);
            // restart timer
            t.Enabled = false;
            t.Enabled = true;
        }

        // populates the available stocks dropdownnwith nasdaq symbols
        private void Populate()
        {
            // added to prevent errors between differing directories on differing systems
            string loc;
            if (System.Environment.OSVersion.Platform.ToString().Equals("Unix")) loc = @"/home/pi/stock_trader/stock_trader/symbols.txt";
            else loc = @"..\..\symbols.txt";
            // read all lines into string array
            string[] lines = System.IO.File.ReadAllLines(loc);
            // add individual stocks to dropdown
            for(int i = 0; i < lines.Length; i++)
            {
                DropDown.Items.Add(lines[i]);
            }
        }

        // calls updated change percent value from api for selected stock & sends new value to servo
        private void UpdateAPI(object sender, EventArgs e)
        {
            // make sure something is selected
            if (!CurrentSymbol.Text.Equals("")) {
                // create http client
                var client = new RestClient("https://cloud.iexapis.com");
                // create http request
                var request = new RestRequest($"/stable/stock/{CurrentSymbol.Text}/quote/changePercent");
                // added to prevent errors between differing directories on differing systems
                string loc;
                if (System.Environment.OSVersion.Platform.ToString().Equals("Unix")) loc = @"/home/pi/stock_trader/stock_trader/token.txt";
                else loc = @"..\..\token.txt";
                // read token value into string
                string token = System.IO.File.ReadAllLines(loc)[0];
                // add token parameter to request headers
                request.AddParameter("token", token);
                // get http response
                var response = client.Get(request);
                // parse new change percent into double
                double change_perc = double.Parse(response.Content, System.Globalization.CultureInfo.InvariantCulture);
                // update read-only textbox with newest change percent
                LatestPrice.Text = (change_perc * 100).ToString();
                // scale change percent to send value to servo
                double servo;
                // no changes generally exceed +/- 5% so the servo value is scaled from (-0.05, +0.05) to (1.0, 0.0) & servo is mounted backwards to fit arrow
                if (change_perc < 0.05 && change_perc > -0.05) servo = 1 - ((change_perc + 0.05) / 0.1);
                else
                {
                    // accounts for any extreme changes
                    if (change_perc >= 0.05) servo = 0.001;
                    else servo = 0.999;
                }
                // open serial port if running on linux
                if (System.Environment.OSVersion.Platform.ToString().Equals("Unix"))
                {
                    using (System.IO.Ports.SerialPort port = new System.IO.Ports.SerialPort("/dev/ttyACM0", 9600))
                    {
                        port.Open();
                        port.Write("!" + servo.ToString());
                    }
                }
                // write updated servo value to console
                Console.WriteLine("Updated servo value from stock " + CurrentSymbol.Text + ": " + servo.ToString());
            }
        }
    }
}
