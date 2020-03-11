namespace ComputerLeasing
{
    partial class Ctrl_PrintReport
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.txtShowSerailNo = new System.Windows.Forms.TextBox();
            this.bttShow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(3, 32);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(865, 423);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "SerailNo";
            // 
            // txtShowSerailNo
            // 
            this.txtShowSerailNo.Location = new System.Drawing.Point(58, 7);
            this.txtShowSerailNo.Name = "txtShowSerailNo";
            this.txtShowSerailNo.Size = new System.Drawing.Size(127, 20);
            this.txtShowSerailNo.TabIndex = 5;
            // 
            // bttShow
            // 
            this.bttShow.Location = new System.Drawing.Point(219, 4);
            this.bttShow.Name = "bttShow";
            this.bttShow.Size = new System.Drawing.Size(75, 23);
            this.bttShow.TabIndex = 4;
            this.bttShow.Text = "Show";
            this.bttShow.UseVisualStyleBackColor = true;
            this.bttShow.Click += new System.EventHandler(this.bttShow_Click);
            // 
            // Ctrl_PrintReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtShowSerailNo);
            this.Controls.Add(this.bttShow);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "Ctrl_PrintReport";
            this.Size = new System.Drawing.Size(871, 459);
            this.Load += new System.EventHandler(this.Ctrl_PrintReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtShowSerailNo;
        private System.Windows.Forms.Button bttShow;
    }
}
