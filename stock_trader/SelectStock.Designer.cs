
namespace stock_trader
{
    partial class SelectStock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DropDown = new System.Windows.Forms.ComboBox();
            this.SelectSymbol = new System.Windows.Forms.Button();
            this.CurrentSymbol = new System.Windows.Forms.TextBox();
            this.WindowTitle = new System.Windows.Forms.Label();
            this.SelectedSymbolLabel = new System.Windows.Forms.Label();
            this.LatestPriceLabel = new System.Windows.Forms.Label();
            this.LatestPrice = new System.Windows.Forms.TextBox();
            this.CreditsIEXCloud = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DropDown
            // 
            this.DropDown.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DropDown.FormattingEnabled = true;
            this.DropDown.Location = new System.Drawing.Point(32, 306);
            this.DropDown.Name = "DropDown";
            this.DropDown.Size = new System.Drawing.Size(241, 35);
            this.DropDown.TabIndex = 0;
            // 
            // SelectSymbol
            // 
            this.SelectSymbol.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.SelectSymbol.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectSymbol.Location = new System.Drawing.Point(306, 300);
            this.SelectSymbol.Name = "SelectSymbol";
            this.SelectSymbol.Size = new System.Drawing.Size(213, 49);
            this.SelectSymbol.TabIndex = 1;
            this.SelectSymbol.Text = "Select New Symbol";
            this.SelectSymbol.UseVisualStyleBackColor = false;
            this.SelectSymbol.Click += new System.EventHandler(this.SendNewSymbol);
            // 
            // CurrentSymbol
            // 
            this.CurrentSymbol.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.CurrentSymbol.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentSymbol.Location = new System.Drawing.Point(336, 154);
            this.CurrentSymbol.Name = "CurrentSymbol";
            this.CurrentSymbol.ReadOnly = true;
            this.CurrentSymbol.Size = new System.Drawing.Size(181, 33);
            this.CurrentSymbol.TabIndex = 2;
            // 
            // WindowTitle
            // 
            this.WindowTitle.AutoSize = true;
            this.WindowTitle.Font = new System.Drawing.Font("Trebuchet MS", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindowTitle.Location = new System.Drawing.Point(12, 9);
            this.WindowTitle.Name = "WindowTitle";
            this.WindowTitle.Size = new System.Drawing.Size(340, 42);
            this.WindowTitle.TabIndex = 3;
            this.WindowTitle.Text = "Stock Trader Monitor";
            this.WindowTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.WindowTitle.UseWaitCursor = true;
            // 
            // SelectedSymbolLabel
            // 
            this.SelectedSymbolLabel.AutoSize = true;
            this.SelectedSymbolLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedSymbolLabel.Location = new System.Drawing.Point(26, 154);
            this.SelectedSymbolLabel.Name = "SelectedSymbolLabel";
            this.SelectedSymbolLabel.Size = new System.Drawing.Size(283, 29);
            this.SelectedSymbolLabel.TabIndex = 4;
            this.SelectedSymbolLabel.Text = "Current selected symbol:";
            this.SelectedSymbolLabel.UseWaitCursor = true;
            // 
            // LatestPriceLabel
            // 
            this.LatestPriceLabel.AutoSize = true;
            this.LatestPriceLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LatestPriceLabel.Location = new System.Drawing.Point(87, 225);
            this.LatestPriceLabel.Name = "LatestPriceLabel";
            this.LatestPriceLabel.Size = new System.Drawing.Size(220, 29);
            this.LatestPriceLabel.TabIndex = 6;
            this.LatestPriceLabel.Text = "Latest price quote:";
            this.LatestPriceLabel.UseWaitCursor = true;
            // 
            // LatestPrice
            // 
            this.LatestPrice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.LatestPrice.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LatestPrice.Location = new System.Drawing.Point(336, 225);
            this.LatestPrice.Name = "LatestPrice";
            this.LatestPrice.ReadOnly = true;
            this.LatestPrice.Size = new System.Drawing.Size(181, 33);
            this.LatestPrice.TabIndex = 5;
            // 
            // CreditsIEXCloud
            // 
            this.CreditsIEXCloud.AutoSize = true;
            this.CreditsIEXCloud.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditsIEXCloud.Location = new System.Drawing.Point(14, 68);
            this.CreditsIEXCloud.Name = "CreditsIEXCloud";
            this.CreditsIEXCloud.Size = new System.Drawing.Size(296, 29);
            this.CreditsIEXCloud.TabIndex = 7;
            this.CreditsIEXCloud.Text = "Data provided by IEXCloud";
            this.CreditsIEXCloud.UseWaitCursor = true;
            // 
            // SelectStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(563, 383);
            this.Controls.Add(this.CreditsIEXCloud);
            this.Controls.Add(this.LatestPriceLabel);
            this.Controls.Add(this.LatestPrice);
            this.Controls.Add(this.SelectedSymbolLabel);
            this.Controls.Add(this.WindowTitle);
            this.Controls.Add(this.CurrentSymbol);
            this.Controls.Add(this.SelectSymbol);
            this.Controls.Add(this.DropDown);
            this.Name = "SelectStock";
            this.Text = "SelectStock";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox DropDown;
        private System.Windows.Forms.Button SelectSymbol;
        private System.Windows.Forms.TextBox CurrentSymbol;
        private System.Windows.Forms.Label WindowTitle;
        private System.Windows.Forms.Label SelectedSymbolLabel;
        private System.Windows.Forms.Label LatestPriceLabel;
        private System.Windows.Forms.TextBox LatestPrice;
        private System.Windows.Forms.Label CreditsIEXCloud;
    }
}