
namespace DailyReportConverter.Classes
{
    public class Flight
    {
        public CallType MissionCallType { get; set; }
        public Status MissionStatus { get; set; }
        public Base ProfitCenter { get; set; }

        private string baseString { get; set; }

        public string BaseString
        {
            get
            {
                return baseString;
            }

            set
            {
                baseString = FlightPropertiesExtensions.GetBaseNameString(this.ProfitCenter);
            }
        }

        private string statusString { get; set; }

        public string StatusString
        {
            get
            {
                return statusString;
            }
            set
            {
                statusString = FlightPropertiesExtensions.GetStatusTypeString(this.MissionStatus);
            }
        }

        private string callTypeString { get; set; }

        public string CallTypeString
        {
            get
            {
                return callTypeString;
            }
            set
            {
                callTypeString = FlightPropertiesExtensions.GetCallTypeString(this.MissionCallType);
            }
        }

        public string FullInfo
        {
            get
            {
                return $"{BaseString} {StatusString} {CallTypeString}";
            }
        }

        public static Flight ReturnFlight(string[] data, int baseInt)
        {
            return new Flight()
            {
                MissionCallType = FlightPropertiesExtensions.ReturnCallType(data[0].ToString()),
                MissionStatus = FlightPropertiesExtensions.ReturnStatusType(data[2].ToString(), data[0].ToString()),
                ProfitCenter = FlightPropertiesExtensions.ReturnBaseType(data[baseInt].ToString())
            };
        }

    }

    public enum CallType
    {
        RW,
        FW,
        Ground
    }

    public enum Status
    {
        MissionComplete,
        Turndown,
        Missed,
        Cancel,
        SAR_NT_AT
    }

    public enum Base
    {
        Page,
        Vernal,
        Lander,
        Riverton,
        Moab,
        Steamboat,
        Rawlins,
        Craig,
        LosAlamos,
        Glenwood,
        FortMohave,
        Pocatello
    }
}
