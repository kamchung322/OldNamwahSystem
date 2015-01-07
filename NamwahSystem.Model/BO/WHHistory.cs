using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using NamwahSystem.Model.Func;

namespace NamwahSystem.Model.BO
{
    [Table("WHHistory")]
    public class WHHistory : BaseBusinessObject
    {
        public MySqlConnection CnnMySQL;
        public MySqlTransaction TranMySQL;

        public static List<WHHistory> LoadListMySQL(MySqlConnection Cnn, string StrFilter, string StrOrderBy)
        {
            Logger.For(typeof(WHHistory)).Info("开始");
            string StrSQL = string.Format("SELECT * FROM WHHistory {0} {1}", StrFilter, StrOrderBy);
            Logger.For(typeof(WHHistory)).Info("结束");
            return Cnn.Query<WHHistory>(StrSQL).ToList<WHHistory>();
        }

        public void Save()
        {
            if (Glob.IsDebugMode)
                return;

            if (id == null)
                SqlMapperExtensions.Insert(CnnMySQL, this, TranMySQL);
            else
                SqlMapperExtensions.Update(CnnMySQL, this, TranMySQL);

            WHTotal WHTotal = WHTotal.LoadMySQL(CnnMySQL, ItemNo, Warehouse);

            if (WHTotal == null)
            {
                WHTotal = new WHTotal();
                Item Item = Item.Load(ItemNo);
                WHTotal.ItemNo = ItemNo;
                if (Item != null)
                {
                    WHTotal.ItemName = Item.ItemName;
                    WHTotal.ItemType = Item.ItemType;
                }
                else
                {
                    WHTotal.ItemName = ItemName;
                    WHTotal.ItemType = ItemType;
                }
                WHTotal.Warehouse = Warehouse;
            }
            WHTotal.CnnMySQL = CnnMySQL;
            WHTotal.Save();
        }

        #region Fields

        public int? id { get; set;}

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

        private string _RefNo = "";
        public string RefNo
        {
            get { return _RefNo; }
            set { _RefNo = value; }
        }

        private string _RefType = "";
        public string RefType
        {
            get { return _RefType; }
            set { _RefType = value; }
        }

        private string _Supplier = "";
        public string Supplier
        {
            get { return _Supplier; }
            set { _Supplier = value; }
        }

        private string _Remark = "";
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        private string _DNNo = "";
        public string DNNo
        {
            get { return _DNNo; }
            set { _DNNo = value; }
        }

        private WHIOType _IOType = WHIOType.Input;
        public WHIOType IOType
        {
            get { return _IOType; }
            set { _IOType = value; }
        }

        private double _OKQty = 0;
        public double OKQty
        {
            get { return _OKQty; }
            set { _OKQty = value; }
        }

        private double _DefectQty = 0;
        public double DefectQty
        {
            get { return _DefectQty; }
            set { _DefectQty = value; }
        }

        private double _VendDefectQty = 0;
        public double VendDefectQty
        {
            get
            {
                return _VendDefectQty;
            }
            set
            {
                _VendDefectQty = value;
            }
        }

        private WHName _Warehouse = WHName.SZ;
        public WHName Warehouse
        {
            get { return _Warehouse; }
            set { _Warehouse = value; }
        }

        private string _Status = "";
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        #endregion
        
    }
}
