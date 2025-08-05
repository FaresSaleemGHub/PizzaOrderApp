namespace PizzaOrderApp
{
    partial class HomePage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelTopBar = new System.Windows.Forms.Panel();
            this.pictClose = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.lblTitleBar = new System.Windows.Forms.Label();
            this.panelTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelTopBar
            // 
            this.panelTopBar.BackColor = System.Drawing.Color.Transparent;
            this.panelTopBar.Controls.Add(this.pictClose);
            this.panelTopBar.Controls.Add(this.picClose);
            this.panelTopBar.Controls.Add(this.lblTitleBar);
            this.panelTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBar.Location = new System.Drawing.Point(0, 0);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Size = new System.Drawing.Size(700, 40);
            this.panelTopBar.TabIndex = 0;
            // 
            // pictClose
            // 
            this.pictClose.BackColor = System.Drawing.Color.White;
            this.pictClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictClose.Image = global::PizzaOrderApp.Properties.Resources.Close;
            this.pictClose.Location = new System.Drawing.Point(700, 6);
            this.pictClose.Margin = new System.Windows.Forms.Padding(0);
            this.pictClose.Name = "pictClose";
            this.pictClose.Size = new System.Drawing.Size(24, 24);
            this.pictClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictClose.TabIndex = 2;
            this.pictClose.TabStop = false;
            this.pictClose.Click += new System.EventHandler(this.pictClose_Click);
            this.pictClose.MouseEnter += new System.EventHandler(this.pictClose_MouseEnter);
            this.pictClose.MouseLeave += new System.EventHandler(this.pictClose_MouseLeave);
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.BackColor = System.Drawing.Color.White;
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Location = new System.Drawing.Point(902, 6);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(24, 24);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picClose.TabIndex = 1;
            this.picClose.TabStop = false;
            // 
            // lblTitleBar
            // 
            this.lblTitleBar.AutoSize = true;
            this.lblTitleBar.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleBar.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleBar.ForeColor = System.Drawing.Color.White;
            this.lblTitleBar.Location = new System.Drawing.Point(261, 10);
            this.lblTitleBar.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitleBar.Name = "lblTitleBar";
            this.lblTitleBar.Size = new System.Drawing.Size(17, 28);
            this.lblTitleBar.TabIndex = 0;
            this.lblTitleBar.Text = " ";
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.BackgroundImage = global::PizzaOrderApp.Properties.Resources.PizzaBg4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(700, 900);
            this.Controls.Add(this.panelTopBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.panelTopBar.ResumeLayout(false);
            this.panelTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.Label lblTitleBar;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox pictClose;
        private System.Windows.Forms.Panel panel1;
    }
}

