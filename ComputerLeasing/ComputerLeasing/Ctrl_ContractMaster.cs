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

namespace ComputerLeasing
{
    public partial class Ctrl_ContractMaster : UserControl
    {

        int valErr = 0;

        SqlConnection conn = new SqlConnection("Server=...;Database=...;User Id=...;Password=...;MultipleActiveResultSets=True");

        public Ctrl_ContractMaster()
        {
            InitializeComponent();
        }

        private void Ctrl_ContractMaster_Load(object sender, EventArgs e)
        {
            conn.Open();
            Showdata();
            ClearData();
            this.Dock = DockStyle.Fill;
        }

        private void ClearData()
        {
            txtContractNo.Text = "";
            txtConDesc.Text = "";
            txtStrDate.Text = "";
            txtEndDate.Text = "";
            txtRental.Text = "";


            bttAdd.Enabled = true;
            bttDelete.Enabled = false;
            bttDetail.Enabled = false;

        }

        private void Showdata()
        {
            int varindex = 0;

            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 5;

            dataGridView1.Columns[varindex].Name = "ContractNo";
            dataGridView1.Columns[varindex].Width = 100;

            varindex = varindex + 1;
            dataGridView1.Columns[varindex].Name = "ConDesc";
            dataGridView1.Columns[varindex].Width = 250;

            varindex = varindex + 1;
            dataGridView1.Columns[varindex].Name = "StrDate";
            dataGridView1.Columns[varindex].Width = 100;

            varindex = varindex + 1;
            dataGridView1.Columns[varindex].Name = "EndDate";
            dataGridView1.Columns[varindex].Width = 100;

            varindex = varindex + 1;
            dataGridView1.Columns[varindex].Name = "Rental";
            dataGridView1.Columns[varindex].Width = 100;

            string sql = "";
            if (txtSearch.Text == "")
            {
                sql = "Select * from ContractMaster order by ContractNo ";
            }
            else
            {
                sql = "Select * from ContractMaster where ContractNo like '%' + '" + txtSearch.Text + "' + '%' order by ContractNo ";

            }
            SqlCommand com = new SqlCommand(sql, conn);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr["ContractNo"].ToString(), dr["ConDesc"].ToString(), dr["StrDate"].ToString(), dr["EndDate"].ToString(), dr["Rental"].ToString());
            }

            dr.Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtContractNo.Text = dataGridView1.Rows[e.RowIndex].Cells["ContractNo"].Value.ToString();
                txtConDesc.Text = dataGridView1.Rows[e.RowIndex].Cells["ConDesc"].Value.ToString();
                txtStrDate.Text = dataGridView1.Rows[e.RowIndex].Cells["StrDate"].Value.ToString();
                txtEndDate.Text = dataGridView1.Rows[e.RowIndex].Cells["EndDate"].Value.ToString();
                txtRental.Text = dataGridView1.Rows[e.RowIndex].Cells["Rental"].Value.ToString();
                MyGlobal.GlobalShowDetail = dataGridView1.Rows[e.RowIndex].Cells["ContractNo"].Value.ToString();
            }
            catch { }

            bttAdd.Enabled = false;
            bttDelete.Enabled = true;
            bttDetail.Enabled = true;
        }

        private void CheckError()
        {
            valErr = 0;
            if (txtContractNo.Text.Trim() == "")
            {
                MessageBox.Show("please input ContractNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); valErr = +1; return;
            }
            else if (txtConDesc.Text.Trim() == "") { MessageBox.Show("please input ConDesc", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); valErr = +1; return; }
            else if (txtStrDate.Text.Trim() == "") { MessageBox.Show("please input StrDate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); valErr = +1; return; }
            else if (txtEndDate.Text.Trim() == "") { MessageBox.Show("please input EndDate ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); valErr = +1; return; }
            else if (txtRental.Text.Trim() == "") { MessageBox.Show("please input Rental ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); valErr = +1; return; }
        }

        private void bttAdd_Click(object sender, EventArgs e)
        {
            CheckError();
            if (valErr == 0)
            {
                String sql = "INSERT INTO ContractMaster (ContractNo,ConDesc,StrDate,EndDate,Rental)VALUES ('" + txtContractNo.Text + "','" + txtConDesc.Text + "','" + txtStrDate.Text + "','" + txtEndDate.Text + "','" + txtRental.Text + "')";

                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();
                MessageBox.Show("Add completed");

                Showdata();
                ClearData();
            }
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            txtStrDate.Text = dateTimePicker1.Value.Year.ToString("0000") + "/" + dateTimePicker1.Value.Month.ToString("00") + "/" + dateTimePicker1.Value.Day.ToString("00");
        }

        private void dateTimePicker2_CloseUp(object sender, EventArgs e)
        {
            txtEndDate.Text = dateTimePicker2.Value.Year.ToString("0000") + "/" + dateTimePicker2.Value.Month.ToString("00") + "/" + dateTimePicker2.Value.Day.ToString("00");
        }

        private void bttDelete_Click(object sender, EventArgs e)
        {
            if (txtContractNo.Text.Trim() == "")
            { MessageBox.Show("Please Select Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); return; }

            if (MessageBox.Show("Do you want to delete the data ? " + txtContractNo.Text, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                String sql = "Delete from ContractMaster where ContractNo ='" + txtContractNo.Text + "' ";
                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();

                MessageBox.Show("Delete completed");
                Showdata();
                ClearData();
            }
        }

        private void bttClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void bttUpdate_Click(object sender, EventArgs e)
        {
            CheckError();
            if (valErr != 0) { return; }
            if (txtContractNo.Text.Trim() == "")
            {
                MessageBox.Show("Please Select Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); return;
            }

            if (MessageBox.Show("Do you want to Update the data ? " + txtContractNo.Text, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                String sql = "Update ContractMaster SET ContractNo = '" + txtContractNo.Text + "', ConDesc = '" + txtConDesc.Text + "', StrDate = '" + txtStrDate.Text + "' , EndDate = '" + txtEndDate.Text + "', Rental = '" + txtRental.Text + "' where ContractNo = '" + txtContractNo.Text + "'";
                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();

                MessageBox.Show("Update completed");
                Showdata();
                ClearData();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Showdata();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void bttDetail_Click(object sender, EventArgs e)
        {
          
            //MyGlobal.GlobalShowDetail = txtContractNo.Text;
        }
    }
}
