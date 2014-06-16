using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OldNamwahSystem.Func;
using OldNamwahSystem.BO;

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
            Shipment Shipment = Shipment.LoadMySQL("XS1940368");

            Shipment.InsertAllRecord();

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
            List<SalesOrderLine> SOLines = SalesOrderLine.LoadListMySQL("WHERE OrderNo = '5133139' AND OrderIndex = 37 ", "");
            MySql.Data.MySqlClient.MySqlConnection CnnMySQL = ServerHelper.ConnectToMySQL();
            SOLines[0].CnnMySQL = CnnMySQL;

            SOLines[0].UpdateAllRecord();
            
            //SOLines = SplitOrder.SplitSOLineByDateAndPriority(SOLines);
            //SOLines = SplitOrder.SortSOLines(SOLines);

            //foreach(SalesOrderLine SOLine in SOLines)
            //{
            //    System.Diagnostics.Debug.Print(string.Format("Date : {0}.  Priority : {1}", SOLine.PromisedDate, SOLine.Priority));
            //}
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
    }
}