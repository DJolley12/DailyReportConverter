using System.Collections.Generic;
using System.Linq;

namespace DailyReportConverter.Classes
{
    public class BaseTotal
    {
        private static Base myBase { get; set; }
        private static Status myStatus { get; set; }
        private static CallType myCallType { get; set; }
        private static object mySearch { get; set; }

        public Base MyBase { get; set; }

        private static List<Flight> myFlights { get; set; }
        internal static List<BaseTotal> myBaseTotals { get; set; }

        private static int rw { get; set; }
        private static int fw { get; set; }
        private static int ground { get; set; }
        private static int turndown { get; set; }
        private static int missed { get; set; }
        private static int cancel { get; set; }
        private static int sar_etc { get; set; }

        public int RW { get; set; }
        public int FW { get; set; }
        public int Ground { get; set; }
        public int Turndown { get; set; }
        public int Missed { get; set; }
        public int Cancel { get; set; }
        public int SAR_NT_AT { get; set; }
        
        public static BaseTotal Page;
        public static BaseTotal Vernal;
        public static BaseTotal Lander;
        public static BaseTotal Riverton;
        public static BaseTotal Moab;
        public static BaseTotal Steamboat;
        public static BaseTotal Rawlins;
        public static BaseTotal Craig;
        public static BaseTotal LosAlamos;
        public static BaseTotal Glenwood;
        public static BaseTotal FortMohave;
        public static BaseTotal Pocatello;

        public List<BaseTotal> GetBaseTotalsList(List<Flight> flights)
        {
            myFlights = flights;
            List<BaseTotal> baseTotals = new List<BaseTotal>();

            Page = new BaseTotal(Base.Page);
            baseTotals.Add(Page);
            Vernal = new BaseTotal(Base.Vernal);
            baseTotals.Add(Vernal);
            Lander = new BaseTotal(Base.Lander);
            baseTotals.Add(Lander);
            Riverton = new BaseTotal(Base.Riverton);
            baseTotals.Add(Riverton);
            Moab = new BaseTotal(Base.Moab);
            baseTotals.Add(Moab);
            Steamboat = new BaseTotal(Base.Steamboat);
            baseTotals.Add(Steamboat);
            Rawlins = new BaseTotal(Base.Rawlins);
            baseTotals.Add(Rawlins);
            Craig = new BaseTotal(Base.Craig);
            baseTotals.Add(Craig);
            LosAlamos = new BaseTotal(Base.LosAlamos);
            baseTotals.Add(LosAlamos);
            Glenwood = new BaseTotal(Base.Glenwood);
            baseTotals.Add(Glenwood);
            FortMohave = new BaseTotal(Base.FortMohave);
            baseTotals.Add(FortMohave);
            Pocatello = new BaseTotal(Base.Pocatello);
            baseTotals.Add(Pocatello);

            return baseTotals;
        }

        private static Status[] searchStatusParams =
        {
            Status.Turndown,
            Status.Missed,
            Status.Cancel,
            Status.SAR_NT_AT
        };

        private static CallType[] searchCallTypeParams =
        {
            CallType.RW,
            CallType.FW,
            CallType.Ground
        };

        private static object[] searchCallTypeAssigned =
        {
            rw,
            fw,
            ground
        };

        private static object[] searchStatusAssigend =
        {
            turndown,
            missed,
            cancel,
            sar_etc
        };

        private static object[] searchBaseParams =
        {
            Base.Page, Base.Vernal,Base.Lander,
            Base.Riverton, Base.Moab, Base.Steamboat,
            Base.Rawlins, Base.Craig, Base.LosAlamos,
            Base.Glenwood, Base.FortMohave, Base.Pocatello
        };

        public BaseTotal()
        {
        }

        public BaseTotal(List<Flight> flights, Base _base)
        {
            myFlights = flights;
            myBase = _base;
            MyBase = myBase;
            ReturnBaseTotal();
        }

        public BaseTotal(Base _base)
        { 
            myBase = _base;
            MyBase = myBase;
            ReturnBaseTotal();
        }

        private BaseTotal ReturnBaseTotal()
        {
            for (int i = 0; i < searchCallTypeAssigned.Length; i++)
            {
                myCallType = searchCallTypeParams[i];
                getTotalCompletions();
            }
            RW = rw;
            FW = fw;
            Ground = ground;
            for (int i = 0; i < searchStatusParams.Length; i++)
            {
                myStatus = searchStatusParams[i];
                getTotalOthers();
            }
            Turndown = turndown;
            Missed = missed;
            Cancel = cancel;
            SAR_NT_AT = sar_etc;

            return new BaseTotal();
        }

        public string ReturnTotalRWToString()
        {
            List<int> rwList = myBaseTotals.Select(b => b.RW).ToList();
            string totalNumbers = "";

            foreach (var baseTotal in rwList)
            {
                totalNumbers += baseTotal.ToString() + ",";
            }
            return totalNumbers;
        }

        public string ReturnFWToString()
        {
            List<int> fwList = myBaseTotals.Select(b => b.FW).ToList();
            string totalNumbers = "";

            foreach (var baseTotal in fwList)
            {
                totalNumbers += baseTotal.ToString() + ",";
            }
            return totalNumbers;
        }

        public string ReturnGroundToString()
        {
            List<int> gList = myBaseTotals.Select(b => b.Ground).ToList();
            string totalNumbers = "";

            foreach (var baseTotal in gList)
            {
                totalNumbers += baseTotal.ToString() + ",";
            }
            return totalNumbers;
        }

        public string ReturnTurndownToString()
        {
            List<int> tdList = myBaseTotals.Select(b => b.Turndown).ToList();
            string totalNumbers = "";

            foreach (var baseTotal in tdList)
            {
                totalNumbers += baseTotal.ToString() + ",";
            }
            return totalNumbers;
        }

        public string ReturnMissedToString()
        {
            List<int> mList = myBaseTotals.Select(b => b.Missed).ToList();
            string totalNumbers = "";

            foreach (var baseTotal in mList)
            {
                totalNumbers += baseTotal.ToString() + ",";
            }
            return totalNumbers;
        }

        public string ReturnCancelToString()
        {
            List<int> cList = myBaseTotals.Select(b => b.Cancel).ToList();
            string totalNumbers = "";

            foreach (var baseTotal in cList)
            {
                totalNumbers += baseTotal.ToString() + ",";
            }
            return totalNumbers;
        }

        public string ReturnSAR_ETCToString()
        {
            List<int> sarList = myBaseTotals.Select(b => b.SAR_NT_AT).ToList();
            string totalNumbers = "";

            foreach (var baseTotal in sarList)
            {
                totalNumbers += baseTotal.ToString() + ",";
            }
            return totalNumbers;
        }

        private static void getTotalCompletions()
        {
            int totalCompletions = myFlights.Where(
                f => f.ProfitCenter == myBase
                && f.MissionStatus == Status.MissionComplete
                && f.MissionCallType == myCallType).Count();
            if (myCallType == CallType.RW)
            {
                rw = totalCompletions;
            }
            else if (myCallType == CallType.FW)
            {
                fw = totalCompletions;
            }
            else if (myCallType == CallType.Ground)
            {
                ground = totalCompletions;
            }
        }

        private static void getTotalOthers()
        {
            int totalOthers = myFlights.Where(
                f => f.ProfitCenter == myBase
                && f.MissionStatus == myStatus).Count();
            if (myStatus == Status.Turndown)
            {
                turndown = totalOthers;
            }
            else if (myStatus == Status.Missed)
            {
                missed = totalOthers;
            }
            else if (myStatus == Status.Cancel)
            {
                cancel = totalOthers;
            }
            else if (myStatus == Status.SAR_NT_AT)
            {
                sar_etc = totalOthers;
            }
        }
    }
}
