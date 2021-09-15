using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.Models
{
    public class ProductDataView
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public string SubCategoryId { get; set; }

        public string BrandId { get; set; }

        public string ProductName { get; set; }
    }
}