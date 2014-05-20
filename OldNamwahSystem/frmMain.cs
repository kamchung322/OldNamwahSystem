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
            Logger.Info(string.Format("Debug Mode is {0}", Glob.IsDebugMode));
            CheckingSecurity();
        }

        private void navBarFromWHLabel_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmFromWHLabel frmFromWHLabel = new frmFromWHLabel();
            frmFromWHLabel.MdiParent = this;
            frmFromWHLabel.Show();
        }

        private void navBarDeductFromWH_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmDeductFromWH frmDeductFromWH = new frmDeductFromWH();
            frmDeductFromWH.MdiParent = this;
            frmDeductFromWH.Show();
        }

        private void navBarShipment_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmShipment frmShipment = new frmShipment();
            frmShipment.MdiParent = this;
            frmShipment.Show();
        }

        private void CheckingSecurity()
        {
            navBarTest.Visible = false; 

            ServerHelper.UserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToUpper();

            if (ServerHelper.UserName == @"NWNET\IT002" || ServerHelper.UserName == @"NWNET\KENNETH")
            {
                navBarTest.Visible = true;
                return;
            }
            else if (ServerHelper.UserName != @"NWNET\LINDA")
            {
                navBarFQCShipment.Visible = false;
            }
            else if (ServerHelper.UserName != @"NWNET\XK02" && 
                    ServerHelper.UserName != @"NWNET\K_CLERK" && 
                    ServerHelper.UserName != @"NWNET\YHHE" && 
                    ServerHelper.UserName != @"NWNET\FJWANG")
            {
                navBarShipmentExit.Visible = false;
                navBarDeductFromWH.Visible = false;
            }
            // xk02, k_clerk, yhhe
        }

        private void navBarManualLabel_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmManualLabel frmLabel = new frmManualLabel();
            frmLabel.MdiParent = this;
            frmLabel.Show();
        }
    }
}
