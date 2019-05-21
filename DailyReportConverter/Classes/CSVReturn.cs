using System;
using System.Collections.Generic;
using System.IO;

namespace DailyReportConverter.Classes
{
    class CSVReturn : BaseTotal
    {
        public string Header
        {
            get
            {
                return ",Page," + "Vernal," + "Lander," + "Riverton," 
                    + "Moab," + "Steamboat," + "Rawlins," + "Craig," 
                    + "Los Alamos," + "Glenwood," + "Fort Mohave," + "Pocatello";
            }
        }
        
        public string FormatToCSV(List<BaseTotal> baseTotals)
        {
            myBaseTotals = baseTotals;
            string rw = ReturnTotalRWToString();
            string fw = ReturnFWToString();
            string ground = ReturnGroundToString();
            string turndown = ReturnMissedToString();
            string missed = ReturnMissedToString();
            string cancel = ReturnCancelToString();
            string sar_etc = ReturnSAR_ETCToString();

            string csv = $"{Header}\n,{rw}\n,{fw}\n,{ground}\nTotals:\n\n,{turndown}\n,{missed}\n,{cancel}\n,{sar_etc}\nTotals:\n\nBase Totals:,";

            return csv;
        }

        public string Path { get; set; }

        public void WriteCSVFile(string csvString)
        {
            File.WriteAllText(Path, csvString);
        }

        public void OpenFile()
        {
            File.Open(Path, FileMode.Open);
        }
    }
}
