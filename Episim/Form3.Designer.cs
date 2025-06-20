namespace Sim03
{
    partial class Form3
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PimageModel = new System.Windows.Forms.Panel();
            this.pBmodel = new System.Windows.Forms.PictureBox();
            this.cBempty = new System.Windows.Forms.CheckBox();
            this.cBvseiqr = new System.Windows.Forms.CheckBox();
            this.cBsir = new System.Windows.Forms.CheckBox();
            this.cBsis = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Color = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.States = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MinTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.V = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Is = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Q = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplyModel = new System.Windows.Forms.Button();
            this.AcceptModel = new System.Windows.Forms.Button();
            this.CB3Terrain = new System.Windows.Forms.CheckBox();
            this.CB3NoTerrain = new System.Windows.Forms.CheckBox();
            this.cBseair = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.PimageModel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBmodel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(23)))), ((int)(((byte)(32)))));
            this.panel1.Controls.Add(this.cBseair);
            this.panel1.Controls.Add(this.CB3NoTerrain);
            this.panel1.Controls.Add(this.CB3Terrain);
            this.panel1.Controls.Add(this.PimageModel);
            this.panel1.Controls.Add(this.cBempty);
            this.panel1.Controls.Add(this.cBvseiqr);
            this.panel1.Controls.Add(this.cBsir);
            this.panel1.Controls.Add(this.cBsis);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.ApplyModel);
            this.panel1.Controls.Add(this.AcceptModel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(914, 606);
            this.panel1.TabIndex = 0;
            // 
            // PimageModel
            // 
            this.PimageModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PimageModel.Controls.Add(this.pBmodel);
            this.PimageModel.Location = new System.Drawing.Point(67, 278);
            this.PimageModel.Name = "PimageModel";
            this.PimageModel.Size = new System.Drawing.Size(484, 246);
            this.PimageModel.TabIndex = 7;
            // 
            // pBmodel
            // 
            this.pBmodel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pBmodel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(23)))), ((int)(((byte)(32)))));
            this.pBmodel.Location = new System.Drawing.Point(3, 3);
            this.pBmodel.Name = "pBmodel";
            this.pBmodel.Size = new System.Drawing.Size(477, 240);
            this.pBmodel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pBmodel.TabIndex = 0;
            this.pBmodel.TabStop = false;
            // 
            // cBempty
            // 
            this.cBempty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cBempty.AutoSize = true;
            this.cBempty.ForeColor = System.Drawing.Color.White;
            this.cBempty.Location = new System.Drawing.Point(313, 556);
            this.cBempty.Name = "cBempty";
            this.cBempty.Size = new System.Drawing.Size(67, 20);
            this.cBempty.TabIndex = 6;
            this.cBempty.Text = "Empty";
            this.cBempty.UseVisualStyleBackColor = true;
            this.cBempty.CheckedChanged += new System.EventHandler(this.cBempty_CheckedChanged);
            // 
            // cBvseiqr
            // 
            this.cBvseiqr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cBvseiqr.AutoSize = true;
            this.cBvseiqr.ForeColor = System.Drawing.Color.White;
            this.cBvseiqr.Location = new System.Drawing.Point(228, 556);
            this.cBvseiqr.Name = "cBvseiqr";
            this.cBvseiqr.Size = new System.Drawing.Size(79, 20);
            this.cBvseiqr.TabIndex = 5;
            this.cBvseiqr.Text = "VSEIQR";
            this.cBvseiqr.UseVisualStyleBackColor = true;
            this.cBvseiqr.CheckedChanged += new System.EventHandler(this.cBvseiqr_CheckedChanged);
            // 
            // cBsir
            // 
            this.cBsir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cBsir.AutoSize = true;
            this.cBsir.ForeColor = System.Drawing.Color.White;
            this.cBsir.Location = new System.Drawing.Point(86, 556);
            this.cBsir.Name = "cBsir";
            this.cBsir.Size = new System.Drawing.Size(51, 20);
            this.cBsir.TabIndex = 4;
            this.cBsir.Text = "SIR";
            this.cBsir.UseVisualStyleBackColor = true;
            this.cBsir.CheckedChanged += new System.EventHandler(this.cBsir_CheckedChanged);
            // 
            // cBsis
            // 
            this.cBsis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cBsis.AutoSize = true;
            this.cBsis.ForeColor = System.Drawing.Color.White;
            this.cBsis.Location = new System.Drawing.Point(23, 556);
            this.cBsis.Name = "cBsis";
            this.cBsis.Size = new System.Drawing.Size(50, 20);
            this.cBsis.TabIndex = 3;
            this.cBsis.Text = "SIS";
            this.cBsis.UseVisualStyleBackColor = true;
            this.cBsis.CheckedChanged += new System.EventHandler(this.cBsis_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(23)))), ((int)(((byte)(32)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Color,
            this.States,
            this.Qty,
            this.Action,
            this.MinTime,
            this.MaxTime,
            this.S,
            this.V,
            this.E,
            this.Is,
            this.Ia,
            this.Q,
            this.R,
            this.M});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(23, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(859, 260);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // Color
            // 
            this.Color.HeaderText = "Color";
            this.Color.MinimumWidth = 6;
            this.Color.Name = "Color";
            this.Color.Width = 70;
            // 
            // States
            // 
            this.States.HeaderText = "States";
            this.States.MinimumWidth = 6;
            this.States.Name = "States";
            this.States.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.States.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.States.Width = 50;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.MinimumWidth = 6;
            this.Qty.Name = "Qty";
            this.Qty.Width = 50;
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.MinimumWidth = 6;
            this.Action.Name = "Action";
            this.Action.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Action.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Action.Width = 50;
            // 
            // MinTime
            // 
            this.MinTime.HeaderText = "Min Time";
            this.MinTime.MaxInputLength = 200;
            this.MinTime.MinimumWidth = 6;
            this.MinTime.Name = "MinTime";
            this.MinTime.Width = 50;
            // 
            // MaxTime
            // 
            this.MaxTime.HeaderText = "Max Time";
            this.MaxTime.MinimumWidth = 6;
            this.MaxTime.Name = "MaxTime";
            this.MaxTime.Width = 50;
            // 
            // S
            // 
            this.S.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.S.HeaderText = "S";
            this.S.MinimumWidth = 6;
            this.S.Name = "S";
            this.S.Width = 45;
            // 
            // V
            // 
            this.V.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.V.HeaderText = "V";
            this.V.MinimumWidth = 6;
            this.V.Name = "V";
            this.V.Width = 45;
            // 
            // E
            // 
            this.E.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.E.HeaderText = "E";
            this.E.MinimumWidth = 6;
            this.E.Name = "E";
            this.E.Width = 45;
            // 
            // Is
            // 
            this.Is.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Is.HeaderText = "Is";
            this.Is.MinimumWidth = 6;
            this.Is.Name = "Is";
            this.Is.Width = 46;
            // 
            // Ia
            // 
            this.Ia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ia.HeaderText = "Ia";
            this.Ia.MinimumWidth = 6;
            this.Ia.Name = "Ia";
            this.Ia.Width = 47;
            // 
            // Q
            // 
            this.Q.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Q.HeaderText = "Q";
            this.Q.MinimumWidth = 6;
            this.Q.Name = "Q";
            this.Q.Width = 46;
            // 
            // R
            // 
            this.R.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.R.HeaderText = "R";
            this.R.MinimumWidth = 6;
            this.R.Name = "R";
            this.R.Width = 46;
            // 
            // M
            // 
            this.M.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.M.HeaderText = "M";
            this.M.MinimumWidth = 6;
            this.M.Name = "M";
            this.M.Width = 47;
            // 
            // ApplyModel
            // 
            this.ApplyModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyModel.Location = new System.Drawing.Point(592, 546);
            this.ApplyModel.Name = "ApplyModel";
            this.ApplyModel.Size = new System.Drawing.Size(124, 38);
            this.ApplyModel.TabIndex = 1;
            this.ApplyModel.Text = "Apply";
            this.ApplyModel.UseVisualStyleBackColor = true;
            this.ApplyModel.Click += new System.EventHandler(this.ApplyModel_Click);
            // 
            // AcceptModel
            // 
            this.AcceptModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AcceptModel.Location = new System.Drawing.Point(737, 546);
            this.AcceptModel.Name = "AcceptModel";
            this.AcceptModel.Size = new System.Drawing.Size(124, 38);
            this.AcceptModel.TabIndex = 0;
            this.AcceptModel.Text = "Accept";
            this.AcceptModel.UseVisualStyleBackColor = true;
            this.AcceptModel.Click += new System.EventHandler(this.AcceptModel_Click);
            // 
            // CB3Terrain
            // 
            this.CB3Terrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CB3Terrain.AutoSize = true;
            this.CB3Terrain.ForeColor = System.Drawing.Color.White;
            this.CB3Terrain.Location = new System.Drawing.Point(685, 326);
            this.CB3Terrain.Name = "CB3Terrain";
            this.CB3Terrain.Size = new System.Drawing.Size(72, 20);
            this.CB3Terrain.TabIndex = 8;
            this.CB3Terrain.Text = "Terrain";
            this.CB3Terrain.UseVisualStyleBackColor = true;
            // 
            // CB3NoTerrain
            // 
            this.CB3NoTerrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CB3NoTerrain.AutoSize = true;
            this.CB3NoTerrain.ForeColor = System.Drawing.Color.White;
            this.CB3NoTerrain.Location = new System.Drawing.Point(685, 392);
            this.CB3NoTerrain.Name = "CB3NoTerrain";
            this.CB3NoTerrain.Size = new System.Drawing.Size(93, 20);
            this.CB3NoTerrain.TabIndex = 9;
            this.CB3NoTerrain.Text = "No Terrain";
            this.CB3NoTerrain.UseVisualStyleBackColor = true;
            // 
            // cBseair
            // 
            this.cBseair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cBseair.AutoSize = true;
            this.cBseair.ForeColor = System.Drawing.Color.White;
            this.cBseair.Location = new System.Drawing.Point(153, 556);
            this.cBseair.Name = "cBseair";
            this.cBseair.Size = new System.Drawing.Size(69, 20);
            this.cBseair.TabIndex = 10;
            this.cBseair.Text = "SEAIR";
            this.cBseair.UseVisualStyleBackColor = true;
            this.cBseair.CheckedChanged += new System.EventHandler(this.cBseair_CheckedChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 606);
            this.Controls.Add(this.panel1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PimageModel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBmodel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AcceptModel;
        private System.Windows.Forms.Button ApplyModel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox cBsir;
        private System.Windows.Forms.CheckBox cBsis;
        private System.Windows.Forms.CheckBox cBvseiqr;
        private System.Windows.Forms.CheckBox cBempty;
        private System.Windows.Forms.Panel PimageModel;
        private System.Windows.Forms.PictureBox pBmodel;
        private System.Windows.Forms.DataGridViewComboBoxColumn Color;
        private System.Windows.Forms.DataGridViewComboBoxColumn States;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewComboBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn S;
        private System.Windows.Forms.DataGridViewTextBoxColumn V;
        private System.Windows.Forms.DataGridViewTextBoxColumn E;
        private System.Windows.Forms.DataGridViewTextBoxColumn Is;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Q;
        private System.Windows.Forms.DataGridViewTextBoxColumn R;
        private System.Windows.Forms.DataGridViewTextBoxColumn M;
        private System.Windows.Forms.CheckBox CB3Terrain;
        private System.Windows.Forms.CheckBox CB3NoTerrain;
        private System.Windows.Forms.CheckBox cBseair;
    }
}