
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
            this.SymbolBox = new System.Windows.Forms.ComboBox();
            this.SelectSymbol = new System.Windows.Forms.Button();
            this.CurrentSymbol = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SymbolBox
            // 
            this.SymbolBox.FormattingEnabled = true;
            this.SymbolBox.Location = new System.Drawing.Point(80, 189);
            this.SymbolBox.Name = "SymbolBox";
            this.SymbolBox.Size = new System.Drawing.Size(431, 24);
            this.SymbolBox.TabIndex = 0;
            this.SymbolBox.SelectedIndexChanged += new System.EventHandler(this.AlteredDropdown);
            // 
            // SelectSymbol
            // 
            this.SelectSymbol.Location = new System.Drawing.Point(568, 189);
            this.SelectSymbol.Name = "SelectSymbol";
            this.SelectSymbol.Size = new System.Drawing.Size(75, 23);
            this.SelectSymbol.TabIndex = 1;
            this.SelectSymbol.Text = "Select";
            this.SelectSymbol.UseVisualStyleBackColor = true;
            this.SelectSymbol.Click += new System.EventHandler(this.SendNewSymbol);
            // 
            // CurrentSymbol
            // 
            this.CurrentSymbol.Location = new System.Drawing.Point(148, 310);
            this.CurrentSymbol.Name = "CurrentSymbol";
            this.CurrentSymbol.Size = new System.Drawing.Size(372, 22);
            this.CurrentSymbol.TabIndex = 2;
            // 
            // SelectStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CurrentSymbol);
            this.Controls.Add(this.SelectSymbol);
            this.Controls.Add(this.SymbolBox);
            this.Name = "SelectStock";
            this.Text = "SelectStock";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SymbolBox;
        private System.Windows.Forms.Button SelectSymbol;
        private System.Windows.Forms.TextBox CurrentSymbol;
    }
}