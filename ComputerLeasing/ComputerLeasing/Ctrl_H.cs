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
    public partial class Ctrl_H : UserControl
    {
        int valErr = 0;

        SqlConnection conn = new SqlConnection("Server=...;Database=...;User Id=...;Password=...;MultipleActiveResultSets=True");

        public Ctrl_H()
        {
            InitializeComponent();
        }

        private void Ctrl_H_Load(object sender, EventArgs e)
        {
            conn.Open();
            Showdata();
            //  ClearData();
            this.Dock = DockStyle.Fill;
            // this.ActiveControl = txtSearchSerialNo;
        }

        private void Showdata()
        {
            int varindex = 0;

            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 7;


            dataGridView1.Columns[varindex].Name = "ContactNo";
            dataGridView1.Columns[varindex].Width = 100;

            varindex = varindex + 1;
            dataGridView1.Columns[varindex].Name = "SerialNo";
            dataGridView1.Columns[varindex].Width = 100;

            varindex = varindex + 1;
            dataGridView1.Columns[varindex].Name = "UserName";
            dataGridView1.Columns[varindex].Width = 200;

            varindex = varindex + 1;
            dataGridView1.Columns[varindex].Name = "Type";
            dataGridView1.Columns[varindex].Width = 100;

            varindex = varindex + 1;
            dataGridView1.Columns[varindex].Name = "Detail";
            dataGridView1.Columns[varindex].Width = 200;

            varindex = varindex + 1;
            dataGridView1.Columns[varindex].Name = "RentalTotal";
            dataGridView1.Columns[varindex].Width = 80;
            //dataGridView1.Columns[varindex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            varindex = varindex + 1;
            dataGridView1.Columns[varindex].Name = "Rental";
            dataGridView1.Columns[varindex].Width = 50;

            //  int varCount = 0;
            string sql = "";
            string RentelSerialNo = "";
            string SerialNo = "";
            string Status = "";

            //SerialNoMaster OwnerHistory
            // sql = "Select * from ContractMaster AS d1 inner join SerialNoMaster AS d2 on (d1.ContractNo = d2.ContractNo) inner join OwnerHistory AS d3 on (d2.SerialNo = d3.SerialNo)";
            //sql = "Select * from SerialNoMaster inner join OwnerHistory on SerialNoMaster.SerialNo = OwnerHistory.SerialNo order by ContractNo ASC";
            sql = "Select * from SerialNoMaster inner join OwnerHistory on SerialNoMaster.SerialNo = OwnerHistory.SerialNo where StatusComputer = '9' order by ContractNo ASC";

            SqlCommand com = new SqlCommand(sql, conn);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                string sql1 = "Select * from ContractMaster inner join SerialNoMaster on ContractMaster.ContractNo = SerialNoMaster.ContractNo where ContractMaster.ContractNo = '" + dr["ContractNo"].ToString() + "' ";
                SqlCommand com1 = new SqlCommand(sql1, conn);
                SqlDataReader dr1 = com1.ExecuteReader();
                while (dr1.Read())
                {
                    RentelSerialNo = dr1["Rental"].ToString();
                    //SerialNo = dr1["SerialNo"].ToString();
                }
                dr1.Close();
                dataGridView1.Rows.Add(dr["ContractNo"].ToString(), dr["SerialNo"].ToString(), dr["User"].ToString(), dr["ComType"].ToString(), dr["ComModel"].ToString(), RentelSerialNo, dr["Rental"].ToString());
            }


            dr.Close();
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

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                MyGlobal.GlobalSerialNo = dataGridView1.Rows[e.RowIndex].Cells["SerialNo"].Value.ToString();
                /*txtUser.Text = dataGridView1.Rows[e.RowIndex].Cells["User"].Value.ToString();
                txtStrDate.Text = dataGridView1.Rows[e.RowIndex].Cells["StrDate"].Value.ToString();
                txtEndDate.Text = dataGridView1.Rows[e.RowIndex].Cells["EndDate"].Value.ToString();
                txtSEQ.Text = dataGridView1.Rows[e.RowIndex].Cells["SEQ"].Value.ToString();*/
                //    MyGlobal.GlobalPrintReport = dataGridView1.Rows[e.RowIndex].Cells["SerialNo"].Value.ToString();          
            }
            catch { }

        }

        private void bttDetails_Click(object sender, EventArgs e)
        {
            Detail WinD3 = new Detail();
            WinD3.Show();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Details" + ": " + MyGlobal.GlobalSerialNo));
                // m.MenuItems.Add(new MenuItem("Copy"));
                // m.MenuItems.Add(new MenuItem("Paste"));
               
                int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                // if (currentMouseOverRow >= 0)
                // {
                //    m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                //  }

                m.Show(dataGridView1, new Point(e.X, e.Y));

                Detail WinD3 = new Detail();
                WinD3.Show();
            }
            else
            {

            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                MyGlobal.GlobalSerialNo = dataGridView1.Rows[e.RowIndex].Cells["SerialNo"].Value.ToString();
            }
            catch { }

        }
    }
}
