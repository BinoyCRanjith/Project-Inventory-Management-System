using OneTeamAptitudeMVC.AptitudeCore;
using OneTeamAptitudeMVC.Models;
using OneTeamAptitudeMVC.Scripts;
using OneTeamAptitudeMVC.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneTeamAptitudeMVC.Controllers
{

    [AptitudeAuthorizeAttributes(Roles = "Admin,Staff,Student")]
    public class ExamController : Controller
    {
        // GET: Exam
        int? UserId;
        int? LevelId;
        int? Passmark;
        public ExamController()
        {
            User user = new Models.User();
           
            if (SessionManager.UserID != null && SessionManager.RollId == 1)
            {
                UserId = SessionManager.UserID;
                user = SessionManager.AuthenticatedUser;
            }
           

        }
        
        public ActionResult Index()
        {
            this.LevelId =Convert.ToInt16(TempData["LevewlId"]);
           this.Passmark =Convert.ToInt16(TempData["Passmark"]);
            int CatId = SessionManager.ExamCat;
            //TempData.Remove("CatId");
            int NoOfQns = SessionManager.NoOfQn;
            //TempData.Remove("NoOfQns");
            ViewBag.LeveId = SessionManager.ExamDetails.Level.Id;
            ViewBag.Passmark = SessionManager.ExamDetails.Passmark;
            List<Questions> QuestionList = ExamDTO.FillQuestions(CatId, NoOfQns);
            return View(QuestionList);
        }

        [HttpGet]
        public ActionResult QiuckExam(int CatId, int NoQn)
        {
            SessionManager.ExamCat = CatId;
            SessionManager.NoOfQn = NoQn;
            List<Questions> QuestionList = ExamDTO.FillQuestions(CatId, NoQn);
            //return View("Index", QuestionList);
            return View(QuestionList);
        }
       

        [HttpPost]
        public ActionResult AnswerSubmit()
        {
            string Result ;
            int CatId = SessionManager.ExamCat;
            TempData.Remove("CatId");
            int NoOfQns = SessionManager.NoOfQn;
            TempData.Remove("NoOfQns");
            List<Questions> QuestionList = ExamDTO.FillQuestions(CatId, NoOfQns);
            Result = AnswerCalculation(QuestionList);
            ExamDTO.SubmitExam(Result);
            string[] tokens = Result.Split(',');
            if (Convert.ToInt16(tokens[0]) <Convert.ToInt32(SessionManager.ExamDetails.Passmark))
            {
                ViewBag.Message = "Have Not Cleared The Exam Try Again !";
            }
                ViewBag.Correctanswer = tokens[0];
            ViewBag.attendqn = tokens[1];
            ViewBag.TotalQn = QuestionList.Count;
            ViewBag.Category = SessionManager.ExamDetails.QuestionCategory.Id;
            ViewBag.TotalQn = SessionManager.ExamDetails.TotalQuestion;

            return View("Exam_Result");
        }
        public string AnswerCalculation(List<Questions> QnList)
        {
            string Category = "";
            int CorrectAnswerCount = 0;
            int AttendQn = 0;
            int totalQn=0;
            foreach (var item in QnList)
            {
                string selectedAnswer = Request[item.Id.ToString()];
                if (item.AnswerKey== selectedAnswer)
                {
                    CorrectAnswerCount += 1;
                }
                if(selectedAnswer!=null)
                {
                    AttendQn += 1;
                }
                Category = item.CatogoryName;
                totalQn = QnList.Count;
            }
            string result = CorrectAnswerCount.ToString()+"," + AttendQn.ToString();
            return result;
        }
    }
}