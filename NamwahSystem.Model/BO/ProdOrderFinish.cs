using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using NamwahSystem.Model.Func;

namespace NamwahSystem.Model.BO
{
    [Table("ProdOrderFinish")]
    public class ProdOrderFinish : BaseBusinessObject
    {
        private const string SZInvHisPath = "http://nwszmail/public/namwah/Inventory/sz_Finished/History/";
        public MySqlConnection CnnMySQL;

        public void Save()
        {
            SaveToExchange();
        }

        private void SaveToExchange()
        {
            Logger.For(this).Info(string.Format("开始.  编码 : {0}", ItemNo));

            ADODB.Record Rec = new ADODB.Record();
            string Subject = string.Format("{0}_{1}", DateTime.Now.ToString("yyMMddhhmmss"), ItemNo);
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
            Rec.Fields["nw:inv:reftype"].Value = "SS";
            Rec.Fields["nw:inv:totalqty"].Value = int.Parse(OKQty.ToString());
            Rec.Fields["nw:inv:sectionqty"].Value = OKQty.ToString();
            Rec.Fields["nw:inv:vendefectqty"].Value = int.Parse(VendDefectQty.ToString());
            Rec.Fields["nw:inv:defectqty"].Value = int.Parse(DefectQty.ToString());
            Rec.Fields["nw:inv:section"].Value = "";
            Rec.Fields["nw:inv:ok"].Value = "";
            Rec.Fields["nw:supplier"].Value = Supplier;
            Rec.Fields["nw:inv:remark"].Value = Remark;
            Rec.Fields["nw:inv:supplierdn"].Value = ProdOrderNo;
            Rec.Fields["nw:inv:status"].Value = Status;
            //Rec.Fields["urn:schemas:httpmail:fromname"].Value = CreatedBy;

            Rec.Fields["nw:inv:io"].Value = IOType.ToString();

            if (IOType == WHIOType.Input)
                Rec.Fields["http://schemas.microsoft.com/exchange/outlookmessageclass"].Value = "IPM.Post.invparts_szinput";
            else
                Rec.Fields["http://schemas.microsoft.com/exchange/outlookmessageclass"].Value = "IPM.Post.invparts_szoutput";

            Rec.Fields.Update();

            Logger.For(this).Info(string.Format("结束.  编码 : {0}", ItemNo));
        }

        #region Fields

        public int? id { get; set; }

        private string _ProdOrderNo = "";
        public string ProdOrderNo
        {
            get { return _ProdOrderNo; }
            set { _ProdOrderNo = value; }
        }

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
