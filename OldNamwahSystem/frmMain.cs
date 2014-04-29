using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OldNamwahSystem.Func;
using log4net;

namespace OldNamwahSystem
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        static ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private void navBarFQCShipment_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmFQC FromFQC = new frmFQC();
            FromFQC.MdiParent = this;
            FromFQC.Show();

        }

        private void navBarShipmentExit_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmShipOrderExist FromShipOrderExist = new frmShipOrderExist();
            FromShipOrderExist.MdiParent = this;
            FromShipOrderExist.Show();
        }

        private void navBarSOLine_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmSalesOrder FromSalesOrder = new frmSalesOrder();
            FromSalesOrder.MdiParent = this;
            FromSalesOrder.Show();
        }

        private void navBarTest_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmTest FromTest = new frmTest();
            FromTest.MdiParent = this;
            FromTest.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            navBarTest.Visible = Glob.IsDebugMode;
            Logger.Info(string.Format("Debug Mode is {0}", Glob.IsDebugMode));
        }
    }
}
