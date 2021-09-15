using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.Models
{
    public class User: DataOption
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="name is mandotory")]
        public string Name { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "phone is mandotory")]
        public string Phone { get; set; }
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "Department is mandotory")]
        public int DepartmentId { get; set; }
        public string RollName { get; set; }
      
        public string Password { get; set; }
        [Required(ErrorMessage = "User roll is mandotory")]

        public int RollId { get; set; }
    }
}