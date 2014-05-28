using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using OldNamwahSystem.BO;

namespace OldNamwahSystem.Label
{
    class BoxLabel
    {
        [DllImport("TTNT.dll", EntryPoint = "openport")]
        public extern static void OpenPort(string port);

        [DllImport("TTNT.dll", EntryPoint = "setup")]
        public extern static void Setup(int Height, int Darkness, int Speed, int LabelType, int LabelGap, int BlackMark);

        [DllImport("TTNT.dll", EntryPoint = "sendcommand")]
        public extern static void SendCommand(string comm);

        [DllImport("TTNT.dll", EntryPoint = "closeport")]
        public extern static void ClosePort();

        [DllImport("TTNT.dll", EntryPoint = "RetryTimeout")]
        public extern static void RetryTimeout(string second);

        public Item Item;
        public string ItemNo = "";
        public string ItemName = "";
        public string ItemType = "";
        public string Revision = "01";
        public string Material = "";
        public string JSNo = "";

        public string SalesOrderNo = "";
        public string IRNo = "";
        public string Inspector = "";
        public string InspectSpec = "";
        public string InspectStatus = "";
        private int SourceType = 1;
        public string ShipMethod = "Air";
        public string Category = "";
        public double ShipQty = 0;

        private const int SOURCE_TYPE_CASE = 1;
        private const int SOURCE_TYPE_BAND = 2;

        public bool IsReady = false;

        public BoxLabel()
        {
            InitPrinter();
        }

        ~BoxLabel()
        {
            ClosePrinter();
        }

        public static void PrintCartonLabel(int CartonNo)
        {
            SendCommand("~MDEL");
            Setup(19, 6, 2, 0, 2, 0);
            SendCommand("^P1");
            SendCommand("^L");
            SendCommand(string.Format("AH,80,51,1,1,0,0,  {0}", CartonNo));
            SendCommand("E");
        }

        public void PrintLabel()
        {
            if (SalesOrderNo == "存仓")
            {
                PrintWHLabel();
                return;
            }

            PrintShipmentLabel();
        }

        public void PrintLabel(SoCompress SoCompress)
        {
            Item = SoCompress.Item;

            if (Item != null)
            {
                ItemNo = Item.CustomerItemNo;
                ItemName = Item.ItemName;
                ItemType = Item.ItemType;
                Material = Item.Material;

                if (ItemType == "BandAccessories") // endpiece, springbar, pin , bracelet
                {
                    SourceType = SOURCE_TYPE_BAND;
                }
                else
                {
                    SourceType = SOURCE_TYPE_CASE;
                }
            }

            Revision = SoCompress.Revision;
            SalesOrderNo = SoCompress.SalesOrderNo;
            Inspector = SoCompress.Inspector;
            InspectSpec = SoCompress.InspectSpec;
            InspectStatus = SoCompress.InspectStatus;
            JSNo = SoCompress.JSNo;

            if (SoCompress.Box1 == 0)
                return;

            ShipQty = SoCompress.Box1;
            PrintLabel();

            if (SoCompress.Box2 == 0)
                return;

            ShipQty = SoCompress.Box2;
            PrintLabel();

            if (SoCompress.Box3 == 0)
                return;

            ShipQty = SoCompress.Box3;
            PrintLabel();

            if (SoCompress.Box4 == 0)
                return;

            ShipQty = SoCompress.Box4;
            PrintLabel();

            if (SoCompress.Box5 == 0)
                return;

            ShipQty = SoCompress.Box5;
            PrintLabel();

        }

        private void PrintShipmentLabel()
        {
        /*
            Dim barcode As String, qtyCode As String, sourceTypeCode As String
        Dim I As Long
        */
            string Barcode, SourceTypeCode, QtyCode;
            string TSI = "";

        // Set Label Begin Sign
            SendCommand("^L");
            
            QtyCode = ShipQty.ToString().PadLeft(7, (char)48);
       
            if (SourceType == SOURCE_TYPE_CASE)
                SourceTypeCode = "XNX0000";
            else
                SourceTypeCode = "XXX0000";

            if (InspectStatus == "PRRI")
                TSI = "TSI";

            Barcode = string.Format("1PO{0}PN{1}X{2}00{3}Q{4}{5}{6}", SalesOrderNo, ItemNo.Substring(0, 3), 
                ItemNo.Substring(3, ItemNo.Length - 3), Revision, QtyCode, SourceTypeCode, TSI);

            /*
        barcode = "1PO" & cpoNo & "PN" & Left(partNo, 3) & "X" & Right(partNo, Len(partNo) - 3) & _
             "00" & revisionNo & "Q" & qtyCode & sourceTypeCode & TSI  ' Temp. add "TSI"
            */  
                
            SendCommand("Lo,504,54,507,1152");
            SendCommand(string.Format("BQ,568,1010,2,5,180,3,1,{0}", Barcode));
            SendCommand("Lo,76,686,504,689");
            SendCommand("AD,104,668,1,1,0,3,PO NUMBER");
            SendCommand("AD,236,664,1,1,0,3,P/N");
            SendCommand("AD,372,668,1,1,0,3,LOT QTY");

            SendCommand(string.Format("AE,420,640,1,1,0,3,{0}", InspectStatus));
        
            SendCommand("Lo,180,52,183,687");
            SendCommand("Lo,320,50,323,685");
            SendCommand("Lo,254,686,257,1155");
            SendCommand(string.Format("AG,72,334,1,1,0,3,{0}", SalesOrderNo));
            SendCommand(string.Format("AF,224,516,1,1,0,3,{0}-X{1}-00-{2}", ItemNo.Substring(0, 3), ItemNo.Substring(3, ItemNo.Length - 3), Revision));
            SendCommand(string.Format("AG,360,334,1,1,0,3,{0}", QtyCode));
            SendCommand("AC,270,1150,1,1,0,3,VENDOR:");
            SendCommand("AB,312,1138,1,1,0,3,Nam Wah Watch Case Factory Ltd");
        
            if (Material == "")
                SendCommand(string.Format("AB,348,1138,1,1,0,3,{0}{1}", ItemType , Category));
            else
                SendCommand(string.Format("AB,348,1138,1,1,0,3,{0}({1}){2}", ItemType , Material, Category));

            if (ItemName.Length > 35)
            {
                SendCommand(string.Format("AB,372,1138,1,1,0,3,{0}", ItemName.Substring(0, 35)));
                SendCommand(string.Format("AB,396,1118,1,1,0,3,{0}", ItemName.Substring(35, ItemName.Length - 35)));
            }
            else
            {
                SendCommand(string.Format("AB,372,1138,1,1,0,3,{0}", ItemName));
            }

            SendCommand("AC,68,1152,1,1,0,3,SHIP TO:");
            SendCommand("AB,118,1134,1,1,0,3,TMX PHILLIPINES INC.");
            SendCommand("AB,140,1134,1,1,0,3,MACTAN ECONOMIC ZONE 1");
            SendCommand("AB,162,1134,1,1,0,3,AIRPORT ROAD, ");
            SendCommand("AB,184,1134,1,1,0,3,LAPULAPU CITY, CEBU");
            SendCommand("AB,206,1134,1,1,0,3,PHILIPPINES");
        
            //SendCommand("Y40,10,LOGO")
            
            if (Inspector == "")
                SendCommand(string.Format("AB,415,1138,1,1,0,3,{0}", IRNo));
            else
                SendCommand(string.Format("AB,415,1138,1,1,0,3,{0}({1})", IRNo, Inspector));

        
            SendCommand(string.Format("AG,430,1138,1,1,0,3,{0}", ShipMethod));
            
            //End label formatting mode and print label
            SendCommand("E");
        }

        private void PrintWHLabel()
        {
            string TmpJsNo;
            // Set Label Begin Sing
            SendCommand("^L");
            SendCommand("AH,20,866,1,1,0,3,Safety Stock");
            SendCommand("AF,612,1156,1,1,0,3,Part:");
            SendCommand("AF,716,1150,1,1,0,3,Qty:");
            SendCommand("AE,128,484,1,1,0,3,FQC Date:");
            SendCommand("R602,80,694,968,3,3");
            SendCommand("AF,454,1154,1,1,0,3,Name:");
            SendCommand("R708,76,800,964,3,3");
        
            SendCommand(string.Format("AE,128,268,1,1,0,3,{0}", DateTime.Today.ToString("yyyy-MM-dd")));
            SendCommand(string.Format("AG,610,938,1,1,0,3,{0}-{1}", ItemNo, Revision));
            SendCommand(string.Format("AG,712,938,1,1,0,3,{0}", ShipQty));
            SendCommand("Lo,404,54,410,1167");

            if (ItemName.Length > 30)
            {
                SendCommand(string.Format("AF,454,956,1,1,0,3,{0}", ItemName.Substring(0, 30)));
                SendCommand(string.Format("AF,510,948,1,1,0,3,{0}", ItemName.Substring(30, ItemName.Length - 30)));
            }
            else
            {
                SendCommand(string.Format("AF,454,956,1,1,0,3,{0}", ItemName));
            }

            SendCommand("AE,128,1136,1,1,0,3,IR No:");
            SendCommand(string.Format("AE,128,964,1,1,0,3,{0}({1})", IRNo, Inspector));
            SendCommand("R440,80,586,970,3,3");
            SendCommand("AE,190,1138,1,1,0,3,Type:");
    
            if (Material == "")
                SendCommand(string.Format("AE,190,964,1,1,0,3,{0}", ItemType));
            else
                SendCommand(string.Format("AE,190,964,1,1,0,3,{0}({1})", ItemType, Material));

            TmpJsNo = JSNo;
            TmpJsNo = TmpJsNo.Substring(ItemNo.Length, TmpJsNo.Length - ItemNo.Length);
            TmpJsNo = string.Format("{0}-{1}{2}", ItemNo, Revision, TmpJsNo);

            SendCommand(string.Format("BQ,256,1130,2,5,100,3,1,{0}QTY{1}", TmpJsNo, ShipQty));
        
            //End label formatting mode and print label
            SendCommand("E");
        }

        private void InitPrinter()
        {
            try
            {
                OpenPort("5"); // LPT2
                RetryTimeout("10");
                
                // Reset
                // SendCommand("~Z");

                // Clear All Buffer
                SendCommand("~MDEL");
                SendCommand("^Q150,3");
                SendCommand("^W102");
                SendCommand("^E15");
                SendCommand("^H10");
                SendCommand("^P1");
                SendCommand("^S1");
                SendCommand("^C1");
                SendCommand("^R0");
                SendCommand("~Q+0");
                SendCommand("^O0");
                SendCommand("^D0");
                SendCommand("~R200");

                IsReady = true;
            }
            catch
            {

            }
        }

        private void ClosePrinter()
        {
            ClosePort();
        }
    }
}
