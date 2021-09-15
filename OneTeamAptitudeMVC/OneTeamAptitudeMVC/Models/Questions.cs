using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.Models
{
    public class Questions
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Question is mandotory")]
        public string Question { get; set; }
        [Required(ErrorMessage = "Option1 is mandotory")]
        public string Option1 { get; set; }
        [Required(ErrorMessage = "Option2 is mandotory")]

        public string Option2 { get; set; }
        [Required(ErrorMessage = "Option3 is mandotory")]

        public string Option3 { get; set; }
        [Required(ErrorMessage = "Option4 is mandotory")]

        public string Option4 { get; set; }
        [Required(ErrorMessage ="Please Select Option As Answer")]
        public string AnswerKey { get; set; }
        [Required(ErrorMessage = "Category is mandotory")]

        public int CatagoryId { get; set; }

        public string CatogoryName { get; set; }
    }
}