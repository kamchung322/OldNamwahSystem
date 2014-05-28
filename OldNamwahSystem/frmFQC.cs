using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OldNamwahSystem.BO;
using OldNamwahSystem.Func;
using log4net;

namespace OldNamwahSystem
{
    public partial class frmFQC : DevExpress.XtraEditors.XtraForm
    {
        JobSchedule JS;
        BindingList<SoCompress> SOCompressList;
        static ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public frmFQC()
        {
            InitializeComponent();
        }

        private void txtJSNo_Enter(object sender, EventArgs e)
        {
            txtJSNo.SelectAll();

        }

        private void txtJSNo_Leave(object sender, EventArgs e)
        {
            txtJSNo.Text = txtJSNo.Text.ToUpper().Trim();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (txtJSNo.Text == "")
            {
                XtraMessageBox.Show("请先输入派工单号 !!");
                txtJSNo.Focus();
                return;
            }

            JS = JobSchedule.LoadExchange(txtJSNo.Text);

            if (JS == null)
            {
                XtraMessageBox.Show(string.Format("找不到此单号 {0}, 请查清楚再试!!", txtJSNo.Text));
                txtJSNo.Focus();
                return;
            }

            if (JS.ActiveLocation != "Q")
            {
                XtraMessageBox.Show(string.Format("这张单现时地点为{0}, 不在FQC, 所以不能过帐 !!",
                    JS.ActiveLocation));

                txtJSNo.SelectAll();
                txtJSNo.Focus();
                return;
            }

            txtPartNo.Text = JS.ItemNo;
            txtPartName.Text = JS.ItemName;
            txtPartType.Text = JS.ItemType;
            txtShipQty.Text = JS.ActiveQty.ToString();

            if (JS.Item != null)
            {
                txtRevision.Text = JS.Item.CustomerRevision;
                txtBoxQty.Text = JS.Item.BoxQty.ToString();
            }

            txtIRNo.Text = JS.IrNo;
            txtInspector.Text = JS.FQCInspector;
            txtJSStatus.Text = JS.OrderStatus;

            EnableFindButton(false);
            txtShipQty.SelectAll();
            txtShipQty.Focus();

        }

        private void EnableFindButton(bool IsEnable)
        {
            btnLoad.Enabled = IsEnable;

            btnCancel.Enabled = !IsEnable;
            btnInputResult.Enabled = !IsEnable;
            //btnPrintBoxLabel.Enabled = !IsEnable;
            btnPrintIRLabel.Enabled = !IsEnable;

            txtJSNo.Properties.ReadOnly = !IsEnable;

            txtRevision.Properties.ReadOnly = IsEnable;
            txtShipQty.Properties.ReadOnly = IsEnable;
            txtIRNo.Properties.ReadOnly = IsEnable;
            txtBoxQty.Properties.ReadOnly = IsEnable;
            txtInspector.Properties.ReadOnly = IsEnable;
            txtInspectSpec.Properties.ReadOnly = IsEnable;
            txtInspectStatus.Properties.ReadOnly = IsEnable;
        }

        private void ClearAll()
        {
            txtPartNo.Text = "";
            txtPartName.Text = "";
            txtPartType.Text = "";
            txtJSStatus.Text = "";

            txtRevision.Text = "";
            txtShipQty.Text = "0";
            txtIRNo.Text = "";
            txtBoxQty.Text = "0";
            txtInspector.Text = "";
            gridShipList.DataSource = null;

        }

        private bool ValidateInputResult()
        {
            if (int.Parse(txtShipQty.Text) < 0)
            {
                XtraMessageBox.Show(string.Format("出货数量 ({0}) 不能少于0, 请更正.", txtShipQty.Text), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtShipQty.SelectAll();
                txtShipQty.Focus();
                return false;
            }

            if (int.Parse(txtShipQty.Text) == 0)
            {
                if (XtraMessageBox.Show(string.Format("出货数量 ({0}) 等于0, 请问是否要输入结果?", txtShipQty.Text),
                    "注意!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                {
                    txtShipQty.SelectAll();
                    txtShipQty.Focus();
                    return false;
                }
            }

            if (int.Parse(txtBoxQty.Text) < 0)
            {
                XtraMessageBox.Show(string.Format("每箱数量 ({0}) 不能少于0, 请更正.", txtBoxQty.Text), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoxQty.SelectAll();
                txtBoxQty.Focus();
                return false;
            }

            txtInspector.Text = txtInspector.Text.Trim();
            if (txtInspector.Text == "")
            {
                XtraMessageBox.Show("请输入检查员 !!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInspector.SelectAll();
                txtInspector.Focus();
                return false;

            }

            txtIRNo.Text = txtIRNo.Text.Trim();
            if (txtIRNo.Text == "")
            {
                XtraMessageBox.Show("请输入IR号码 !!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIRNo.SelectAll();
                txtIRNo.Focus();
                return false;

            }

            txtRevision.Text = txtRevision.Text.Trim();
            if (txtRevision.Text == "")
            {
                XtraMessageBox.Show("请输入版本 !!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRevision.SelectAll();
                txtRevision.Focus();
                return false;

            }

            return true;
        }

        private void frmFQC_Load(object sender, EventArgs e)
        {
            EnableFindButton(true);
            ClearAll();
            txtJSNo.Focus();

            if (Glob.IsDebugMode)
            {
                txtPartNo.Properties.ReadOnly = false;
                txtShipQty.Properties.ReadOnly = false;
                //btnTest.Visible = true;
            }

        }

        private void btnInputResult_Click(object sender, EventArgs e)
        {
            SOCompressList = new BindingList<SoCompress>();

            if (ValidateInputResult() == false)
            {
                return;
            }

            if (int.Parse(txtShipQty.Text) == 0)
            {
                btnCancel.Enabled = false;
                btnInputResult.Enabled = false;
                btnOK.Enabled = true;
                return;
            }

            UpdateBoxQtyToItem(txtPartNo.Text, int.Parse(txtBoxQty.Text));

            if (UpdateFQCJS() == false)
            {
                return;
            }

            if (chkAllInputWH.Checked == true)
            {
                ShipToWH(int.Parse(txtShipQty.Text));
            }
            else
            {
                if (ShipToSalesOrder() == false)
                    return;
            }

            gridShipList.DataSource = SOCompressList;

            btnCancel.Enabled = false;
            btnInputResult.Enabled = false;
            btnOK.Enabled = true;
            btnPrintBoxLabel.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EnableFindButton(true);
            ClearAll();
            btnPrintBoxLabel.Enabled = false;
            txtJSNo.SelectAll();
            txtJSNo.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EnableFindButton(true);
            ClearAll();
            btnPrintBoxLabel.Enabled = false;
            btnOK.Enabled = false;
            txtJSNo.SelectAll();
            txtJSNo.Focus();
        }

        private void btnPrintBoxLabel_Click(object sender, EventArgs e)
        {
            Label.BoxLabel BoxLabel = new Label.BoxLabel();

            if (BoxLabel.IsReady == false)
            {
                XtraMessageBox.Show("打印机出现问题, 不能打印, 请重启打印机 !!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < gridShipList.MainView.RowCount; i++)
            {
                SoCompress SoCompress = (SoCompress)gridShipList.MainView.GetRow(i);
                SoCompress.Revision = txtRevision.Text;
                SoCompress.InspectStatus = txtInspectStatus.Text;
                SoCompress.InspectSpec = txtInspectSpec.Text;
                SoCompress.JSNo = txtJSNo.Text;
                BoxLabel.IRNo = txtIRNo.Text;
                BoxLabel.PrintLabel(SoCompress);
            }

            BoxLabel = null;
            GC.Collect();
        }

        private void btnPrintIRLabel_Click(object sender, EventArgs e)
        {
            Label.IRLabel IrLabel = new Label.IRLabel();

            if (IrLabel.IsReady == false)
            {
                XtraMessageBox.Show("打印机出现问题, 不能打印, 请重启打印机 !!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IrLabel.ItemNo = string.Format("{0}-{1}", txtPartNo.Text, txtRevision.Text);

            Item item = Item.Load(txtPartNo.Text);

            if (item != null)
                IrLabel.ItemNo = string.Format("{0}-{1}", item.CustomerItemNo, txtRevision.Text);

            IrLabel.IRNo = txtIRNo.Text;
            IrLabel.Inspector = txtInspector.Text;
            IrLabel.QualitySpec = txtInspectSpec.Text;
            IrLabel.NoOfCopy = int.Parse(txtIRLabelQty.Text);
            IrLabel.PrintLabel();

            IrLabel = null;
            GC.Collect();
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

        private bool UpdateFQCJS()
        {
            if (JS == null)
            {
                XtraMessageBox.Show("系统问题, 请退出重试 !!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Glob.IsDebugMode)
                return true;

            JS.ActiveQty = int.Parse(txtShipQty.Text);
            JS.FQCInspectionDate = DateTime.Now;
            JS.FQCInspector = txtInspector.Text;
            JS.IrNo = txtIRNo.Text;
            JS.UpdateFQC();

            return true;
        }

        private void ShipToWH(double WHQty)
        {
            WHHistory WHHistory = new WHHistory();
            WHHistory.ItemNo = txtPartNo.Text;
            WHHistory.ItemName = txtPartName.Text;
            WHHistory.ItemType = txtPartType.Text;
            WHHistory.Qty = WHQty;
            WHHistory.RefNo = txtJSNo.Text;
            WHHistory.RefType = "SS";
            WHHistory.IO = "Input";
            WHHistory.Supplier = "FQC";
            WHHistory.Remark = txtRevision.Text;
            WHHistory.CreatedBy = Glob.UserName;
            WHHistory.InsertToExchange();

            SoCompress SoComp = new SoCompress();
            SoComp.Item = Item.Load(txtPartNo.Text);
            SoComp.ShipMethod = "Air";
            SoComp.SalesOrderNo = "存仓";
            SoComp.BoxQty = 0;
            SoComp.ShipQty = WHQty;
            SoComp.Calc();
            SOCompressList.Add(SoComp);
        }

        private bool ShipToSalesOrder()
        {
            Dictionary<string, SalesOrderLine> SOLines = new Dictionary<string, SalesOrderLine>();
            List<Shipment> Shipments = new List<Shipment>();
            List<Shipment> NewShipments = new List<Shipment>();

            string ItemNo = txtPartNo.Text;
            double RemainQty = double.Parse(txtShipQty.Text);

            SOLines = SalesOrderLine.LoadDictMySQL(string.Format("WHERE NOT( OrderStatus = 'Complete') AND Priority >= 0 AND ItemNo = '{0}' ", ItemNo)
                            , " ORDER BY  PromisedDate ASC , Priority DESC ");

            if (SOLines.Count > 0)
            {
                Shipments = Shipment.LoadListByMySQL(string.Format("WHERE ( OrderStatus = 'Ready' OR OrderStatus = 'Waiting' OR OrderStatus = 'TSI' ) AND ItemNo = '{0}' ", ItemNo), "");
                SalesOrderLine.CalcActualBalance(Shipments, SOLines);
                NewShipments = SalesOrderLine.CreateShipmentOrders(ref RemainQty, SOLines, txtJSNo.Text);
                SOCompressList = SoCompress.CompressSO(NewShipments);

                foreach (SoCompress SoComp in SOCompressList)
                {
                    SoComp.IRNo = txtIRNo.Text;
                    SoComp.Inspector = txtInspector.Text;
                    SoComp.InspectSpec = txtInspectSpec.Text;
                    SoComp.InspectStatus = txtInspectStatus.Text;
                    SoComp.JSNo = txtJSNo.Text;
                }

            }

            if (RemainQty > 0)
                ShipToWH(RemainQty);

            return true;

        }

        private void txtIRNo_Leave(object sender, EventArgs e)
        {
            txtIRNo.Text = txtIRNo.Text.ToUpper().Trim();
        }
    }
}