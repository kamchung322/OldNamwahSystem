using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using NamwahSystem.Model.Func;

namespace NamwahSystem.Model.BO
{
    [Table("WHTotal")]
    public class WHTotal : BaseBusinessObject
    {
        private const string SZInvPath = "http://nwszmail/public/namwah/Inventory/sz_Finished/";
        public MySqlConnection CnnMySQL;
        public MySqlTransaction TranMySQL;

        public static WHTotal LoadMySQL(MySqlConnection Cnn, string ItemNo, WHName Warehouse)
        {
            Logger.For(typeof(WHTotal)).Info("开始");
            string StrSQL = string.Format("SELECT * FROM WHTotal WHERE ( ItemNo = '{0}' AND Warehouse = {1} ) ", ItemNo, (int)Warehouse);
            Logger.For(typeof(WHTotal)).Info("结束");
            return Cnn.Query<WHTotal>(StrSQL).SingleOrDefault();
        }

        public void Save()
        {
            Calc();
            
            if (id == null)
                SqlMapperExtensions.Insert(CnnMySQL, this, TranMySQL);
            else
                SqlMapperExtensions.Update(CnnMySQL, this, TranMySQL);
        }

        public void Calc()
        {
            string strSQL = string.Format(" WHERE ItemNo = '{0}' AND Warehouse = {1}", ItemNo, (int)Warehouse);
            List<WHHistory> whHistory = WHHistory.LoadListMySQL(CnnMySQL, strSQL, "");
            double InputQty = whHistory.Where(w => w.IOType == WHIOType.Input).Sum(w => w.OKQty);
            double InputDefect = whHistory.Where(w => w.IOType == WHIOType.Input).Sum(w => w.DefectQty + w.VendDefectQty);
            double OutputDefect = whHistory.Where(w => w.IOType == WHIOType.Output).Sum(w => w.DefectQty + w.VendDefectQty);
            double OutputQty = whHistory.Where(w => w.IOType == WHIOType.Output).Sum(w => w.OKQty);
            double TransferQty = whHistory.Where(w => w.IOType == WHIOType.Transfer).Sum(w => w.DefectQty + w.VendDefectQty);

            OKQty = InputQty - OutputQty - TransferQty;
            DefectQty = InputDefect - OutputDefect + TransferQty;

            if (OKQty < 0)
                throw new Exception(string.Format("产品编码 {0}, 良品数({1})不能少於0", ItemNo, OKQty));

            if (DefectQty < 0)
                throw new Exception(string.Format("产品编码 {0}, 不良品数({1})不能少於0", ItemNo, DefectQty));

            // OKQty, DefectQty, QAQty
        }

        public static WHTotal LoadExchange(string ItemNo)
        {
            Logger.For(typeof(WHTotal)).Info(string.Format("开始.  编码 : {0}", ItemNo));
            ADODB.Connection Cnn = ServerHelper.ConnectExchange(SZInvPath);
            ADODB.Record Rst = new ADODB.Record();
            WHTotal WHTotal = new WHTotal();

            try
            {
                Rst.Open(string.Format("{0}{1}.eml", SZInvPath, ItemNo), Cnn, ADODB.ConnectModeEnum.adModeReadWrite, ADODB.RecordCreateOptionsEnum.adOpenIfExists, ADODB.RecordOpenOptionsEnum.adDelayFetchFields, "namwah", "ParaW0rld");
                WHTotal.InitFromExchange(Rst);
                Logger.For(typeof(WHTotal)).Info(string.Format("结束.  编码 : {0}", ItemNo));
            }
            catch (Exception ex)
            {
                Logger.For(typeof(WHTotal)).Error(string.Format("编码 {0} :  原因 : {1}.", ItemNo, ex.Message));
                return null;
            }

            return WHTotal;

        }

        private void UpdateToExchange()
        {
            if (Glob.IsDebugMode)
                return ;

            try
            {
                Logger.For(this).Info(string.Format("开始.  编码 : {0}", ItemNo));
                ADODB.Connection Cnn = ServerHelper.ConnectExchange(SZInvPath);
                ADODB.Record Rec = new ADODB.Record();
                Rec.Open(string.Format("{0}{1}.eml", SZInvPath, ItemNo), Cnn, ADODB.ConnectModeEnum.adModeReadWrite, ADODB.RecordCreateOptionsEnum.adOpenIfExists, ADODB.RecordOpenOptionsEnum.adDelayFetchFields, "namwah", "ParaW0rld");
                Rec.Fields["nw:inv:totalqty"].Value = int.Parse(OKQty.ToString());
                Rec.Fields["nw:inv:qaqty"].Value = int.Parse(QAQty.ToString());
                Rec.Fields["nw:inv:availqty"].Value = int.Parse(OKQty.ToString()) - int.Parse(QAQty.ToString());
                Rec.Fields["nw:inv:defectqty"].Value = int.Parse(DefectQty.ToString());
                Rec.Fields.Update();
                Logger.For(this).Info(string.Format("结束.  编码 : {0}", ItemNo));
            }
            catch (Exception ex)
            {
                Logger.For(this).Error(string.Format("编码 {0} :  原因 : {1}.", ItemNo, ex.Message));
                throw ex;
            }
        }

        private void InitFromExchange(ADODB.Record Rec)
        {
            ItemNo = ExchangeHelper.GetStringField(Rec.Fields["nw:partno"]);
            ItemName = ExchangeHelper.GetStringField(Rec.Fields["nw:partname"]);
            ItemType = ExchangeHelper.GetStringField(Rec.Fields["nw:parttype"]);
            OKQty = ExchangeHelper.GetDoubleField(Rec.Fields["nw:inv:totalqty"]);
            QAQty = ExchangeHelper.GetDoubleField(Rec.Fields["nw:inv:qaqty"]);
            DefectQty = ExchangeHelper.GetDoubleField(Rec.Fields["nw:inv:defectqty"]);
        }

        #region Field

        // Fields...
        public int? id { get; set; }

        private string _ItemNo = "";
        public string ItemNo
        {
            get { return _ItemNo; }
            set { _ItemNo = value; }
        }

        private string _ItemName = "";
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; }
        }

        private string _ItemType = "";
        public string ItemType
        {
            get { return _ItemType; }
            set { _ItemType = value; }
        }

        private double _OKQty = 0; // nw:inv:totalqty
        public double OKQty
        {
            get { return _OKQty; }
            set { _OKQty = value; }
        }

        private double _QAQty = 0;  // nw:inv:qaqty
        public double QAQty
        {
            get { return _QAQty; }
            set { _QAQty = value; }
        }

        private double _DefectQty = 0; // nw:inv:defectqty
        public double DefectQty
        {
            get { return _DefectQty; }
            set { _DefectQty = value; }
        }

        public double AvailQty
        {
            get 
            {
                double _AvailQty = OKQty - QAQty;
                if (_AvailQty < 0)
                    _AvailQty = 0;

                return _AvailQty; 
            }
        }

        private WHName _Warehouse = WHName.SZ;
        public WHName Warehouse
        {
            get { return _Warehouse; }
            set { _Warehouse = value; }
        }

        #endregion
    }
}
