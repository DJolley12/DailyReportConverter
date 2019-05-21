using System;
using System.Collections.Generic;
using DailyReportConverter.Properties;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace DailyReportConverter.Classes
{
    public static class ExcelWriter
    {
        public static void WriteToExcelTemplate(List<BaseTotal> baseTotals)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Excel.Application();
            Excel.Workbook sheet = excel.Workbooks.Open(Settings.Default["TemplateFilePath"].ToString());
            Excel.Worksheet x = excel.ActiveSheet as Excel.Worksheet;

            int i = 1;

            int rwTot = 0;
            int fwTot = 0;
            int grTot = 0;
            int tot1Tot = 0;
            int tdTot = 0;
            int miTot = 0;
            int caTot = 0;
            int sarTot = 0;
            int tot2Tot = 0;
            int allTotTot = 0;

            foreach (var baseTotal in baseTotals)
            {
                int rw = baseTotal.RW;
                int fw = baseTotal.FW;
                int gr = baseTotal.Ground;
                int tot1 = baseTotal.RW + baseTotal.FW + baseTotal.Ground;
                int td = baseTotal.Turndown;
                int mi = baseTotal.Missed;
                int ca = baseTotal.Cancel;
                int sar = baseTotal.SAR_NT_AT;
                int tot2 = baseTotal.Turndown + baseTotal.Missed + baseTotal.Cancel + baseTotal.SAR_NT_AT;
                int alltot = baseTotal.RW + baseTotal.FW + baseTotal.Ground +
                        baseTotal.Turndown + baseTotal.Missed + baseTotal.Cancel + baseTotal.SAR_NT_AT;

                string rwStr = rw.ToString();
                string fwStr = fw.ToString();
                string grStr = gr.ToString();
                string tot1Str = tot1.ToString();
                string tdStr = td.ToString();
                string miStr = mi.ToString();
                string caStr = ca.ToString();
                string sarStr = sar.ToString();
                string tot2Str = tot2.ToString();
                string alltotStr = alltot.ToString();


                if (rwStr == "0")
                {
                    rwStr = "";
                }

                if (fwStr == "0")
                {
                    fwStr = "";
                }

                if (grStr == "0")
                {
                    grStr = "";
                }

                if (tdStr == "0")
                {
                    tdStr = "";
                }

                if (miStr == "0")
                {
                    miStr = "";
                }

                if (caStr == "0")
                {
                    caStr = "";
                }

                if (sarStr == "0")
                {
                    sarStr = "";
                }

                x.Cells[2, i + 1] = rwStr;
                x.Cells[3, i + 1] = fwStr;
                x.Cells[4, i + 1] = grStr;
                x.Cells[5, i + 1] = tot1;
                x.Cells[8, i + 1] = tdStr;
                x.Cells[9, i + 1] = miStr;
                x.Cells[10, i + 1] = caStr;
                x.Cells[11, i + 1] = sarStr;
                x.Cells[12, i + 1] = tot2;
                x.Cells[14, i + 1] = alltot;

                rwTot += rw;
                fwTot += fw;
                grTot += gr;
                tot1Tot += tot1;
                tdTot += td;
                miTot += mi;
                caTot += ca;
                sarTot += sar;
                tot2Tot += tot2;
                allTotTot += alltot;

                i++;
            }

            x.Cells[2, 14] = rwTot;
            x.Cells[3, 14] = fwTot;
            x.Cells[4, 14] = grTot;
            x.Cells[5, 14] = tot1Tot;
            x.Cells[8, 14] = tdTot;
            x.Cells[9, 14] = miTot;
            x.Cells[10, 14] = caTot;
            x.Cells[11, 14] = sarTot;
            x.Cells[12, 14] = tot2Tot;
            x.Cells[14, 14] = allTotTot;


            sheet.Close(true, Type.Missing, Type.Missing);
            excel.Quit();
        }

        public static void WriteToExcelTemplate(List<Flight> flights)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Excel.Application();
            Excel.Workbook sheet = excel.Workbooks.Open(Settings.Default["TemplateFilePath"].ToString());
            Excel.Worksheet x = excel.ActiveSheet as Excel.Worksheet;
            
            Base[] baseParams =
            {
                Base.Page, Base.Vernal,Base.Lander,
                Base.Riverton, Base.Moab, Base.Steamboat,
                Base.Rawlins, Base.Craig, Base.LosAlamos,
                Base.Glenwood, Base.FortMohave, Base.Pocatello
            };

            Status[] searchStatusParams =
            {
                Status.Turndown,
                Status.Missed,
                Status.Cancel,
                Status.SAR_NT_AT
            };

            CallType[] searchCallTypeParams =
            {
                CallType.RW,
                CallType.FW,
                CallType.Ground
            };



        foreach (var _base in baseParams)
        {
            foreach (var callType in searchCallTypeParams)
            {
                foreach (var status in searchStatusParams)
                {
                    int cellData = dataQuery(flights, callType, _base, status);
                        x.Cells[returnRowCell(callType, status), returnBaseCell(_base)] = returnCellEntry(cellData);
                    }
            }
        };

        sheet.Close(true, Type.Missing, Type.Missing);
        excel.Quit();
        }

        private static int dataQuery(List<Flight> flights, CallType callType, Base _base, Status status)
        {
            int result = flights.Where(d => d.ProfitCenter == _base)
                .Where(c => c.MissionCallType == callType)
                .Where(s => s.MissionStatus == status).Count();
            return result;
        }

        private static object returnCellEntry(int cellNumber)
        {
            switch (cellNumber)
            {
                case 0:
                    return "";
                default:
                    return cellNumber;
            }
        }

        private static int returnBaseCell(Base _base)
        {
            switch (_base)
            {
                case Base.Page:
                    return 2;
                case Base.Vernal:
                    return 3;
                case Base.Lander:
                    return 4;
                case Base.Riverton:
                    return 5;
                case Base.Moab:
                    return 6;
                case Base.Steamboat:
                    return 7;
                case Base.Rawlins:
                    return 8;
                case Base.Craig:
                    return 9;
                case Base.LosAlamos:
                    return 10;
                case Base.Glenwood:
                    return 11;
                case Base.FortMohave:
                    return 12;
                case Base.Pocatello:
                    return 13;
                default:
                    throw new Exception("Unrecognized base: " + _base);
            }
        }

        private static int returnRowCell(CallType callType, Status status)
        {
            int rowCell = 0;

            if (status == Status.MissionComplete)
            {
                if (status == Status.SAR_NT_AT)
                {
                    rowCell = 11;
                }
                else if (callType == CallType.RW)
                {
                    rowCell = 2;
                }
                else if (callType == CallType.FW)
                {
                    rowCell = 3;
                }
                else if (callType == CallType.Ground)
                {
                    rowCell = 4;
                }
            }
            else if (status == Status.Turndown)
            {
                rowCell = 8;
            }
            else if (status == Status.Missed)
            {
                rowCell = 9;
            }
            else if (status == Status.Cancel)
            {
                rowCell = 10;
            }
            else if (status == Status.SAR_NT_AT)
            {
                rowCell = 11;
            }
            else
            {
                throw new Exception("Status type not recognized: " + status);
            }
            return rowCell;
        }

        private static Excel.Worksheet insertDataIntoCells(List<BaseTotal> baseTotals, Excel.Worksheet x)
        {
            for (int i = 0; i < baseTotals.Count; i++)
            {
                foreach (var baseTotal in baseTotals)
                {
                    x.Cells[2, i + 2] = baseTotal.RW;
                    x.Cells[3, i + 2] = baseTotal.FW;
                    x.Cells[4, i + 2] = baseTotal.Ground;
                    x.Cells[5, i + 2] = baseTotal.RW + baseTotal.FW + baseTotal.Ground;
                    x.Cells[8, i + 2] = baseTotal.Turndown;
                    x.Cells[9, i + 2] = baseTotal.Missed;
                    x.Cells[10, i + 2] = baseTotal.Cancel;
                    x.Cells[11, i + 2] = baseTotal.SAR_NT_AT;
                    x.Cells[12, i + 2] = baseTotal.Turndown + baseTotal.Missed + baseTotal.Cancel + baseTotal.SAR_NT_AT;
                    x.Cells[14, i + 2] = baseTotal.RW + baseTotal.FW + baseTotal.Ground +
                        baseTotal.Turndown + baseTotal.Missed + baseTotal.Cancel + baseTotal.SAR_NT_AT;
                }
            }
            return x;
        }
    }
}
