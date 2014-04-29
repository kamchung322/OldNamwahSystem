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
    public partial class frmShipOrderExist : DevExpress.XtraEditors.XtraForm
    {
    
        public frmShipOrderExist()
        {
            InitializeComponent();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadShipment();
        }

        private void LoadShipment()
        {
            BindingList<Shipment> Shipments = Shipment.LoadBindingListByMySQL("WHERE (OrderStatus = 'Ready' OR OrderStatus = 'TSI' OR OrderStatus = 'Waiting' OR OrderStatus = 'Active') ", "Order By OrderNo"); 

            gridShipment.DataSource = Shipments;

        }
    }
}