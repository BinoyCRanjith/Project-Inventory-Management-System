using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.Models
{
    public class StudentViewModel
    {
        public int DepartmentId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int RollId { get; set; }
    }
}