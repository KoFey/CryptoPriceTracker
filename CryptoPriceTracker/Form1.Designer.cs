namespace CryptoPriceTracker
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        /// 

        private System.Windows.Forms.ListBox listBoxPricesBinance;
        private System.Windows.Forms.ListBox listBoxPricesBybit;
        private System.Windows.Forms.ListBox listBoxPricesKucoin;
        private System.Windows.Forms.ListBox listBoxPricesBitget;
        private System.Windows.Forms.Label lblCurrentPriceBinance;
        private System.Windows.Forms.Label lblCurrentPriceBybit;
        private System.Windows.Forms.Label lblCurrentPriceKucoin;
        private System.Windows.Forms.Label lblCurrentPriceBitget;
        private System.Windows.Forms.ComboBox comboBoxSymbols;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;

        private void InitializeComponent()
        {
            this.listBoxPricesBinance = new System.Windows.Forms.ListBox();
            this.listBoxPricesBybit = new System.Windows.Forms.ListBox();
            this.listBoxPricesKucoin = new System.Windows.Forms.ListBox();
            this.listBoxPricesBitget = new System.Windows.Forms.ListBox();
            this.lblCurrentPriceBinance = new System.Windows.Forms.Label();
            this.lblCurrentPriceBybit = new System.Windows.Forms.Label();
            this.lblCurrentPriceKucoin = new System.Windows.Forms.Label();
            this.lblCurrentPriceBitget = new System.Windows.Forms.Label();
            this.comboBoxSymbols = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // listBoxPricesBinance
            this.listBoxPricesBinance.FormattingEnabled = true;
            this.listBoxPricesBinance.Location = new System.Drawing.Point(12, 12);
            this.listBoxPricesBinance.Size = new System.Drawing.Size(120, 160);

            // listBoxPricesBybit
            this.listBoxPricesBybit.FormattingEnabled = true;
            this.listBoxPricesBybit.Location = new System.Drawing.Point(150, 12);
            this.listBoxPricesBybit.Size = new System.Drawing.Size(120, 160);

            // listBoxPricesKucoin
            this.listBoxPricesKucoin.FormattingEnabled = true;
            this.listBoxPricesKucoin.Location = new System.Drawing.Point(290, 12);
            this.listBoxPricesKucoin.Size = new System.Drawing.Size(120, 160);

            // listBoxPricesBitget
            this.listBoxPricesBitget.FormattingEnabled = true;
            this.listBoxPricesBitget.Location = new System.Drawing.Point(430, 12);
            this.listBoxPricesBitget.Size = new System.Drawing.Size(120, 160);

            // lblCurrentPriceBinance
            this.lblCurrentPriceBinance.AutoSize = true;
            this.lblCurrentPriceBinance.Location = new System.Drawing.Point(12, 180);
            this.lblCurrentPriceBinance.Size = new System.Drawing.Size(0, 13);

            // lblCurrentPriceBybit
            this.lblCurrentPriceBybit.AutoSize = true;
            this.lblCurrentPriceBybit.Location = new System.Drawing.Point(150, 180);
            this.lblCurrentPriceBybit.Size = new System.Drawing.Size(0, 13);

            // lblCurrentPriceKucoin
            this.lblCurrentPriceKucoin.AutoSize = true;
            this.lblCurrentPriceKucoin.Location = new System.Drawing.Point(290, 180);
            this.lblCurrentPriceKucoin.Size = new System.Drawing.Size(0, 13);

            // lblCurrentPriceBitget
            this.lblCurrentPriceBitget.AutoSize = true;
            this.lblCurrentPriceBitget.Location = new System.Drawing.Point(430, 180);
            this.lblCurrentPriceBitget.Size = new System.Drawing.Size(0, 13);

            // comboBoxSymbols
            this.comboBoxSymbols.FormattingEnabled = true;
            this.comboBoxSymbols.Location = new System.Drawing.Point(12, 210);
            this.comboBoxSymbols.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSymbols.SelectedIndexChanged += new System.EventHandler(this.comboBoxSymbols_SelectedIndexChanged);

            // btnStart
            this.btnStart.Location = new System.Drawing.Point(150, 210);
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);

            // btnStop
            this.btnStop.Location = new System.Drawing.Point(240, 210);
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);

            // MainForm
            this.ClientSize = new System.Drawing.Size(600, 250);
            this.Controls.Add(this.listBoxPricesBinance);
            this.Controls.Add(this.listBoxPricesBybit);
            this.Controls.Add(this.listBoxPricesKucoin);
            this.Controls.Add(this.listBoxPricesBitget);
            this.Controls.Add(this.lblCurrentPriceBinance);
            this.Controls.Add(this.lblCurrentPriceBybit);
            this.Controls.Add(this.lblCurrentPriceKucoin);
            this.Controls.Add(this.lblCurrentPriceBitget);
            this.Controls.Add(this.comboBoxSymbols);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}

