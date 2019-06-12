using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DailyReportConverter.Classes
{
    public class CSVParser
    {
        public string CSVFileString { get; set; }
        public string ProfitCenter { get; set; }
        public string MissionCallType { get; set; }
        public string MissionStatus { get; set; }
        public string InCompleteFlights { get; set; }
        private string formatedString { get; set; }

        public string[] ParseWithRegularExpressions(string line)
        {
            Regex pattern = new Regex("(\",\"|,,)");
            string[] data = pattern.Split(line);
            return data;
        }

        public string[] ParseWithRegularExpressionsByLine(string line)
        {
            Regex pattern = new Regex("\n");
            string[] data = pattern.Split(line);
            return data;
        }

        public List<Flight> ParseDataToFlightListByLine(string[] data)
        {
            List<Flight> flights = new List<Flight>();
            for (int i = 0; i < data.Length; i++)
            {
                Regex pattern = new Regex("(\",\"|,,)");
                string[] line = pattern.Split(data[i]);
                if (line.Length > 1)
                {

                    if (line[2].Contains("RW Interfacility") || line[2].Contains("RW Scene")
                    || line[2].Contains("FW Interfacility") || line[2].Contains("FW Scene")
                    || line[2].Contains("Ground") || line[2].Contains("RF Interfacility (FW)")
                    || line[2].Contains("SAR") || line[2].Contains("SAR To Hosp") || line[2].Contains("RF Scene (FW)"))
                    {
                        int baseInt = CleanData(line);
                        bool containsBase = DoesStringContainBase(line[baseInt]);
                        if (containsBase == false)
                        {
                            IncompleteFlight incompleteFlight = new IncompleteFlight(line);
                            ViewModel.IncompleteFlights.Add(incompleteFlight);
                        }
                        else
                        {
                            Flight flight = Flight.ReturnFlight(line, 2, 4, baseInt);
                            flights.Add(flight);
                        }

                    }
                }
            }
            return flights;
        }

        public string[] SplitData(string line)
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
                    || data[i].Contains("SAR") || data[i].Contains("SAR To Hosp") || data[i].Contains("RF Scene (FW)"))
                {
                    if (!data[i - 2].Contains("SAR"))
                    {
                        int point = i;
                        int baseInt = CleanData(data, i);
                        int checkPoint = baseInt + i;
                        bool containsBase = DoesStringContainBase(data[checkPoint]);
                        if (containsBase == false)
                        {
                            IncompleteFlight incompleteFlight = new IncompleteFlight(data, i);
                            ViewModel.IncompleteFlights.Add(incompleteFlight);
                        }
                        else
                        { 
                            Flight flight = Flight.ReturnFlight(data.Skip(point).ToArray(), baseInt);
                            flights.Add(flight);
                        }
                    }
                }
            }
            return flights;
        }

        private static int CleanData(string[] data, int i)
        {
            int j = i + 10;
            string checkString = data[j];
            bool containsBase = DoesStringContainBase(checkString);
            if (containsBase == false)
            {
                for (int p = j - 5; p < i + 15; p++)
                {
                    checkString = data[p];
                    containsBase = DoesStringContainBase(checkString);
                    if (containsBase == true)
                    {
                        j = p - i;
                        return j;
                    }
                }
                j = 0;
            }
            j -= i;
            return j;
        }

        private static int CleanData(string[] data)
        {
            string checkString = data[12];
            int baseLocation = 12;
            bool containsBase = DoesStringContainBase(checkString);
            if (containsBase == false)
            {
                for (int i = 6; i < data.Length; i++)
                {
                    checkString = data[i];
                    containsBase = DoesStringContainBase(checkString);
                    if (containsBase == true)
                    {
                        baseLocation = i;
                        return baseLocation;
                    }
                }
            }
            return baseLocation;
        }

        private static bool DoesStringContainBase(string checkString)
        {
            if (checkString.Contains("Page") || checkString.Contains("Vernal")
                || checkString.Contains("Lander") || checkString.Contains("Riverton")
                || checkString.Contains("Moab") || checkString.Contains("Steamboat Springs")
                || checkString.Contains("Rawlins") || checkString.Contains("Craig")
                || checkString.Contains("Los Alamos") || checkString.Contains("Glenwood Springs")
                || checkString.Contains("Fort Mohave") || checkString.Contains("Pocatello"))
            {
                return true;
            }
            return false;
        }
    }
}
