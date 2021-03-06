﻿using System;
using System.Collections.Generic;
using System.Linq;
using OldNamwahSystem.Func;
using MySql.Data.MySqlClient;
using Dapper;

namespace OldNamwahSystem.BO
{
    class Item
    {
        /// <summary>
        ///  
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
