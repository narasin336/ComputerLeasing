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
    public partial class Ctrl_SerialNoMaster : UserControl
    {

        int valErr = 0;
        int i = 0;
        SqlConnection conn = new SqlConnection("Server=...;Database=...;User Id=...;Password=...;MultipleActiveResultSets=True");

        public Ctrl_SerialNoMaster()
        {
            InitializeComponent();
        }

        private void Ctrl_SerialNoMaster_Load(object sender, EventArgs e)
        {
            conn.Open();
            Showdata();
            this.Dock = DockStyle.Fill;
            txtSearchSerialNo.Text = MyGlobal.GlobalShowDetail;

            string sql1 = "Select * from ContractMaster order by ContractNo ";
            SqlCommand com1 = new SqlCommand(sql1, conn);
            SqlDataReader dr1 = com1.ExecuteReader();
            while (dr1.Read())
            {
                txtContractNo.Items.Add(dr1["ContractNo"]);
            }
            dr1.Close();

            ClearData();         

        }

        private void ClearData()
        {
            txtContractNo.Text = "";
            txtSerialNo.Text = "";
            txtMaker.Text = "";
            txtComType.Text = "";
            txtComModel.Text = "";
            txtRental.Text = "";


            bttAdd.Enabled = true;
            bttDelete.Enabled = false;
            bttUpdate.Enabled = false;

        }

        private void Showdata()
        {
            int varindex = 0;

            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 6;

            dataGridView1.Columns[varindex].Name = "ContractNo";
            dataGridView1.Columns[varindex].Width = 100;

            varindex = varindex + 1;
            dataGridView1.Columns[varindex].Name = "SerialNo";
            dataGridView1.Columns[varindex].Width = 100;

            varindex = varindex + 1;
            dataGridView1.Columns[varindex].Name = "Maker";
            dataGridView1.Columns[varindex].Width = 100;

            varindex = varindex + 1;
            dataGridView1.Columns[varindex].Name = "ComType";
            dataGridView1.Columns[varindex].Width = 100;

            varindex = varindex + 1;
            dataGridView1.Columns[varindex].Name = "ComModel";
            dataGridView1.Columns[varindex].Width = 200;

            varindex = varindex + 1;
            dataGridView1.Columns[varindex].Name = "Rental";
            dataGridView1.Columns[varindex].Width = 80;

            string sql = "";
            if (txtSearchSerialNo.Text == "")
            {
                sql = "Select * from SerialNoMaster order by ContractNo ";
            }
            else if(txtSearchSerialNo.Text == MyGlobal.GlobalShowDetail)
            {
                sql = "Select * from SerialNoMaster where SerialNo like '%' + '" + txtSearchSerialNo.Text + "' + '%' or ContractNo like '%' + '" + txtSearchSerialNo.Text + "' + '%' order by SerialNo";
            }
            else
            {
                sql = "Select * from SerialNoMaster where SerialNo like '%' + '" + txtSearchSerialNo.Text + "' + '%' or ContractNo like '%' + '" + txtSearchSerialNo.Text + "' + '%' order by SerialNo";
            }



            SqlCommand com = new SqlCommand(sql, conn);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr["ContractNo"].ToString(), dr["SerialNo"].ToString(), dr["Maker"].ToString(), dr["ComType"].ToString(), dr["ComModel"].ToString(), dr["Rental"].ToString());
            }

           

            dr.Close();
        }

        private void CheckError()
        {
            valErr = 0;
            if (txtContractNo.Text.Trim() == "")
            {
                MessageBox.Show("please input ContractNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); valErr = +1; return;
            }
            else if (txtSerialNo.Text.Trim() == "") { MessageBox.Show("please input SerialNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); valErr = +1; return; }
            else if (txtMaker.Text.Trim() == "") { MessageBox.Show("please input Maker", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); valErr = +1; return; }
            else if (txtComType.Text.Trim() == "") { MessageBox.Show("please input ComType ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); valErr = +1; return; }
            else if (txtComModel.Text.Trim() == "") { MessageBox.Show("please input ComModel ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); valErr = +1; return; }
            else if (txtRental.Text.Trim() == "") { MessageBox.Show("please input Rental ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); valErr = +1; return; }
        }

        private void bttAdd_Click(object sender, EventArgs e)
        {
            CheckError();
           
                    if (valErr == 0)
                    {
                        String sql = "INSERT INTO SerialNoMaster (ContractNo,SerialNo,Maker,ComType,ComModel,Rental)VALUES ('" + txtContractNo.Text + "','" + txtSerialNo.Text + "','" + txtMaker.Text + "','" + txtComType.Text + "','" + txtComModel.Text + "','" + txtRental.Text + "')";

                        SqlCommand com = new SqlCommand(sql, conn);
                        com.ExecuteNonQuery();
                        MessageBox.Show("Add completed");

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
            if (txtSerialNo.Text.Trim() == "")
            {
                MessageBox.Show("Please Select Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); return;
            }

            if (MessageBox.Show("Do you want to Update the data ? " + txtSerialNo.Text, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                String sql = "Update SerialNoMaster SET ContractNo = '" + txtContractNo.Text + "', SerialNo = '" + txtSerialNo.Text + "', Maker = '" + txtMaker.Text + "' , ComType = '" + txtComType.Text + "', ComModel = '" + txtComModel.Text + "' , Rental = '" + txtRental.Text + "'  where SerialNo = '" + txtSerialNo.Text + "'";
                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();

                MessageBox.Show("Update completed");
                Showdata();
                ClearData();
            }
        }

        private void bttDelete_Click(object sender, EventArgs e)
        {
            if (txtSerialNo.Text.Trim() == "")
            { MessageBox.Show("Please Select Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); return; }

            if (MessageBox.Show("Do you want to delete the data ? " + txtSerialNo.Text, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                String sql = "Delete from SerialNoMaster where SerialNo ='" + txtSerialNo.Text + "' ";
                SqlCommand com = new SqlCommand(sql, conn);
                com.ExecuteNonQuery();

                MessageBox.Show("Delete completed");
                Showdata();
                ClearData();
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
                txtContractNo.Text = dataGridView1.Rows[e.RowIndex].Cells["ContractNo"].Value.ToString();
                txtSerialNo.Text = dataGridView1.Rows[e.RowIndex].Cells["SerialNo"].Value.ToString();
                txtMaker.Text = dataGridView1.Rows[e.RowIndex].Cells["Maker"].Value.ToString();
                txtComType.Text = dataGridView1.Rows[e.RowIndex].Cells["ComType"].Value.ToString();
                txtComModel.Text = dataGridView1.Rows[e.RowIndex].Cells["ComModel"].Value.ToString();
                txtRental.Text = dataGridView1.Rows[e.RowIndex].Cells["Rental"].Value.ToString();
            }
            catch { }

            bttAdd.Enabled = false;
            bttDelete.Enabled = true;
            bttUpdate.Enabled = true;
        }

        private void txtSearchSerialNo_TextChanged(object sender, EventArgs e)
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
            Detail WinD3 = new Detail();
            WinD3.Show();
        }
    }
}
