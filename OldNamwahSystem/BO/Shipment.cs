using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using OldNamwahSystem.Func;
using DevExpress.Xpo;
using log4net;

namespace OldNamwahSystem.BO
{
    class Shipment
    {
        public const string SHIPMENTPATH = "http://nwszmail/public/namwah/Shipping/ShipmentOrders/";

        static ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static Dictionary<string, Shipment> LoadMySQL(string StrFilter, string StrOrderBy)
        {
            Dictionary<string, Shipment> Shipments = new Dictionary<string, Shipment>();
            Logger.Info("Start");
            ADODB.Connection Cnn = new ADODB.Connection();
            ADODB.Recordset Rst = new ADODB.Recordset();
            string StrSQL = string.Format("SELECT * FROM Shipment {0} {1}", StrFilter, StrOrderBy);
            Shipment Shipment;

            string Key = "";

            Cnn = Func.ServerHelper.ConnectMySQL();
            Rst.Open(StrSQL, Cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

            while (!Rst.EOF)
            {
                try
                {
                    Shipment = new Shipment();
                    Shipment.InitFromMySQL(Rst);

                    Key = string.Format("{0}", Shipment.OrderNo);

                    Shipments.Add(Key, Shipment);
                }
                catch(Exception ex)
                {
                    Logger.Error(ex.Message);
                }
                Rst.MoveNext();
            }

            Logger.Info("End");
            return Shipments;
        }

        public static BindingList<Shipment> LoadBindingListByMySQL(string StrFilter, string StrOrderBy)
        {
            BindingList<Shipment> Shipments = new BindingList<Shipment>();
            Logger.Info("Start");
            ADODB.Connection Cnn = new ADODB.Connection();
            ADODB.Recordset Rst = new ADODB.Recordset();
            string StrSQL = string.Format("SELECT * FROM Shipment {0} {1}", StrFilter, StrOrderBy);
            Shipment Shipment;

            Cnn = Func.ServerHelper.ConnectMySQL();
            Rst.Open(StrSQL, Cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

            while (!Rst.EOF)
            {
                try
                {
                    Shipment = new Shipment();
                    Shipment.InitFromMySQL(Rst);
                    Shipments.Add(Shipment);
                }
                catch(Exception ex)
                {
                    Logger.Error(ex.Message);
                }
                Rst.MoveNext();
            }
            Logger.Info("Start");
            return Shipments;
        }

        public static List<Shipment> LoadListByMySQL(string StrFilter, string StrOrderBy)
        {
            List<Shipment> Shipments = new List<Shipment>();
            Logger.Info("Start");
            ADODB.Connection Cnn = new ADODB.Connection();
            ADODB.Recordset Rst = new ADODB.Recordset();
            string StrSQL = string.Format("SELECT * FROM Shipment {0} {1}", StrFilter, StrOrderBy);
            Shipment Shipment;

            Cnn = Func.ServerHelper.ConnectMySQL();
            Rst.Open(StrSQL, Cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

            while (!Rst.EOF)
            {
                try
                {
                    Shipment = new Shipment();
                    Shipment.InitFromMySQL(Rst);
                    Shipments.Add(Shipment);
                }
                catch(Exception ex)
                {
                    Logger.Error(ex.Message);
                }
                Rst.MoveNext();
            }
            Logger.Info("Start");
            return Shipments;
        }

        public void InitFromMySQL(ADODB.Recordset Rst)
        {
            this.ArrivedQty = double.Parse(Rst.Fields["ArrivedQty"].Value.ToString());
            this.Carton = Rst.Fields["Carton"].Value.ToString();
            this.CompDate = DateTime.Parse(Rst.Fields["CompDate"].Value.ToString());
            this.Customer = Rst.Fields["Customer"].Value.ToString();
            this.CustomerItemNo = Rst.Fields["CustomerItemNo"].Value.ToString();
            this.CustomerPrice = double.Parse(Rst.Fields["CustomerPrice"].Value.ToString());
            this.Destination = Rst.Fields["Destination"].Value.ToString();
            this.InvoiceNo = Rst.Fields["InvoiceNo"].Value.ToString();
            this.ItemName = Rst.Fields["ItemName"].Value.ToString();
            this.ItemNo = Rst.Fields["ItemNo"].Value.ToString();
            this.Item = Item.Load(this.ItemNo);
            this.ItemType = Rst.Fields["ItemType"].Value.ToString();
            this.ItemRevision = Rst.Fields["ItemRevision"].Value.ToString();
            this.LastModifiedDate = DateTime.Parse(Rst.Fields["LastModifiedDate"].Value.ToString());
            this.Material = Rst.Fields["Material"].Value.ToString();
            this.MoveDate = DateTime.Parse(Rst.Fields["MoveDate"].Value.ToString());
            this.MoveQty = double.Parse(Rst.Fields["MoveQty"].Value.ToString());
            this.OrderDate = DateTime.Parse(Rst.Fields["OrderDate"].Value.ToString());
            this.OrderNo = Rst.Fields["OrderNo"].Value.ToString();
            this.Origin = Rst.Fields["Origin"].Value.ToString();
            this.OurPrice = double.Parse(Rst.Fields["OurPrice"].Value.ToString());
            this.PlatingInvoiceDate = DateTime.Parse(Rst.Fields["PlatingInvoiceDate"].Value.ToString());
            this.PlatingInvoiceNo = Rst.Fields["PlatingInvoiceNo"].Value.ToString();
            this.RefNo = Rst.Fields["RefNo"].Value.ToString();
            this.RefType = Rst.Fields["RefType"].Value.ToString();
            this.SalesOrderNo = Rst.Fields["SalesOrderNo"].Value.ToString();
            this.SalesOrderIndex = int.Parse(Rst.Fields["SalesOrderIndex"].Value.ToString());
            this.ShipMethod = Rst.Fields["ShipMethod"].Value.ToString();
            this.SoType = Rst.Fields["SoType"].Value.ToString();
            this.OrderStatus = Rst.Fields["OrderStatus"].Value.ToString();
            this.SOLine = SalesOrderLine.LoadMySQL(this.SalesOrderNo, this.SalesOrderIndex);
        }

        public bool SaveNewRecord()
        {
            if (Glob.IsDebugMode)
                return true;

            Logger.Info("Start");
            ADODB.Record Rec;
            ADODB.Connection Cnn = new ADODB.Connection();
            Cnn = ServerHelper.ConnectExchange(SHIPMENTPATH);

            Rec = new ADODB.Record();
            string StrSQL = "";

            for (int Attempt = 0; Attempt < 2; Attempt++)
            {
                try
                {
                    if (OrderNo == "")
                        OrderNo = Glob.GetShipmentBarcode();

                    if (OrderNo == "")
                    {
                        Logger.Error("Cannot get the shipment barcorde");
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
                        Logger.Error(string.Format("Cannot create shipment order.  Error : {0}.", ex.Message));
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
            Rec.Fields["nw:mo:no"].Value = OrderNo;
            Rec.Fields["nw:partno"].Value = Item.ItemNo;
            Rec.Fields["nw:part:revision"].Value = Item.CustomerRevision;
            Rec.Fields["nw:part:tmxrefno"].Value = CustomerItemNo;
            Rec.Fields["nw:parttype"].Value = Item.ItemType;
            Rec.Fields["nw:partname"].Value = Item.ItemName;
            Rec.Fields["nw:strprice"].Value = SOLine.OurPrice.ToString();
            Rec.Fields["nw:cpo:item:strprice"].Value = SOLine.OurPrice.ToString();
            Rec.Fields["nw:mo:origin"].Value = "FQC";
            Rec.Fields["nw:customer"].Value = SOLine.Customer;
            Rec.Fields["nw:mo:destination"].Value = SOLine.Customer;
            Rec.Fields["nw:mo:moveqty"].Value = MoveQty;
            Rec.Fields["nw:mo:arrivedqty"].Value = 0;
            Rec.Fields["nw:cpo:item:shipmethod"].Value = SOLine.ShipMethod;

            //Rec.Fields.Append("nw:mo:movedate", ADODB.DataTypeEnum.adFileTime);
            Rec.Fields["nw:mo:movedate"].Value = DateTime.Today;
            Rec.Fields["nw:cpo:no"].Value = SOLine.OrderNo;
            Rec.Fields["nw:cpo:item:index"].Value = SOLine.OrderIndex;
            Rec.Fields["nw:material"].Value = Item.Material;
            Rec.Fields["nw:mo:refno"].Value = RefNo;
            Rec.Fields["nw:mo:reftype"].Value = "CPO";
            Rec.Fields["nw:mo:sotype"].Value = "FQC";
            Rec.Fields["nw:mo:status"].Value = "TSI"; //  ' Change from Ready to TSI
            Rec.Fields["nw:history"].Value = "";

            Glob.AddADOHistory(Rec, "Created");
            Glob.AddADOHistory(Rec, string.Format("Original Ship Qty is {0}", MoveQty));

            Rec.Fields.Update();

            Logger.Info("End");
            return true;
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
        private SalesOrderLine _SOLine;

        public SalesOrderLine SOLine
        {
            get
            {
                return _SOLine;
            }
            set
            {
                _SOLine = value;
            }
        }

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
