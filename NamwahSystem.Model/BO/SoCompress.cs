using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace NamwahSystem.Model.BO
{
    public class SoCompress
    {
        public static BindingList<SoCompress> CompressSO(List<Shipment> Shipments)
        {
            Dictionary<string, SoCompress> DictSoCompress = new Dictionary<string, SoCompress>();
            BindingList<SoCompress> SOCompresses = new BindingList<SoCompress>();
            SoCompress SOCompress;
            string Key;

            foreach (Shipment Shipment in Shipments)
            {
                Key = Shipment.SalesOrderNo + Shipment.ItemNo + Shipment.ShipMethod;
                Shipment.Item = Item.Load(Shipment.ItemNo);

                if (DictSoCompress.ContainsKey(Key))
                {
                    SOCompress = DictSoCompress[Key];
                    SOCompress.ShipQty = SOCompress.ShipQty + Shipment.MoveQty;
                }
                else
                {
                    SOCompress = new SoCompress();
                    SOCompress.Shipment = Shipment;
                    SOCompress.ShipMethod = Shipment.ShipMethod;
                    SOCompress.SalesOrderNo = Shipment.SalesOrderNo;
                    if (Shipment.Item != null)
                        SOCompress.BoxQty = Shipment.Item.BoxQty;

                    if (SOCompress.SalesOrderNo == "存仓")
                        SOCompress.BoxQty = 0;

                    SOCompress.ShipQty = Shipment.MoveQty;
                    DictSoCompress.Add(Key, SOCompress);
                }
            }

            foreach (KeyValuePair<string, SoCompress> KVP in DictSoCompress)
            {
                SOCompress = KVP.Value;
                SOCompress.Calc();

                do
                {
                    SoCompress TmpSOCompress = new SoCompress();
                    TmpSOCompress.Shipment = SOCompress.Shipment;
                    TmpSOCompress.Item = TmpSOCompress.Shipment.Item;
                    TmpSOCompress.ShipMethod = TmpSOCompress.Shipment.ShipMethod;
                    TmpSOCompress.SalesOrderNo = TmpSOCompress.Shipment.SalesOrderNo;
                    TmpSOCompress.MaxQty = SOCompress.MaxQty;
                    TmpSOCompress.BoxQty = SOCompress.BoxQty;

                    if (SOCompress.MaxQty > SOCompress.ShipQty)
                    {
                        TmpSOCompress.ShipQty = SOCompress.ShipQty;
                        SOCompress.ShipQty = 0;
                    }
                    else
                    {
                        TmpSOCompress.ShipQty = SOCompress.MaxQty;
                        SOCompress.ShipQty = SOCompress.ShipQty - SOCompress.MaxQty;
                    }

                    TmpSOCompress.Calc();
                    SOCompresses.Add(TmpSOCompress);

                } while (SOCompress.ShipQty > 0);
            }

            return SOCompresses;
        }

        public void Calc()
        {
            double RemainQty = ShipQty;

            if (BoxQty == 0)
            {
                MaxQty = double.MaxValue;
                Box1 = RemainQty;
                return;
            }
            else
            {
                MaxQty = BoxQty * 5;
            }

            if (RemainQty > BoxQty)
            {
                Box1 = BoxQty;
                RemainQty = RemainQty - BoxQty;
            }
            else
            {
                Box1 = RemainQty;
                RemainQty = 0;
                return;
            }

            if (RemainQty > BoxQty)
            {
                Box2 = BoxQty;
                RemainQty = RemainQty - BoxQty;
            }
            else
            {
                Box2 = RemainQty;
                RemainQty = 0;
                return;
            }

            if (RemainQty > BoxQty)
            {
                Box3 = BoxQty;
                RemainQty = RemainQty - BoxQty;
            }
            else
            {
                Box3 = RemainQty;
                RemainQty = 0;
                return;
            }

            if (RemainQty > BoxQty)
            {
                Box4 = BoxQty;
                RemainQty = RemainQty - BoxQty;
            }
            else
            {
                Box4 = RemainQty;
                RemainQty = 0;
                return;
            }

            if (RemainQty > BoxQty)
            {
                Box5 = BoxQty;
                RemainQty = RemainQty - BoxQty;
            }
            else
            {
                Box5 = RemainQty;
                RemainQty = 0;
                return;
            }
        }

        #region field

        public string JSNo = "";
        public double TotalBox = 5;

        private Shipment _Shipment;
        public Shipment Shipment
        {
            get
            {
                return _Shipment;
            }
            set
            {
                _Shipment = value;
            }
        }

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

                if (Revision == "" && _Item != null)
                    Revision = _Item.CustomerRevision;
            }
        }

        private string _ShipMethod;
        public string ShipMethod
        {
            get
            {
                return _ShipMethod;
            }
            set
            {
                _ShipMethod = value;
            }
        }

        private string _SalesOrderNo;
        public string SalesOrderNo
        {
            get
            {
                return _SalesOrderNo;
            }
            set
            {
                _SalesOrderNo = value;
            }
        }

        private string _IRNo = "";
        public string IRNo
        {
            get
            {
                return _IRNo;
            }
            set
            {
                _IRNo = value;
            }
        }

        private string _Inspector = "";
        public string Inspector
        {
            get
            {
                return _Inspector;
            }
            set
            {
                _Inspector = value;
            }
        }

        private string _InspectStatus = "NRI";
        public string InspectStatus
        {
            get
            {
                return _InspectStatus;
            }
            set
            {
                _InspectStatus = value;
            }
        }

        private string _InspectSpec = "";
        public string InspectSpec
        {
            get
            {
                return _InspectSpec;
            }
            set
            {
                _InspectSpec = value;
            }
        }

        private string _Revision = "";
        public string Revision
        {
            get
            {
                return _Revision;
            }
            set
            {
                _Revision = value;
            }
        }

        private double _MaxQty = 0;
        public double MaxQty
        {
            get
            {
                return _MaxQty;
            }
            set
            {
                _MaxQty = value;
            }
        }

        private double _ShipQty = 0;
        public double ShipQty
        {
            get
            {
                return _ShipQty;
            }
            set
            {
                _ShipQty = value;
            }
        }

        private double _BoxQty = 0;
        public double BoxQty
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

        private double _Box1 = 0;
        public double Box1
        {
            get
            {
                return _Box1;
            }
            set
            {
                _Box1 = value;
            }
        }

        private double _Box2 = 0;
        public double Box2
        {
            get
            {
                return _Box2;
            }
            set
            {
                _Box2 = value;
            }
        }

        private double _Box3 = 0;
        public double Box3
        {
            get
            {
                return _Box3;
            }
            set
            {
                _Box3 = value;
            }
        }

        private double _Box4 = 0;
        public double Box4
        {
            get
            {
                return _Box4;
            }
            set
            {
                _Box4 = value;
            }
        }

        private double _Box5 = 0;
        public double Box5
        {
            get
            {
                return _Box5;
            }
            set
            {
                _Box5 = value;
            }
        }
        #endregion
    }
}
