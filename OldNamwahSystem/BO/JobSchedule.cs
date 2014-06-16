using System;
using System.Collections.Generic;
using System.Linq;
using OldNamwahSystem.Func;

namespace OldNamwahSystem.BO
{
    class JobSchedule
    {
        public const string JSPATH = "http://nwszmail/public/namwah/WorkOrders/SZProduction/JobSchedule/";

        public static JobSchedule LoadExchange(string StrJSNo)
        {
            try
            {
                Logger.For(typeof(JobSchedule)).Info(string.Format("开始.  单号 : {0}.", StrJSNo));
                ADODB.Connection Cnn = ServerHelper.ConnectExchange(JSPATH);
                ADODB.Record Rec = new ADODB.Record();
                Rec.Open(string.Format("{0}{1}.eml", JSPATH, StrJSNo), Cnn, ADODB.ConnectModeEnum.adModeReadWrite, ADODB.RecordCreateOptionsEnum.adFailIfNotExists, ADODB.RecordOpenOptionsEnum.adOpenRecordUnspecified, "namwah", "ParaW0rld");
                JobSchedule JS = new JobSchedule();
                JS.InitFromRec(Rec);
                Logger.For(typeof(JobSchedule)).Info(string.Format("结束.  单号 : {0}.", StrJSNo));
                return JS;
            }
            catch (Exception ex)
            {
                Logger.For(typeof(JobSchedule)).Error(string.Format("单号 : {0}.  原因 : {1}", StrJSNo, ex.Message));
                throw ex;
            }
        }

        private void InitFromRec(ADODB.Record Rec)
        {
            CellLine = ExchangeHelper.GetStringField(Rec.Fields["nw:cellline"]);
            FQCInspectionDate = ExchangeHelper.GetDateTimeField(Rec.Fields["nw:fqc:inspectiondate"]);
            FQCInspector = ExchangeHelper.GetStringField(Rec.Fields["nw:fqc:inspector"]);
            ActiveQty = ExchangeHelper.GetDoubleField(Rec.Fields["nw:js:activeqty"]);
            IrNo = ExchangeHelper.GetStringField(Rec.Fields["nw:js:irno"]);
            Location = ExchangeHelper.GetStringField(Rec.Fields["nw:js:location"]);
            NeedDate = ExchangeHelper.GetDateTimeField(Rec.Fields["nw:js:needdate"]);
            NeedQty = ExchangeHelper.GetDoubleField(Rec.Fields["nw:js:needqty"]);
            OrderNo = ExchangeHelper.GetStringField(Rec.Fields["nw:js:no"]);
            OrderStatus = ExchangeHelper.GetStringField(Rec.Fields["nw:js:status"]);
            Material = ExchangeHelper.GetStringField(Rec.Fields["nw:material"]);
            ItemName = ExchangeHelper.GetStringField(Rec.Fields["nw:partname"]);
            ItemNo = ExchangeHelper.GetStringField(Rec.Fields["nw:partno"]);
            ItemType = ExchangeHelper.GetStringField(Rec.Fields["nw:parttype"]);
            ActiveLocation = ExchangeHelper.GetStringField(Rec.Fields["nw:js:activelocation"]);
            Item = Item.Load(ItemNo);
        }

        public void UpdateFQC()
        {
            if (Glob.IsDebugMode)
                return;

            try
            {
                Logger.For(this).Info(string.Format("Order No : {0}. Start.", OrderNo));
                ADODB.Connection Cnn = ServerHelper.ConnectExchange(JSPATH);
                ADODB.Record Rec = new ADODB.Record();

                Rec.Open(string.Format("{0}{1}.eml", JSPATH, OrderNo), Cnn, ADODB.ConnectModeEnum.adModeReadWrite, ADODB.RecordCreateOptionsEnum.adFailIfNotExists, ADODB.RecordOpenOptionsEnum.adOpenRecordUnspecified, "namwah", "ParaW0rld");
                Rec.Fields["nw:fqc:inspector"].Value = FQCInspector;

                if (FQCInspectionDate != DateTime.MinValue)
                    Rec.Fields["nw:fqc:inspectiondate"].Value = FQCInspectionDate;

                Rec.Fields["nw:fqc:sample:inspectqty"].Value = int.Parse(ActiveQty.ToString());
                Rec.Fields["nw:js:irno"].Value = IrNo;
                Rec.Fields["nw:js:activeqty"].Value = int.Parse(ActiveQty.ToString());
                Rec.Fields["nw:js:status"].Value = "Complete";
                Rec.Fields["nw:js:activelocation"].Value = "Q";
                Rec.Fields.Update();

                Logger.For(this).Info(string.Format("Order No : {0}. End.", OrderNo));
            }
            catch (Exception ex)
            {
                Logger.For(this).Error(string.Format("Order No : {0}. Error : {1}.", OrderNo, ex.Message));
                throw ex;
            }
        }

        #region Field

        private string _ActiveLocation;
        private Item _Item;
        private string _ItemType = "";
        private string _ItemNo = "";
        private string _ItemName = "";
        private string _Material = "";
        private string _OrderStatus = "";
        private string _OrderNo = "";
        private double _NeedQty = 0;
        private DateTime _NeedDate = DateTime.MinValue;
        private string _Location = "";
        private string _IrNo = "";
        private double _ActiveQty = 0;
        private string _FQCInspector = "";
        private DateTime _FQCInspectionDate = DateTime.MinValue;
        private string _CellLine = "";

        public Item Item
        {
            get
            {
                return _Item;
            }
            set
            {
                _Item = value;
            }
        }

        public string ActiveLocation
        {
            get
            {
                return _ActiveLocation;
            }
            set
            {
                _ActiveLocation = value;
            }
        }

        public string CellLine
        {
            get
            {
                return _CellLine;
            }
            set
            {
                _CellLine = value;
            }
        }

        public DateTime FQCInspectionDate
        {
            get
            {
                return _FQCInspectionDate;
            }
            set
            {
                _FQCInspectionDate = value;
            }
        }

        public string FQCInspector
        {
            get
            {
                return _FQCInspector;
            }
            set
            {
                _FQCInspector = value;
            }
        }

        public double ActiveQty
        {
            get
            {
                return _ActiveQty;
            }
            set
            {
                _ActiveQty = value;
            }
        }

        public string IrNo
        {
            get
            {
                return _IrNo;
            }
            set
            {
                _IrNo = value;
            }
        }

        public string Location
        {
            get
            {
                return _Location;
            }
            set
            {
                _Location = value;
            }
        }

        public DateTime NeedDate
        {
            get
            {
                return _NeedDate;
            }
            set
            {
                _NeedDate = value;
            }
        }

        public double NeedQty
        {
            get
            {
                return _NeedQty;
            }
            set
            {
                _NeedQty = value;
            }
        }

        public string OrderNo
        {
            get
            {
                return _OrderNo;
            }
            set
            {
                _OrderNo = value;
            }
        }

        public string OrderStatus
        {
            get
            {
                return _OrderStatus;
            }
            set
            {
                _OrderStatus = value;
            }
        }

        public string Material
        {
            get
            {
                return _Material;
            }
            set
            {
                _Material = value;
            }
        }

        public string ItemName
        {
            get
            {
                return _ItemName;
            }
            set
            {
                _ItemName = value;
            }
        }

        public string ItemNo
        {
            get
            {
                return _ItemNo;
            }
            set
            {
                _ItemNo = value;
            }
        }

        public string ItemType
        {
            get
            {
                return _ItemType;
            }
            set
            {
                _ItemType = value;
            }
        }

#endregion
    }
}
