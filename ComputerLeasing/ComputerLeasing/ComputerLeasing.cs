using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace ComputerLeasing
{
    public partial class ComputerLeasing : Form
    {
        public ComputerLeasing()
        {
            InitializeComponent();
        }

        private void ComputerLeasing_Load(object sender, EventArgs e)
        {
          
            ShowData();

            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }
            panel1.Controls.Add(new Ctrl_H());
        }

        private void ShowData()
        {
            
            treeView1.ExpandAll();
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Name == "NodeOwnerHistory")
            {
                foreach (Control ctrl in panel1.Controls)
                {
                    ctrl.Dispose();
                }
                panel1.Controls.Add(new Ctrl_OwnerHistory());
                MyGlobal.GlobalSerialNo = "";
            }
            else if (treeView1.SelectedNode.Name == "NodeSerialMaster")
            {
                foreach (Control ctrl in panel1.Controls)
                {
                    ctrl.Dispose();
                }
                panel1.Controls.Add(new Ctrl_SerialNoMaster());              
            }
            else if (treeView1.SelectedNode.Name == "NodeContractMaster")
            {
                foreach (Control ctrl in panel1.Controls)
                {
                    ctrl.Dispose();
                }
                panel1.Controls.Add(new Ctrl_ContractMaster());
            }
            else if (treeView1.SelectedNode.Name == "NodeComputerLeasing")
            {
                foreach (Control ctrl in panel1.Controls)
                {
                    ctrl.Dispose();
                }
                panel1.Controls.Add(new Ctrl_H());
            }
        }
    }
}