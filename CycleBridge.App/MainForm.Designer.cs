namespace CycleBridge.App
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.graphPanel = new CycleBridge.Controls.GraphPanel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExample = new System.Windows.Forms.Button();
            this.nudN = new System.Windows.Forms.NumericUpDown();
            this.lblN = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            this.panelLeft.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudN)).BeginInit();
            this.SuspendLayout();
            // 
            // graphPanel
            // 
            this.graphPanel.BackColor = System.Drawing.Color.White;
            this.graphPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphPanel.Location = new System.Drawing.Point(290, 0);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(610, 600);
            this.graphPanel.TabIndex = 1;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.lstResult);
            this.panelLeft.Controls.Add(this.panelTop);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(290, 600);
            this.panelLeft.TabIndex = 0;
            // 
            // lstResult
            // 
            this.lstResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstResult.FormattingEnabled = true;
            this.lstResult.Location = new System.Drawing.Point(0, 200);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(290, 400);
            this.lstResult.TabIndex = 1;
            this.lstResult.SelectedIndexChanged += new System.EventHandler(this.lstResult_SelectedIndexChanged);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnAbout);
            this.panelTop.Controls.Add(this.btnClear);
            this.panelTop.Controls.Add(this.btnExample);
            this.panelTop.Controls.Add(this.nudN);
            this.panelTop.Controls.Add(this.lblN);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(290, 200);
            this.panelTop.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(150, 45);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(130, 28);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExample
            // 
            this.btnExample.Location = new System.Drawing.Point(10, 45);
            this.btnExample.Name = "btnExample";
            this.btnExample.Size = new System.Drawing.Size(130, 28);
            this.btnExample.TabIndex = 2;
            this.btnExample.Text = "Пример";
            this.btnExample.UseVisualStyleBackColor = true;
            this.btnExample.Click += new System.EventHandler(this.btnExample_Click);
            // 
            // nudN
            // 
            this.nudN.Location = new System.Drawing.Point(130, 10);
            this.nudN.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudN.Name = "nudN";
            this.nudN.Size = new System.Drawing.Size(60, 20);
            this.nudN.TabIndex = 1;
            this.nudN.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudN.ValueChanged += new System.EventHandler(this.nudN_ValueChanged);
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Location = new System.Drawing.Point(10, 14);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(83, 13);
            this.lblN.TabIndex = 0;
            this.lblN.Text = "Число вершин:";
            // 
            // btnAbout
            // 
            this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAbout.Location = new System.Drawing.Point(13, 108);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(267, 66);
            this.btnAbout.TabIndex = 4;
            this.btnAbout.Text = "О программе";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.panelLeft);
            this.MinimumSize = new System.Drawing.Size(700, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поиск циклов и мостов в графе";
            this.panelLeft.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudN)).EndInit();
            this.ResumeLayout(false);

        }

        private CycleBridge.Controls.GraphPanel graphPanel;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExample;
        private System.Windows.Forms.NumericUpDown nudN;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.Button btnAbout;
    }
}