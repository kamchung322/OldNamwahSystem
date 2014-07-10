using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Excel = Microsoft.Office.Interop.Excel;
using OldNamwahSystem.BO;
using OldNamwahSystem.Func;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;

namespace OldNamwahSystem
{
    public partial class frmShipOrderExist : XtraForm
    {
        private int CartonNo = 0;
        System.Media.SoundPlayer PlayOK;
        System.Media.SoundPlayer PlayError;

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
            gridShipment.DataSource = Shipment.LoadListByMySQL("WHERE (OrderStatus = 'Ready' OR OrderStatus = 'TSI' OR OrderStatus = 'Waiting' OR OrderStatus = 'Active') ", "Order By OrderNo");
            txtTime.Text = string.Format("最后更新时间 : {0}", DateTime.Now.ToString("yy-MM-dd hh:mm:ss"));
        }

        private void ShowError(string ErrMsg)
        { 
            // Play Error.Wav;
            PlayError.Play();
            txtResult.Text = ErrMsg;
        }

        private void ShowResult(string ResultMsg)
        {
            PlayOK.Play();
            txtResult.Text = ResultMsg;
        }

        private void DeductShipment(string SalesOrderNo, string ItemNo, double DeductQty)
        {
            double TmpDeductQty = DeductQty;
            double SQty = 0;
            
            List<Shipment> Shipments = Shipment.LoadListByMySQL(
                        string.Format("WHERE (SalesOrderNo = '{0}' AND CustomerItemNo = '{1}' AND OrderStatus = 'Ready' )", SalesOrderNo, ItemNo),
                        "ORDER BY OrderDate ASC");

            using (MySqlConnection CnnMySQL = ServerHelper.ConnectToMySQL())
            {
                foreach (Shipment ShipOrder in Shipments)
                {
                    using (MySqlTransaction TranMySQL = CnnMySQL.BeginTransaction())
                    {
                        try
                        {
                            if (TmpDeductQty > ShipOrder.MoveQty - ShipOrder.ArrivedQty)
                                SQty = ShipOrder.MoveQty - ShipOrder.ArrivedQty;
                            else
                                SQty = TmpDeductQty;

                            TmpDeductQty = TmpDeductQty - SQty;

                            ShipOrder.CnnMySQL = CnnMySQL;
                            ShipOrder.AddShippedQty(SQty);
                            ShipOrder.AddCartonNo(CartonNo);
                            ShipOrder.UpdateAllRecord();
                            TranMySQL.Commit();

                            if (TmpDeductQty == 0)
                                break;
                        }
                        catch (Exception ex)
                        {
                            TranMySQL.Rollback();
                            ShowError(string.Format("不能更新, 原因 : {0}", ex.Message));
                        }
                    }
                }
            }

            if (TmpDeductQty > 0)
                ShowError(string.Format("还有余数{0}", TmpDeductQty));
            else
                ShowResult("OK");

        }

        private bool ValidateCartonNo()
        {
            if (CartonNo > 0)
                return true;

            string TmpCartonNo = Interaction.InputBox("请输入箱号 !!");

            if (int.TryParse(TmpCartonNo, out CartonNo))
            {
                txtCartonNo.Text = CartonNo.ToString();
                return true;
            }
            else
            {
                ShowError("输入箱号有错!! 请重新输入!!");
                return false;
            }

        }

        private void SplitBarcode(string BarCode, out string SalesOrderNo, out string ItemNo, out double DeductQty)
        {
            string TmpSalesOrderNo = "";
            string TmpItemNo = "";
            string TmpDeductQty = "";

            TmpSalesOrderNo = BarCode.Substring(3, 7);
            TmpItemNo = BarCode.Substring(12, 3) + BarCode.Substring(16, 6);
            TmpDeductQty = BarCode.Substring(27, 7);

            SalesOrderNo = TmpSalesOrderNo;
            ItemNo = TmpItemNo;
            DeductQty = double.Parse(TmpDeductQty);
        }

        private List<Shipment> GetSelectedShipment()
        {
            List<Shipment> ListTmp = new List<Shipment>();
            int[] Rows = gridView1.GetSelectedRows();

            for (int i = 0; i <= Rows.GetUpperBound(0); i++)
            {
                Shipment Shipment = gridView1.GetRow(Rows[i]) as Shipment ;
                ListTmp.Add(Shipment);
            }

            return ListTmp;
        }

        private void btnChangeToAir_Click(object sender, EventArgs e)
        {
            List<Shipment> Shipments = GetSelectedShipment();
            using (MySqlConnection CnnMySQL = ServerHelper.ConnectToMySQL())
            {
                MySqlTransaction TranMySQL = CnnMySQL.BeginTransaction();
                foreach (Shipment Ship in Shipments)
                {
                    if (Ship.ShipMethod != "Air")
                    {
                        Shipment ShipUpdate = Shipment.LoadMySQL(Ship.OrderNo);
                        ShipUpdate.CnnMySQL = CnnMySQL;
                        ShipUpdate.ShipMethod = "Air";
                        ShipUpdate.UpdateAllRecord();
                    }
                }
                TranMySQL.Commit();
            }

            LoadShipment();
        }

        private void btnChangeToSea_Click(object sender, EventArgs e)
        {
            List<Shipment> Shipments = GetSelectedShipment();
            using (MySqlConnection CnnMySQL = ServerHelper.ConnectToMySQL())
            {
                MySqlTransaction TranMySQL = CnnMySQL.BeginTransaction();
                foreach (Shipment Ship in Shipments)
                {
                    if (Ship.ShipMethod != "Sea")
                    {
                        Shipment ShipUpdate = Shipment.LoadMySQL(Ship.OrderNo);
                        ShipUpdate.CnnMySQL = CnnMySQL;
                        ShipUpdate.ShipMethod = "Sea";
                        ShipUpdate.UpdateAllRecord();
                    }
                }
                TranMySQL.Commit();
            }
            LoadShipment();
        }

        private void btnChangeQty_Click(object sender, EventArgs e)
        {
            int[] Rows = gridView1.GetSelectedRows();
            string TmpQty = "";
            double NewQty = 0;

            if (Rows.GetUpperBound(0) == -1)
                return;

            Shipment Shipment = gridView1.GetRow(Rows[0]) as Shipment;
            
            TmpQty = Interaction.InputBox("请输入更改数量 !", "更改数量", "");

            if (TmpQty == "")
                return;

            if (double.TryParse(TmpQty, out NewQty))
            {
                try
                {
                    Shipment = Shipment.LoadMySQL(Shipment.OrderNo);

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
                    XtraMessageBox.Show(string.Format("单号{0}不能更改寄货数量.  \n原因 : {1}.", Shipment.OrderNo,  ex.Message));
                }
            }

            Shipment = null;
        }

        private void btnTSIOK_Click(object sender, EventArgs e)
        {
            List<Shipment> Shipments = GetSelectedShipment();

            using (MySqlConnection CnnMySQL = ServerHelper.ConnectToMySQL())
            {
                MySqlTransaction TranMySQL = CnnMySQL.BeginTransaction();
                foreach (Shipment Ship in Shipments)
                {
                    if (Ship.OrderStatus == "TSI")
                    {
                        Shipment ShipUpdate = Shipment.LoadMySQL(Ship.OrderNo);
                        ShipUpdate.CnnMySQL = CnnMySQL;
                        ShipUpdate.ChangeStatus("Ready");
                        ShipUpdate.UpdateAllRecord();
                    }
                }
                TranMySQL.Commit();
            }
            LoadShipment();
        }

        private void btnShipmentReport_Click(object sender, EventArgs e)
        {
            Excel.Application XlApp = new Excel.Application();
            XlApp.Caption = "NWMMS - " + DateTime.Now.ToLongTimeString();
            Excel.Workbook XlWb;
            string FilePath = "\\\\nwszmail\\_nws\\Client\\MassPlanning\\mp_sz_exitSZ.xls";

            try
            {
                XlWb = XlApp.Workbooks.Open(FilePath, System.Type.Missing, false,
                System.Type.Missing, System.Type.Missing, System.Type.Missing,
                System.Type.Missing, System.Type.Missing, System.Type.Missing,
                System.Type.Missing, System.Type.Missing, System.Type.Missing,
                System.Type.Missing, System.Type.Missing, System.Type.Missing);

                XlApp.Visible = true;
            }
            catch (Exception ex)
            {
                Logger.For(this).Error(string.Format("不能打开 mp_sz_exitSZ.xls.  原因 : {0}", ex.Message));
            }

        }

        private void btnOtherCustomer_Click(object sender, EventArgs e)
        {
            DeductShipmentManually();
            LoadShipment();
        }

        private void DeductShipmentManually()
        {
            List<Shipment> Shipments = GetSelectedShipment();
            StringBuilder SBMsg = new StringBuilder();
            SBMsg.AppendLine(string.Format("你选择把下列共 {0} 个出货项目, 请确认是否手工寄货 ??", Shipments.Count + 1));

            foreach(Shipment Shipment in Shipments)
            {
                SBMsg.AppendLine(string.Format("寄货单号 : {0}.  本厂编码 : {1}.  数量 : {2}.", Shipment.OrderNo, Shipment.ItemNo, Shipment.MoveQty));
            }

            DialogResult dialogResult = XtraMessageBox.Show(SBMsg.ToString(), "确认手工寄货", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
                return;

            SBMsg.Clear();

            using (MySqlConnection CnnMySQL = ServerHelper.ConnectToMySQL())
            {
                using (MySqlTransaction TransMySQL = CnnMySQL.BeginTransaction())
                {
                    foreach (Shipment S in Shipments)
                    {
                        Shipment Ship = Shipment.LoadMySQL(S.OrderNo);
                        Ship.CnnMySQL = CnnMySQL;
                        Ship.AddShippedQty(Ship.MoveQty - Ship.ArrivedQty);
                        Ship.AddCartonNo(CartonNo);
                        try
                        {
                            Ship.UpdateAllRecord();
                        }
                        catch
                        {
                            SBMsg.AppendLine(string.Format("寄货单号 : {0}.  本厂编码 : {1}.  数量 : {2}.", Ship.OrderNo, Ship.ItemNo, Ship.MoveQty));
                        }
                    }
                    TransMySQL.Commit();
                }
            }

            if (SBMsg.ToString() != "")
                XtraMessageBox.Show(string.Format("以下寄货单不能手工寄货 !! \n {0}", SBMsg.ToString()), "錯误");
            else
                XtraMessageBox.Show("完成", "手工寄货成功");

        }

        private void txtBarcode_Enter(object sender, EventArgs e)
        {
            txtBarcode.SelectAll();
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            txtBarcode.Text = txtBarcode.Text.ToUpper().Trim();

            if (txtBarcode.Text == "")
                return;

            if (ValidateCartonNo() == false)
                return;

            if (txtBarcode.Text == "NEXTCARTON")
            {
                Label.BoxLabel.PrintCartonLabel(CartonNo);
                CartonNo++;
                txtCartonNo.Text = CartonNo.ToString();
                txtBarcode.Text = "";
                txtBarcode.Focus();
                return;
            }

            if (txtBarcode.Text.Length < 41 || txtBarcode.Text.Length > 46)
            {
                ShowError("输入的条码长度有问题, 正确的长度应为41至46.  请查!!!");
                return;
            }

            string SalesOrderNo = "";
            string ItemNo = "";
            double DeductQty = 0;

            SplitBarcode(txtBarcode.Text, out SalesOrderNo, out ItemNo, out DeductQty);
            DeductShipment(SalesOrderNo, ItemNo, DeductQty);
            LoadShipment();

            txtBarcode.Text = "";
            txtBarcode.Focus();
        }

        private void frmShipOrderExist_Load(object sender, EventArgs e)
        {
            PlayOK = new System.Media.SoundPlayer(Properties.Resources.ok);
            PlayError = new System.Media.SoundPlayer(Properties.Resources.ERROR);
            LoadShipment();
            //txtBarcode.Text = "1PO5136810PN905X3257370005Q0000010XNX0000TSI";
        }

        private void frmShipOrderExist_FormClosed(object sender, FormClosedEventArgs e)
        {
            PlayOK = null;
            PlayError = null;
        }

    }
}