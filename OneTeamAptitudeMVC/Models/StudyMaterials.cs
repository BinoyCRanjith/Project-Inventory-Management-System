using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneTeamAptitudeMVC.Models
{
    public class StudyMaterials
    {
        [Required(ErrorMessage = "QuestionCategory Is Mandatory")]
        public QuestionCategory StudyMaterialCat { get; set; }
        public int StudyMaterialsId { get; set; }
        [Display(Name = "Title"), Required, AllowHtml]
        public string StudyMaterialsData { get; set; }
    }
}