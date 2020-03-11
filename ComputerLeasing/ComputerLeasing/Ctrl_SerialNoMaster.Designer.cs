namespace ComputerLeasing
{
    partial class Ctrl_SerialNoMaster
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
            this.txtComModel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComType = new System.Windows.Forms.TextBox();
            this.txtMaker = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bttUpdate = new System.Windows.Forms.Button();
            this.bttDelete = new System.Windows.Forms.Button();
            this.bttClear = new System.Windows.Forms.Button();
            this.bttAdd = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtRental = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtContractNo = new System.Windows.Forms.ComboBox();
            this.txtSearchSerialNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bttDetail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtComModel
            // 
            this.txtComModel.Location = new System.Drawing.Point(664, 12);
            this.txtComModel.Name = "txtComModel";
            this.txtComModel.Size = new System.Drawing.Size(76, 20);
            this.txtComModel.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(596, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "ComModel :";
            // 
            // txtComType
            // 
            this.txtComType.Location = new System.Drawing.Point(512, 12);
            this.txtComType.Name = "txtComType";
            this.txtComType.Size = new System.Drawing.Size(71, 20);
            this.txtComType.TabIndex = 20;
            // 
            // txtMaker
            // 
            this.txtMaker.Location = new System.Drawing.Point(376, 12);
            this.txtMaker.Name = "txtMaker";
            this.txtMaker.Size = new System.Drawing.Size(55, 20);
            this.txtMaker.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(446, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Com Type :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(327, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Maker :";
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Location = new System.Drawing.Point(240, 12);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(83, 20);
            this.txtSerialNo.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "SerialNo :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "ContractNo :";
            // 
            // bttUpdate
            // 
            this.bttUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bttUpdate.Location = new System.Drawing.Point(711, 432);
            this.bttUpdate.Name = "bttUpdate";
            this.bttUpdate.Size = new System.Drawing.Size(75, 23);
            this.bttUpdate.TabIndex = 35;
            this.bttUpdate.Text = "Update";
            this.bttUpdate.UseVisualStyleBackColor = false;
            this.bttUpdate.Click += new System.EventHandler(this.bttUpdate_Click);
            // 
            // bttDelete
            // 
            this.bttDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttDelete.BackColor = System.Drawing.Color.Red;
            this.bttDelete.Location = new System.Drawing.Point(792, 432);
            this.bttDelete.Name = "bttDelete";
            this.bttDelete.Size = new System.Drawing.Size(75, 23);
            this.bttDelete.TabIndex = 32;
            this.bttDelete.Text = "Delete";
            this.bttDelete.UseVisualStyleBackColor = false;
            this.bttDelete.Click += new System.EventHandler(this.bttDelete_Click);
            // 
            // bttClear
            // 
            this.bttClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttClear.Location = new System.Drawing.Point(84, 432);
            this.bttClear.Name = "bttClear";
            this.bttClear.Size = new System.Drawing.Size(75, 23);
            this.bttClear.TabIndex = 33;
            this.bttClear.Text = "Clear";
            this.bttClear.UseVisualStyleBackColor = true;
            this.bttClear.Click += new System.EventHandler(this.bttClear_Click);
            // 
            // bttAdd
            // 
            this.bttAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bttAdd.Location = new System.Drawing.Point(3, 432);
            this.bttAdd.Name = "bttAdd";
            this.bttAdd.Size = new System.Drawing.Size(75, 23);
            this.bttAdd.TabIndex = 34;
            this.bttAdd.Text = "Add";
            this.bttAdd.UseVisualStyleBackColor = false;
            this.bttAdd.Click += new System.EventHandler(this.bttAdd_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(865, 384);
            this.dataGridView1.TabIndex = 36;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // txtRental
            // 
            this.txtRental.Location = new System.Drawing.Point(799, 12);
            this.txtRental.Name = "txtRental";
            this.txtRental.Size = new System.Drawing.Size(64, 20);
            this.txtRental.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(749, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Rental :";
            // 
            // txtContractNo
            // 
            this.txtContractNo.FormattingEnabled = true;
            this.txtContractNo.Location = new System.Drawing.Point(78, 12);
            this.txtContractNo.Name = "txtContractNo";
            this.txtContractNo.Size = new System.Drawing.Size(100, 21);
            this.txtContractNo.TabIndex = 39;
            // 
            // txtSearchSerialNo
            // 
            this.txtSearchSerialNo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSearchSerialNo.Location = new System.Drawing.Point(376, 431);
            this.txtSearchSerialNo.Name = "txtSearchSerialNo";
            this.txtSearchSerialNo.Size = new System.Drawing.Size(83, 20);
            this.txtSearchSerialNo.TabIndex = 40;
            this.txtSearchSerialNo.TextChanged += new System.EventHandler(this.txtSearchSerialNo_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(335, 435);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "ค้นหา";
            // 
            // bttDetail
            // 
            this.bttDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttDetail.Location = new System.Drawing.Point(206, 432);
            this.bttDetail.Name = "bttDetail";
            this.bttDetail.Size = new System.Drawing.Size(75, 23);
            this.bttDetail.TabIndex = 70;
            this.bttDetail.Text = "Detail";
            this.bttDetail.UseVisualStyleBackColor = true;
            this.bttDetail.Click += new System.EventHandler(this.bttDetail_Click);
            // 
            // Ctrl_SerialNoMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.bttDetail);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSearchSerialNo);
            this.Controls.Add(this.txtContractNo);
            this.Controls.Add(this.txtRental);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bttUpdate);
            this.Controls.Add(this.bttDelete);
            this.Controls.Add(this.bttClear);
            this.Controls.Add(this.bttAdd);
            this.Controls.Add(this.txtComModel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtComType);
            this.Controls.Add(this.txtMaker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSerialNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Ctrl_SerialNoMaster";
            this.Size = new System.Drawing.Size(871, 459);
            this.Load += new System.EventHandler(this.Ctrl_SerialNoMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtComModel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtComType;
        private System.Windows.Forms.TextBox txtMaker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bttUpdate;
        private System.Windows.Forms.Button bttDelete;
        private System.Windows.Forms.Button bttClear;
        private System.Windows.Forms.Button bttAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtRental;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox txtContractNo;
        private System.Windows.Forms.TextBox txtSearchSerialNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bttDetail;
    }
}
