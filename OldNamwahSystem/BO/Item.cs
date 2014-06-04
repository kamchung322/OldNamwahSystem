using System;
using System.Collections.Generic;
using System.Linq;
using OldNamwahSystem.Func;
using MySql.Data.MySqlClient;
using Dapper;
using log4net;

namespace OldNamwahSystem.BO
{
    class Item
    {
        readonly static ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        ///  dkdkdkdk
        /// </summary>
        private float _SalesPrice = 0;
        private int _BoxQty = 0;
        private string _QCStatus = "";
        private string _Material = "";
        private string _CustomerRevision = "01";
        private string _CustomerItemNo = "";
        private string _ItemType = "";
        private string _ItemName = "";
        private string _ItemNo = "";

        public Item() { }

        public Item(ADODB.Recordset Rsts)
        {
            ItemNo = Rsts.Fields["ItemNo"].Value.ToString();
            ItemName = Rsts.Fields["ItemName"].Value.ToString();
            ItemType = Rsts.Fields["ItemTypeName"].Value.ToString();
            CustomerItemNo = Rsts.Fields["CustomerItemNo"].Value.ToString();

            if (Rsts.Fields["CustomerItemRevision"].Value != null)
            {
                if (Rsts.Fields["CustomerItemRevision"].Value.ToString() != "")
                    CustomerRevision = Rsts.Fields["CustomerItemRevision"].Value.ToString();
            }

            SalesPrice = float.Parse(Rsts.Fields["SalesPrice"].Value.ToString());

            Material = Rsts.Fields["Material"].Value.ToString();
            BoxQty = int.Parse(Rsts.Fields["BoxQty"].Value.ToString());
            QCStatus = "";

        }

        public static Item Load(string INo)
        {
            Logger.Info("开始");
            using (MySqlConnection cnn = ServerHelper.ConnectToMySQL("namwah"))
            {
                string StrSQL = String.Format("SELECT Item.*, ItemType.ItemTypeName as ItemType, Material.Name as Material FROM Item  LEFT Join ItemType on Item.ItemType = ItemType.Oid  LEFT Join Material on Item.Material = Material.Oid WHERE Item.ItemNo = '{0}'", INo);
                Logger.Info("结束");
                return cnn.Query<Item>(StrSQL).SingleOrDefault();
            }
        }

        public void SaveBoxQty()
        {
            if (Glob.IsDebugMode == true)
                return;

            using (MySqlConnection Cnn = ServerHelper.ConnectToMySQL("namwah"))
            {
                string StrSQL = string.Format("UPDATE Item SET BoxQty = {0} WHERE ItemNo = '{1}'", BoxQty, ItemNo);
                int RecordAffect = Cnn.Execute(StrSQL);
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


    }
}
