using System;
using System.Collections.Generic;
using System.Linq;

namespace OldNamwahSystem.Func
{
    class Glob
    {
        public static bool IsDebugMode = false;
        public static string UserName = "Nam Wah System";
        public static string DefaultDatabase = "oldnamwahsystem"; // "test_nws"; //"oldnamwahsystem";

        public static string AddHistory(string OriginalHistory, string Message)
        {
            return string.Format("{0} {1} - {2}\n{3}",
                    DateTime.Now.ToString("yyyy-MM-dd hh:mm"), Glob.UserName,
                    Message, OriginalHistory);
        }

        public static void IncreaseShipmentBarcode(int No)
        {
            string Prefix = "";
            int NextSONo = 0;
            const string BarcodePath = "http://nwszmail/public/namwah/system/barcodes/SZ_ShipOrderCode.EML";
            Logger.For(typeof(Glob)).Info("开始");

            try
            {
                ADODB.Record Rec = new ADODB.Record();
                Rec.Open(BarcodePath, Type.Missing, ADODB.ConnectModeEnum.adModeReadWrite &
                    ADODB.ConnectModeEnum.adModeShareDenyWrite,
                    ADODB.RecordCreateOptionsEnum.adFailIfNotExists,
                    ADODB.RecordOpenOptionsEnum.adOpenRecordUnspecified, "Namwah", "ParaW0rld");

                Prefix = Rec.Fields["nw:barcode:prefix"].Value.ToString();
                NextSONo = int.Parse(Rec.Fields["nw:barcode:nextnumber"].Value.ToString());

                Rec.Fields["nw:barcode:nextnumber"].Value = NextSONo + No;
                Rec.Fields.Update();
                Rec = null;

            }
            catch (Exception ex)
            {
                Logger.For(typeof(Glob)).Error(ex.Message);
            }
            Logger.For(typeof(Glob)).Info("結束");
        }

        public static string GetShipmentBarcode()
        {
            string Prefix = "", Barcode = "";
            int NextSONo = 0;
            string BarcodePath = "http://nwszmail/public/namwah/system/barcodes/SZ_ShipOrderCode.EML";
            Logger.For(typeof(Glob)).Info("开始");
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
                Logger.For(typeof(Glob)).Error(ex.Message);
                //DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }

            Logger.For(typeof(Glob)).Info("結束");
            return Barcode;
        }


    }
}
