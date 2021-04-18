﻿using System;
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

        private float PollLatestPrice()
        {
            var client = new RestClient("https://cloud.iexapis.com");
            var request = new RestRequest($"/stable/stock/{CurrentSymbol.Text}/quote/latestPrice"); //change this for security measures
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
