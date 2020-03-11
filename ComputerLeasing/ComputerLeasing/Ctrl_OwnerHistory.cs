using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace ComputerLeasing
{
    public partial class Ctrl_OwnerHistory : UserControl
    {

        int valErr = 0;
        string varstatus = "";
        string varRigthClick = "";

        SqlConnection conn = new SqlConnection("Server=...;Database=...;User Id=...;Password=...;MultipleActiveResultSets=True");

        public Ctrl_OwnerHistory()
        {
            InitializeComponent();
        }

        private void Ctrl_OwnerHistory_Load(object sender, EventArgs e)
        {
            conn.Open();
            Showdata();
            txtSearchSerialNo.Text = MyGlobal.GlobalSerialNo;
            ClearData();
            this.Dock = DockStyle.Fill;
            this.ActiveControl = txtSearchSerialNo;
            
            //CbCloseJob.Checked = true;
        }

        private void ClearData()
        {
            txtSerialNo.Text = "";
            txtUser.Text = "";
            txtStrDate.Text = "";
            txtEndDate.Text = "";
            txtSEQ.Text = "";
            CbActive.Checked = false;

            bttAdd.Enabled = true;
            bttDelete.Enabled = false;
            bttUpdate.Enabled = false;

        }

        private void Showdata()
        {
            int varindex = 0;

            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 7;

            
            dataGridView1.Columns[varindex].Name = "ContactNo";
            dataGridView1.Columns[varindex].Width = 150;

            varindex = varindex + 1;
            dataGridView1.Columns[varindex].Name = "SerialNo";
            dataGridView1.Columns[varindex].Width = 150;

            varindex = varindex + 1;
            dataGridView1.Columns[varindex].Name = "User";
            dataGridView1.Columns[varindex].Width = 200;

            varindex = varindex + 1;
            dataGridView1.Columns[varindex].Name = "StrDate";
            dataGridView1.Columns[varindex].Width = 100;

            varindex = varindex + 1;
            dataGridView1.Columns[varindex].Name = "EndDate";
            dataGridView1.Columns[varindex].Width = 100;

            varindex = varindex + 1;
            dataGridView1.Columns[varindex].Name = "StatusComputer";
            dataGridView1.Columns[varindex].Width = 80;
            dataGridView1.Columns[varindex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
          
            varindex = varindex + 1;
            dataGridView1.Columns[varindex].Name = "SEQ";
            dataGridView1.Columns[varindex].Width = 50;

          //  int varCount = 0;
            string sql = "";
            if (txtSearchSerialNo.Text == "")
              {            
                    sql = "Select * from SerialNoMaster inner join OwnerHistory on SerialNoMaster.SerialNo = OwnerHistory.SerialNo order by ContractNo DESC";            
              }
            else
            {
                sql = "Select * from SerialNoMaster inner join OwnerHistory on SerialNoMaster.SerialNo = OwnerHistory.SerialNo where OwnerHistory.SerialNo like '%' + '" + txtSearchSerialNo.Text + "' + '%'  or [User] like '%' + '" + txtSearchSerialNo.Text + "' + '%' order by StrDate Desc";
            }


            SqlCommand com = new SqlCommand(sql, conn);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                if(dr["StatusComputer"].ToString() == "9")
                {
                    varstatus = "Active";
                }
                else { varstatus = "Inactive"; }

                dataGridView1.Rows.Add(dr["ContractNo"].ToString(),dr["SerialNo"].ToString(), dr["User"].ToString(), dr["StrDate"].ToString(), dr["EndDate"].ToString(), varstatus, dr["SEQ"].ToString());     
        
            }

            dr.Close();
        }

        private void CheckError()
        {
           
            valErr = 0;
            if (txtSerialNo.Text.Trim() == "")
            {
                MessageBox.Show("please input SerialNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); valErr = +1; return;
            }
            else if (txtUser.Text.Trim() == "") { MessageBox.Show("please input SerialNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); valErr = +1; return; }
            else if (txtStrDate.Text.Trim() == "") { MessageBox.Show("please input StrDate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); valErr = +1; return; }

            
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ClearData();
            try
            {               

                txtSerialNo.Text = dataGridView1.Rows[e.RowIndex].Cells["SerialNo"].Value.ToString();
                txtUser.Text = dataGridView1.Rows[e.RowIndex].Cells["User"].Value.ToString();
                txtStrDate.Text = dataGridView1.Rows[e.RowIndex].Cells["StrDate"].Value.ToString();
                txtEndDate.Text = dataGridView1.Rows[e.RowIndex].Cells["EndDate"].Value.ToString();
                txtSEQ.Text = dataGridView1.Rows[e.RowIndex].Cells["SEQ"].Value.ToString();
                //    MyGlobal.GlobalPrintReport = dataGridView1.Rows[e.RowIndex].Cells["SerialNo"].Value.ToString();

                if (dataGridView1.Rows[e.RowIndex].Cells["StatusComputer"].Value.ToString() == "9")
                {
                    CbActive.Checked = true;
                }
            }
            catch { }


            bttAdd.Enabled = false;
            bttDelete.Enabled = true;

            bttUpdate.Enabled = true;
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            txtStrDate.Text = dateTimePicker1.Value.Year.ToString("0000") + "/" + dateTimePicker1.Value.Month.ToString("00") + "/" + dateTimePicker1.Value.Day.ToString("00");
        }

        private void dateTimePicker2_CloseUp(object sender, EventArgs e)
        {
            txtEndDate.Text = dateTimePicker2.Value.Year.ToString("0000") + "/" + dateTimePicker2.Value.Month.ToString("00") + "/" + dateTimePicker2.Value.Day.ToString("00");
        }

        private void bttClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void bttAdd_Click(object sender, EventArgs e)
        {
            CheckError();          
            if (valErr == 0)
            {
                String sql = "INSERT INTO OwnerHistory (SerialNo,[User],StrDate,EndDate)VALUES ('" + txtSerialNo.Text + "','" + txtUser.Text + "','" + txtStrDate.Text + "','" + txtEndDate.Text + "')";

                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();
                MessageBox.Show("Add completed");

                Showdata();
                ClearData();
            }
        }

        private void bttUpdate_Click(object sender, EventArgs e)
        {
            CheckError();
            string varStatusComputer = "";
            if(CbActive.Checked)
            {
                varStatusComputer = "9";
            }
            else { varStatusComputer = ""; }

            if (valErr != 0) { return; }
            if (txtSEQ.Text.Trim() == "")
            {
                MessageBox.Show("Please Select Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); return;
            }

            if (MessageBox.Show("Do you want to Update the data ? " + txtSEQ.Text, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                String sql = "Update OwnerHistory SET SerialNo = '" + txtSerialNo.Text + "', [User] = '" + txtUser.Text + "', StrDate = '" + txtStrDate.Text + "' , EndDate = '" + txtEndDate.Text + "' , StatusComputer = '" + varStatusComputer + "' where SEQ = '" + txtSEQ.Text + "'";
                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();

                MessageBox.Show("Update completed");
                Showdata();
                ClearData();
            }
        }

        private void bttDelete_Click(object sender, EventArgs e)
        {
            if (txtSEQ.Text.Trim() == "")
            { MessageBox.Show("Please Select Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); return; }

            if (MessageBox.Show("Do you want to delete the data ? " + txtSEQ.Text, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                String sql = "Delete from OwnerHistory where SEQ ='" + txtSEQ.Text + "' ";
                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();

                MessageBox.Show("Delete completed");
                Showdata();
                ClearData();
            }
        }

        private void txtSearchSerialNo_TextChanged(object sender, EventArgs e)
        {
            Showdata();
        }

        private void bttSearchUser_Click(object sender, EventArgs e)
        {
            SearchUserName WinD3 = new SearchUserName();
            WinD3.ShowDialog();
            txtUser.Text = MyGlobal.GlobalUserName;
        }

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           // varRigthClick = dataGridView1.Rows[e.RowIndex].Cells["ContactNo"].Value.ToString();
           // MyGlobal.GlobalRightClick = varRigthClick;
        }

        private void DetailToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);

        }
    }
}
