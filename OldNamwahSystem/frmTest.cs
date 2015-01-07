using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NamwahSystem.Model.Func;
using NamwahSystem.Model.BO;
using MySql.Data.MySqlClient;

namespace OldNamwahSystem
{
    public partial class frmTest : XtraForm
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void btnPriority_Click(object sender, EventArgs e)
        {
            string OriList = " 0 (1498 ), -6  (602) ";
            OriList = " 14-Jan-01 (65), 14-Jan-06 (610), 14-Jan-15 (180), 14-Jan-16 (633), 14-Feb-19 (10), 14-Apr-23 (602)";

            XtraMessageBox.Show(string.Format("Original : {0}\nSort : {1}\nAdd : {2}\nMove : {3}", 
                                                OriList, 
                                                SplitOrder.SortPromisedDateList(OriList, "DESC"), 
                                                SplitOrder.FillPromisedDateList(OriList, 10000, DateTime.Today), 
                                                SplitOrder.FillPromisedDateList(OriList, 10, DateTime.Today)));

/*
            XtraMessageBox.Show(string.Format("Original : {0}\nSort : {1}\nAdd : {2}\nMove : {3}", 
                                                OriList, 
                                                Test.SortPriorityList(OriList, "DESC"), 
                                                Test.FillPriorityList(OriList, 10000, 3), 
                                                Test.FillPriorityList(OriList, 10, 3)));
*/

        }

        private void btnShipment_Click(object sender, EventArgs e)
        {
            using (MySqlConnection Cnn = ServerHelper.ConnectToMySQL())
            {
                Shipment Shipment = Shipment.LoadMySQL(Cnn, "XS1940368");
                Shipment.InsertAllRecord();
            }
        }

        private void btnTestStringSplit_Click(object sender, EventArgs e)
        {
            string[] CartonNos = txtStringList.Text.Split(',');
            string CartonNo = txtCartonNo.Text.Trim();
            List<int> ListCarton = new List<int>();

            ListCarton.Add(int.Parse(CartonNo));

            foreach (string C in CartonNos)
            {
                if (C != CartonNo && C != "")
                    ListCarton.Add(int.Parse(C));
            }

            ListCarton.Sort();
            txtStringList.Text = "";

            foreach (int C in ListCarton)
            {
                txtStringList.Text = string.Format("{0},{1}", txtStringList.Text, C);
            }

            txtStringList.Text = txtStringList.Text.Substring(1, txtStringList.Text.Length - 1);
        }

        private void btnSOLines_Click(object sender, EventArgs e)
        {
            List<SalesOrderLine> SOLines = SalesOrderLine.LoadListMySQL("WHERE ItemNo = '921370306' AND  OrderStatus = 'Waiting' ", "");
            MySqlConnection CnnMySQL = ServerHelper.ConnectToMySQL();
            //SOLines[0].CnnMySQL = CnnMySQL;

            //SOLines[0].UpdateAllRecord();
            
            //SOLines = SplitOrder.SplitSOLineByPromisedDateAndPriority(SOLines);
            SOLines = SplitOrder.SortSOLinesByNeedDateAndPriority(SOLines);

            foreach(SalesOrderLine SOLine in SOLines)
            {
                System.Diagnostics.Debug.Print(string.Format("Date : {0}.  BalQty : {1},  Priority : {2}", SOLine.NeedDate , SOLine.BalQty,  SOLine.Priority));
            }
        }

        private void btnStringTest_Click(object sender, EventArgs e)
        {
            string Test = "Per Wallis's request";
            MessageBox.Show (string.Format("{0}\n{1}",Test,Test.Replace("'", "''")));
        }

        private void btnIsNullOrEmpty_Click(object sender, EventArgs e)
        {
            string Test = null;
            MessageBox.Show(string.Format("{0}", string.IsNullOrEmpty(Test)));
            
            Test = "";
            MessageBox.Show(string.Format("{0}", string.IsNullOrEmpty(Test)));

            Test = "abc";
            MessageBox.Show(string.Format("{0}", string.IsNullOrEmpty(Test)));

        }

        private void btnEnum_Click(object sender, EventArgs e)
        {
            foreach(string Name in Enum.GetNames(typeof(NamwahSystem.Model.Func.WHName)))
            {
                MessageBox.Show(Name);
            }
        }

        private void btnTestFunction_Click(object sender, EventArgs e)
        {
            float Qty1 = 100, Qty2 = 200, Qty3 = 0;

            Qty3 = AssignSmallQty(ref Qty1, ref Qty2);

            MessageBox.Show(string.Format("Qty1 : {0}, Qty2 : {1}, Qty3 : {2},", Qty1, Qty2, Qty3));

        }

        private float AssignSmallQty(ref float Qty1, ref float Qty2)
        {
            float TmpSmallQty = 0;

            if (Qty1 > Qty2)
                TmpSmallQty = Qty2;
            else
                TmpSmallQty = Qty1;

            Qty1 = Qty1 - TmpSmallQty;
            Qty2 = Qty2 - TmpSmallQty;
            return TmpSmallQty;
        }

        private void btnWHHistory_Click(object sender, EventArgs e)
        {
            using (MySqlConnection CnnMySQL = ServerHelper.ConnectToMySQL())
            {
                using (MySqlTransaction TranMySQL = CnnMySQL.BeginTransaction())
                {
                    try
                    {
                        WHIOType IOType = WHIOType.Input;
                        for (int i = 1; i < 1000; i++)
                        {
                            WHHistory WHHistory = new WHHistory();
                            WHHistory.TranMySQL = TranMySQL;
                            WHHistory.ItemNo = "01TX0015";
                            WHHistory.IOType = IOType;
                            WHHistory.OKQty = 111;
                            WHHistory.CreatedBy = "Kenneth";
                            WHHistory.CreatedDate = DateTime.Now;
                            WHHistory.CnnMySQL = CnnMySQL;
                            WHHistory.Save();

                            if (IOType == WHIOType.Input)
                                IOType = WHIOType.Output;
                            else
                                IOType = WHIOType.Input;

                        }
                        TranMySQL.Commit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        TranMySQL.Rollback();
                    }
                }
                MessageBox.Show("OK");
            }
        }

    }
}