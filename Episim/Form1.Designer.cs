namespace Sim03
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Properties = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Start_1 = new System.Windows.Forms.Button();
            this.Run_1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Clear = new System.Windows.Forms.Button();
            this.panelPropSubmenu = new System.Windows.Forms.Panel();
            this.Config = new System.Windows.Forms.Button();
            this.Models = new System.Windows.Forms.Button();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.BttnHideMain = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.rTEjec = new System.Windows.Forms.RichTextBox();
            this.panelConfig = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelPropSubmenu.SuspendLayout();
            this.panelSideMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panelConfig.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(52, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Properties
            // 
            this.Properties.Dock = System.Windows.Forms.DockStyle.Top;
            this.Properties.FlatAppearance.BorderSize = 0;
            this.Properties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Properties.ForeColor = System.Drawing.Color.Gainsboro;
            this.Properties.Location = new System.Drawing.Point(0, 100);
            this.Properties.Name = "Properties";
            this.Properties.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Properties.Size = new System.Drawing.Size(250, 45);
            this.Properties.TabIndex = 2;
            this.Properties.Text = "Properties";
            this.Properties.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Properties.UseVisualStyleBackColor = true;
            this.Properties.Click += new System.EventHandler(this.Properties_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Start_1);
            this.panel1.Controls.Add(this.Run_1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 563);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 90);
            this.panel1.TabIndex = 3;
            // 
            // Start_1
            // 
            this.Start_1.Dock = System.Windows.Forms.DockStyle.Right;
            this.Start_1.FlatAppearance.BorderSize = 0;
            this.Start_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start_1.ForeColor = System.Drawing.Color.Gainsboro;
            this.Start_1.Location = new System.Drawing.Point(125, 0);
            this.Start_1.Name = "Start_1";
            this.Start_1.Size = new System.Drawing.Size(125, 45);
            this.Start_1.TabIndex = 5;
            this.Start_1.Text = "Start";
            this.Start_1.UseVisualStyleBackColor = true;
            this.Start_1.Click += new System.EventHandler(this.Start_1_Click);
            // 
            // Run_1
            // 
            this.Run_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.Run_1.FlatAppearance.BorderSize = 0;
            this.Run_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Run_1.ForeColor = System.Drawing.Color.Gainsboro;
            this.Run_1.Location = new System.Drawing.Point(0, 0);
            this.Run_1.Name = "Run_1";
            this.Run_1.Size = new System.Drawing.Size(125, 45);
            this.Run_1.TabIndex = 4;
            this.Run_1.Text = "Run";
            this.Run_1.UseVisualStyleBackColor = true;
            this.Run_1.Click += new System.EventHandler(this.Run_1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Clear);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 45);
            this.panel2.TabIndex = 2;
            // 
            // Clear
            // 
            this.Clear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Clear.FlatAppearance.BorderSize = 0;
            this.Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clear.ForeColor = System.Drawing.Color.Gainsboro;
            this.Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Clear.Location = new System.Drawing.Point(0, 0);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(250, 45);
            this.Clear.TabIndex = 0;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Exit_Click);
            // 
            // panelPropSubmenu
            // 
            this.panelPropSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelPropSubmenu.Controls.Add(this.Config);
            this.panelPropSubmenu.Controls.Add(this.Models);
            this.panelPropSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPropSubmenu.Location = new System.Drawing.Point(0, 145);
            this.panelPropSubmenu.Name = "panelPropSubmenu";
            this.panelPropSubmenu.Size = new System.Drawing.Size(250, 81);
            this.panelPropSubmenu.TabIndex = 4;
            // 
            // Config
            // 
            this.Config.Dock = System.Windows.Forms.DockStyle.Top;
            this.Config.FlatAppearance.BorderSize = 0;
            this.Config.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.Config.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Config.ForeColor = System.Drawing.Color.LightGray;
            this.Config.Location = new System.Drawing.Point(0, 40);
            this.Config.Name = "Config";
            this.Config.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.Config.Size = new System.Drawing.Size(250, 40);
            this.Config.TabIndex = 1;
            this.Config.Text = "Config";
            this.Config.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Config.UseVisualStyleBackColor = true;
            this.Config.Click += new System.EventHandler(this.Config_Click);
            // 
            // Models
            // 
            this.Models.Dock = System.Windows.Forms.DockStyle.Top;
            this.Models.FlatAppearance.BorderSize = 0;
            this.Models.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.Models.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Models.ForeColor = System.Drawing.Color.LightGray;
            this.Models.Location = new System.Drawing.Point(0, 0);
            this.Models.Name = "Models";
            this.Models.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.Models.Size = new System.Drawing.Size(250, 40);
            this.Models.TabIndex = 0;
            this.Models.Text = "Models";
            this.Models.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Models.UseVisualStyleBackColor = true;
            this.Models.Click += new System.EventHandler(this.Models_Click);
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelSideMenu.Controls.Add(this.BttnHideMain);
            this.panelSideMenu.Controls.Add(this.chart1);
            this.panelSideMenu.Controls.Add(this.rTEjec);
            this.panelSideMenu.Controls.Add(this.panelPropSubmenu);
            this.panelSideMenu.Controls.Add(this.panel1);
            this.panelSideMenu.Controls.Add(this.Properties);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(250, 653);
            this.panelSideMenu.TabIndex = 3;
            // 
            // BttnHideMain
            // 
            this.BttnHideMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.BttnHideMain.FlatAppearance.BorderSize = 0;
            this.BttnHideMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BttnHideMain.ForeColor = System.Drawing.Color.White;
            this.BttnHideMain.Location = new System.Drawing.Point(0, 226);
            this.BttnHideMain.Name = "BttnHideMain";
            this.BttnHideMain.Size = new System.Drawing.Size(250, 35);
            this.BttnHideMain.TabIndex = 7;
            this.BttnHideMain.Text = "Hide";
            this.BttnHideMain.UseVisualStyleBackColor = true;
            this.BttnHideMain.Click += new System.EventHandler(this.BttnHideMain_Click);
            // 
            // chart1
            // 
            this.chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.chart1.BorderSkin.PageColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(21, 328);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(210, 154);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // rTEjec
            // 
            this.rTEjec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.rTEjec.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rTEjec.Cursor = System.Windows.Forms.Cursors.No;
            this.rTEjec.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rTEjec.Location = new System.Drawing.Point(0, 525);
            this.rTEjec.Name = "rTEjec";
            this.rTEjec.Size = new System.Drawing.Size(250, 38);
            this.rTEjec.TabIndex = 6;
            this.rTEjec.Text = "";
            // 
            // panelConfig
            // 
            this.panelConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(23)))), ((int)(((byte)(32)))));
            this.panelConfig.Controls.Add(this.panelMain);
            this.panelConfig.Location = new System.Drawing.Point(250, 0);
            this.panelConfig.Name = "panelConfig";
            this.panelConfig.Size = new System.Drawing.Size(932, 653);
            this.panelConfig.TabIndex = 4;
            this.panelConfig.Visible = false;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelMain.Controls.Add(this.buttonMenu);
            this.panelMain.Location = new System.Drawing.Point(252, 3);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(219, 26);
            this.panelMain.TabIndex = 1;
            // 
            // buttonMenu
            // 
            this.buttonMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonMenu.FlatAppearance.BorderSize = 0;
            this.buttonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenu.ForeColor = System.Drawing.Color.White;
            this.buttonMenu.Location = new System.Drawing.Point(0, 0);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(219, 25);
            this.buttonMenu.TabIndex = 0;
            this.buttonMenu.Text = "Menu";
            this.buttonMenu.UseVisualStyleBackColor = true;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.panelConfig);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "x";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelPropSubmenu.ResumeLayout(false);
            this.panelSideMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panelConfig.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Properties;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Start_1;
        private System.Windows.Forms.Button Run_1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Panel panelPropSubmenu;
        private System.Windows.Forms.Button Config;
        private System.Windows.Forms.Button Models;
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelConfig;
        private System.Windows.Forms.RichTextBox rTEjec;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.Button BttnHideMain;
    }
}

