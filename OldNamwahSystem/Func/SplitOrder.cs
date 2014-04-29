using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using OldNamwahSystem.BO;

namespace OldNamwahSystem.Func
{
    class SplitOrder
    {
        static ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static List<SalesOrderLine> SplitSOLine(List<SalesOrderLine> SOLines)
        {
            List<SalesOrderLine> TmpList = new List<SalesOrderLine>();

             
            return TmpList;
        }
        

        // 14-Jan-01 (65), 14-Jan-06 (610), 14-Jan-15 (180), 14-Jan-16 (633), 14-Feb-19 (10), 14-Apr-23 (602)
        // 0 (1498), -6 (602)

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
                Logger.Error(string.Format("PromisedDateList : {0}.  Error : {1}", PromisedDateList, ex.Message));
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
                Logger.Error(string.Format("PriorityList : {0}.  Error : {1}", PriorityList, ex.Message));
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
}
