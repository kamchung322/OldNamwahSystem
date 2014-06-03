using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OldNamwahSystem.Func;
using log4net;
using Dapper;
using MySql.Data.MySqlClient;

namespace OldNamwahSystem.BO
{
    class SalesOrderLine
    {
        static ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public const string SOLINEPATH = "http://nwszmail/public/namwah/sales/timex/purchaseorders/";
        public MySqlConnection CnnMySQL;

        public static Dictionary<string, SalesOrderLine> LoadDictMySQL(string StrFilter, string StrOrderBy)
        {
            Logger.Info("开始");
            using (IDbConnection cnn = ServerHelper.ConnectToMySQL())
            {
                string StrSQL = string.Format("SELECT * FROM SalesOrderLine {0} {1}", StrFilter, StrOrderBy);
                Logger.Info("结束");
                return cnn.Query<SalesOrderLine>(StrSQL).ToDictionary<SalesOrderLine, string>(k => string.Format("{0}-{1}", k.OrderNo, k.OrderIndex));
            }
        }

        public static List<SalesOrderLine> LoadListMySQL(string StrFilter, string StrOrderBy)
        {
            Logger.Info("开始");
            using (IDbConnection cnn = ServerHelper.ConnectToMySQL())
            {
                string StrSQL = string.Format("SELECT * FROM SalesOrderLine {0} {1}", StrFilter, StrOrderBy);
                Logger.Info("结束");
                return cnn.Query<SalesOrderLine>(StrSQL).ToList<SalesOrderLine>();
            }
        }

        public static SalesOrderLine LoadMySQL(string OrderNo, int OrderIndex)
        {
            Logger.Info("开始");
            using (IDbConnection cnn = ServerHelper.ConnectToMySQL())
            {
                string StrSQL = string.Format("SELECT * FROM SalesOrderLine WHERE ( OrderNo = '{0}' AND OrderIndex = {1} ) ", OrderNo, OrderIndex);
                Logger.Info("结束");
                return cnn.Query<SalesOrderLine>(StrSQL).SingleOrDefault();
            }
        }

        public static List<Shipment> CreateShipmentOrders(ref double RemainQty, Dictionary<string, SalesOrderLine> SOLines, string RefNo)
        {
            List<Shipment> Shipments = new List<Shipment>();
            Dictionary<string, double> DictIssueQty = new Dictionary<string, double>();
            Shipment Shipment;
            string Key;
            List<SalesOrderLine> SplitSOLine = SplitOrder.SplitSOLineByDateAndPriority(SOLines.Values.ToList());
            SplitSOLine = SplitOrder.SortSOLines(SplitSOLine);
            // 1.  Split Sales Order
            // 2.  Sort Sales Order
            // 3.  Calc 
            // 4.  CreateShipmentOrders

            foreach (SalesOrderLine SOLine in SplitSOLine)
            {
                double ShipQty = 0;
                Key = string.Format("{0}-{1}", SOLine.OrderNo, SOLine.OrderIndex);

                if (RemainQty > SOLine.BalQty)
                    ShipQty = SOLine.BalQty;
                else
                    ShipQty = RemainQty;

                if (DictIssueQty.ContainsKey(Key))
                    DictIssueQty[Key] = DictIssueQty[Key] + ShipQty;
                else
                    DictIssueQty.Add(Key, ShipQty);

                RemainQty = RemainQty - ShipQty;

                if (RemainQty == 0)
                    break;

            }

            foreach (KeyValuePair<string, double> KVP in DictIssueQty)
            {
                if (SOLines.ContainsKey(KVP.Key))
                {
                    SalesOrderLine SOLine = SOLines[KVP.Key];
                    Shipment = SOLine.CreateShipmentOrder(KVP.Value, RefNo);
                    if (Shipment != null)
                        Shipments.Add(Shipment);
                }
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
                        SOLine.PendingShipQty = SOLine.PendingShipQty + ShipOrder.MoveQty;

                        if (SOLine.BalQty <= 0)
                            SOLines.Remove(Key);

                    }
                }
            }
        }

        private void InitFromMySQL(ADODB.Recordset Rst)
        {
            Customer = Rst.Fields["Customer"].Value.ToString();
            ItemNo = Rst.Fields["ItemNo"].Value.ToString();
            ItemName = Rst.Fields["ItemName"].Value.ToString();
            ItemType = Rst.Fields["ItemType"].Value.ToString();
            Material = Rst.Fields["Material"].Value.ToString();
            OrderNo = Rst.Fields["OrderNo"].Value.ToString();
            OrderIndex = int.Parse(Rst.Fields["OrderIndex"].Value.ToString());
            CustomerItemNo = Rst.Fields["CustomerItemNo"].Value.ToString();
            OurPrice = double.Parse(Rst.Fields["OurPrice"].Value.ToString());
            ShipMethod = Rst.Fields["ShipMethod"].Value.ToString();
            NeedQty = double.Parse(Rst.Fields["NeedQty"].Value.ToString());
            ShippedQty = double.Parse(Rst.Fields["ShippedQty"].Value.ToString());
            PriorityList = Rst.Fields["PriorityList"].Value.ToString();
            PromisedDateList = Rst.Fields["PromisedDateList"].Value.ToString();
            PromisedDate = DateTime.Parse(Rst.Fields["PromisedDate"].Value.ToString());
            OrderDate = DateTime.Parse(Rst.Fields["OrderDate"].Value.ToString());
            NeedDate = DateTime.Parse(Rst.Fields["NeedDate"].Value.ToString());
            Priority = int.Parse(Rst.Fields["Priority"].Value.ToString());
            History = Rst.Fields["History"].Value.ToString();

            InitPList();
        }

        public void InitPList()
        {
            PromisedDateList = SplitOrder.SortPromisedDateList(PromisedDateList, "DESC");
            PromisedDateList = SplitOrder.FillPromisedDateList(PromisedDateList, BalQty, NeedDate.AddYears(1));
            PromisedDateList = SplitOrder.SortPromisedDateList(PromisedDateList, "ASC");

            PriorityList = SplitOrder.SortPriorityList(PriorityList, "DESC");
            PriorityList = SplitOrder.FillPriorityList(PriorityList, BalQty, Priority);
            PriorityList = SplitOrder.SortPriorityList(PriorityList, "ASC");
        }

        public void Copy(SalesOrderLine OldSOLine)
        {
            Customer = OldSOLine.Customer;
            ItemNo = OldSOLine.ItemNo;
            ItemName = OldSOLine.ItemName;
            ItemType = OldSOLine.ItemType;
            Material = OldSOLine.Material;
            OrderNo = OldSOLine.OrderNo;
            OrderIndex = OldSOLine.OrderIndex;
            CustomerItemNo = OldSOLine.CustomerItemNo;
            OurPrice = OldSOLine.OurPrice;
            ShipMethod = OldSOLine.ShipMethod;
            NeedQty = OldSOLine.NeedQty;
            ShippedQty = OldSOLine.ShippedQty;
            Priority = OldSOLine.Priority;
            PriorityList = OldSOLine.PriorityList;
            PromisedDate = OldSOLine.PromisedDate;
            PromisedDateList = OldSOLine.PromisedDateList;
            OrderDate = OldSOLine.OrderDate;
            NeedDate = OldSOLine.NeedDate;
        }

        public Shipment CreateShipmentOrder(double ShipQty, string JSNo)
        {
            Shipment ShipOrder = new Shipment();

            using (CnnMySQL = ServerHelper.ConnectToMySQL())
            {
                MySqlTransaction TranMySQL = CnnMySQL.BeginTransaction();
                try
                {
                    //ShipOrder.SOLine = this;
                    ShipOrder.CnnMySQL = CnnMySQL;
                    ShipOrder.ItemNo = ItemNo;
                    ShipOrder.ItemName = ItemName;
                    ShipOrder.ItemType = ItemType;
                    ShipOrder.CustomerItemNo = CustomerItemNo;
                    ShipOrder.OurPrice = OurPrice;
                    ShipOrder.CustomerPrice = CustomerPrice;
                    ShipOrder.Customer = Customer;
                    ShipOrder.Destination = Customer;
                    ShipOrder.SalesOrderNo = OrderNo;
                    ShipOrder.SalesOrderIndex = OrderIndex;
                    ShipOrder.RefNo = JSNo;
                    ShipOrder.RefType = "CPO";
                    ShipOrder.SoType = "FQC";
                    ShipOrder.ShipMethod = ShipMethod;
                    ShipOrder.OrderStatus = "TSI";
                    ShipOrder.Origin = "FQC";
                    ShipOrder.MoveQty = ShipQty;
                    ShipOrder.MoveDate = DateTime.Today;
                    ShipOrder.Item = Item.Load(ItemNo);
                    if (ShipOrder.Item != null)
                        ShipOrder.Material = ShipOrder.Item.Material;
                    ShipOrder.OrderDate = DateTime.Now;
                    //ShipOrder.BoxQty = ShipOrder.Item.BoxQty;

                    if (ShipOrder.InsertAllRecord())
                    {
                        AddHistory(string.Format("Shipped from FQC, {0} PCS, {1}", ShipQty, JSNo));
                        UpdateAllRecord();
                        TranMySQL.Commit();
                    }
                    else
                    {
                        TranMySQL.Rollback();
                        return null;
                    }
                    CnnMySQL.Close();
                }
                catch (Exception ex)
                {
                    Logger.Error(string.Format("销售单{0}-{1}, 不能建立寄货单, 原因 : {2}", OrderNo, OrderIndex, ex.Message));
                    TranMySQL.Rollback();
                    CnnMySQL.Close();
                    return null;
                }
                TranMySQL.Dispose();
            }
            
            return ShipOrder;
        }

        public void AddHistory(string Message)
        {
            History = Glob.AddHistory(History, Message);
        }

        public void AddShippedQty(double SQty)
        {
            if (SQty == 0)
                return;

            if (SQty + ShippedQty > NeedQty)
            {
                Logger.Error(string.Format("销售单{0}-{1}. 已交数量{2}({3}+{4})不能大于要求数量{5}",
                    OrderNo, OrderIndex, SQty + ShippedQty, ShippedQty, SQty, NeedQty));

                throw new Exception(string.Format("已交数量{0}({1}+{2})不能大于要求数量{3}",
                    SQty + ShippedQty, ShippedQty, SQty, NeedQty));

            }

            if (SQty + ShippedQty == NeedQty)
            {
                AddHistory(string.Format("Shipped Qty change from {0} to {1}.", ShippedQty, ShippedQty + SQty));
            }

            ShippedQty = ShippedQty + SQty;

            if (BalQty == 0)
                ChangeStatus("Complete");
                
        }

        public void ChangeStatus(string NewStatus)
        {
            if (OrderStatus == NewStatus)
                return;

            AddHistory(string.Format("Status change from {0} to {1}.", OrderStatus, NewStatus));
            OrderStatus = NewStatus;
        }

        private void RecToExchange(ADODB.Record Rec)
        {
            Rec.Fields["nw:history"].Value = History;
            Rec.Fields["nw:cpo:item:status"].Value = OrderStatus;
            //Rec.Fields["nw:cpo:item:priority"].Value = Priority;
            //Rec.Fields["nw:cpo:item:prioritylist"].Value = PriorityList;
            //Rec.Fields["nw:cpo:item:promiseddate"].Value = PromisedDate;
            //Rec.Fields["nw:cpo:item:shipmentlist"].Value = PromisedDateList;
            Rec.Fields["nw:cpo:item:shippedqty"].Value = int.Parse(ShippedQty.ToString());
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

        private bool UpdateToExchange()
        {
            Logger.Info(string.Format("销售单{0}-{1}.  开始.", OrderNo, OrderIndex));

            ADODB.Connection Cnn = new ADODB.Connection();
            ADODB.Record Rec = new ADODB.Record();

            Cnn = ServerHelper.ConnectExchange(SOLINEPATH);

            string StrSQL = "";

            StrSQL = string.Format("{0}{1}_{2}.eml", SOLINEPATH, OrderNo, OrderIndex );

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
                Logger.Error(string.Format("销售单{0}-{1} 不能储存.  原因 : {2}.", OrderNo, OrderIndex, ex.Message));
                return false;
            }

            Logger.Info(string.Format("销售单{0}-{1}.  结束", OrderNo, OrderIndex ));
            return true;
        }

        private bool SaveToMySQL()
        {
            Logger.Info(string.Format("销售单 {0}-{1}.  开始", OrderNo, OrderIndex));

            StringBuilder SBSql = new StringBuilder();
            String StrSQL = "";
            int AffectRecord = 0;

            SBSql.Append("UPDATE SalesOrderLine SET");
            SBSql.Append(" History = '{0}', OrderStatus = '{1}'");
            SBSql.Append(", ShippedQty = '{2}'");
            SBSql.Append(" WHERE OrderNo = '{3}' AND OrderIndex = '{4}'");

            StrSQL = string.Format(SBSql.ToString(), History.Replace("'", "''"), OrderStatus,
                        ShippedQty, 
                        OrderNo, OrderIndex);

            AffectRecord = CnnMySQL.Execute(StrSQL);

            if (AffectRecord > 0)
            {
                Logger.Info(string.Format("销售单 {0}-{1}.  结束", OrderNo, OrderIndex));
                return true;
            }
            else
            {
                Logger.Error(string.Format("销售单 {0}-{1}.  原因 : 没有储存到数据库", OrderNo, OrderIndex));
                return true;
                //return false;
            }

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
        private int _OrderSubIndex = 0;
        private string _History = "";

        public string History
        {
            get
            {
                return _History;
            }
            set
            {
                _History = value;
            }
        }

        private double _PendingShipQty = 0;
        public double PendingShipQty
        {
            get { return _PendingShipQty; }
            set { _PendingShipQty = value; }
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

        public int OrderSubIndex
        {
            get
            {
                return _OrderSubIndex;
            }
            set
            {
                _OrderSubIndex = value;
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
                return NeedQty - ShippedQty - PendingShipQty;
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
