using System.Collections.Generic;
using System.Drawing;

namespace TJQ
{
    public class MSExcel
    {
        private List<string> AirportCodePH = new List<string>()
        {
            "MNL", "PPS", "CRK", "NOP", "MYZ", "MLP", "MBO", "MRQ", "MBT", "WNP",
            "OMC", "OZC", "PAG", "/LZ", "RXS", "SJI", "SGL", "NCP", "SFS", "SUG",
            "TAC", "TAG", "TUG", "VRC", "ZAM", "DPL", "BAG", "BQA", "BSO", "BPH",
            "BXU", "CGY", "CYP", "CGM", "CYZ", "CBO", "DAE", "DVO", "BCD", "DGT",
            "GES", "IGN", "ILO", "IPE", "JOL", "KLO", "LAO", "CEB", "LGP", "LBX"
        };

        public bool Export(List<TJQModel> TJQ210M, List<TJQModel> TJQ3501, List<TJQModel> TJQ3502,
            List<TJQModel> TJQ31D7, string date, string path)
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application();

            excelApp.SheetsInNewWorkbook = 4;

            var excelWorkBook = excelApp.Workbooks.Add();

            var excelWorkSheetMNLPH210M = new Microsoft.Office.Interop.Excel.Worksheet();
                  
            excelWorkSheetMNLPH210M = excelWorkBook.Worksheets.Item[1];

            var excelWorkSheetMNLPH3501 = new Microsoft.Office.Interop.Excel.Worksheet();

            excelWorkSheetMNLPH3501 = excelWorkBook.Worksheets.Item[2];

            var excelWorkSheetMNLPH3502 = new Microsoft.Office.Interop.Excel.Worksheet();

            excelWorkSheetMNLPH3502 = excelWorkBook.Worksheets.Item[3];

            var excelWorkSheetMNLPH31D7 = new Microsoft.Office.Interop.Excel.Worksheet();

            excelWorkSheetMNLPH31D7 = excelWorkBook.Worksheets.Item[4];

            //===================MNLPH210M=======================
            excelWorkSheetMNLPH210M.Name = "MNLPH210M";

            //====================HEADER=========================
            Microsoft.Office.Interop.Excel.Range format = excelWorkSheetMNLPH210M.Range[excelWorkSheetMNLPH210M.Cells[4,1], excelWorkSheetMNLPH210M.Cells[4,22]];

            format.Font.Bold = true;

            format.Font.Size = 11;

            format.Font.Name = "Calibri";

            format.ColumnWidth = 15;

            format.HorizontalAlignment = -4108;

            format.VerticalAlignment = -4108;

            format.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(41, 57, 85));

            format.Font.Color = ColorTranslator.ToOle(Color.FromArgb(214,219,233));

            excelWorkSheetMNLPH210M.Cells[1, 1] = "TJQ Report - 210M";

            excelWorkSheetMNLPH210M.Cells[2, 1] = date;

            excelWorkSheetMNLPH210M.Cells[4, 1] = "TICKET NO";

            excelWorkSheetMNLPH210M.Cells[4, 2] = "DATE ISSUED";

            excelWorkSheetMNLPH210M.Cells[4, 3] = "RECORD LOCATOR";

            excelWorkSheetMNLPH210M.Cells[4, 4] = "BOOKING DATE";

            excelWorkSheetMNLPH210M.Cells[4, 5] = "INVOICE NO";

            excelWorkSheetMNLPH210M.Cells[4, 6] = "INVOICE DATE";

            excelWorkSheetMNLPH210M.Cells[4, 7] = "AIRLINE CODE";

            excelWorkSheetMNLPH210M.Cells[4, 8] = "CLIENT NO";

            excelWorkSheetMNLPH210M.Cells[4, 9] = "CLIENT NAME";

            excelWorkSheetMNLPH210M.Cells[4, 10] = "PAX NAME";

            excelWorkSheetMNLPH210M.Cells[4, 11] = "ITINERARY";

            excelWorkSheetMNLPH210M.Cells[4, 12] = "QUANTITY";

            excelWorkSheetMNLPH210M.Cells[4, 13] = "CURRENCY";

            excelWorkSheetMNLPH210M.Cells[4, 14] = "PUBLISH AMOUNT";

            excelWorkSheetMNLPH210M.Cells[4, 15] = "NET AMOUNT";

            excelWorkSheetMNLPH210M.Cells[4, 16] = "COMMISSION";

            excelWorkSheetMNLPH210M.Cells[4, 17] = "TOTAL TAX";

            excelWorkSheetMNLPH210M.Cells[4, 18] = "NET PAYABLE";

            excelWorkSheetMNLPH210M.Cells[4, 19] = "BOOKING AGENT";

            excelWorkSheetMNLPH210M.Cells[4, 20] = "PH TAX";

            excelWorkSheetMNLPH210M.Cells[4, 21] = "STATUS";

            excelWorkSheetMNLPH210M.Cells[4, 22] = "OUTBOUND";

            TravComService travcom = new TravComService();

            for (int ctr = 0; ctr < TJQ210M.Count; ctr++)
            {
                var record = travcom.CheckIfPosted(TJQ210M[ctr].DOCNO);

                if (record == null)
                {
                    record = travcom.CheckIfUnPosted(TJQ210M[ctr].DOCNO);
                }

                excelWorkSheetMNLPH210M.Cells[ctr + 5, 1] = TJQ210M[ctr].DOCNO;

                excelWorkSheetMNLPH210M.Cells[ctr + 5, 3] = TJQ210M[ctr].RELOC;

                excelWorkSheetMNLPH210M.Cells[ctr + 5, 21] = TJQ210M[ctr].TRNC;

                if (record != null)
                {
                    excelWorkSheetMNLPH210M.Cells[ctr + 5, 2] = record.InvoiceDate;

                    excelWorkSheetMNLPH210M.Cells[ctr + 5, 4] = record.BookingDate;

                    excelWorkSheetMNLPH210M.Cells[ctr + 5, 7] = record.AirlineCode;

                    excelWorkSheetMNLPH210M.Cells[ctr + 5, 8] = record.ProfileNo;

                    excelWorkSheetMNLPH210M.Cells[ctr + 5, 9] = record.ProfileName;

                    excelWorkSheetMNLPH210M.Cells[ctr + 5, 10] = record.PassengerName;

                    excelWorkSheetMNLPH210M.Cells[ctr + 5, 11] = record.DepartureCityCode + "-" + record.ArrivalCityCode;

                    excelWorkSheetMNLPH210M.Cells[ctr + 5, 12] = "1";

                    excelWorkSheetMNLPH210M.Cells[ctr + 5, 13] = record.CurrencyCode;

                    excelWorkSheetMNLPH210M.Cells[ctr + 5, 14] = record.PublishedFare;

                    excelWorkSheetMNLPH210M.Cells[ctr + 5, 15] = record.NetFare;

                    excelWorkSheetMNLPH210M.Cells[ctr + 5, 16] = record.CommissionAmount;

                    excelWorkSheetMNLPH210M.Cells[ctr + 5, 17] = (record.Tax1 + record.Tax2);

                    excelWorkSheetMNLPH210M.Cells[ctr + 5, 18] = record.NetPayable;

                    excelWorkSheetMNLPH210M.Cells[ctr + 5, 19] = record.FullName;

                    excelWorkSheetMNLPH210M.Cells[ctr + 5, 20] = record.Tax1;

                    if (AirportCodePH.Contains(record.DepartureCityCode) && !AirportCodePH.Contains(record.ArrivalCityCode))
                        excelWorkSheetMNLPH210M.Cells[ctr + 5, 22] = "YES";
                }
                else //No record in TravCom
                {
                    excelWorkSheetMNLPH210M.Cells[ctr + 5, 15] = excelWorkSheetMNLPH210M.Cells[ctr + 5, 14] = TJQ210M[ctr].AMOUNT; //NetFare and Publish Fare

                    excelWorkSheetMNLPH210M.Cells[ctr + 5, 16] = TJQ210M[ctr].COMM;

                    excelWorkSheetMNLPH210M.Cells[ctr + 5, 17] = TJQ210M[ctr].TAX;
                }
            }//For loop for MNLPH210M

            //===================MNLPH3501=======================
            excelWorkSheetMNLPH3501.Name = "MNLPH3501";

            //====================HEADER=========================
            format = excelWorkSheetMNLPH3501.Range[excelWorkSheetMNLPH3501.Cells[4, 1], excelWorkSheetMNLPH3501.Cells[4, 22]];

            format.Font.Bold = true;

            format.Font.Size = 11;

            format.Font.Name = "Calibri";

            format.ColumnWidth = 15;

            format.HorizontalAlignment = -4108;

            format.VerticalAlignment = -4108;

            format.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(41, 57, 85));

            format.Font.Color = ColorTranslator.ToOle(Color.FromArgb(214, 219, 233));

            excelWorkSheetMNLPH3501.Cells[1, 1] = "TJQ Report - 3501";

            excelWorkSheetMNLPH3501.Cells[2, 1] = date;

            excelWorkSheetMNLPH3501.Cells[4, 1] = "TICKET NO";

            excelWorkSheetMNLPH3501.Cells[4, 2] = "DATE ISSUED";

            excelWorkSheetMNLPH3501.Cells[4, 3] = "RECORD LOCATOR";

            excelWorkSheetMNLPH3501.Cells[4, 4] = "BOOKING DATE";

            excelWorkSheetMNLPH3501.Cells[4, 5] = "INVOICE NO";

            excelWorkSheetMNLPH3501.Cells[4, 6] = "INVOICE DATE";

            excelWorkSheetMNLPH3501.Cells[4, 7] = "AIRLINE CODE";

            excelWorkSheetMNLPH3501.Cells[4, 8] = "CLIENT NO";

            excelWorkSheetMNLPH3501.Cells[4, 9] = "CLIENT NAME";

            excelWorkSheetMNLPH3501.Cells[4, 10] = "PAX NAME";

            excelWorkSheetMNLPH3501.Cells[4, 11] = "ITINERARY";

            excelWorkSheetMNLPH3501.Cells[4, 12] = "QUANTITY";

            excelWorkSheetMNLPH3501.Cells[4, 13] = "CURRENCY";

            excelWorkSheetMNLPH3501.Cells[4, 14] = "PUBLISH AMOUNT";

            excelWorkSheetMNLPH3501.Cells[4, 15] = "NET AMOUNT";

            excelWorkSheetMNLPH3501.Cells[4, 16] = "COMMISSION";

            excelWorkSheetMNLPH3501.Cells[4, 17] = "TOTAL TAX";

            excelWorkSheetMNLPH3501.Cells[4, 18] = "NET PAYABLE";

            excelWorkSheetMNLPH3501.Cells[4, 19] = "BOOKING AGENT";

            excelWorkSheetMNLPH3501.Cells[4, 20] = "PH TAX";

            excelWorkSheetMNLPH3501.Cells[4, 21] = "STATUS";

            excelWorkSheetMNLPH3501.Cells[4, 22] = "OUTBOUND";

            for (int ctr = 0; ctr < TJQ3501.Count; ctr++)
            {
                var record = travcom.CheckIfPosted(TJQ3501[ctr].DOCNO);

                if (record == null)
                {
                    record = travcom.CheckIfUnPosted(TJQ3501[ctr].DOCNO);
                }

                excelWorkSheetMNLPH3501.Cells[ctr + 5, 21] = TJQ3501[ctr].TRNC;

                excelWorkSheetMNLPH3501.Cells[ctr + 5, 1] = TJQ3501[ctr].DOCNO;

                excelWorkSheetMNLPH3501.Cells[ctr + 5, 3] = TJQ3501[ctr].RELOC;

                if (record != null)
                {
                    excelWorkSheetMNLPH3501.Cells[ctr + 5, 2] = record.InvoiceDate;

                    excelWorkSheetMNLPH3501.Cells[ctr + 5, 4] = record.BookingDate;

                    excelWorkSheetMNLPH3501.Cells[ctr + 5, 7] = record.AirlineCode;

                    excelWorkSheetMNLPH3501.Cells[ctr + 5, 8] = record.ProfileNo;

                    excelWorkSheetMNLPH3501.Cells[ctr + 5, 9] = record.ProfileName;

                    excelWorkSheetMNLPH3501.Cells[ctr + 5, 10] = record.PassengerName;

                    excelWorkSheetMNLPH3501.Cells[ctr + 5, 11] = record.DepartureCityCode + "-" + record.ArrivalCityCode;

                    excelWorkSheetMNLPH3501.Cells[ctr + 5, 12] = "1";

                    excelWorkSheetMNLPH3501.Cells[ctr + 5, 13] = record.CurrencyCode;

                    excelWorkSheetMNLPH3501.Cells[ctr + 5, 14] = record.PublishedFare;

                    excelWorkSheetMNLPH3501.Cells[ctr + 5, 15] = record.NetFare;

                    excelWorkSheetMNLPH3501.Cells[ctr + 5, 16] = record.CommissionAmount;

                    excelWorkSheetMNLPH3501.Cells[ctr + 5, 17] = (record.Tax1 + record.Tax2);

                    excelWorkSheetMNLPH3501.Cells[ctr + 5, 18] = record.NetPayable;

                    excelWorkSheetMNLPH3501.Cells[ctr + 5, 19] = record.FullName;

                    excelWorkSheetMNLPH3501.Cells[ctr + 5, 20] = record.Tax1;

                    if (AirportCodePH.Contains(record.DepartureCityCode) && !AirportCodePH.Contains(record.ArrivalCityCode))
                        excelWorkSheetMNLPH3501.Cells[ctr + 5, 22] = "YES";
                }
                else //No Record in TravCom
                {
                    excelWorkSheetMNLPH3501.Cells[ctr + 5, 15] = excelWorkSheetMNLPH3501.Cells[ctr + 5, 14] = TJQ3501[ctr].AMOUNT; //NetFare and Publish Fare

                    excelWorkSheetMNLPH3501.Cells[ctr + 5, 16] = TJQ3501[ctr].COMM;

                    excelWorkSheetMNLPH3501.Cells[ctr + 5, 17] = TJQ3501[ctr].TAX;
                }
            }//For loop for MNLPH3501

            //===================MNLPH3502=======================
            excelWorkSheetMNLPH3502.Name = "MNLPH3502";

            //====================HEADER=========================
            format = excelWorkSheetMNLPH3502.Range[excelWorkSheetMNLPH3502.Cells[4, 1], excelWorkSheetMNLPH3502.Cells[4, 22]];

            format.Font.Bold = true;

            format.Font.Size = 11;

            format.Font.Name = "Calibri";

            format.ColumnWidth = 15;

            format.HorizontalAlignment = -4108;

            format.VerticalAlignment = -4108;

            format.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(41, 57, 85));

            format.Font.Color = ColorTranslator.ToOle(Color.FromArgb(214, 219, 233));

            excelWorkSheetMNLPH3502.Cells[1, 1] = "TJQ Report - 3501";

            excelWorkSheetMNLPH3502.Cells[2, 1] = date;

            excelWorkSheetMNLPH3502.Cells[4, 1] = "TICKET NO";

            excelWorkSheetMNLPH3502.Cells[4, 2] = "DATE ISSUED";

            excelWorkSheetMNLPH3502.Cells[4, 3] = "RECORD LOCATOR";

            excelWorkSheetMNLPH3502.Cells[4, 4] = "BOOKING DATE";

            excelWorkSheetMNLPH3502.Cells[4, 5] = "INVOICE NO";

            excelWorkSheetMNLPH3502.Cells[4, 6] = "INVOICE DATE";

            excelWorkSheetMNLPH3502.Cells[4, 7] = "AIRLINE CODE";

            excelWorkSheetMNLPH3502.Cells[4, 8] = "CLIENT NO";

            excelWorkSheetMNLPH3502.Cells[4, 9] = "CLIENT NAME";

            excelWorkSheetMNLPH3502.Cells[4, 10] = "PAX NAME";

            excelWorkSheetMNLPH3502.Cells[4, 11] = "ITINERARY";

            excelWorkSheetMNLPH3502.Cells[4, 12] = "QUANTITY";

            excelWorkSheetMNLPH3502.Cells[4, 13] = "CURRENCY";

            excelWorkSheetMNLPH3502.Cells[4, 14] = "PUBLISH AMOUNT";

            excelWorkSheetMNLPH3502.Cells[4, 15] = "NET AMOUNT";

            excelWorkSheetMNLPH3502.Cells[4, 16] = "COMMISSION";

            excelWorkSheetMNLPH3502.Cells[4, 17] = "TOTAL TAX";

            excelWorkSheetMNLPH3502.Cells[4, 18] = "NET PAYABLE";

            excelWorkSheetMNLPH3502.Cells[4, 19] = "BOOKING AGENT";

            excelWorkSheetMNLPH3502.Cells[4, 20] = "PH TAX";

            excelWorkSheetMNLPH3502.Cells[4, 21] = "STATUS";

            excelWorkSheetMNLPH3502.Cells[4, 22] = "OUTBOUND";

            for (int ctr = 0; ctr < TJQ3502.Count; ctr++)
            {
                var record = travcom.CheckIfPosted(TJQ3502[ctr].DOCNO);

                if (record == null)
                {
                    record = travcom.CheckIfUnPosted(TJQ3502[ctr].DOCNO);
                }

                excelWorkSheetMNLPH3502.Cells[ctr + 5, 1] = TJQ3502[ctr].DOCNO;

                excelWorkSheetMNLPH3502.Cells[ctr + 5, 3] = TJQ3502[ctr].RELOC;

                excelWorkSheetMNLPH3502.Cells[ctr + 5, 21] = TJQ3502[ctr].TRNC;

                if (record != null)
                {
                    excelWorkSheetMNLPH3502.Cells[ctr + 5, 2] = record.InvoiceDate;

                    excelWorkSheetMNLPH3502.Cells[ctr + 5, 4] = record.BookingDate;

                    excelWorkSheetMNLPH3502.Cells[ctr + 5, 7] = record.AirlineCode;

                    excelWorkSheetMNLPH3502.Cells[ctr + 5, 8] = record.ProfileNo;

                    excelWorkSheetMNLPH3502.Cells[ctr + 5, 9] = record.ProfileName;

                    excelWorkSheetMNLPH3502.Cells[ctr + 5, 10] = record.PassengerName;

                    excelWorkSheetMNLPH3502.Cells[ctr + 5, 11] = record.DepartureCityCode + "-" + record.ArrivalCityCode;

                    excelWorkSheetMNLPH3502.Cells[ctr + 5, 12] = "1";

                    excelWorkSheetMNLPH3502.Cells[ctr + 5, 13] = record.CurrencyCode;

                    excelWorkSheetMNLPH3502.Cells[ctr + 5, 14] = record.PublishedFare;

                    excelWorkSheetMNLPH3502.Cells[ctr + 5, 15] = record.NetFare;

                    excelWorkSheetMNLPH3502.Cells[ctr + 5, 16] = record.CommissionAmount;

                    excelWorkSheetMNLPH3502.Cells[ctr + 5, 17] = (record.Tax1 + record.Tax2);

                    excelWorkSheetMNLPH3502.Cells[ctr + 5, 18] = record.NetPayable;
                
                    excelWorkSheetMNLPH3502.Cells[ctr + 5, 19] = record.FullName;

                    excelWorkSheetMNLPH3502.Cells[ctr + 5, 20] = record.Tax1;

                    if (AirportCodePH.Contains(record.DepartureCityCode) && !AirportCodePH.Contains(record.ArrivalCityCode))
                        excelWorkSheetMNLPH3502.Cells[ctr + 5, 22] = "YES";
                }
                else //No Record in TravCom
                {
                    excelWorkSheetMNLPH3502.Cells[ctr + 5, 15] = excelWorkSheetMNLPH3502.Cells[ctr + 5, 14] = TJQ3502[ctr].AMOUNT; //NetFare and Publish Fare

                    excelWorkSheetMNLPH3502.Cells[ctr + 5, 16] = TJQ3502[ctr].COMM;

                    excelWorkSheetMNLPH3502.Cells[ctr + 5, 17] = TJQ3502[ctr].TAX;
                }
            }//For loop for MNLPH3502

            //=====================MNLPH31D7========================
            excelWorkSheetMNLPH31D7.Name = "MNLPH31D7";

            //=====================HEADER=======================
            format = excelWorkSheetMNLPH31D7.Range[excelWorkSheetMNLPH31D7.Cells[4, 1], excelWorkSheetMNLPH31D7.Cells[4, 22]];

            format.Font.Bold = true;

            format.Font.Size = 11;

            format.Font.Name = "Calibri";

            format.ColumnWidth = 15;

            format.HorizontalAlignment = -4108;

            format.VerticalAlignment = -4108;

            format.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(41, 57, 85));

            format.Font.Color = ColorTranslator.ToOle(Color.FromArgb(214, 219, 233));

            excelWorkSheetMNLPH31D7.Cells[1, 1] = "TJQ Report - 31D7";

            excelWorkSheetMNLPH31D7.Cells[2, 1] = date;

            excelWorkSheetMNLPH31D7.Cells[4, 1] = "TICKET NO";

            excelWorkSheetMNLPH31D7.Cells[4, 2] = "DATE ISSUED";

            excelWorkSheetMNLPH31D7.Cells[4, 3] = "RECORD LOCATOR";

            excelWorkSheetMNLPH31D7.Cells[4, 4] = "BOOKING DATE";

            excelWorkSheetMNLPH31D7.Cells[4, 5] = "INVOICE NO";

            excelWorkSheetMNLPH31D7.Cells[4, 6] = "INVOICE DATE";

            excelWorkSheetMNLPH31D7.Cells[4, 7] = "AIRLINE CODE";

            excelWorkSheetMNLPH31D7.Cells[4, 8] = "CLIENT NO";

            excelWorkSheetMNLPH31D7.Cells[4, 9] = "CLIENT NAME";

            excelWorkSheetMNLPH31D7.Cells[4, 10] = "PAX NAME";

            excelWorkSheetMNLPH31D7.Cells[4, 11] = "ITINERARY";

            excelWorkSheetMNLPH31D7.Cells[4, 12] = "QUANTITY";

            excelWorkSheetMNLPH31D7.Cells[4, 13] = "CURRENCY";

            excelWorkSheetMNLPH31D7.Cells[4, 14] = "PUBLISH AMOUNT";

            excelWorkSheetMNLPH31D7.Cells[4, 15] = "NET AMOUNTH";

            excelWorkSheetMNLPH31D7.Cells[4, 16] = "COMMISSION";

            excelWorkSheetMNLPH31D7.Cells[4, 17] = "TOTAL TAX";

            excelWorkSheetMNLPH31D7.Cells[4, 18] = "NET PAYABLE";

            excelWorkSheetMNLPH31D7.Cells[4, 19] = "BOOKING AGENT";

            excelWorkSheetMNLPH31D7.Cells[4, 20] = "PH TAX";

            excelWorkSheetMNLPH31D7.Cells[4, 21] = "STATUS";

            excelWorkSheetMNLPH31D7.Cells[4, 22] = "OUTBOUND";

            for(int ctr = 0; ctr < TJQ31D7.Count; ctr++)
            {
                var record = travcom.CheckIfPosted(TJQ31D7[ctr].DOCNO);

                if(record == null)
                {
                    record = travcom.CheckIfUnPosted(TJQ31D7[ctr].DOCNO);
                }

                excelWorkSheetMNLPH31D7.Cells[ctr + 5, 21] = TJQ31D7[ctr].TRNC;

                excelWorkSheetMNLPH31D7.Cells[ctr + 5, 1] = TJQ31D7[ctr].DOCNO;

                excelWorkSheetMNLPH31D7.Cells[ctr + 5, 3] = TJQ31D7[ctr].RELOC;

                if(record != null)
                {
                    excelWorkSheetMNLPH31D7.Cells[ctr + 5, 2] = record.InvoiceDate;

                    excelWorkSheetMNLPH31D7.Cells[ctr + 5, 4] = record.BookingDate;

                    excelWorkSheetMNLPH31D7.Cells[ctr + 5, 7] = record.AirlineCode;

                    excelWorkSheetMNLPH31D7.Cells[ctr + 5, 8] = record.ProfileNo;

                    excelWorkSheetMNLPH31D7.Cells[ctr + 5, 9] = record.ProfileName;

                    excelWorkSheetMNLPH31D7.Cells[ctr + 5, 10] = record.PassengerName;

                    excelWorkSheetMNLPH31D7.Cells[ctr + 5, 11] = record.DepartureCityCode + "-" + record.ArrivalCityCode;

                    excelWorkSheetMNLPH31D7.Cells[ctr + 5, 12] = "1";

                    excelWorkSheetMNLPH31D7.Cells[ctr + 5, 13] = record.CurrencyCode;

                    excelWorkSheetMNLPH31D7.Cells[ctr + 5, 14] = record.PublishedFare;

                    excelWorkSheetMNLPH31D7.Cells[ctr + 5, 15] = record.NetFare;

                    excelWorkSheetMNLPH31D7.Cells[ctr + 5, 16] = record.CommissionAmount;

                    excelWorkSheetMNLPH31D7.Cells[ctr + 5, 17] = (record.Tax1 + record.Tax2);

                    excelWorkSheetMNLPH31D7.Cells[ctr + 5, 18] = record.NetPayable;

                    excelWorkSheetMNLPH31D7.Cells[ctr + 5, 19] = record.FullName;

                    excelWorkSheetMNLPH31D7.Cells[ctr + 5, 20] = record.Tax1;

                    if(AirportCodePH.Contains(record.DepartureCityCode) && !AirportCodePH.Contains(record.ArrivalCityCode))
                        excelWorkSheetMNLPH31D7.Cells[ctr + 5, 22] = "YES";
                }
                else //NO RECORD IN TRAVCOM
                {
                    excelWorkSheetMNLPH31D7.Cells[ctr + 5, 15] = excelWorkSheetMNLPH31D7.Cells[ctr + 5, 14] = TJQ31D7[ctr].AMOUNT;

                    excelWorkSheetMNLPH31D7.Cells[ctr + 5, 16] = TJQ31D7[ctr].COMM;

                    excelWorkSheetMNLPH31D7.Cells[ctr + 5, 17] = TJQ31D7[ctr].TAX;
                }
            }//For Lopp for MNLPH31D7

            //==============SAVE EXCEL FILE===================
            excelWorkBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault);

            excelWorkBook.Close();

            excelApp.Quit();

            return true;
        }
    }
}
