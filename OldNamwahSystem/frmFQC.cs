﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using NamwahSystem.Model.Func;
using NamwahSystem.Model.BO;
using MySql.Data.MySqlClient;

namespace OldNamwahSystem
{
    public partial class frmFQC : XtraForm
    {
        ProdOrder JS;

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

            try
            {
                JS = ProdOrder.LoadExchange(txtJSNo.Text);

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
            catch
            {
                XtraMessageBox.Show(string.Format("找不到此单号 {0}, 请查清楚再试!!", txtJSNo.Text));
                txtJSNo.Focus();
            }
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
                btnInputResult.Enabled = true;
            }
        }

        private void btnInputResult_Click(object sender, EventArgs e)
        {
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
            
            try
            {
                UpdateBoxQtyToItem(txtPartNo.Text, int.Parse(txtBoxQty.Text));
                UpdateFQCJS();
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show(Ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            BindingList<SoCompress> SOCompressList = new BindingList<SoCompress>();
            double RemainQty = double.Parse(txtShipQty.Text);

            if (chkAllInputWH.Checked == false)
            {
                int Priority = chkToSample.Checked ? 11 : 0;
                ShipToSalesOrder(ref SOCompressList, txtPartNo.Text, Priority, ref RemainQty);
            }

            if (RemainQty > 0)
                ShipToWH(ref SOCompressList, ref RemainQty);

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

        private void txtIRNo_Leave(object sender, EventArgs e)
        {
            txtIRNo.Text = txtIRNo.Text.ToUpper().Trim();
        }

        private void btnPrintTSICheckingLabel_Click(object sender, EventArgs e)
        {
            Label.BoxLabel BoxLabel = new Label.BoxLabel();

            if (BoxLabel.IsReady == false)
            {
                XtraMessageBox.Show("打印机出现问题, 不能打印, 请重启打印机 !!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BoxLabel.ItemNo = txtPartNo.Text;
            BoxLabel.ItemName = txtPartName.Text;
            BoxLabel.ItemType = txtPartType.Text;
            BoxLabel.Revision = txtRevision.Text;
            BoxLabel.InspectStatus = txtInspectStatus.Text;
            BoxLabel.Inspector = txtInspector.Text;
            BoxLabel.InspectSpec = txtInspectSpec.Text;
            BoxLabel.JSNo = txtJSNo.Text;
            BoxLabel.IRNo = txtIRNo.Text;
            BoxLabel.ShipQty = double.Parse(txtShipQty.Text);
            BoxLabel.PrintTSICheckingLabel();
            BoxLabel = null;
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

        private void UpdateFQCJS()
        {
            if (Glob.IsDebugMode)
                return;

            if (JS == null)
                throw new Exception("系统问题, 请退出重试 !!");

            JS.ActiveQty = int.Parse(txtShipQty.Text);
            JS.FQCInspectionDate = DateTime.Now;
            JS.FQCInspector = txtInspector.Text;
            JS.IrNo = txtIRNo.Text;
            JS.UpdateToExchange();
        }

        private void ShipToWH(ref BindingList<SoCompress> SOCompressList, ref double WHQty)
        {
            ProdOrderFinish ProdOrderFinish = new ProdOrderFinish();
            ProdOrderFinish.ItemNo = txtPartNo.Text;
            ProdOrderFinish.ItemName = txtPartName.Text;
            ProdOrderFinish.ItemType = txtPartType.Text;
            ProdOrderFinish.OKQty = WHQty;
            ProdOrderFinish.RefNo = txtJSNo.Text;
            ProdOrderFinish.IOType = WHIOType.Input;
            ProdOrderFinish.Supplier = "FQC";
            ProdOrderFinish.Remark = txtRevision.Text;
            ProdOrderFinish.CreatedBy = Glob.UserName;
            ProdOrderFinish.Save();

            SoCompress SoComp = new SoCompress();
            SoComp.Item = Item.Load(txtPartNo.Text);
            SoComp.ShipMethod = "Air";
            SoComp.SalesOrderNo = "存仓";
            SoComp.BoxQty = 0;
            SoComp.ShipQty = WHQty;
            SoComp.Calc();
            SOCompressList.Add(SoComp);
            
            WHQty = 0;
        }

        private void ShipToSalesOrder(ref BindingList<SoCompress> SOCompressList, 
            string ItemNo, int Priority, ref double RemainQty)
        {
            List<SalesOrderLine> SOLines = DBHelper.GetOpenSalesOrderByItemNo(ItemNo, Priority);

            if (SOLines.Count > 0)
            {
                Dictionary<string, double> ShipmentToBeCreated = SalesOrderLine.CalcActualShipment(SOLines, ref RemainQty);

                List<Shipment> NewShipments = SalesOrderLine.CreateShipmentOrders(SOLines, ShipmentToBeCreated, txtJSNo.Text);
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
        }

        private void EnableFindButton(bool IsEnable)
        {
            btnLoad.Enabled = IsEnable;
            btnCancel.Enabled = !IsEnable;
            btnInputResult.Enabled = !IsEnable;
            //btnPrintBoxLabel.Enabled = !IsEnable;
            btnPrintIRLabel.Enabled = !IsEnable;
            btnPrintTSICheckingLabel.Enabled = !IsEnable;
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
            if (Glob.IsDebugMode)
                return true;

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

    }
}