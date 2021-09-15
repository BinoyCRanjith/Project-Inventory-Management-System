using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.Models
{
    public class ExamStats
    {
      
        public Level Level { get; set; }
        public QuestionCategory QuestionCategory { get; set; }
        public int Passmark { get; set; }
        public int TotalQuestion { get; set; }
        public int TimeForExam { get; set; }
        //public string  Instruction { get; set; }
    }
}