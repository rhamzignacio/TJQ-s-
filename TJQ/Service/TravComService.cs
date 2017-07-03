using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJQ.Model;

namespace TJQ
{
    public class TravComService
    {
        public TravComModels CheckIfUnPosted(string _ticketNo)
        {
            var db = new TravComEntities();

            var query = from ifInvDetails in db.IfInvoiceDetails //IfInvoiceDetails
                        join a in db.Airlines on ifInvDetails.ValidatingCarrier equals a.AirlineNumber into qA //Airline Table
                        from airline in qA.DefaultIfEmpty()
                        join s in db.IfSegments on ifInvDetails.InvoiceDetailID equals s.InvoiceDetailID into qS //IfSegment
                        from segment in qS.DefaultIfEmpty() 
                        join inv in db.IfInvoices on ifInvDetails.InvoiceID equals inv.InvoiceID into qInv //IfInvoice
                        from invoice in qInv.DefaultIfEmpty()
                        join p in db.Profiles on invoice.BookingAgentNumber equals p.ProfileNumber into qP //Profiles
                        from profile in qP.DefaultIfEmpty()
                        where ifInvDetails.TicketNumber == _ticketNo
                        select new TravComModels
                        {
                            TicketNumber = ifInvDetails.TicketNumber,
                            Tax1 = ifInvDetails.Tax1,
                            Tax2 = ifInvDetails.Tax2,
                            PublishedFare = ifInvDetails.PublishedFare,
                            CommissionAmount = ifInvDetails.CommissionAmount,
                            NetFare = ifInvDetails.NetFare,
                            NetPayable = (ifInvDetails.Tax1 + ifInvDetails.Tax2 + ifInvDetails.PublishedFare + ifInvDetails.CommissionAmount),
                            PassengerName = ifInvDetails.PassengerName,
                            CurrencyCode = ifInvDetails.CurrencyCode,
                            AirlineCode = airline.AirlineCode,
                            DepartureCityCode = segment.DepartureCityCode,
                            ArrivalCityCode = segment.ArrivalCityCode,
                            BookingDate = invoice.BookingDate,
                            InvoiceDate = invoice.InvoiceDate,
                            ProfileNo = invoice.ProfileNumber,
                            ProfileName = invoice.ProfileName,
                            FullName = profile.FullName
                        };

                return query.FirstOrDefault();
        }

        public TravComModels CheckIfPosted(string _ticketNo)
        {
            var db = new TravComEntities();

            var query = from ARInvoiceDetails in db.ARInvoiceDetails //ARInvoiceDetails
                        join a in db.Airlines on ARInvoiceDetails.ValidatingCarrier equals a.AirlineNumber into qA //Airlines
                        from airline in qA.DefaultIfEmpty()
                        join s in db.Segments on ARInvoiceDetails.InvoiceDetailID equals s.InvoiceDetailID into qS //Segments
                        from segment in qS.DefaultIfEmpty()
                        join inv in db.ARInvoices on ARInvoiceDetails.InvoiceID equals inv.InvoiceID into qInv //ARInvoices
                        from invoice in qInv.DefaultIfEmpty()
                        join p in db.Profiles on invoice.BookingAgentNumber equals p.ProfileNumber into qP //Profiles
                        from profile in qP.DefaultIfEmpty()
                        where ARInvoiceDetails.TicketNumber == _ticketNo
                        select new TravComModels
                        {
                            TicketNumber = ARInvoiceDetails.TicketNumber,
                            Tax1 = ARInvoiceDetails.Tax1,
                            Tax2 = ARInvoiceDetails.Tax2,
                            PublishedFare = ARInvoiceDetails.PublishedFare,
                            CommissionAmount = ARInvoiceDetails.CommissionAmount,
                            NetFare = ARInvoiceDetails.NetFare,
                            NetPayable = (ARInvoiceDetails.Tax1 + ARInvoiceDetails.Tax2 + ARInvoiceDetails.PublishedFare + ARInvoiceDetails.CommissionAmount),
                            PassengerName = ARInvoiceDetails.PassengerName,
                            CurrencyCode = ARInvoiceDetails.CurrencyCode,
                            AirlineCode = airline.AirlineCode,
                            DepartureCityCode = segment.DepartureCityCode,
                            ArrivalCityCode = segment.ArrivalCityCode,
                            BookingDate = invoice.BookingDate,
                            InvoiceDate = invoice.InvoiceDate,
                            ProfileNo = invoice.ProfileNumber,
                            ProfileName = invoice.ProfileName,
                            FullName = profile.FullName
                        };

            return query.FirstOrDefault();
        }
    }
}
