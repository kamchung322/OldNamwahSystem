using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace OldNamwahSystem.BO
{
    class WHHistory
    {

        public const string SZInvHisPath = "http://nwszmail/public/namwah/Inventory/sz_Finished/History/";

        static ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool SaveNewRecord()
        {
            if (Func.Glob.IsDebugMode)
                return true;

            Logger.Info("Start");

            ADODB.Record Rec;
            Rec = new ADODB.Record();
            string StrSQL = "";
            string Subject = string.Format("{0}_{1}", DateTime.Now.ToString("yyMMddhhmmss"), ItemNo ) ;

            StrSQL = string.Format("{0}{1}.eml", SZInvHisPath, Subject);

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
            Rec.Fields["nw:inv:reftype"].Value = "SS";
            Rec.Fields["nw:inv:totalqty"].Value = Qty;
            Rec.Fields["nw:inv:sectionqty"].Value = Qty.ToString();
            Rec.Fields["nw:inv:vendefectqty"].Value = VendDefectQty;
            Rec.Fields["nw:inv:defectqty"].Value = DefectQty;
            Rec.Fields["nw:inv:section"].Value = "";
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

            Logger.Info("End");

            return true;
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
