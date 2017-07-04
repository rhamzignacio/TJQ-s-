using System;
using System.Collections.Generic;
using System.Linq;

namespace TJQ
{
    public class AmadeusSellingPlatform : AmadeusDLLModel
    {
        List<string> temp = new List<string>();
        string errorString = "";
        List<string> checkTemp = new List<string>();

        public void JumpOfficeID(string officeID)
        {
            objSession.Send("IG"); //Ignore current PNR

            objSession.Send("JO"); //logout user

            objSession.Send("JUO"); //logout office ID

            if (Properties.Settings.Default.DefaultOID != officeID)
                objSession.Send("JUI/O-" + officeID); //login office ID
        }

        public void GetTJQData(string startDate = "", string endDate = "", string currency = "")
        {
            if (startDate != "" && endDate != "")
                ASPNext(objSession.Send("TJQ/SOF/D-" + DateTime.Parse(startDate).ToString("ddMMM") + DateTime.Parse(endDate).ToString("ddMMM") + "/C-" + currency));
            else if (startDate != "")
                ASPNext(objSession.Send("TJQ/SOF/D-" + DateTime.Parse(startDate).ToString("ddMMM") + "/C-" + currency));

            for (int rowCount = 0; rowCount < temp.Count - 1; rowCount++)
            {
                try
                {
                    if (errorString.Contains("REQUESTED DISPLAY NOT SCROLLABLE") || errorString.Contains("NO DATA FOUND") || errorString.Contains("TRANSACTION CODE NOT SUPPORTED") ||
                        errorString.Contains("CHECK TRANSACTION CODE"))
                        return;

                    if (temp[temp.Count - 1] == checkTemp[checkTemp.Count - 1])
                    {
                    }
                    else
                    {
                        ASPNext(objSession.Send("MD"));

                        rowCount = 0;
                    }
                }
                catch
                {
                    ASPNext(objSession.Send("MD"));

                    rowCount = 0;
                }
            }
        }

        public void ASPNext(k1aHostToolKit.HostResponse response)
        {
            for (short ctr = 0; ctr < response.NumberOfLines; ctr++)
            {
                if (response.GetLineFromBuffer(ref ctr).ToString() != "")
                {
                    if (response.GetLineFromBuffer(ref ctr).ToString().Contains("TKTT") || response.GetLineFromBuffer(ref ctr).ToString().Contains("CANN") ||
                        response.GetLineFromBuffer(ref ctr).ToString().Contains("RFND") || response.GetLineFromBuffer(ref ctr).ToString().Contains("CANX") ||
                        response.GetLineFromBuffer(ref ctr).ToString().Contains("CNJ") || response.GetLineFromBuffer(ref ctr).ToString().Contains("EMDS"))
                    {
                        var checkIfDupplicate = temp.FirstOrDefault(r => r.Contains(response.GetLineFromBuffer(ref ctr)));

                        if (checkIfDupplicate == null)
                            temp.Add(response.GetLineFromBuffer(ref ctr));
                        else
                            checkTemp.Add(response.GetLineFromBuffer(ref ctr));

                        errorString = "";
                    }
                    else
                        errorString = response.GetLineFromBuffer(ref ctr);
                }
            }
        }

        public List<TJQModel> GetMNLPH31D(string startDate = "", string endDate = "", string currency = "")
        {
            List<TJQModel> TJQList = new List<TJQModel>();

            temp = new List<string>(); //Clear temp string

            JumpOfficeID("MNLPH31D7");

            objSession.Send("JI" + Properties.Settings.Default.Username31D7 + "-" + Properties.Settings.Default.Password31D7);

            GetTJQData(startDate, endDate, currency);

            temp.ForEach(item =>
            {
                TJQModel tempTJQ = new TJQModel
                {
                    SEQNO = item.Substring(0, 5).Replace(" ", ""),
                    AL = item.Substring(7, 3).Replace(" ", ""),
                    DOCNO = item.Substring(11, 10).Replace(" ", ""),
                    AMOUNT = item.Substring(21, 10).Replace(" ", ""),
                    TAX = item.Substring(31, 10).Replace(" ", ""),
                    FEE = item.Substring(41, 7).Replace(" ", ""),
                    COMM = item.Substring(48, 5).Replace(" ", ""),
                    FP = item.Substring(53, 2).Replace(" ", ""),
                    PAXNAME = item.Substring(56, 8).Replace(" ", ""),
                    AS = item.Substring(65, 2).Replace(" ", ""),
                    RELOC = item.Substring(68, 6).Replace(" ", ""),
                    TRNC = item.Substring(75, 5).Replace(" ", "")
                };

                TJQList.Add(tempTJQ);
            });

            return TJQList;
        }
            

        public List<TJQModel> GetMNLPH210M(string startDate = "", string endDate = "", string currency = "")
        {
            List<TJQModel> TJQList = new List<TJQModel>();

            temp = new List<string>(); // Clear temp string

            JumpOfficeID("MNLPH210M");

            objSession.Send("JI" + Properties.Settings.Default.Username210M + "-" + Properties.Settings.Default.Password210M);

            GetTJQData(startDate, endDate, currency);

            temp.ForEach(item =>
            {
                TJQModel tempTJQ = new TJQModel
                {
                    SEQNO = item.Substring(0, 5).Replace(" ", ""),
                    AL = item.Substring(7, 3).Replace(" ", ""),
                    DOCNO = item.Substring(11, 10).Replace(" ", ""),
                    AMOUNT = item.Substring(21, 10).Replace(" ", ""),
                    TAX = item.Substring(31, 10).Replace(" ", ""),
                    FEE = item.Substring(41, 7).Replace(" ", ""),
                    COMM = item.Substring(48, 5).Replace(" ", ""),
                    FP = item.Substring(53, 2).Replace(" ", ""),
                    PAXNAME = item.Substring(56, 8).Replace(" ", ""),
                    AS = item.Substring(65, 2).Replace(" ", ""),
                    RELOC = item.Substring(68, 6).Replace(" ", ""),
                    TRNC = item.Substring(75, 5).Replace(" ", "")
                };

                TJQList.Add(tempTJQ);
            });

            return TJQList;
        }

        public List<TJQModel> GetMNLPH3501(string startDate = "", string endDate = "", string currency = "")
        {
            List<TJQModel> TJQList = new List<TJQModel>();

            temp = new List<string>(); // Clear temp string

            JumpOfficeID("MNLPH3501");

            objSession.Send("JI" + Properties.Settings.Default.Username3501 + "-" + Properties.Settings.Default.Password3501);

            GetTJQData(startDate, endDate, currency);

            temp.ForEach(item =>
            {
                TJQModel tempTJQ = new TJQModel
                {
                    SEQNO = item.Substring(0, 5).Replace(" ", ""),
                    AL = item.Substring(7, 3).Replace(" ", ""),
                    DOCNO = item.Substring(11, 10).Replace(" ", ""),
                    AMOUNT = item.Substring(21, 10).Replace(" ", ""),
                    TAX = item.Substring(31, 10).Replace(" ", ""),
                    FEE = item.Substring(41, 7).Replace(" ", ""),
                    COMM = item.Substring(48, 5).Replace(" ", ""),
                    FP = item.Substring(53, 2).Replace(" ", ""),
                    PAXNAME = item.Substring(56, 8).Replace(" ", ""),
                    AS = item.Substring(65, 2).Replace(" ", ""),
                    RELOC = item.Substring(68, 6).Replace(" ", ""),
                    TRNC = item.Substring(75, 5).Replace(" ", "")
                };

                TJQList.Add(tempTJQ);
            });

                return TJQList;
        }

        public List<TJQModel> GetMNLPH3502(string startDate = "", string endDate = "", string currency = "")
        {
            List<TJQModel> TJQList = new List<TJQModel>();

            temp = new List<string>(); // Clear temp string

            JumpOfficeID("MNLPH3502");

            objSession.Send("JI" + Properties.Settings.Default.Username3502 + "-" + Properties.Settings.Default.Password3502);

            GetTJQData(startDate, endDate, currency);

            temp.ForEach(item =>
            {
                TJQModel tempTJQ = new TJQModel
                {
                    SEQNO = item.Substring(0, 5).Replace(" ", ""),
                    AL = item.Substring(7, 3).Replace(" ", ""),
                    DOCNO = item.Substring(11, 10).Replace(" ", ""),
                    AMOUNT = item.Substring(21, 10).Replace(" ", ""),
                    TAX = item.Substring(31, 10).Replace(" ", ""),
                    FEE = item.Substring(41, 7).Replace(" ", ""),
                    COMM = item.Substring(48, 5).Replace(" ", ""),
                    FP = item.Substring(53, 2).Replace(" ", ""),
                    PAXNAME = item.Substring(56, 8).Replace(" ", ""),
                    AS = item.Substring(65, 2).Replace(" ", ""),
                    RELOC = item.Substring(68, 6).Replace(" ", ""),
                    TRNC = item.Substring(75, 5).Replace(" ", "")
                };

                TJQList.Add(tempTJQ);
            });

            return TJQList;
        }
    }
}
