using System;
using System.Collections.Generic;
using System.Linq;
using OldNamwahSystem.Func;

namespace OldNamwahSystem.BO
{
    class WHTotal
    {
        public const string SZInvPath = "http://nwszmail/public/namwah/Inventory/sz_Finished/";

        public static WHTotal LoadByExchange(string ItemNo)
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
            catch(Exception ex)
            {
                Logger.For(typeof(WHTotal)).Error(string.Format("编码 {0} :  原因 : {1}.", ItemNo, ex.Message));
                return null;
            }

            return WHTotal;

        }

        public bool UpdateToExchange()
        {
            if (Glob.IsDebugMode)
                return true;

            Logger.For(this).Info(string.Format("开始.  编码 : {0}", ItemNo));
            ADODB.Connection Cnn = ServerHelper.ConnectExchange(SZInvPath);
            ADODB.Record Rec = new ADODB.Record();

            try
            {
                Rec.Open(string.Format("{0}{1}.eml", SZInvPath, ItemNo), Cnn, ADODB.ConnectModeEnum.adModeReadWrite, ADODB.RecordCreateOptionsEnum.adOpenIfExists, ADODB.RecordOpenOptionsEnum.adDelayFetchFields, "namwah", "ParaW0rld");
                Rec.Fields["nw:inv:totalqty"].Value = int.Parse(Qty.ToString());
                Rec.Fields["nw:inv:qaqty"].Value = int.Parse(QAQty.ToString());
                Rec.Fields["nw:inv:availqty"].Value = int.Parse(Qty.ToString()) - int.Parse(QAQty.ToString());
                Rec.Fields["nw:inv:defectqty"].Value = int.Parse(DefectQty.ToString());
                Rec.Fields.Update();
                Logger.For(this).Info(string.Format("结束.  编码 : {0}", ItemNo));
                return true;
            }
            catch (Exception ex)
            {
                Logger.For(this).Error(string.Format("编码 {0} :  原因 : {1}.", ItemNo, ex.Message));
                return false;
            }
        }

        private void InitFromExchange(ADODB.Record Rec)
        {
            ItemNo = ExchangeHelper.GetStringField(Rec.Fields["nw:partno"]);
            ItemName = ExchangeHelper.GetStringField(Rec.Fields["nw:partname"]);
            ItemType = ExchangeHelper.GetStringField(Rec.Fields["nw:parttype"]);
            Qty = ExchangeHelper.GetDoubleField(Rec.Fields["nw:inv:totalqty"]);
            QAQty = ExchangeHelper.GetDoubleField(Rec.Fields["nw:inv:qaqty"]);
            DefectQty = ExchangeHelper.GetDoubleField(Rec.Fields["nw:inv:defectqty"]);
        }

        #region Field

        // Fields...

        private Item _Item;
        public Item Item
        {
            get { return _Item; }
            set { _Item = value; }
        }

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

        private double _Qty = 0; // nw:inv:totalqty
        public double Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
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
                double _AvailQty = Qty - QAQty;
                if (_AvailQty < 0)
                    _AvailQty = 0;

                return _AvailQty; 
            }
        }
        #endregion
    }
}
