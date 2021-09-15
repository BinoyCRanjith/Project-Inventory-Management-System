using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.Models
{
    public class PurchaseDataView
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public string PurchaseQTY { get; set; }

        public string PurchasePrice { get; set; }

        public string TotalPrice { get; set; }

        public string SellPrice { get; set; }

        public string PaymentTypeId { get; set; }

        public string StaffId { get; set; }

        public DateTime PurchaseDate { get; set; }
    }
}