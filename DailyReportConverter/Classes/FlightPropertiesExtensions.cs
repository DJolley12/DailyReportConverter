using System;

namespace DailyReportConverter.Classes
{
    public static class FlightPropertiesExtensions
    {
        //public static Base ReturnBaseType(string baseString)
        //{
        //    switch (baseString)
        //    {
        //        case "Page":
        //            return Base.Page;
        //        case "Vernal":
        //            return Base.Vernal;
        //        case "Lander":
        //            return Base.Lander;
        //        case "Riverton":
        //            return Base.Riverton;
        //        case "Moab":
        //            return Base.Moab;
        //        case "Steamboat Springs":
        //            return Base.Steamboat;
        //        case "Rawlins":
        //            return Base.Rawlins;
        //        case "Craig":
        //            return Base.Craig;
        //        case "Los Alamos":
        //            return Base.LosAlamos;
        //        case "Glenwood Springs":
        //            return Base.Glenwood;
        //        case "Fort Mohave":
        //            return Base.FortMohave;
        //        case "Pocatello":
        //            return Base.Pocatello;
        //        default:
        //            throw new Exception("Unrecognized base: " + baseString);
        //    }
        //}

        public static Base ReturnBaseType(string baseString)
        {
            Base myBase = new Base();
            if (baseString.Contains("Page"))
            {
                myBase = Base.Page;
            }
            else if (baseString.Contains("Vernal"))
            {
                myBase = Base.Vernal;
            }
            else if (baseString.Contains("Lander"))
            {
                myBase = Base.Lander;
            }
            else if (baseString.Contains("Riverton"))
            {
                myBase = Base.Riverton;
            }
            else if (baseString.Contains("Moab"))
            {
                myBase = Base.Moab;
            }
            else if (baseString.Contains("Steamboat Springs"))
            {
                myBase = Base.Steamboat;
            }
            else if (baseString.Contains("Rawlins"))
            {
                myBase = Base.Rawlins;
            }
            else if (baseString.Contains("Craig"))
            {
                myBase = Base.Craig;
            }
            else if (baseString.Contains("Los Alamos"))
            {
                myBase = Base.LosAlamos;
            }
            else if (baseString.Contains("Glenwood Springs"))
            {
                myBase = Base.Glenwood;
            }
            else if (baseString.Contains("Fort Mohave"))
            {
                myBase = Base.FortMohave;
            }
            else if (baseString.Contains("Pocatello"))
            {
                myBase = Base.Pocatello;
            }
            else
            {
                throw new Exception("Base not recognized: " + baseString);
            }
            return myBase;
        }

        public static Status ReturnStatusType(string statusString)
        {
            Status status = new Status();
            if (statusString.Contains("Mission Complete"))
            {
                status = Status.MissionComplete;
            }
            else if (statusString.Contains("Turndown"))
            {
                status = Status.Turndown;
            }
            else if (statusString.Contains("Cancel"))
            {
                status = Status.Cancel;
            }
            else if (statusString.Contains("Missed Flight"))
            {
                status = Status.Missed;
            }
            else if (statusString.Contains("No Transport") || statusString.Contains("Abort") || statusString.Contains("SAR"))
            {
                status = Status.SAR_NT_AT;
            }
            else
            {
                throw new Exception("Status type not recognized: " + statusString);
            }
            return status;
        }

        public static CallType ReturnCallType(string callString)
        {
            CallType callType = new CallType();
            if (callString.Contains("RW Interfacility"))
            {
                callType = CallType.RW;
            }
            else if (callString.Contains("RW Scene"))
            {
                callType = CallType.RW;
            }
            else if (callString.Contains("FW Interfacility"))
            {
                callType = CallType.FW;
            }
            else if (callString.Contains("FW Scene"))
            {
                callType = CallType.FW;
            }
            else if (callString.Contains("Ground"))
            {
                callType = CallType.Ground;
            }
            else if (callString.Contains("RF Interfacility (FW)"))
            {
                callType = CallType.FW;
            }
            else if (callString.Contains("RF Scene (FW)"))
            {
                callType = CallType.FW;
            }
            else if (callString.Contains("SAR"))
            {
                callType = CallType.RW;
            }
            else if (callString.Contains("SAR to Hosp"))
            {
                callType = CallType.RW;
            }
            else
            {
                throw new Exception("Unrecognized Call Type: " + callString);
            }
            return callType;
        }

        public static string GetBaseNameString(Base myBase)
        {
            switch (myBase)
            {
                case Base.Page:
                    return "Page";
                case Base.Vernal:
                    return "Vernal";
                case Base.Lander:
                    return "Lander";
                case Base.Riverton:
                    return "Riverton";
                case Base.Moab:
                    return "Moab";
                case Base.Steamboat:
                    return "Steamboat";
                case Base.Rawlins:
                    return "Rawlins";
                case Base.Craig:
                    return "Craig";
                case Base.LosAlamos:
                    return "Los Alamos";
                case Base.Glenwood:
                    return "Glenwood";
                case Base.FortMohave:
                    return "Fort Mohave";
                case Base.Pocatello:
                    return "Pocatello";
                default:
                    throw new Exception("Unrecognized base: " + myBase);
            }
        }

        public static string GetCallTypeString(CallType callType)
        {
            switch (callType)
            {
                case CallType.RW:
                    return "RW";
                case CallType.FW:
                    return "FW";
                case CallType.Ground:
                    return "Ground";
                default:
                    throw new Exception("Unrecognized Call Type: " + callType);
            }
        }

        public static string GetStatusTypeString(Status status)
        {
            switch (status)
            {
                case Status.Turndown:
                    return "Turndown";
                case Status.Cancel:
                    return "Cancel";
                case Status.Missed:
                    return "Missed";
                case Status.MissionComplete:
                    return "Mission Complete";
                case Status.SAR_NT_AT:
                    return "SAR/NT/AT";
                default:
                    throw new Exception("Unrecognized base: " + status);
            }
        }
    }
}
