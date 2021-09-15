using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.Models
{
    public class ExamResult
    {
        public string Name { get; set; }
        public string LevelOfExam { get; set; }
        public DateTime DateOfExam { get; set; }
        public string Category { get; set; }
        public int Markscored { get; set; }
        public int Total { get; set; }
    }
}