using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ComputerLeasing
{
    public partial class Ctrl_PrintReport : UserControl
    {
        public Ctrl_PrintReport()
        {
            InitializeComponent();
        }

        private void Ctrl_PrintReport_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            txtShowSerailNo.Text = MyGlobal.GlobalPrintReport;
        }

        private void bttShow_Click(object sender, EventArgs e)
        {
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;

            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"\\192.168.4.7\mis\Program\ProgramEXE\ReportComputerLeasing.rpt");
            crConnectionInfo.ServerName = "...";
            crConnectionInfo.DatabaseName = "...";
            crConnectionInfo.UserID = "...";
            crConnectionInfo.Password = "...";

            CrTables = cryRpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = txtShowSerailNo.Text;
            cryRpt.DataDefinition.ParameterFields["PSerialNo"].CurrentValues.Clear();
            cryRpt.DataDefinition.ParameterFields["PSerialNo"].CurrentValues.Add(crParameterDiscreteValue);
            cryRpt.DataDefinition.ParameterFields["PSerialNo"].ApplyCurrentValues(cryRpt.DataDefinition.ParameterFields["PSerialNo"].CurrentValues);

            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
