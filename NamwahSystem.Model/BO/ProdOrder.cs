using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NamwahSystem.Model.Func;

namespace NamwahSystem.Model.BO
{
    public class ProdOrder : BaseBusinessObject
    {
        private const string JSPATH = "http://nwszmail/public/namwah/WorkOrders/SZProduction/JobSchedule/";

        public static ProdOrder LoadExchange(string StrJSNo)
        {
            try
            {
                Logger.For(typeof(ProdOrder)).Info(string.Format("开始.  单号 : {0}.", StrJSNo));
                ADODB.Connection Cnn = ServerHelper.ConnectExchange(JSPATH);
                ADODB.Record Rec = new ADODB.Record();
                Rec.Open(string.Format("{0}{1}.eml", JSPATH, StrJSNo), Cnn, ADODB.ConnectModeEnum.adModeReadWrite, ADODB.RecordCreateOptionsEnum.adFailIfNotExists, ADODB.RecordOpenOptionsEnum.adOpenRecordUnspecified, "namwah", "ParaW0rld");
                ProdOrder JS = new ProdOrder();
                JS.InitFromRec(Rec);
                Logger.For(typeof(ProdOrder)).Info(string.Format("结束.  单号 : {0}.", StrJSNo));
                return JS;
            }
            catch (Exception ex)
            {
                Logger.For(typeof(ProdOrder)).Error(string.Format("单号 : {0}.  原因 : {1}", StrJSNo, ex.Message));
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

        public void UpdateToExchange()
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

        private Item _Item;
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

        private string _ActiveLocation;
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

        private string _CellLine = "";
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

        private DateTime _FQCInspectionDate = DateTime.MinValue;
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

        private string _FQCInspector = "";
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

        private double _ActiveQty = 0;
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

        private string _IrNo = "";
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

        private string _Location = "";
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

        private DateTime _NeedDate = DateTime.MinValue;
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

        private double _NeedQty = 0;
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

        private string _OrderNo = "";
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

        private string _OrderStatus = "";
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

        private string _Material = "";
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

        private string _ItemName = "";
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

        private string _ItemNo = "";
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

        private string _ItemType = "";
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
