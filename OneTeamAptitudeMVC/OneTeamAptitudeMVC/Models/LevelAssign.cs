using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.Models
{
    public class LevelAssign
    {
        public int LevelQnId { get; set; }

        [Required(ErrorMessage = "Category is mandotory")]
        public QuestionCategory Category { get; set; }

        [Required(ErrorMessage = "Level is mandotory")]
        public Level Level { get; set; }
        [Display(Name ="PassMark :")]
        [Required(ErrorMessage = "Passmark is mandotory")]

        public int Passmark { get; set; }
        [Required(ErrorMessage = "Totalmark is mandotory")]

        public int Totalmark { get; set; }
        [Required(ErrorMessage = "TimeForExam is mandotory")]

        public int TimeForExam { get; set; }
        [Required(ErrorMessage = "Instruction is mandotory")]

        public string Instruction { get; set; }

    }
}