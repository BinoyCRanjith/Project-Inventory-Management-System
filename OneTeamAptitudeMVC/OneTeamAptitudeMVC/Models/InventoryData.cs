using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.Models
{
    public class InventoryData
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int CurrentQTY { get; set; }

        public int LastQTY { get; set; }
    }
}