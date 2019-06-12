using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyReportConverter.Classes
{
    public class IncompleteFlight
    {
        public string FlightNumber { get; set; }

        public IncompleteFlight (string[] data, int i)
        {
            FlightNumber = ReturnFlightNumber(data, i);
        }

        public IncompleteFlight(string[] data)
        {
            FlightNumber = ReturnFlightNumber(data);
        }

        private string ReturnFlightNumber(string[] data, int i)
        {
            string flightNumber = "could not find flight number";
            string yearLastTwo = GetCurrentYear();
            for (int j = i; j < i + 15; j++)
            {
                if (data[j].Contains(yearLastTwo) && data[j].IndexOf(yearLastTwo) == 0)
                {
                    flightNumber = data[j];
                }
            }
            return flightNumber;
        }

        private string ReturnFlightNumber(string[] data)
        {
            string flightNumber = "could not find flight number";
            string yearLastTwo = GetCurrentYear();
            if (data[8].Contains(yearLastTwo))
            {
                for (int i = 5; i < 12; i++)
                {
                    if (data[i].Contains(yearLastTwo) && data[i].IndexOf(yearLastTwo) == 0)
                    {
                        flightNumber = data[i].Replace('"', ' ').Replace(',', ' ').Trim();
                    }
                }
            }
            return flightNumber;
        }

        private string GetCurrentYear()
        {
            DateTime date = DateTime.Now;
            string year = date.Year.ToString();
            string yearLastTwo = year.Substring(2, 2);
            return yearLastTwo;
        }
    }
}
