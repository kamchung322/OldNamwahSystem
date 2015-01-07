using System;
using System.Collections.Generic;
using System.Linq;
using NamwahSystem.Model.Func;
using MySql.Data.MySqlClient;
using Dapper;

namespace NamwahSystem.Model.BO
{
    public class Item
    {        
        public Item() { }

        public static Item Load(string INo)
        {
            Logger.For(typeof(Item)).Info(string.Format("开始.  产品编码 {0}", INo));
            using (MySqlConnection cnn = ServerHelper.ConnectToMySQL("namwah"))
            {
                string StrSQL = String.Format("SELECT Item.*, ItemType.ItemTypeName as ItemType, Material.Name as Material FROM Item  LEFT Join ItemType on Item.ItemType = ItemType.Oid  LEFT Join Material on Item.Material = Material.Oid WHERE Item.ItemNo = '{0}'", INo);
                Logger.For(typeof(Item)).Info(string.Format("结束.  产品编码 {0}", INo));
                return cnn.Query<Item>(StrSQL).SingleOrDefault();
            }
        }

        public void SaveBoxQty()
        {
            using (MySqlConnection Cnn = ServerHelper.ConnectToMySQL("namwah"))
            {
                string StrSQL = string.Format("UPDATE Item SET BoxQty = {0} WHERE ItemNo = '{1}'", BoxQty, ItemNo);
                int RecordAffect = Cnn.Execute(StrSQL);
            }
        }

        #region Field

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

        private string _CustomerRevision = "01";
        public string CustomerRevision
        {
            get
            {
                return _CustomerRevision;
            }
            set
            {
                _CustomerRevision = value;
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

        private string _QCStatus = "";
        public string QCStatus
        {
            get
            {
                return _QCStatus;
            }
            set
            {
                _QCStatus = value;
            }
        }

        private int _BoxQty = 0;
        public int BoxQty
        {
            get
            {
                return _BoxQty;
            }
            set
            {
                _BoxQty = value;
            }
        }

        private float _SalesPrice = 0;
        public float SalesPrice
        {
            get
            {
                return _SalesPrice;
            }
            set
            {
                _SalesPrice = value;
            }
        }

        #endregion
    }
}
