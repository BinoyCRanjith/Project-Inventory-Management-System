using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.Models
{
    public class StaffData
    {
        public int Id { get; set; }

        public string Fullname { get; set; }

        public string Email { get; set; }

        public string Phonenumber { get; set; }

        public string Address { get; set; }
        public string Type { get; set; }

        public string Password { get; set; }
    }
}