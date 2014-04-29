using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using OldNamwahSystem.Func;
using log4net;

namespace OldNamwahSystem.BO
{
    class SalesOrderLine
    {
        static ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public const string SOLINEPATH = "http://nwszmail/public/namwah/sales/timex/purchaseorders/";

        public static Dictionary<string, SalesOrderLine> LoadDictMySQL(string StrFilter, string StrOrderBy)
        {
            Dictionary<string, SalesOrderLine> SOLines = new Dictionary<string, SalesOrderLine>();
            Logger.Info("Start");
            ADODB.Connection Cnn = new ADODB.Connection();
            ADODB.Recordset Rst = new ADODB.Recordset();
            string StrSQL = string.Format("SELECT * FROM SalesOrderLine {0} {1}", StrFilter, StrOrderBy);
            SalesOrderLine SOLine;
            string Key = "";

            Cnn = Func.ServerHelper.ConnectMySQL();
            Rst.Open(StrSQL, Cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

            while (!Rst.EOF)
            {
                try
                {
                    SOLine = new SalesOrderLine();
                    SOLine.InitFromMySQL(Rst);
                    Key = string.Format("{0}-{1}", SOLine.OrderNo, SOLine.OrderIndex);

                    SOLines.Add(Key, SOLine);
                }
                catch(Exception ex)
                {
                    Logger.Error(ex.Message);
                }
                Rst.MoveNext();
            }

            Logger.Info("End");

            return SOLines;
        }

        public static List<SalesOrderLine> LoadListMySQL(string StrFilter, string StrOrderBy)
        {
            List<SalesOrderLine> SOLines = new List<SalesOrderLine>();
            Logger.Info("Start");
            ADODB.Connection Cnn = new ADODB.Connection();
            ADODB.Recordset Rst = new ADODB.Recordset();
            string StrSQL = string.Format("SELECT * FROM SalesOrderLine {0} {1}", StrFilter, StrOrderBy);
            SalesOrderLine SOLine;

            Cnn = Func.ServerHelper.ConnectMySQL();
            Rst.Open(StrSQL, Cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

            while (!Rst.EOF)
            {
                try
                {
                    SOLine = new SalesOrderLine();
                    SOLine.InitFromMySQL(Rst);
                    SOLines.Add(SOLine);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }
                Rst.MoveNext();
            }

            Logger.Info("End");
            return SOLines;
        }

        public static SalesOrderLine LoadMySQL(string OrderNo, int OrderIndex)
        {
            Logger.Info("Start");
            ADODB.Connection Cnn = new ADODB.Connection();
            ADODB.Recordset Rst = new ADODB.Recordset();
            string StrSQL = string.Format("SELECT * FROM SalesOrderLine WHERE ( OrderNo = '{0}' AND OrderIndex = {1} ) ", OrderNo, OrderIndex);
            SalesOrderLine SOLine;

            Cnn = Func.ServerHelper.ConnectMySQL();
            Rst.Open(StrSQL, Cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

            while (!Rst.EOF)
            {
                try
                {
                    SOLine = new SalesOrderLine();
                    SOLine.InitFromMySQL(Rst);
                    Logger.Info("End");
                    return SOLine;
                }
                catch(Exception ex)
                {
                    Logger.Error(ex.Message);
                }
                Rst.MoveNext();
            }

            Logger.Info("End");
            return null;
        }

        public static List<Shipment> CreateShipmentOrders(ref double RemainQty, Dictionary<string, SalesOrderLine> SOLines, string RefNo)
        {
            List<Shipment> Shipments = new List<Shipment>();
            Shipment Shipment;

            foreach (KeyValuePair<string, SalesOrderLine> KVP in SOLines)
            {
                SalesOrderLine SOLine = KVP.Value;
                double ShipQty = 0;

                if (RemainQty > SOLine.BalQty)
                {
                    ShipQty = SOLine.BalQty;
                }
                else
                {
                    ShipQty = RemainQty;
                }

                Shipment = SOLine.CreateShipmentOrder(ShipQty, RefNo);

                if (Shipment == null)
                {
                    return null;
                }
                else
                {
                    RemainQty = RemainQty - ShipQty;
                    Shipments.Add(Shipment);
                }

                if (RemainQty == 0)
                    break;
            }

            return Shipments;
        }

        public static void CalcActualBalance(List<Shipment> Shipments, Dictionary<string, SalesOrderLine> SOLines)
        {
            foreach (Shipment ShipOrder in Shipments)
            {
                if (ShipOrder.OrderStatus != "Active")
                {
                    string Key = string.Format("{0}-{1}", ShipOrder.SalesOrderNo, ShipOrder.SalesOrderIndex);
                    SalesOrderLine SOLine;

                    if (SOLines.ContainsKey(Key))
                    {
                        SOLine = SOLines[Key];
                        SOLine.ShippedQty = SOLine.ShippedQty + ShipOrder.MoveQty;

                        if (SOLine.BalQty <= 0)
                            SOLines.Remove(Key);

                    }
                }
            }

        }

        public void InitFromMySQL(ADODB.Recordset Rst)
        {
            this.Customer = Rst.Fields["Customer"].Value.ToString();
            this.ItemNo = Rst.Fields["ItemNo"].Value.ToString();
            this.ItemName = Rst.Fields["ItemName"].Value.ToString();
            this.ItemType = Rst.Fields["ItemType"].Value.ToString();
            this.Material = Rst.Fields["Material"].Value.ToString();
            this.OrderNo = Rst.Fields["OrderNo"].Value.ToString();
            this.OrderIndex = int.Parse(Rst.Fields["OrderIndex"].Value.ToString());
            this.CustomerItemNo = Rst.Fields["CustomerItemNo"].Value.ToString();
            this.OurPrice = double.Parse(Rst.Fields["OurPrice"].Value.ToString());
            this.ShipMethod = Rst.Fields["ShipMethod"].Value.ToString();
            this.NeedQty = double.Parse(Rst.Fields["NeedQty"].Value.ToString());
            this.ShippedQty = double.Parse(Rst.Fields["ShippedQty"].Value.ToString());
            this.PriorityList = Rst.Fields["PriorityList"].Value.ToString();
            this.PromisedDateList = Rst.Fields["PromisedDateList"].Value.ToString();
            this.PromisedDate = DateTime.Parse(Rst.Fields["PromisedDate"].Value.ToString());
            this.OrderDate = DateTime.Parse(Rst.Fields["OrderDate"].Value.ToString());
            this.NeedDate = DateTime.Parse(Rst.Fields["NeedDate"].Value.ToString());
            this.Priority = int.Parse(Rst.Fields["Priority"].Value.ToString());

            
            this.PromisedDateList = SplitOrder.SortPromisedDateList(this.PromisedDateList, "DESC");
            this.PromisedDateList = SplitOrder.FillPromisedDateList(this.PromisedDateList, this.BalQty, this.NeedDate.AddYears(1));
            this.PromisedDateList = SplitOrder.SortPromisedDateList(this.PromisedDateList, "ASC");

            this.PriorityList = SplitOrder.SortPriorityList(this.PriorityList, "DESC");
            this.PriorityList = SplitOrder.FillPriorityList(this.PriorityList, this.BalQty, this.Priority);
            this.PriorityList = SplitOrder.SortPriorityList(this.PriorityList, "ASC");
            
        }

        public Shipment CreateShipmentOrder(double ShipQty, string JSNo)
        {
            Shipment ShipOrder = new Shipment();

            try
            {
                ShipOrder.SOLine = this;
                ShipOrder.ItemNo = ItemNo;
                ShipOrder.ItemName = ItemName;
                ShipOrder.ItemType = ItemType;
                ShipOrder.CustomerItemNo = CustomerItemNo;
                ShipOrder.SalesOrderNo = OrderNo;
                ShipOrder.SalesOrderIndex = OrderIndex;
                ShipOrder.RefNo = JSNo;
                ShipOrder.ShipMethod = ShipMethod;
                ShipOrder.MoveQty = ShipQty;
                ShipOrder.Item = Item.Load(ItemNo);
                //ShipOrder.BoxQty = ShipOrder.Item.BoxQty;
                if (ShipOrder.SaveNewRecord())
                {
                    UpdateHistory(string.Format("Shipped from FQC, {0} PCS, {1}", ShipQty, JSNo));
                }
                else
                {
                    return null;
                }

            }
            catch(Exception ex)
            {
                Logger.Error(string.Format("Cannot Create Shipment Order.  Error : {0}", ex.Message));
                return null;
            }

            return ShipOrder;
        }

        public void UpdateHistory(string Message)
        {

        }

        #region Fields

        // Fields...
        private DateTime _LastModifiedDate = DateTime.MinValue;
        private double _ShippedQty = 0;
        private string _ShipMethod = "";
        private string _Remark = "";
        private string _PromisedDateList = "";
        private DateTime _PromisedDate = DateTime.MinValue;
        private string _PriorityList = "";
        private int _Priority = 0;
        private double _OurPrice = 0;
        private string _OrderStatus = "";
        private string _OrderNo = "";
        private int _OrderIndex = 0;
        private DateTime _OrderDate = DateTime.MinValue;
        private double _NeedQty = 0;
        private DateTime _NeedDate = DateTime.MinValue;
        private string _Material = "";
        private string _ItemType = "";
        private string _ItemNo = "";
        private string _ItemName = "";
        private string _ItemDescription = "";
        private string _ItemCategory = "";
        private DateTime _InitNeedDate = DateTime.MinValue;
        private bool _IgnorePlanning = false;
        private double _CustomerPrice = 0;
        private string _CustomerItemNo = "";
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

        public bool IgnorePlanning
        {
            get
            {
                return _IgnorePlanning;
            }
            set
            {
                _IgnorePlanning = value;
            }
        }

        public DateTime InitNeedDate
        {
            get
            {
                return _InitNeedDate;
            }
            set
            {
                _InitNeedDate = value;
            }
        }

        public string ItemCategory
        {
            get
            {
                return _ItemCategory;
            }
            set
            {
                _ItemCategory = value;
            }
        }

        public string ItemDescription
        {
            get
            {
                return _ItemDescription;
            }
            set
            {
                _ItemDescription = value;
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

        public int OrderIndex
        {
            get
            {
                return _OrderIndex;
            }
            set
            {
                _OrderIndex = value;
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

        public int Priority
        {
            get
            {
                return _Priority;
            }
            set
            {
                _Priority = value;
            }
        }

        public string PriorityList
        {
            get
            {
                return _PriorityList;
            }
            set
            {
                _PriorityList = value;
            }
        }

        public DateTime PromisedDate
        {
            get
            {
                return _PromisedDate;
            }
            set
            {
                _PromisedDate = value;
            }
        }

        public string PromisedDateList
        {
            get
            {
                return _PromisedDateList;
            }
            set
            {
                _PromisedDateList = value;
            }
        }

        public string Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                _Remark = value;
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

        public double ShippedQty
        {
            get
            {
                return _ShippedQty;
            }
            set
            {
                _ShippedQty = value;
            }
        }

        public double BalQty
        {
            get
            {
                return NeedQty - ShippedQty;
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
        #endregion

    }
}
