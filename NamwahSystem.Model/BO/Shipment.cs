using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NamwahSystem.Model.Func;
using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace NamwahSystem.Model.BO
{
    public class Shipment : BaseBusinessObject
    {
        public const string SHIPMENTPATH = "http://nwszmail/public/namwah/Shipping/ShipmentOrders/";
        public MySqlConnection CnnMySQL;

        public static Dictionary<string, Shipment> LoadMySQL(MySqlConnection Cnn, string StrFilter, string StrOrderBy)
        {
            Logger.For(typeof(Shipment)).Info("开始");
            string StrSQL = string.Format("SELECT * FROM Shipment {0} {1}", StrFilter, StrOrderBy);
            Logger.For(typeof(Shipment)).Info("结束");
            return Cnn.Query<Shipment>(StrSQL).ToDictionary<Shipment, string>(k => k.OrderNo);
        }

        public static Shipment LoadMySQL(MySqlConnection Cnn, string OrderNo)
        {
            Logger.For(typeof(Shipment)).Info("开始");
            string StrSQL = string.Format("SELECT * FROM Shipment WHERE OrderNo = '{0}'", OrderNo);
            Logger.For(typeof(Shipment)).Info("结束");
            return Cnn.Query<Shipment>(StrSQL).SingleOrDefault();
        }

        public static List<Shipment> LoadListByMySQL(MySqlConnection Cnn, string StrFilter, string StrOrderBy)
        {
            Logger.For(typeof(Shipment)).Info("开始");
            string StrSQL = string.Format("SELECT * FROM Shipment {0} {1}", StrFilter, StrOrderBy);
            Logger.For(typeof(Shipment)).Info("结束");
            return Cnn.Query<Shipment>(StrSQL).ToList<Shipment>();
        }

        public void DeductWH()
        {
            if (OrderStatus != "Waiting")
                return;

            WHHistory WHHistory = new WHHistory();
            WHHistory.ItemNo = ItemNo;
            WHHistory.ItemName = ItemName;
            WHHistory.ItemType = ItemType;
            WHHistory.RefNo = OrderNo;
            WHHistory.RefType = "SO";
            WHHistory.OKQty = MoveQty;
            WHHistory.VendDefectQty = 0;
            WHHistory.DefectQty = 0;
            //WHHistory.OK = "ok";
            WHHistory.Supplier = Destination;
            WHHistory.Status = "Complete";
            WHHistory.IOType = WHIOType.Output;
            WHHistory.Save();

            ChangeStatus("TSI");
            UpdateAllRecord();
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
                Logger.For(this).Error(string.Format("寄货单号{0}. 已装箱数{1}({2}+{3})不能大于寄货数量{4}",
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
                Logger.For(this).Error(string.Format("寄货单号{0}, 产品编码{1}, 找不到销售单号{2}-{3}.",
                    OrderNo, ItemNo, SalesOrderNo, SalesOrderIndex));
                throw new Exception(string.Format("找不到此销售单号{0}-{1}"
                    , SalesOrderNo, SalesOrderIndex));
            }

            SOLine.CnnMySQL = CnnMySQL;
            SOLine.AddShippedQty(SQty);
            SOLine.Save();
        }

        public void ChangeStatus(string NewStatus)
        {
            if (OrderStatus == NewStatus)
                return;

            AddHistory(string.Format("Status change from {0} to {1}.", OrderStatus, NewStatus));
            OrderStatus = NewStatus;
        }

        public void UpdateAllRecord()
        {
            if (Glob.IsDebugMode)
                return;

            UpdateToExchange();
            SaveToMySQL();
        }

        public void InsertAllRecord()
        {
            if (Glob.IsDebugMode)
                return;

            InsertToExchange();
            SaveToMySQL();
        }

        private void UpdateToExchange()
        {
            try
            {
                Logger.For(this).Info(string.Format("寄货单号 {0}.  开始", OrderNo));
                ADODB.Connection Cnn = ServerHelper.ConnectExchange(SHIPMENTPATH);
                ADODB.Record Rec = new ADODB.Record();
                string StrSQL = string.Format("{0}{1}.eml", SHIPMENTPATH, OrderNo);
                Rec.Open(StrSQL, Cnn, ADODB.ConnectModeEnum.adModeReadWrite,
                    ADODB.RecordCreateOptionsEnum.adFailIfNotExists,
                    ADODB.RecordOpenOptionsEnum.adOpenRecordUnspecified,
                        "Namwah", "ParaW0rld");
                RecToExchange(Rec);
                Rec.Fields.Update();
                Rec.Close();
                Rec = null;
                Cnn = null;
                Logger.For(this).Info(string.Format("寄货单号 {0}.  结束", OrderNo));
            }
            catch (Exception ex)
            {
                Logger.For(this).Error(string.Format("寄货单号 {0}不能储存.  原因 : {1}.", OrderNo, ex.Message));
                throw ex;
            }
        }

        private void InsertToExchange()
        {
            Logger.For(this).Info(string.Format("开始.  寄货单号 {0}.", OrderNo));

            ADODB.Connection Cnn = ServerHelper.ConnectExchange(SHIPMENTPATH);
            ADODB.Record Rec = new ADODB.Record();

            for (int Attempt = 0; Attempt < 2; Attempt++)
            {
                Rec = new ADODB.Record();
                try
                {
                    if (OrderNo == "")
                        OrderNo = Glob.GetShipmentBarcode();

                    string StrSQL = string.Format("{0}{1}.eml", SHIPMENTPATH, OrderNo);

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
                        Logger.For(this).Error(string.Format("不能建立寄货单.  原因 : {0}.", ex.Message));
                        throw ex;
                    }
                    else
                    {
                        Glob.IncreaseShipmentBarcode(10);
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
            Logger.For(this).Info(string.Format("结束.  寄货单号 {0}.", OrderNo));
        }

        public void SaveToMySQL()
        {
            Logger.For(this).Info(string.Format("开始.  寄货单号 {0}.", OrderNo));
            StringBuilder SBSql = new StringBuilder();

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

            string StrSQL = string.Format(SBSql.ToString(), ArrivedQty, Carton, CompDate.ToString("yyyy-MM-dd"),
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

            int AffectRecord = CnnMySQL.Execute(StrSQL);

            if (AffectRecord > 0)
            {
                Logger.For(this).Info(string.Format("结束.  寄货单号 {0}.", OrderNo));
                return;
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
                Logger.For(this).Info(string.Format("结束.  寄货单号 {0}.", OrderNo));
                return;
            }
            else
            {
                Logger.For(this).Error(string.Format("寄货单号 {0}.  原因 : 没有储存到数据库", OrderNo));
                throw new Exception("没有储存到数据库");
            }
        }

        #region Fields

        // Fields...
        public int? id { get; set; }

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

                if (_Item != null && Material != "")
                    Material = _Item.Material;

            }
        }

        private double _ArrivedQty = 0;
        public double ArrivedQty
        {
            get
            {
                return _ArrivedQty;
            }
            set
            {
                _ArrivedQty = value;
            }
        }

        private string _Carton = "";
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

        private DateTime _CompDate = DateTime.MinValue;
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

        private string _Customer = "";
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

        private string _CustomerItemNo = "";
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

        private double _CustomerPrice = 0;
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

        private string _Destination = "";
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

        private string _InvoiceNo = "";
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

        private string _ItemRevision = "";
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

        private DateTime _LastModifiedDate = DateTime.MinValue;
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

        private DateTime _MoveDate = DateTime.MinValue;
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

        private double _MoveQty = 0;
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

        private DateTime _OrderDate = DateTime.MinValue;
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

        private string _Origin = "";
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

        private double _OurPrice = 0;
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

        private DateTime _PlatingInvoiceDate = DateTime.MinValue;
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

        private string _PlatingInvoiceNo = "";
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

        private string _RefNo = "";
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

        private string _RefType = "";
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

        private int _SalesOrderIndex = 0;
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

        private string _SalesOrderNo = "";
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

        private string _ShipMethod = "";
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

        private string _SoType = "";
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

        #endregion

    }
}
