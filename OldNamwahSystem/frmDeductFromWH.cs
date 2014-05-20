using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using OldNamwahSystem.BO;
using OldNamwahSystem.Func;
using MySql.Data.MySqlClient;

namespace OldNamwahSystem
{
    public partial class frmDeductFromWH : XtraForm
    {
        public frmDeductFromWH()
        {
            InitializeComponent();
        }

        private void btnLoadShipment_Click(object sender, EventArgs e)
        {
            LoadShipment();
        }

        private void LoadShipment()
        {
            gridShipment.DataSource = Shipment.LoadListByMySQL("WHERE (OrderStatus = 'Waiting' AND SOType = 'SZInv') ", "");
            txtTime.Text = string.Format("最后更新时间 : {0}", DateTime.Now.ToString("yy-MM-dd hh:mm:ss"));
        }

        private void frmDeductFromWH_Load(object sender, EventArgs e)
        {
            LoadShipment();
        }

        private void btnChangeQty_Click(object sender, EventArgs e)
        {
            int[] Rows = gridView1.GetSelectedRows();
            string TmpQty = "";
            double NewQty = 0;

            if (Rows.GetUpperBound(0) == -1)
            {
                XtraMessageBox.Show("请先选取要列印的资料 !!", "注意!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            Shipment Shipment = (Shipment)gridView1.GetRow(Rows[0]);
            Shipment = Shipment.LoadMySQL(Shipment.OrderNo);

            if (Shipment.OrderStatus != "Waiting")
            {
                XtraMessageBox.Show(string.Format("单号{0}不能更改寄货数量.  \n原因 : 状态不是 Waiting.",
                   Shipment.OrderNo));
                return;
            }

            StringBuilder SBMsg = new StringBuilder();

            SBMsg.AppendLine(string.Format("寄货单号 : {0}", Shipment.OrderNo ));
            SBMsg.AppendLine(string.Format("本厂编码 : {0}", Shipment.ItemNo));
            SBMsg.AppendLine(string.Format("名称 : {0}", Shipment.ItemName));
            SBMsg.AppendLine(string.Format("原数量 : {0}", Shipment.MoveQty));
            SBMsg.AppendLine("请输入更改数量 !! ");

            TmpQty = Interaction.InputBox(SBMsg.ToString(), "更改数量", "");

            if (TmpQty == "")
                return;

            if (double.TryParse(TmpQty, out NewQty))
            {
                try
                {
                    if (NewQty > Shipment.MoveQty)
                    {
                        XtraMessageBox.Show(string.Format("单号{0}不能更改寄货数量.  \n原因 : 更改数量{0}不能大于原数量{1}.",
                                           Shipment.OrderNo, NewQty, Shipment.MoveQty));
                        return;
                    }

                    if (NewQty < Shipment.ArrivedQty)
                    {
                        XtraMessageBox.Show(string.Format("单号{0}不能更改寄货数量.  \n原因 : 更改数量{0}不能少于已装箱数{1}.",
                                           Shipment.OrderNo, NewQty, Shipment.ArrivedQty));
                        return;
                    }

                    Shipment.ChangeMoveQty(NewQty);
                    Shipment.UpdateAllRecord();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(string.Format("单号{0}不能更改寄货数量.  \n原因 : {1}.", Shipment.OrderNo, ex.Message));
                }
            }

            Shipment = null;

            LoadShipment();
        }

        private void btnDeductShipment_Click(object sender, EventArgs e)
        {
            int[] Rows = gridView1.GetSelectedRows();

            if (Rows.GetUpperBound(0) == -1)
            {
                XtraMessageBox.Show("请先选取要出仓的资料 !!", "注意!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<Shipment> Shipments = new List<Shipment>();
            StringBuilder SBMsg = new StringBuilder();
            SBMsg.AppendLine(string.Format("你选择把下列共 {0} 个出货项目, 请确认是否扣数出仓 ??", Rows.GetUpperBound(0) + 1));

            for (int i = 0; i <= Rows.GetUpperBound(0); i++)
            {
                Shipment Shipment = (Shipment)gridView1.GetRow(Rows[i]);
                SBMsg.AppendLine(string.Format("寄货单号 : {0}.  本厂编码 : {1}.  数量 : {2}.", Shipment.OrderNo, Shipment.ItemNo, Shipment.MoveQty ));
                Shipments.Add(Shipment);
            }

            DialogResult dialogResult = XtraMessageBox.Show(SBMsg.ToString(), "确认出仓", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
                return;

            SBMsg.Clear();

            using (MySqlConnection CnnMySQL = ServerHelper.ConnectToMySQL())
            {
                MySqlTransaction TransMySQL = CnnMySQL.BeginTransaction();
            
                foreach (Shipment S in Shipments)
                {
                    Shipment Ship = Shipment.LoadMySQL(S.OrderNo);
                    Ship.CnnMySQL = CnnMySQL;

                    if (Ship.DeductWH() == false)
                        SBMsg.AppendLine(string.Format("寄货单号 : {0}.  本厂编码 : {1}.  数量 : {2}.", Ship.OrderNo, Ship.ItemNo, Ship.MoveQty));
                }
                TransMySQL.Commit();
            }

            if (SBMsg.ToString() != "")
            {
                XtraMessageBox.Show(string.Format("以下寄货单不能出仓 !! \n {0}", SBMsg.ToString()), "錯误");
            }
            else
            {
                XtraMessageBox.Show("完成", "出仓成功");
            }

            LoadShipment();
        }
    }
}