using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace OldNamwahSystem.Label
{
    class IRLabel
    {
        [DllImport("Ez2000.dll", EntryPoint = "openport")]
        public extern static void OpenPort(string port);

        [DllImport("Ez2000.dll", EntryPoint = "closeport")]
        public extern static void ClosePort();

        [DllImport("Ez2000.dll", EntryPoint = "setup")]
        public extern static void Setup(int Height, int Darkness, int Speed, int LabelType, int LabelGap, int BlackMark);

        [DllImport("Ez2000.dll", EntryPoint = "sendcommand")]
        public extern static void SendCommand(string comm);

        public string ItemNo = "";
        public string IRNo = "";
        public string Inspector = "";
        public string QualitySpec = "";
        public int NoOfCopy = 1;

        public bool IsReady = false;

        public IRLabel()
        {
            InitPrinter();
        }

        ~IRLabel()
        {
            ClosePrinter();
        }

        public void PrintLabel()
        {
            Setup(19, 6, 2, 0, 2, 0);
            SendCommand("^Q20,1");
            SendCommand("^W35");
            SendCommand("^E2");
            SendCommand("^H15");
            SendCommand("~MDEL");
            SendCommand("^P1");
            SendCommand("^C" + NoOfCopy);
            SendCommand("^L");

            if (QualitySpec == "GP12")
                SendCommand(string.Format("BQ,22,8,2,5,50,0,1,{0}(GP12)", ItemNo));
            else
                SendCommand(string.Format("BQ,22,8,2,5,50,0,1,{0}", ItemNo));

            SendCommand(string.Format("AC,6,96,1,1,0,0,{0}({1})", IRNo, Inspector));
            SendCommand("E");
        }

        private void InitPrinter()
        {
            try
            {
                OpenPort("0");  // LPT1
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
