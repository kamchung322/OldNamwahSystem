using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OldNamwahSystem.Func;

namespace OldNamwahSystem.BO
{
    class Item
    {
        private float _SalesPrice = 0;
        private int _BoxQty = 0;
        private string _QCStatus = "";
        private string _Material = "";
        private string _CustomerRevision = "01";
        private string _CustomerPN = "";
        private string _ItemType = "";
        private string _ItemName = "";
        private string _ItemNo = "";

        public Item() { }

        public Item(ADODB.Recordset Rsts)
        {
            ItemNo = Rsts.Fields["ItemNo"].Value.ToString();
            ItemName = Rsts.Fields["ItemName"].Value.ToString();
            ItemType = Rsts.Fields["ItemTypeName"].Value.ToString();
            CustomerPN = Rsts.Fields["CustomerItemNo"].Value.ToString();

            if (Rsts.Fields["CustomerItemRevision"].Value != null)
            {
                if (Rsts.Fields["CustomerItemRevision"].Value.ToString() != "")
                    CustomerRevision = Rsts.Fields["CustomerItemRevision"].Value.ToString();
            }

            SalesPrice = float.Parse(Rsts.Fields["SalesPrice"].Value.ToString());

            Material = Rsts.Fields["Name"].Value.ToString();
            BoxQty = int.Parse(Rsts.Fields["BoxQty"].Value.ToString());
            QCStatus = "";

            /*
                If InStr(1, ItemType, "Bezel") > 0 Or InStr(1, ItemType, "Assembly") > 0 Then
                    LotNo = Left(ItemName, 4)
                End If
            */
        }

        public static Item Load(string INo)
        {
            Item TmpItem = new Item();
            ADODB.Connection Cnn;
            ADODB.Recordset Rst;
            string StrSQL;
            bool IsFound = false;

            StrSQL = "SELECT Item.*, ItemType.ItemTypeName, Material.Name FROM Item " +
                " LEFT Join ItemType on Item.ItemType = ItemType.Oid " +
                " LEFT Join Material on Item.Material = Material.Oid" +
                " WHERE Item.ItemNo = '" + INo + "'";

            Cnn = ServerHelper.ConnectMySQL("namwah");
            Rst = new ADODB.Recordset();
            Rst.Open(StrSQL, Cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockBatchOptimistic, 1);

            while (!Rst.EOF)
            {
                TmpItem = new Item(Rst);
                IsFound = true;
                break;
            }

            if (IsFound)
                return TmpItem;
            else
                return null;

        }

        public void SaveBoxQty()
        {
            if (Func.Glob.IsDebugMode == true)
                return;

            ADODB.Connection Cnn = ServerHelper.ConnectMySQL("namwah");
            Object RecordAffect;
            string StrSQL = string.Format("UPDATE Item SET BoxQty = {0} WHERE ItemNo = '{1}'", BoxQty, ItemNo);
            Cnn.Execute(StrSQL, out RecordAffect);
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

        public string CustomerPN
        {
            get
            {
                return _CustomerPN;
            }
            set
            {
                _CustomerPN = value;
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
