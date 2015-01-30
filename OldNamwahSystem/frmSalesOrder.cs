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
namespace OldNamwahSystem
{
    public partial class frmSalesOrder : DevExpress.XtraEditors.XtraForm
    {
        public frmSalesOrder()
        {
            InitializeComponent();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadSOLine();
        }

        private void LoadSOLine()
        {
            StringBuilder SBSQL = new StringBuilder();
            string StrSQL = "";

            txtSalesOrderNo.Text = txtSalesOrderNo.Text.Trim();
            txtCustomer.Text = txtCustomer.Text.Trim();
            txtItemNo.Text = txtItemNo.Text.Trim();
            txtItemName.Text = txtItemName.Text.Trim();
            txtItemType.Text = txtItemType.Text.Trim();
            
            if (txtSalesOrderNo.Text != "")
                SBSQL.Append(string.Format(" AND OrderNo LIKE '%{0}%' ", txtSalesOrderNo.Text));

            if (txtCustomer.Text != "")
                SBSQL.Append(string.Format(" AND Customer = '{0}' ", txtCustomer.Text));

            if (txtItemNo.Text != "")
                SBSQL.Append(string.Format(" AND ItemNo LIKE '%{0}%' ", txtItemNo.Text));

            if (txtItemName.Text != "")
                SBSQL.Append(string.Format(" AND ItemName LIKE '%{0}%' ", txtItemName.Text));

            if (txtItemType.Text != "")
                SBSQL.Append(string.Format(" AND ItemType = '{0}' ", txtItemType.Text));

            if (cboStatus.Text == "未完成")
                SBSQL.Append(" AND OrderStatus != 'Complete'" );

            if (cboStatus.Text == "已完成")
                SBSQL.Append(" AND OrderStatus = 'Complete'" );


            if (SBSQL.ToString() != "")
            {
                StrSQL = string.Format(" WHERE ({0})", SBSQL.ToString().Substring(5, SBSQL.ToString().Length - 5));
            }

            List<SalesOrderLine> SOLines =  DBHelper.GetSalesOrder(StrSQL, "");

            if (bool.Parse(chkSplitOrder.EditValue.ToString()))
                SOLines = SplitOrder.SplitSOLineByPromisedDateAndPriority(SOLines);

            gridSOLine.DataSource = SOLines;
            txtTime.Text = string.Format("最后更新时间 : {0}", DateTime.Now.ToString("yy-MM-dd hh:mm:ss"));
        }

        private void frmSalesOrder_Load(object sender, EventArgs e)
        {
            cboStatus.Properties.Items.Add("全部");
            cboStatus.Properties.Items.Add("未完成");
            cboStatus.Properties.Items.Add("已完成");
            cboStatus.Text = "未完成";

            if (Glob.UserName != @"NWNET\IT002" &&
                Glob.UserName != @"NWNET\KENNETH")
            {
                ColPrice.Visible = false; 
            }
        }
    }
}