using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using OldNamwahSystem.Func;
using log4net;
using Dapper;

namespace OldNamwahSystem.BO
{
    class Shipment
    {
        public const string SHIPMENTPATH = "http://nwszmail/public/namwah/Shipping/ShipmentOrders/";
        public MySqlConnection CnnMySQL;

        static ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static Dictionary<string, Shipment> LoadMySQL(string StrFilter, string StrOrderBy)
        {
            Logger.Info("开始");
            using (MySqlConnection cnn = ServerHelper.ConnectToMySQL())
            {
                string StrSQL = string.Format("SELECT * FROM Shipment {0} {1}", StrFilter, StrOrderBy);
                Logger.Info("结束");
                return cnn.Query<Shipment>(StrSQL).ToDictionary<Shipment, string>(k=>k.OrderNo);
            }
        }

        public static Shipment LoadMySQL(string OrderNo)
        {
            Logger.Info("开始");
            using (MySqlConnection cnn = ServerHelper.ConnectToMySQL())
            {
                string StrSQL = string.Format("SELECT * FROM Shipment WHERE OrderNo = '{0}'", OrderNo);
                Logger.Info("结束");

                return cnn.Query<Shipment>(StrSQL).SingleOrDefault();
            }
        }

        public static List<Shipment> LoadListByMySQL(string StrFilter, string StrOrderBy)
        {
            Logger.Info("开始");
            using (MySqlConnection cnn = ServerHelper.ConnectToMySQL())
            {
                string StrSQL = string.Format("SELECT * FROM Shipment {0} {1}", StrFilter, StrOrderBy);
                Logger.Info("结束");
                return cnn.Query<Shipment>(StrSQL).ToList<Shipment>();
            }
        }

        public bool DeductWH()
        {
            if (OrderStatus != "Waiting")
                return false;

            WHHistory WHHistory = new WHHistory();

            WHHistory.ItemNo = ItemNo;
            WHHistory.ItemName = ItemName;
            WHHistory.ItemType = ItemType;
            WHHistory.RefNo = OrderNo;
            WHHistory.RefType = "SO";
            WHHistory.Qty = MoveQty;
            WHHistory.VendDefectQty = 0;
            WHHistory.DefectQty = 0;
            WHHistory.OK = "ok";
            WHHistory.Supplier = Destination;
            WHHistory.Status = "Complete";
            WHHistory.IO = "Output";

            if (WHHistory.PostFromShipment() == false)
                return false;

            ChangeStatus("TSI");
            UpdateAllRecord();

            return true;
        }
        
        private void RecToExchange(ADODB.Record Rec)
        {
            Rec.Fields["nw:mo:no"].Value = OrderNo;
            Rec.Fields["nw:partno"].Value = ItemNo;

            if (Item != null)
                Rec.Fields["nw:part:revision"].Value = Item.CustomerRevision;
            
            Rec.Fields["nw:part:tmxrefno"].Value = CustomerItemNo;
            Rec.Fields["nw:material"].Value = Material;
            Rec.Fields["nw:parttype"].Value = ItemType;
            Rec.Fields["nw:partname"].Value = ItemName;
            Rec.Fields["nw:strprice"].Value = OurPrice.ToString(); 
            Rec.Fields["nw:cpo:item:strprice"].Value = CustomerPrice.ToString();
            Rec.Fields["nw:mo:origin"].Value = Origin;
            Rec.Fields["nw:customer"].Value = Customer;
            Rec.Fields["nw:mo:destination"].Value = Destination; 
            Rec.Fields["nw:mo:moveqty"].Value = int.Parse(MoveQty.ToString());
            Rec.Fields["nw:mo:arrivedqty"].Value = int.Parse(ArrivedQty.ToString()); 
            Rec.Fields["nw:cpo:item:shipmethod"].Value = ShipMethod;
            //Rec.Fields.Append("nw:mo:movedate", ADODB.DataTypeEnum.adFileTime);
            
            if (CompDate.Year > 2000)
                Rec.Fields["nw:mo:compdate"].Value = CompDate;

            if (MoveDate.Year > 2000)
                Rec.Fields["nw:mo:movedate"].Value = MoveDate; // DateTime.Today;

            Rec.Fields["nw:cpo:no"].Value = SalesOrderNo; //  SOLine.OrderNo;
            Rec.Fields["nw:cpo:item:index"].Value = SalesOrderIndex; //  SOLine.OrderIndex;
            Rec.Fields["nw:mo:refno"].Value = RefNo;
            Rec.Fields["nw:mo:reftype"].Value = RefType;//  "CPO";
            Rec.Fields["nw:mo:sotype"].Value = SoType; //  "FQC";
            Rec.Fields["nw:mo:status"].Value = OrderStatus; 
            Rec.Fields["nw:history"].Value = History;
        }

        public void AddHistory(string Message)
        {
            History = Glob.AddHistory(History, Message);
        }

        public void AddCartonNo(int NewCartonNo)
        {
            string[] CartonNos = Carton.Split(',');
            string CartonNo = NewCartonNo.ToString();

            List<int> ListCarton = new List<int>();

            ListCarton.Add(NewCartonNo);

            foreach (string C in CartonNos)
            {
                if (C != CartonNo && C != "")
                    ListCarton.Add(int.Parse(C));
            }

            ListCarton.Sort();
            Carton = "";

            foreach (int C in ListCarton)
            {
                Carton = string.Format("{0},{1}", Carton, C);
            }

            Carton = Carton.Substring(1, Carton.Length - 1);
        }

        public void AddShippedQty(double SQty)
        {
            if (SQty == 0)
                return;

            if (SQty + ArrivedQty > MoveQty)
            {
                Logger.Error(string.Format("寄货单号{0}. 已装箱数{1}({2}+{3})不能大于寄货数量{4}",
                    OrderNo, SQty + ArrivedQty, ArrivedQty, SQty, MoveQty));

                throw new Exception(string.Format("已装箱数{0}({1}+{2})不能大于寄货数量{3}", 
                    SQty + ArrivedQty, ArrivedQty, SQty, MoveQty));
            }

            if (SQty + ArrivedQty == MoveQty)
            {
                AddHistory(string.Format("Arrived Qty change from {0} to {1}.", ArrivedQty, ArrivedQty + SQty));
                ChangeStatus("Active");
            }

            ArrivedQty = ArrivedQty + SQty;

            AddSOLineArrivedQty(SQty);
        }

        public void ChangeMoveQty(double NewMoveQty)
        {
            if (NewMoveQty > MoveQty)
                throw new Exception(string.Format("更改数量{0}不能大于原数量{1}", NewMoveQty, MoveQty));

            if (NewMoveQty < ArrivedQty)
                throw new Exception(string.Format("更改数量{0}不能少于已装箱数{1}.", NewMoveQty, ArrivedQty));
    
            AddHistory(string.Format("寄货数量由{0}改为{1}.", MoveQty, NewMoveQty));
            MoveQty = NewMoveQty;

            if (MoveQty == 0)
            {
                ChangeStatus("Complete");
            }
            else if (MoveQty == ArrivedQty)
            {
                ChangeStatus("Active");
            }
        }

        private void AddSOLineArrivedQty(double SQty)
        {
            SalesOrderLine SOLine = SalesOrderLine.LoadMySQL(SalesOrderNo, SalesOrderIndex);

            if (SOLine == null)
            {
                Logger.Error(string.Format("寄货单号{0}, 产品编码{1}, 找不到销售单号{2}-{3}.", 
                    OrderNo, ItemNo, SalesOrderNo, SalesOrderIndex));
                throw new Exception(string.Format("找不到此销售单号{0}-{1}"
                    , SalesOrderNo, SalesOrderIndex));
            }

            SOLine.CnnMySQL = CnnMySQL;
            SOLine.AddShippedQty(SQty);
            SOLine.UpdateAllRecord();
        }

        public void ChangeStatus(string NewStatus)
        {
            if (OrderStatus == NewStatus)
                return;

            AddHistory(string.Format("Status change from {0} to {1}.", OrderStatus, NewStatus));
            OrderStatus = NewStatus;
        }

        public bool UpdateAllRecord()
        {
            if (Glob.IsDebugMode)
                return true;

            bool IsOK = UpdateToExchange();

            if (IsOK)
                IsOK = SaveToMySQL();

            return IsOK;
        }

        public bool InsertAllRecord()
        {
            if (Glob.IsDebugMode)
                return true;

            bool IsOK = InsertToExchange();

            if (IsOK)
                IsOK = SaveToMySQL();

            return IsOK;
        }

        private bool UpdateToExchange()
        {
            Logger.Info(string.Format("寄货单号 {0}.  开始", OrderNo));

            ADODB.Connection Cnn = new ADODB.Connection();
            ADODB.Record Rec = new ADODB.Record();
            Cnn = ServerHelper.ConnectExchange(SHIPMENTPATH);
            string StrSQL = "";

            StrSQL = string.Format("{0}{1}.eml", SHIPMENTPATH, OrderNo);

            try
            {
                Rec.Open(StrSQL, Cnn, ADODB.ConnectModeEnum.adModeReadWrite, 
                    ADODB.RecordCreateOptionsEnum.adFailIfNotExists,
                    ADODB.RecordOpenOptionsEnum.adOpenRecordUnspecified,
                        "Namwah", "ParaW0rld");
                RecToExchange(Rec);
                Rec.Fields.Update();
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("寄货单号 {0}不能储存.  原因 : {1}.", OrderNo, ex.Message));
                return false;
            }

            Logger.Info(string.Format("寄货单号 {0}.  结束", OrderNo));
            return true;
        }

        private bool InsertToExchange()
        {
            Logger.Info(string.Format("开始.  寄货单号 {0}.", OrderNo));

            ADODB.Connection Cnn = new ADODB.Connection();
            ADODB.Record Rec = new ADODB.Record();
            Cnn = ServerHelper.ConnectExchange(SHIPMENTPATH);
            string StrSQL = "";

            for (int Attempt = 0; Attempt < 2; Attempt++)
            {
                try
                {
                    if (OrderNo == "")
                        OrderNo = Glob.GetShipmentBarcode();

                    if (OrderNo == "")
                    {
                        Logger.Error("原因 : 不能取得寄货单号.");
                        return false;
                    }

                    StrSQL = string.Format("{0}{1}.eml", SHIPMENTPATH, OrderNo);

                    Rec.Open(StrSQL, Cnn, ADODB.ConnectModeEnum.adModeReadWrite,
                        ADODB.RecordCreateOptionsEnum.adCreateNonCollection,
                        ADODB.RecordOpenOptionsEnum.adOpenRecordUnspecified,
                        "Namwah", "ParaW0rld");
                    break;
                }
                catch (Exception ex)
                {
                    if (Attempt == 2)
                    {
                        Logger.Error(string.Format("不能建立寄货单.  原因 : {0}.", ex.Message));
                        return false;
                    }
                    else
                    {
                        Glob.IncreaseShipmentBarcode(10);
                        OrderNo = Glob.GetShipmentBarcode();
                        Rec = new ADODB.Record();
                    }
                }
            }

            Rec.Fields["http://schemas.microsoft.com/exchange/outlookmessageclass"].Value = "IPM.Post.ship_order";
            Rec.Fields["DAV:contentclass"].Value = "nw:content-classes:mo";
            Rec.Fields["urn:schemas:httpmail:subject"].Value = OrderNo;

            AddHistory("Created");
            AddHistory(string.Format("Original Ship Qty is {0}", MoveQty));

            RecToExchange(Rec);

            Rec.Fields.Update();
            Logger.Info(string.Format("结束.  寄货单号 {0}.", OrderNo));
            return true;
        }

        public  bool SaveToMySQL()
        {
            Logger.Info(string.Format("开始.  寄货单号 {0}.", OrderNo));

            StringBuilder SBSql = new StringBuilder();
            String StrSQL = "";
            int AffectRecord = 0;

            SBSql.Append("UPDATE Shipment SET");
            SBSql.Append(" ArrivedQty = '{0}', Carton = '{1}', CompDate = '{2}'");
            SBSql.Append(", Customer = '{3}', CustomerItemNo = '{4}', CustomerPrice = '{5}'");
            SBSql.Append(", MoveDate = '{6}', MoveQty = '{7}'");
            SBSql.Append(", OrderDate = '{8}', Origin = '{9}'");
            SBSql.Append(", OurPrice = '{10}', PlatingInvoiceDate = '{11}'");
            SBSql.Append(", Destination = '{12}', InvoiceNo = '{13}'");
            SBSql.Append(", ItemName = '{14}', ItemNo = '{15}', ItemType = '{16}'");
            SBSql.Append(", ItemRevision = '{17}', Material = '{18}'");
            SBSql.Append(", PlatingInvoiceNo = '{19}', RefNo = '{20}', RefType = '{21}'");
            SBSql.Append(", SalesOrderNo = '{22}', SalesOrderIndex = '{23}'");
            SBSql.Append(", ShipMethod = '{24}', SoType = '{25}'");
            SBSql.Append(", OrderStatus = '{26}', LastModifiedDate = '{27}', History = '{28}' ");
            SBSql.Append(" WHERE OrderNo = '{29}'");

            StrSQL = string.Format(SBSql.ToString(), ArrivedQty, Carton, CompDate.ToString("yyyy-MM-dd"),
                        Customer, CustomerItemNo, CustomerPrice,
                        MoveDate.ToString("yyyy-MM-dd"), MoveQty,
                        OrderDate.ToString("yyyy-MM-dd hh:mm:ss"), Origin,
                        OurPrice, PlatingInvoiceDate.ToString("yyyy-MM-dd"),
                        Destination, InvoiceNo,
                        ItemName, ItemNo, ItemType,
                        ItemRevision, Material,
                        PlatingInvoiceNo, RefNo, RefType,
                        SalesOrderNo, SalesOrderIndex,
                        ShipMethod, SoType,
                        OrderStatus, LastModifiedDate.ToString("yyyy-MM-dd hh:mm:ss"),
                        History.Replace("'", "''") , OrderNo);

            AffectRecord = CnnMySQL.Execute(StrSQL);

            if (AffectRecord > 0)
            {
                Logger.Info(string.Format("结束.  寄货单号 {0}.", OrderNo));
                return true;
            }

            SBSql.Clear();
            SBSql.Append("INSERT INTO Shipment (");
            SBSql.Append("ArrivedQty, Carton, CompDate, Customer, CustomerItemNo, CustomerPrice");
            SBSql.Append(", MoveDate, MoveQty, OrderDate, Origin, OurPrice, PlatingInvoiceDate");
            SBSql.Append(", Destination, InvoiceNo, ItemName, ItemNo, ItemType, ItemRevision, Material");
            SBSql.Append(", PlatingInvoiceNo, RefNo, RefType, SalesOrderNo, SalesOrderIndex");
            SBSql.Append(", ShipMethod, SoType, OrderStatus, LastModifiedDate, History, OrderNo )");
            SBSql.Append(" VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}'");
            SBSql.Append(", '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}'");
            SBSql.Append(", '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}'");
            SBSql.Append(", '{26}', '{27}', '{28}', '{29}' )");

            StrSQL = string.Format(SBSql.ToString(), ArrivedQty, Carton, CompDate.ToString("yyyy-MM-dd"),
                        Customer, CustomerItemNo, CustomerPrice,
                        MoveDate.ToString("yyyy-MM-dd"), MoveQty,
                        OrderDate.ToString("yyyy-MM-dd hh:mm:ss"), Origin,
                        OurPrice, PlatingInvoiceDate.ToString("yyyy-MM-dd"),
                        Destination, InvoiceNo,
                        ItemName, ItemNo, ItemType,
                        ItemRevision, Material,
                        PlatingInvoiceNo, RefNo, RefType,
                        SalesOrderNo, SalesOrderIndex,
                        ShipMethod, SoType,
                        OrderStatus, LastModifiedDate.ToString("yyyy-MM-dd hh:mm:ss"),
                        History.Replace("'", "''"), OrderNo);

            AffectRecord = CnnMySQL.Execute(StrSQL);

            if (AffectRecord > 0)
            {
                Logger.Info(string.Format("结束.  寄货单号 {0}.", OrderNo));
                return true;
            }
            else
            {
                Logger.Error(string.Format("寄货单号 {0}.  原因 : 没有储存到数据库", OrderNo));
                return false;
            }
        }

        #region Fields

        // Fields...
        private string _OrderStatus = "";
        private string _SoType = "";
        private string _ShipMethod = "";
        private string _SalesOrderNo = "";
        private int _SalesOrderIndex = 0;
        private string _RefType = "";
        private string _RefNo = "";
        private string _PlatingInvoiceNo = "";
        private DateTime _PlatingInvoiceDate = DateTime.MinValue;
        private double _OurPrice = 0;
        private string _Origin = "";
        private string _OrderNo = "";
        private DateTime _OrderDate = DateTime.MinValue;
        private double _MoveQty = 0;
        private DateTime _MoveDate = DateTime.MinValue;
        private string _Material = "";
        private DateTime _LastModifiedDate = DateTime.MinValue;
        private string _ItemType = "";
        private Item _Item;
        private string _ItemRevision = "";
        private string _ItemNo = "";
        private string _ItemName = "";
        private string _InvoiceNo = "";
        private string _Destination = "";
        private double _CustomerPrice = 0;
        private string _CustomerItemNo = "";
        private string _Customer = "";
        private DateTime _CompDate = DateTime.MinValue;
        private string _Carton = "";
        private double _ArrivedQty = 0;

        //private SalesOrderLine _SOLine;
        //public SalesOrderLine SOLine
        //{
        //       get { return _SOLine; }
        //       set { _SOLine = value; }
        //}

        public Item Item
        {
            get
            {
                return _Item;
            }
            set
            {
                _Item = value;

                if (_Item != null && Material != "")
                    Material = _Item.Material;

            }
        }

        public double ArrivedQty
        {
            get
            {
                return _ArrivedQty;
            }
            set
            {
                _ArrivedQty  = value;
            }
        }

        public string Carton
        {
            get
            {
                return _Carton;
            }
            set
            {
                _Carton = value;
            }
        }

        private string _History = "";
        public string History
        {
            get { return _History; }
            set { _History = value; }
        }

        public DateTime CompDate
        {
            get
            {
                return _CompDate;
            }
            set
            {
                _CompDate = value;
            }
        }

        public string Customer
        {
            get
            {
                return _Customer;
            }
            set
            {
                _Customer = value;
            }
        }

        public string CustomerItemNo
        {
            get
            {
                return _CustomerItemNo;
            }
            set
            {
                _CustomerItemNo = value;
            }
        }

        public double CustomerPrice
        {
            get
            {
                return _CustomerPrice;
            }
            set
            {
                _CustomerPrice = value;
            }
        }

        public string Destination
        {
            get
            {
                return _Destination;
            }
            set
            {
                _Destination = value;
            }
        }

        public string InvoiceNo
        {
            get
            {
                return _InvoiceNo;
            }
            set
            {
                _InvoiceNo = value;
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

        public string ItemRevision
        {
            get
            {
                return _ItemRevision;
            }
            set
            {
                _ItemRevision = value;
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

        public DateTime LastModifiedDate
        {
            get
            {
                return _LastModifiedDate;
            }
            set
            {
                _LastModifiedDate = value;
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

        public DateTime MoveDate
        {
            get
            {
                return _MoveDate;
            }
            set
            {
                _MoveDate = value;
            }
        }

        public double MoveQty
        {
            get
            {
                return _MoveQty;
            }
            set
            {
                _MoveQty = value;
            }
        }

        public DateTime OrderDate
        {
            get
            {
                return _OrderDate;
            }
            set
            {
                _OrderDate = value;
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

        public string Origin
        {
            get
            {
                return _Origin;
            }
            set
            {
                _Origin = value;
            }
        }

        public double OurPrice
        {
            get
            {
                return _OurPrice;
            }
            set
            {
                _OurPrice = value;
            }
        }

        public DateTime PlatingInvoiceDate
        {
            get
            {
                return _PlatingInvoiceDate;
            }
            set
            {
                _PlatingInvoiceDate = value;
            }
        }

        public string PlatingInvoiceNo
        {
            get
            {
                return _PlatingInvoiceNo;
            }
            set
            {
                _PlatingInvoiceNo = value;
            }
        }

        public string RefNo
        {
            get
            {
                return _RefNo;
            }
            set
            {
                _RefNo = value;
            }
        }

        public string RefType
        {
            get
            {
                return _RefType;
            }
            set
            {
                _RefType = value;
            }
        }

        public int SalesOrderIndex
        {
            get
            {
                return _SalesOrderIndex;
            }
            set
            {
                _SalesOrderIndex = value;
            }
        }

        public string SalesOrderNo
        {
            get
            {
                return _SalesOrderNo;
            }
            set
            {
                _SalesOrderNo = value;
            }
        }

        public string ShipMethod
        {
            get
            {
                return _ShipMethod;
            }
            set
            {
                _ShipMethod = value;
            }
        }

        public string SoType
        {
            get
            {
                return _SoType;
            }
            set
            {
                _SoType = value;
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

        #endregion

    }
}
