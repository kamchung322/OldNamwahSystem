using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NamwahSystem.Model.BO;
using NamwahSystem.Model.Func;
using MySql.Data.MySqlClient;

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

            using (MySqlConnection Cnn = ServerHelper.ConnectToMySQL())
            {
                List<Shipment> Shipments = Shipment.LoadListByMySQL(Cnn, StrFilter, "");
                gridShipment.DataSource = Shipments;
            }
            
            txtTime.Text = string.Format("最后更新时间 : {0}", DateTime.Now.ToString("yy-MM-dd hh:mm:ss"));
        }

    }
}