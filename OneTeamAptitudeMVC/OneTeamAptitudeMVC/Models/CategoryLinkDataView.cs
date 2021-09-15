using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.Models
{
    public class CategoryLinkDataView
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
    }
}