using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.Models
{
    public class ReturnDataView
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public string CustomerId { get; set; }

        public string SalesQTY { get; set; }

        public DateTime ReturnDate { get; set; }

        public string SalesPrice { get; set; }

        public string TotalPrice { get; set; }

        public string PaymentTypeId { get; set; }

        public string StaffId { get; set; }

        public string SalesId { get; set; }

        
    }
}