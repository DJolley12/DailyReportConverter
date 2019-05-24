using System.Collections.Generic;
using System.Linq;

namespace DailyReportConverter.Classes
{
    public class CSVParser
    {
        public string CSVFileString { get; set; }
        public string ProfitCenter { get; set; }
        public string MissionCallType { get; set; }
        public string MissionStatus { get; set; }
        private string formatedString { get; set; }

        public string[] FromLine(string line)
        {
            string[] data = line.Split('"');
            return data;
        }

        public List<Flight> ParseDataToFlightList(string[] data)
        {
            List<Flight> flights = new List<Flight>();
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Contains("Call Type Count"))
                {
                    break;
                }
                else if (data[i].Contains("RW Interfacility") || data[i].Contains("RW Scene")
                || data[i].Contains("FW Interfacility") || data[i].Contains("FW Scene")
                || data[i].Contains("Ground") || data[i].Contains("RF Interfacility (FW)")
                || data[i].Contains("SAR to Hosp"))
                {
                    if (!data[i - 1].Contains("SAR"))
                    {
                        int point = i;
                        int baseInt = cleanData(data, i);
                        Flight flight = Flight.ReturnFlight(data.Skip(point).ToArray(), baseInt);
                        flights.Add(flight);
                    }
                }
            }
            return flights;
        }

        private static int cleanData(string[] data, int i)
        {
            int j = i + 10;
            if (!data[j].Equals("Page") || !data[j].Equals("Vernal") 
                || !data[j].Equals("Lander") || !data[j].Equals("Riverton") 
                || !data[j].Equals("Moab") || !data[j].Equals("Steamboat Springs") 
                || !data[j].Equals("Rawlins") || !data[j].Equals("Craig") 
                || !data[j].Equals("Los Alamos") || !data[j].Equals("Glenwood") 
                || !data[j].Equals("Fort Mohave") || !data[j].Equals("Pocatello"))
            {
                for (int p = j - 5; p < i + 15; p++)
                {
                    if (data[p].Equals("Page") || data[p].Equals("Vernal")
                || data[p].Equals("Lander") || data[p].Equals("Riverton")
                || data[p].Equals("Moab") || data[p].Equals("Steamboat Springs")
                || data[p].Equals("Rawlins") || data[p].Equals("Craig")
                || data[p].Equals("Los Alamos") || data[p].Equals("Glenwood")
                || data[p].Equals("Fort Mohave") || data[p].Equals("Pocatello"))
                    {
                        j = p - i;
                        return j;
                    }
                }
            }
            j -= i;
            return j;
        }
    }
}
