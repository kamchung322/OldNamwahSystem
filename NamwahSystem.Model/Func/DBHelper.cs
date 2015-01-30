using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using NamwahSystem.Model.BO;

namespace NamwahSystem.Model.Func
{
    public class DBHelper
    {
        public static List<SalesOrderLine> GetOpenSalesOrderByItemNo(string ItemNo, int Priority)
        {
            using (MySqlConnection cnn = ServerHelper.ConnectToMySQL())
            {
                Logger.For(typeof(DBHelper)).Info("开始");
                string StrSQL = string.Format("SELECT * FROM SalesOrderLine WHERE (ItemNo = '{0}' AND NOT( OrderStatus = 'Complete') AND Priority >= {1} )", ItemNo, Priority);
                
                Dictionary<string, SalesOrderLine> DictSOLine =                
                    cnn.Query<SalesOrderLine>(StrSQL).ToDictionary<SalesOrderLine, string>(k => string.Format("{0}-{1}", k.OrderNo, k.OrderIndex));

                Logger.For(typeof(DBHelper)).Info("结束");

                if (DictSOLine.Count > 0)
                {
                    List<Shipment> Shipments = GetOpenShipmentByItemNo(ItemNo);

                    foreach (Shipment Shipment in Shipments)
                    {
                        string Key = string.Format("{0}-{1}", Shipment.SalesOrderNo, Shipment.SalesOrderIndex);
                        if (DictSOLine.ContainsKey(Key))
                        {
                            SalesOrderLine SOLine = DictSOLine[Key];
                            SOLine.PendingShipQty = SOLine.PendingShipQty + Shipment.MoveQty;
                        }
                    }
                }

                return DictSOLine.Values.ToList<SalesOrderLine>();
            }
        }

        public static List<SalesOrderLine> GetSalesOrder(string StrFilter, string StrOrderBy)
        {
            Logger.For(typeof(DBHelper)).Info("开始");
            using (MySqlConnection cnn = ServerHelper.ConnectToMySQL())
            {
                string StrSQL = string.Format("SELECT * FROM SalesOrderLine {0} {1}", StrFilter, StrOrderBy);
                Logger.For(typeof(DBHelper)).Info("结束");
                return cnn.Query<SalesOrderLine>(StrSQL).ToList<SalesOrderLine>();
            }
        }

        public static SalesOrderLine GetSalesOrderByIndex(string OrderNo, int OrderIndex)
        {
            Logger.For(typeof(SalesOrderLine)).Info("开始");
            using (MySqlConnection cnn = ServerHelper.ConnectToMySQL())
            {
                string StrSQL = string.Format("SELECT * FROM SalesOrderLine WHERE ( OrderNo = '{0}' AND OrderIndex = {1} ) ", OrderNo, OrderIndex);
                Logger.For(typeof(SalesOrderLine)).Info("结束");
                return cnn.Query<SalesOrderLine>(StrSQL).SingleOrDefault();
            }
        }
        public static List<Shipment> GetOpenShipmentByItemNo(string ItemNo)
        {
            using (MySqlConnection Cnn = ServerHelper.ConnectToMySQL())
            {
                Logger.For(typeof(DBHelper)).Info("开始");
                string StrSQL = string.Format("SELECT * FROM Shipment WHERE ItemNo = '{0}' AND ( OrderStatus = 'Ready' OR OrderStatus = 'Waiting' OR OrderStatus = 'TSI' )", ItemNo);
                Logger.For(typeof(DBHelper)).Info("结束");
                return Cnn.Query<Shipment>(StrSQL).ToList<Shipment>();
            }
        }

        public static List<Shipment> GetShipment(string StrFilter)
        {
            using (MySqlConnection Cnn = ServerHelper.ConnectToMySQL())
            {
                Logger.For(typeof(DBHelper)).Info("开始");
                string StrSQL = string.Format("SELECT * FROM Shipment {0}", StrFilter) ;
                Logger.For(typeof(DBHelper)).Info("结束");
                return Cnn.Query<Shipment>(StrSQL).ToList<Shipment>();
            }
        }
    }
}
