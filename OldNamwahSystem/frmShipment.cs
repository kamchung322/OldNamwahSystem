using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OldNamwahSystem.BO;

namespace OldNamwahSystem
{
    public partial class frmShipment : XtraForm
    {
        public frmShipment()
        {
            InitializeComponent();
        }

        private void btnLoadWH_Click(object sender, EventArgs e)
        {
            string StrFilter = "";

            if (cboStatus.Text == "未寄货")
                StrFilter = "WHERE (OrderStatus != 'Complete' and OrderStatus != 'Cancel')";

            List<Shipment> Shipments = Shipment.LoadListByMySQL(StrFilter, "");
            gridShipment.DataSource = Shipments;
            txtTime.Text = string.Format("最后更新时间 : {0}", DateTime.Now.ToString("yy-MM-dd hh:mm:ss"));
        }

    }
}