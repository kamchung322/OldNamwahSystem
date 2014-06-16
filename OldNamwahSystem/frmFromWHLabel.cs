using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using OldNamwahSystem.BO;

namespace OldNamwahSystem
{
    public partial class frmFromWHLabel : XtraForm
    {
        public frmFromWHLabel()
        {
            InitializeComponent();
        }

        private void btnLoadWH_Click(object sender, EventArgs e)
        {
            List<Shipment> Shipments = Shipment.LoadListByMySQL("WHERE (OrderStatus = 'Waiting' OR OrderStatus = 'Ready' OR OrderStatus = 'TSI') AND SOType = 'SZINV'" , "");

            BindingList<SoCompress> WHSoCompressList = SoCompress.CompressSO(Shipments);

            foreach (SoCompress SoComp in WHSoCompressList)
            {
                SoComp.IRNo = "From SS";
            }

            gridWHList.DataSource = WHSoCompressList;
            txtTime.Text = string.Format("最后更新时间 : {0}", DateTime.Now.ToString("yy-MM-dd hh:mm:ss"));
            btnPrintBoxLabelFromWH.Enabled = true;
            btnPrintSelectedBoxLabelFromWH.Enabled = true;
            btnChangeBoxQty.Enabled = true;
        }

        private void btnPrintBoxLabelFromWH_Click(object sender, EventArgs e)
        {
            Label.BoxLabel BoxLabel = new Label.BoxLabel();

            if (BoxLabel.IsReady == false)
            {
                XtraMessageBox.Show("打印机出现问题, 不能打印, 请重启打印机 !!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < gridWHList.MainView.RowCount; i++)
            {
                SoCompress SoCompress = (SoCompress)gridWHList.MainView.GetRow(i);
                BoxLabel.PrintLabel(SoCompress);
            }

            BoxLabel = null;

        }

        private void btnPrintSelectedBoxLabelFromWH_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0)
            {
                XtraMessageBox.Show("请先选取要列印的资料 !!", "注意!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Label.BoxLabel BoxLabel = new Label.BoxLabel();

            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                int row = (gridView1.GetSelectedRows()[i]);
                SoCompress SoCompress = (SoCompress)gridWHList.MainView.GetRow(row);
                BoxLabel.PrintLabel(SoCompress);
            }

            BoxLabel = null;

        }

        private void btnChangeBoxQty_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0)
            {
                XtraMessageBox.Show("请先选取要更改的产品", "注意!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                int row = (gridView1.GetSelectedRows()[i]);
                SoCompress SoCompress = (SoCompress)gridWHList.MainView.GetRow(row);
                string TmpBoxQty = "0";
                int BoxQty = 0;

                TmpBoxQty = Microsoft.VisualBasic.Interaction.InputBox(string.Format("产品编码 : {0}\n产品名称 : {1}.\n请输入新的每箱数量", SoCompress.Item.ItemNo, SoCompress.Item.ItemName));

                if (int.TryParse(TmpBoxQty, out BoxQty))
                {
                    UpdateBoxQtyToItem(SoCompress.Item.ItemNo, BoxQty);
                }
            }

            XtraMessageBox.Show("更新完成, 请重按 '重新读取资料' .");
        }

        private void UpdateBoxQtyToItem(string ItemNo, int BoxQty)
        {
            Item Item = Item.Load(ItemNo);

            if (Item != null)
            {
                Item.BoxQty = BoxQty;
                Item.SaveBoxQty();
            }
        }

        private void frmFromWHLabel_Load(object sender, EventArgs e)
        {
            btnLoadWH.PerformClick();
        }

    }
}