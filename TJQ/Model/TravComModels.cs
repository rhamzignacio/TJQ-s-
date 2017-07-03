using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJQ
{
    public class TravComModels
    {
        public string TicketNumber { get; set; }
        public decimal Tax1 { get; set; }
        public decimal Tax2 { get; set; }
        public decimal PublishedFare { get; set; }
        public decimal CommissionAmount { get; set; }
        public decimal NetFare { get; set; }
        public decimal NetPayable { get; set; }
        public string PassengerName { get; set; }
        public string CurrencyCode { get; set; }
        public string AirlineCode { get; set; }
        public string DepartureCityCode { get; set; }
        public string ArrivalCityCode { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string ProfileNo { get; set; }
        public string ProfileName { get; set; }
        public string FullName { get; set; }
    }

}
