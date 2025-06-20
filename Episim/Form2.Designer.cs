namespace Sim03
{
    partial class Form2
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
            this.AceptarConfig = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cBNoTerrain = new System.Windows.Forms.CheckBox();
            this.CBTerrain = new System.Windows.Forms.CheckBox();
            this.cBContDist = new System.Windows.Forms.CheckBox();
            this.cBRadio = new System.Windows.Forms.CheckBox();
            this.cBTamCell = new System.Windows.Forms.CheckBox();
            this.cBNumInd = new System.Windows.Forms.CheckBox();
            this.labelContDist = new System.Windows.Forms.Label();
            this.labelRadio = new System.Windows.Forms.Label();
            this.labelCell = new System.Windows.Forms.Label();
            this.labelNum = new System.Windows.Forms.Label();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.tBContDist = new System.Windows.Forms.TextBox();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.tBRadio = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.tBTamCell = new System.Windows.Forms.TextBox();
            this.bApply = new System.Windows.Forms.Button();
            this.tBnumeroBolas = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // AceptarConfig
            // 
            this.AceptarConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AceptarConfig.Location = new System.Drawing.Point(737, 527);
            this.AceptarConfig.Name = "AceptarConfig";
            this.AceptarConfig.Size = new System.Drawing.Size(124, 38);
            this.AceptarConfig.TabIndex = 0;
            this.AceptarConfig.Text = "Accept";
            this.AceptarConfig.UseVisualStyleBackColor = true;
            this.AceptarConfig.Click += new System.EventHandler(this.AceptarConfig_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(23)))), ((int)(((byte)(32)))));
            this.panel1.Controls.Add(this.cBNoTerrain);
            this.panel1.Controls.Add(this.CBTerrain);
            this.panel1.Controls.Add(this.cBContDist);
            this.panel1.Controls.Add(this.cBRadio);
            this.panel1.Controls.Add(this.cBTamCell);
            this.panel1.Controls.Add(this.cBNumInd);
            this.panel1.Controls.Add(this.labelContDist);
            this.panel1.Controls.Add(this.labelRadio);
            this.panel1.Controls.Add(this.labelCell);
            this.panel1.Controls.Add(this.labelNum);
            this.panel1.Controls.Add(this.trackBar4);
            this.panel1.Controls.Add(this.trackBar3);
            this.panel1.Controls.Add(this.tBContDist);
            this.panel1.Controls.Add(this.trackBar2);
            this.panel1.Controls.Add(this.tBRadio);
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Controls.Add(this.tBTamCell);
            this.panel1.Controls.Add(this.bApply);
            this.panel1.Controls.Add(this.tBnumeroBolas);
            this.panel1.Controls.Add(this.AceptarConfig);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(914, 606);
            this.panel1.TabIndex = 1;
            // 
            // cBNoTerrain
            // 
            this.cBNoTerrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cBNoTerrain.AutoSize = true;
            this.cBNoTerrain.ForeColor = System.Drawing.Color.White;
            this.cBNoTerrain.Location = new System.Drawing.Point(231, 537);
            this.cBNoTerrain.Name = "cBNoTerrain";
            this.cBNoTerrain.Size = new System.Drawing.Size(93, 20);
            this.cBNoTerrain.TabIndex = 9;
            this.cBNoTerrain.Text = "No Terrain";
            this.cBNoTerrain.UseVisualStyleBackColor = true;
            this.cBNoTerrain.CheckedChanged += new System.EventHandler(this.cBNoTerrain_CheckedChanged);
            // 
            // CBTerrain
            // 
            this.CBTerrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CBTerrain.AutoSize = true;
            this.CBTerrain.ForeColor = System.Drawing.Color.White;
            this.CBTerrain.Location = new System.Drawing.Point(116, 537);
            this.CBTerrain.Name = "CBTerrain";
            this.CBTerrain.Size = new System.Drawing.Size(72, 20);
            this.CBTerrain.TabIndex = 9;
            this.CBTerrain.Text = "Terrain";
            this.CBTerrain.UseVisualStyleBackColor = true;
            this.CBTerrain.CheckedChanged += new System.EventHandler(this.CBTerrain_CheckedChanged);
            // 
            // cBContDist
            // 
            this.cBContDist.AutoSize = true;
            this.cBContDist.ForeColor = System.Drawing.Color.White;
            this.cBContDist.Location = new System.Drawing.Point(22, 338);
            this.cBContDist.Name = "cBContDist";
            this.cBContDist.Size = new System.Drawing.Size(134, 20);
            this.cBContDist.TabIndex = 8;
            this.cBContDist.Text = "Infection Distance";
            this.cBContDist.UseVisualStyleBackColor = true;
            // 
            // cBRadio
            // 
            this.cBRadio.AutoSize = true;
            this.cBRadio.ForeColor = System.Drawing.Color.White;
            this.cBRadio.Location = new System.Drawing.Point(22, 239);
            this.cBRadio.Name = "cBRadio";
            this.cBRadio.Size = new System.Drawing.Size(98, 20);
            this.cBRadio.TabIndex = 8;
            this.cBRadio.Text = "Ball Radius";
            this.cBRadio.UseVisualStyleBackColor = true;
            // 
            // cBTamCell
            // 
            this.cBTamCell.AutoSize = true;
            this.cBTamCell.ForeColor = System.Drawing.Color.White;
            this.cBTamCell.Location = new System.Drawing.Point(22, 135);
            this.cBTamCell.Name = "cBTamCell";
            this.cBTamCell.Size = new System.Drawing.Size(81, 20);
            this.cBTamCell.TabIndex = 8;
            this.cBTamCell.Text = "Cell Size";
            this.cBTamCell.UseVisualStyleBackColor = true;
            // 
            // cBNumInd
            // 
            this.cBNumInd.AutoSize = true;
            this.cBNumInd.ForeColor = System.Drawing.Color.White;
            this.cBNumInd.Location = new System.Drawing.Point(22, 32);
            this.cBNumInd.Name = "cBNumInd";
            this.cBNumInd.Size = new System.Drawing.Size(161, 20);
            this.cBNumInd.TabIndex = 8;
            this.cBNumInd.Text = " Number of Individuals";
            this.cBNumInd.UseVisualStyleBackColor = true;
            // 
            // labelContDist
            // 
            this.labelContDist.AutoSize = true;
            this.labelContDist.ForeColor = System.Drawing.Color.White;
            this.labelContDist.Location = new System.Drawing.Point(853, 381);
            this.labelContDist.Name = "labelContDist";
            this.labelContDist.Size = new System.Drawing.Size(44, 16);
            this.labelContDist.TabIndex = 7;
            this.labelContDist.Text = "label2";
            // 
            // labelRadio
            // 
            this.labelRadio.AutoSize = true;
            this.labelRadio.ForeColor = System.Drawing.Color.White;
            this.labelRadio.Location = new System.Drawing.Point(853, 282);
            this.labelRadio.Name = "labelRadio";
            this.labelRadio.Size = new System.Drawing.Size(44, 16);
            this.labelRadio.TabIndex = 7;
            this.labelRadio.Text = "label2";
            // 
            // labelCell
            // 
            this.labelCell.AutoSize = true;
            this.labelCell.ForeColor = System.Drawing.Color.White;
            this.labelCell.Location = new System.Drawing.Point(853, 178);
            this.labelCell.Name = "labelCell";
            this.labelCell.Size = new System.Drawing.Size(44, 16);
            this.labelCell.TabIndex = 7;
            this.labelCell.Text = "label2";
            // 
            // labelNum
            // 
            this.labelNum.AutoSize = true;
            this.labelNum.ForeColor = System.Drawing.Color.White;
            this.labelNum.Location = new System.Drawing.Point(853, 75);
            this.labelNum.Name = "labelNum";
            this.labelNum.Size = new System.Drawing.Size(44, 16);
            this.labelNum.TabIndex = 7;
            this.labelNum.Text = "label2";
            // 
            // trackBar4
            // 
            this.trackBar4.Location = new System.Drawing.Point(178, 378);
            this.trackBar4.Maximum = 50;
            this.trackBar4.Minimum = 1;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(661, 56);
            this.trackBar4.TabIndex = 6;
            this.trackBar4.Value = 5;
            this.trackBar4.Scroll += new System.EventHandler(this.trackBar4_Scroll);
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(178, 279);
            this.trackBar3.Minimum = 1;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(661, 56);
            this.trackBar3.TabIndex = 6;
            this.trackBar3.Value = 3;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // tBContDist
            // 
            this.tBContDist.Location = new System.Drawing.Point(36, 379);
            this.tBContDist.Name = "tBContDist";
            this.tBContDist.Size = new System.Drawing.Size(118, 22);
            this.tBContDist.TabIndex = 1;
            this.tBContDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(178, 175);
            this.trackBar2.Maximum = 50;
            this.trackBar2.Minimum = 10;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(661, 56);
            this.trackBar2.TabIndex = 6;
            this.trackBar2.TickFrequency = 5;
            this.trackBar2.Value = 20;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // tBRadio
            // 
            this.tBRadio.Location = new System.Drawing.Point(36, 280);
            this.tBRadio.Name = "tBRadio";
            this.tBRadio.Size = new System.Drawing.Size(118, 22);
            this.tBRadio.TabIndex = 1;
            this.tBRadio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(178, 72);
            this.trackBar1.Maximum = 10000;
            this.trackBar1.Minimum = 1000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(661, 56);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.TickFrequency = 100;
            this.trackBar1.Value = 10000;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // tBTamCell
            // 
            this.tBTamCell.Location = new System.Drawing.Point(36, 176);
            this.tBTamCell.Name = "tBTamCell";
            this.tBTamCell.Size = new System.Drawing.Size(118, 22);
            this.tBTamCell.TabIndex = 1;
            this.tBTamCell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bApply
            // 
            this.bApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bApply.Location = new System.Drawing.Point(592, 527);
            this.bApply.Name = "bApply";
            this.bApply.Size = new System.Drawing.Size(124, 38);
            this.bApply.TabIndex = 5;
            this.bApply.Text = "Apply";
            this.bApply.UseVisualStyleBackColor = true;
            this.bApply.Click += new System.EventHandler(this.bApply_Click);
            // 
            // tBnumeroBolas
            // 
            this.tBnumeroBolas.Location = new System.Drawing.Point(36, 73);
            this.tBnumeroBolas.Name = "tBnumeroBolas";
            this.tBnumeroBolas.Size = new System.Drawing.Size(118, 22);
            this.tBnumeroBolas.TabIndex = 1;
            this.tBnumeroBolas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 606);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AceptarConfig;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tBnumeroBolas;
        private System.Windows.Forms.Button bApply;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label labelNum;
        private System.Windows.Forms.CheckBox cBNumInd;
        private System.Windows.Forms.CheckBox cBTamCell;
        private System.Windows.Forms.Label labelCell;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TextBox tBTamCell;
        private System.Windows.Forms.CheckBox cBRadio;
        private System.Windows.Forms.Label labelRadio;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TextBox tBRadio;
        private System.Windows.Forms.CheckBox cBContDist;
        private System.Windows.Forms.Label labelContDist;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.TextBox tBContDist;
        private System.Windows.Forms.CheckBox CBTerrain;
        private System.Windows.Forms.CheckBox cBNoTerrain;
    }
}