using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OldNamwahSystem.BO;

namespace OldNamwahSystem.Func
{
    class SplitOrder
    {
        public static List<SalesOrderLine> SortSOLines(List<SalesOrderLine> SOLines)
        {
            return SOLines.OrderBy(S => S.PromisedDate).OrderByDescending(S => S.Priority).ToList();
        }

        public static List<SalesOrderLine> SplitSOLineByDateAndPriority(List<SalesOrderLine> SOLines)
        {
            List<SalesOrderLine> ListTmp = new List<SalesOrderLine>();
            
            foreach (SalesOrderLine SOLine in SOLines)
            {
                SOLine.InitPList();
                Dictionary<int, ProjInfo> DictProjInfo = DateAndPriorityToDict(SOLine.PriorityList, SOLine.PromisedDateList);
                int OrderSubIndex = 1;

                foreach (KeyValuePair<int, ProjInfo> KvpProjInfo in DictProjInfo)
                {
                    ProjInfo ProjInfo = KvpProjInfo.Value;
                    SalesOrderLine NewSOLine = new SalesOrderLine();
                    NewSOLine.Copy(SOLine);
                    NewSOLine.PromisedDate = ProjInfo.Date;
                    NewSOLine.Priority = ProjInfo.Priority;
                    NewSOLine.NeedQty = ProjInfo.Qty;
                    NewSOLine.ShippedQty = 0;
                    NewSOLine.PriorityList = string.Format("{0} ({1})", ProjInfo.Priority, ProjInfo.Qty);
                    NewSOLine.PromisedDateList = string.Format("{0} ({1})", ProjInfo.Date.ToString("yy-MMM-dd"), ProjInfo.Qty);
                    NewSOLine.OrderSubIndex = OrderSubIndex;
                    OrderSubIndex++;

                    ListTmp.Add(NewSOLine);
                }
            }

            return ListTmp;
        }

        // 14-Jan-01 (65), 14-Jan-06 (610), 14-Jan-15 (180), 14-Jan-16 (633), 14-Feb-19 (10), 14-Apr-23 (602)
        // 0 (1498), -6 (602)

        public static Dictionary<int, ProjInfo> DateAndPriorityToDict(string PriorityList, string PromisedDateList)
        {
            Dictionary<int, ProjInfo> DictTmp = new Dictionary<int, ProjInfo>();
            Dictionary<DateTime, double> DictPromDate = PromisedDateListToDict(PromisedDateList, "ASC");
            Dictionary<int, double> DictPriority = PriorityListToDict(PriorityList, "DESC");

            foreach (KeyValuePair<DateTime, double> KvpPromisedDate in DictPromDate)
            {
                double BalQty = KvpPromisedDate.Value;

                for (int Index = 0; Index < DictPriority.Count; Index++)
                {
                    var KvpPriority = DictPriority.ElementAt(Index);
                    
                //}

                //foreach (KeyValuePair<int, double> KvpPriority in DictPriority)
                //{
                    if (KvpPriority.Value > 0)
                    {
                        ProjInfo ProjInfo = new ProjInfo();
                        ProjInfo.Date = KvpPromisedDate.Key;
                        ProjInfo.Priority = KvpPriority.Key;

                        if (KvpPriority.Value > BalQty)
                        {
                            ProjInfo.Qty = BalQty;
                            DictPriority[KvpPriority.Key] = DictPriority[KvpPriority.Key] - BalQty;
                            BalQty = 0;
                        }
                        else
                        {
                            ProjInfo.Qty = KvpPriority.Value;
                            BalQty = BalQty - KvpPriority.Value;
                            DictPriority[KvpPriority.Key] = 0;
                        }
                        DictTmp.Add(DictTmp.Count, ProjInfo);

                        if (BalQty == 0)
                            break;
                    }
                }
            }

            return DictTmp;
        }

        public static string FillPromisedDateList(string OriList, double FillQty, DateTime DefaultDate)
        {
            Dictionary<DateTime, double> DictTmp = PromisedDateListToDict(OriList);
            Dictionary<DateTime, double> Dict = new Dictionary<DateTime, double>();
            double BalQty = FillQty;
            double TmpQty = 0;

            foreach (KeyValuePair<DateTime, double> KVP in DictTmp)
            {
                if (KVP.Value > BalQty)
                {
                    TmpQty = BalQty;
                    BalQty = 0;
                }
                else
                {
                    TmpQty = KVP.Value;
                    BalQty = BalQty - KVP.Value;
                }

                if (TmpQty > 0)
                {
                    if (Dict.ContainsKey(KVP.Key))
                        Dict[KVP.Key] = Dict[KVP.Key] + TmpQty;
                    else
                        Dict.Add(KVP.Key, TmpQty);

                }
            }

            if (BalQty > 0)
            {
                if (Dict.ContainsKey(DefaultDate))
                    Dict[DefaultDate] = Dict[DefaultDate] + BalQty;
                else
                    Dict.Add(DefaultDate, BalQty);

            }

            return DictToPromisedDateList(Dict);
        }

        public static string SortPromisedDateList(string OriList, string Order)
        {
            OriList = OriList.Trim();

            if (OriList == "")
                return "";

            Dictionary<DateTime, double> Dict = PromisedDateListToDict(OriList, Order);
            return DictToPromisedDateList(Dict);

        }

        public static string DictToPromisedDateList(Dictionary<DateTime, double> Dict)
        {
            StringBuilder SB = new StringBuilder();

            foreach (KeyValuePair<DateTime, double> KVP in Dict)
            {
                SB.Append(string.Format("{0} ({1}), ", KVP.Key.ToString("yy-MMM-dd"), KVP.Value));
            }

            if (SB.ToString() != "")
                return SB.ToString().Substring(0, SB.ToString().Length - 2);
            else
                return "";


        }

        public static Dictionary<DateTime, double> PromisedDateListToDict(string PromisedDateList)
        {
            Dictionary<DateTime, double> DictTmp = new Dictionary<DateTime, double>();

            PromisedDateList = PromisedDateList.Trim();

            if (PromisedDateList == "")
                return DictTmp;

            try
            {
                string[] Lists = PromisedDateList.Split(',');

                foreach (string TmpList in Lists)
                {
                    string SubList = TmpList.Trim();

                    if (SubList != "")
                    {
                        int PosStart = SubList.IndexOf('(');
                        int PosEnd = SubList.IndexOf(')');
                        DateTime PromisedDate = DateTime.Parse("20" + SubList.Substring(0, PosStart).Trim());
                        double Qty = double.Parse(SubList.Substring(PosStart + 1, PosEnd - PosStart - 1).Trim());

                        if (DictTmp.ContainsKey(PromisedDate))
                            DictTmp[PromisedDate] = DictTmp[PromisedDate] + Qty;
                        else
                            DictTmp.Add(PromisedDate, Qty);

                    }
                }
            }
            catch(Exception ex)
            {
                Logger.For(typeof(SplitOrder)).Error(string.Format("PromisedDateList : {0}.  Error : {1}", PromisedDateList, ex.Message));
                //throw ex;
            }

            return DictTmp;

        }

        public static Dictionary<DateTime, double> PromisedDateListToDict(string PromisedDateList, string Order)
        {
            Dictionary<DateTime, double> DictTmp = PromisedDateListToDict(PromisedDateList);
            Dictionary<DateTime, double> Dict = new Dictionary<DateTime, double>();
            var DictLinq = from P in DictTmp orderby P.Key ascending select P;

            if (Order == "DESC")
                DictLinq = from P in DictTmp orderby P.Key descending select P;

            foreach (KeyValuePair<DateTime, double> KVP in DictLinq)
            {
                Dict.Add(KVP.Key, KVP.Value);
            }

            return Dict;

        }

        public static string FillPriorityList(string OriList, double FillQty, int DefaultPriority)
        {
            Dictionary<int, double> DictTmp = PriorityListToDict(OriList);
            Dictionary<int, double> Dict = new Dictionary<int, double>();
            double BalQty = FillQty;
            double TmpQty = 0;

            foreach (KeyValuePair<int, double> KVP in DictTmp)
            {
                if (KVP.Value > BalQty)
                {
                    TmpQty = BalQty;
                    BalQty = 0;
                }
                else
                {
                    TmpQty = KVP.Value;
                    BalQty = BalQty - KVP.Value;
                }

                if (TmpQty > 0)
                {
                    if (Dict.ContainsKey(KVP.Key))
                        Dict[KVP.Key] = Dict[KVP.Key] + TmpQty;
                    else
                        Dict.Add(KVP.Key, TmpQty);

                }
            }

            if (BalQty > 0)
            {
                if (Dict.ContainsKey(DefaultPriority))
                    Dict[DefaultPriority] = Dict[DefaultPriority] + BalQty;
                else
                    Dict.Add(DefaultPriority, BalQty);

            }

            return DictToPriorityList(Dict);

        }

        public static string SortPriorityList(string OriList, string Order)
        {
            if (OriList == "")
                return "";

            Dictionary<int, double> Dict = PriorityListToDict(OriList, Order);
            return DictToPriorityList(Dict);
        }

        public static string DictToPriorityList(Dictionary<int, double> Dict)
        {
            StringBuilder SB = new StringBuilder();

            foreach (KeyValuePair<int, double> KVP in Dict)
            {
                SB.Append(string.Format("{0} ({1}), ", KVP.Key, KVP.Value));
            }

            if (SB.ToString() != "")
                return SB.ToString().Substring(0, SB.ToString().Length - 2);
            else
                return "";

        }

        public static Dictionary<int, double> PriorityListToDict(string PriorityList)
        {
            // 0 (1498), -6 (602)

            Dictionary<int, double> DictTmp = new Dictionary<int, double>();
            
            PriorityList = PriorityList.Trim();
            
            if (PriorityList == "")
                return DictTmp;

            try
            {
                string[] Lists = PriorityList.Split(',');

                foreach (string TmpList in Lists)
                {
                    string SubList = TmpList.Trim();

                    if (SubList != "")
                    {
                        int PosStart = SubList.IndexOf('(');
                        int PosEnd = SubList.IndexOf(')');
                        int Priority = int.Parse(SubList.Substring(0, PosStart).Trim());
                        double Qty = double.Parse(SubList.Substring(PosStart + 1, PosEnd - PosStart - 1).Trim());

                        if (DictTmp.ContainsKey(Priority))
                            DictTmp[Priority] = DictTmp[Priority] + Qty;
                        else
                            DictTmp.Add(Priority, Qty);
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.For(typeof(SplitOrder)).Error(string.Format("PriorityList : {0}.  Error : {1}", PriorityList, ex.Message));
            }

            return DictTmp;
        }

        public static Dictionary<int, double> PriorityListToDict(string PriorityList, string Order)
        {
            Dictionary<int, double> DictTmp = PriorityListToDict(PriorityList);
            Dictionary<int, double> Dict = new Dictionary<int, double>();
            var DictLinq = from P in DictTmp orderby P.Key ascending select P;

            if (Order == "DESC")
                DictLinq = from P in DictTmp orderby P.Key descending select P;

            foreach (KeyValuePair<int, double> KVP in DictLinq)
            {
                Dict.Add(KVP.Key, KVP.Value);
            }

            return Dict;
        }

    }

    class ProjInfo
    {
        // Fields...
        private DateTime _Date;
        public DateTime Date
        {
            get
            {
                return _Date;
            }
            set
            {
                _Date = value;
            }
        }

        private double _Qty;
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

        private int _Priority;
        public int Priority
        {
            get
            {
                return _Priority;
            }
            set
            {
                _Priority = value;
            }
        }
    }
}
