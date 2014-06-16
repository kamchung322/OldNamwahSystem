using System;
using System.Collections.Generic;
using System.Linq;
using OldNamwahSystem.Func;
using log4net;

namespace OldNamwahSystem.BO
{
    class WHHistory
    {

        public const string SZInvHisPath = "http://nwszmail/public/namwah/Inventory/sz_Finished/History/";

        public void PostFromShipment()
        {
            if (Glob.IsDebugMode)
                return;

            Logger.For(this).Info(string.Format("开始.  编码 : {0}", ItemNo));
            WHTotal WHTotal = WHTotal.LoadByExchange(ItemNo);

            if (WHTotal == null)
            {
                Logger.For(this).Error(string.Format("找不到此编码 {0}的仓存总数.", ItemNo));
                throw new Exception(string.Format("找不到此编码 {0}的仓存总数.", ItemNo));
            }

            if (WHTotal.AvailQty < Qty)
            {
                Logger.For(this).Error(string.Format("编码 : {0}, 可用数量 {1} 少於寄货数 {2}.", ItemNo, WHTotal.AvailQty, Qty));
                throw new Exception(string.Format("编码 : {0}, 可用数量 {1} 少於寄货数 {2}.", ItemNo, WHTotal.AvailQty, Qty));
            }

            WHTotal.Qty = WHTotal.Qty - Qty;
            WHTotal.UpdateToExchange();
            InsertToExchange();
        }

        public void InsertToExchange()
        {
            if (Glob.IsDebugMode)
                return;

            Logger.For(this).Info(string.Format("开始.  编码 : {0}", ItemNo));

            ADODB.Record Rec = new ADODB.Record();
            string Subject = string.Format("{0}_{1}", DateTime.Now.ToString("yyMMddhhmmss"), ItemNo ) ;
            string StrSQL = string.Format("{0}{1}.eml", SZInvHisPath, Subject);

            Rec.Open(StrSQL, Type.Missing, ADODB.ConnectModeEnum.adModeReadWrite,
                 ADODB.RecordCreateOptionsEnum.adCreateNonCollection,
                 ADODB.RecordOpenOptionsEnum.adOpenRecordUnspecified,
                 "Namwah", "ParaW0rld");

            Rec.Fields["DAV:contentclass"].Value = "nw:content-classes:invHistory";
            Rec.Fields["urn:schemas:httpmail:subject"].Value = Subject;
            Rec.Fields["nw:partno"].Value = ItemNo;
            Rec.Fields["nw:partname"].Value = ItemName;
            Rec.Fields["nw:parttype"].Value = ItemType;
            Rec.Fields["nw:inv:refno"].Value = RefNo;
            Rec.Fields["nw:inv:reftype"].Value = RefType; 
            Rec.Fields["nw:inv:totalqty"].Value = int.Parse(Qty.ToString());
            Rec.Fields["nw:inv:sectionqty"].Value = Qty.ToString();
            Rec.Fields["nw:inv:vendefectqty"].Value = int.Parse(VendDefectQty.ToString());
            Rec.Fields["nw:inv:defectqty"].Value = int.Parse(DefectQty.ToString());
            Rec.Fields["nw:inv:section"].Value = "";
            Rec.Fields["nw:inv:ok"].Value = OK;
            Rec.Fields["nw:supplier"].Value = Supplier;
            Rec.Fields["nw:inv:remark"].Value = Remark;
            Rec.Fields["nw:inv:supplierdn"].Value = DN;
            Rec.Fields["nw:inv:status"].Value = Status;
            //Rec.Fields["urn:schemas:httpmail:fromname"].Value = CreatedBy;
            Rec.Fields["nw:inv:io"].Value = IO;
            　
            if (IO == "Input")
                Rec.Fields["http://schemas.microsoft.com/exchange/outlookmessageclass"].Value = "IPM.Post.invparts_szinput";
            else
                Rec.Fields["http://schemas.microsoft.com/exchange/outlookmessageclass"].Value = "IPM.Post.invparts_szoutput";

            Rec.Fields.Update();

            Logger.For(this).Info(string.Format("结束.  编码 : {0}", ItemNo));
        }

        #region field

        // Fields...

        private string _CreatedBy = "";
        private string _Remark = "";
        private string _DN = "";
        private string _Supplier = "";
        private double _VendDefectQty = 0;
        private double _DefectQty = 0;
        private double _Qty = 0;
        private double _SISQty = 0;
        private string _ItemType = "";
        private string _ItemName = "";
        private string _ItemNo = "";
        private string _IO = "";
        private string _Status = "";
        private string _RefType = "";
        private string _RefNo = "";

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
            }
        }

        private string _OK = "";
        public string OK
        {
            get { return _OK; }
            set { _OK = value; }
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

        public string Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }

        public string IO
        {
            get
            {
                return _IO;
            }
            set
            {
                _IO = value;
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

        public double SISQty
        {
            get
            {
                return _SISQty;
            }
            set
            {
                _SISQty = value;
            }
        }

        public double Qty
        {
            get
            {
                return _Qty;
            }
            set
            {
                _Qty = value;
            }
        }

        public double DefectQty
        {
            get
            {
                return _DefectQty;
            }
            set
            {
                _DefectQty = value;
            }
        }

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

        public string Supplier
        {
            get
            {
                return _Supplier;
            }
            set
            {
                _Supplier = value;
            }
        }

        public string DN
        {
            get
            {
                return _DN;
            }
            set
            {
                _DN = value;
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

        public string CreatedBy
        {
            get
            {
                return _CreatedBy;
            }
            set
            {
                _CreatedBy = value;
            }
        }

        #endregion

    }
}
