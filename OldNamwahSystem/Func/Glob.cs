using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldNamwahSystem.Func
{
    class Glob
    {
        public static bool IsDebugMode = true;
        public static string UserName = "";

        public static void AddADOHistory(ADODB.Record rst, string history)
        {
            rst.Fields["nw:history"].Value = string.Format("{0} {1} - {2}\n{3}",
                DateTime.Now.ToString("yyyy-MM-dd hh:mm"), Glob.UserName, history,
                rst.Fields["nw:history"].Value.ToString());
        }

        public static void IncreaseShipmentBarcode(int no)
        {
            string Prefix = "", Barcode = "";
            int NextSONo = 0;
            string BarcodePath = "http://nwszmail/public/namwah/system/barcodes/SZ_ShipOrderCode.EML";

            try
            {
                ADODB.Record Rec = new ADODB.Record();
                Rec.Open(BarcodePath, Type.Missing, ADODB.ConnectModeEnum.adModeReadWrite &
                    ADODB.ConnectModeEnum.adModeShareDenyWrite,
                    ADODB.RecordCreateOptionsEnum.adFailIfNotExists,
                    ADODB.RecordOpenOptionsEnum.adOpenRecordUnspecified, "Namwah", "ParaW0rld");

                Prefix = Rec.Fields["nw:barcode:prefix"].Value.ToString();
                NextSONo = int.Parse(Rec.Fields["nw:barcode:nextnumber"].Value.ToString());

                Rec.Fields["nw:barcode:nextnumber"].Value = NextSONo + no;
                Rec.Fields.Update();
                Rec = null;

            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }

        }

        public static string GetShipmentBarcode()
        {
            string Prefix = "", Barcode = "";
            int NextSONo = 0;
            string BarcodePath = "http://nwszmail/public/namwah/system/barcodes/SZ_ShipOrderCode.EML";

            try
            {
                ADODB.Connection Cnn = new ADODB.Connection();
                
                Cnn = ServerHelper.ConnectExchange(BarcodePath);
                ADODB.Record Rec = new ADODB.Record();

                Rec.Open(BarcodePath, Cnn, ADODB.ConnectModeEnum.adModeReadWrite,
                    ADODB.RecordCreateOptionsEnum.adFailIfNotExists,
                    ADODB.RecordOpenOptionsEnum.adOpenRecordUnspecified, "Namwah", "ParaW0rld");
                /*
                Rec.Open(BarcodePath, cnn, ADODB.ConnectModeEnum.adModeReadWrite &
                    ADODB.ConnectModeEnum.adModeShareDenyWrite, 
                    ADODB.RecordCreateOptionsEnum.adFailIfNotExists,
                    ADODB.RecordOpenOptionsEnum.adOpenRecordUnspecified, "Namwah", "ParaW0rld");
                */

                Prefix = Rec.Fields["nw:barcode:prefix"].Value.ToString();
                NextSONo = int.Parse(Rec.Fields["nw:barcode:nextnumber"].Value.ToString());
                Rec.Fields["nw:barcode:nextnumber"].Value = NextSONo + 1;
                Rec.Fields.Update();
                Rec = null;

                Barcode = string.Format("{0}{1}", Prefix, NextSONo.ToString("0000000"));
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }

            return Barcode;
        }

    }
}
