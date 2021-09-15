using Newtonsoft.Json;
using OneTeamAptitudeMVC.AptitudeCore;
using OneTeamAptitudeMVC.Helper;
using OneTeamAptitudeMVC.Models;
using OneTeamAptitudeMVC.Scripts;
using OneTeamAptitudeMVC.Web.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneTeamAptitudeMVC.Controllers
{
    [AptitudeAuthorizeAttributes(Roles = "Admin,Staff")]
    public class AdminController : Controller
    {
        int? UserId;

        public AdminController()
        {
            User user = new Models.User();

            if (SessionManager.UserID != null && (SessionManager.RollId == 2 || SessionManager.RollId == 3))
            {
                UserId = SessionManager.UserID;
                user = SessionManager.AuthenticatedUser;
            }
            else
            {
                ValidateUser();
            }
        }
        public ActionResult ValidateUser()
        {
            return RedirectToAction("Login", "Account");
        }
        // GET: Admin
        public ActionResult Index()
        {
            User Us = new Models.User();
            Us.Action = 1;
            List<UserDepartment> Deptlist = new List<UserDepartment>();

            Deptlist = UserDTO.SelectAllDepartment();
            ViewBag.UserDepartment = Deptlist;
            string JSON = JsonConvert.SerializeObject(Us);
            List<UserRoll> URoll = new List<UserRoll>();
            URoll = UserDTO.Usroll();
            ViewBag.UserRoll = URoll;

            List<User> Userlist = null;
            Userlist = UserDTO.GetAllUser(JSON);
            return View(Userlist);

        }
        public static string GetJSON(object obj)
        {
            string output = JsonConvert.SerializeObject(obj, Formatting.Indented);
            return output;
        }


        [HttpGet]
        public ActionResult UserRegistration()
        {
            List<UserDepartment> Deptlist = new List<UserDepartment>();

            Deptlist = UserDTO.SelectAllDepartment();
            ViewBag.UserDepartment = Deptlist;
            List<UserRoll> URoll = new List<UserRoll>();
            URoll = UserDTO.Usroll();
            ViewBag.UserRoll = URoll;
            return View();
        }
        [HttpPost]

        public ActionResult UserRegistration(User user)
        {
            if (ModelState.IsValid)
            {
                //User Us = new Models.User();
                //Us.Action = 2;

                //string JSON = JsonConvert.SerializeObject(user);
                //AptitudeUtilities.SaveDataToTable("selectAllUser", "Json", JSON);
                UserDTO.SaveUser(user);
                return RedirectToAction("index");
            }
            List<UserDepartment> Deptlist = new List<UserDepartment>();

            Deptlist = UserDTO.SelectAllDepartment();
            ViewBag.UserDepartment = Deptlist;
            List<UserRoll> URoll = new List<UserRoll>();
            URoll = UserDTO.Usroll();
            ViewBag.UserRoll = URoll;

            return View();
        }

        public ActionResult Delete(int Id)
        {

            UserDTO.Deleteuser(Id);

            return RedirectToAction("index");
        }

        public ActionResult Enable(int Id)
        {

            UserDTO.EnableUser(Id);

            return RedirectToAction("DisabledUserView");
        }
        public ActionResult ChangeStatus(int Id)
        {

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Question()
        {
            if (TempData["Delete_Message"] != null)
            {
                ViewBag.Message = TempData["Delete_Message"].ToString();
                TempData.Remove("Delete_Message");
            }
            List<Questions> ListQns = new List<Questions>();
            ListQns = QuestionDTO.GetAllQuestions();
            return View(ListQns);
        }
        [HttpGet]
        public ActionResult QuestionEntry()
        {
            List<QuestionCategory> ListQnCat = QuestionDTO.GetAllQnCategory();
            ViewBag.QuestionCategory = ListQnCat;
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult QuestionEntry(Questions questions)
        {
            if (questions.AnswerKey == "Option1")
            {
                questions.AnswerKey = questions.Option1;
            }
            else if (questions.AnswerKey == "Option2")
            {
                questions.AnswerKey = questions.Option2;

            }
            else if (questions.AnswerKey == "Option3")
            {
                questions.AnswerKey = questions.Option3;

            }
            else if (questions.AnswerKey == "Option4")
            {
                questions.AnswerKey = questions.Option4;

            }
            QuestionDTO.SaveQuestions(questions);
            return RedirectToAction("Question");
        }
        public ActionResult DeleteQuestion(int id)
        {
            QuestionDTO.DeleteQn(id);
            TempData["Delete_Message"] = "Question Deleted";

            return RedirectToAction("Question");

        }
        [HttpGet]
        public ActionResult EditQuestion(int id)
        {
            List<QuestionCategory> ListQnCat = QuestionDTO.GetAllQnCategory();
            ViewBag.QuestionCategory = ListQnCat;
            Questions Qn = QuestionDTO.GetQnUsingId(id);
            ViewBag.CorrectAnswer = Qn.AnswerKey;
            ViewBag.Option1 = Qn.Option1;
            ViewBag.Option2 = Qn.Option2;
            ViewBag.Option3 = Qn.Option3;
            ViewBag.Option4 = Qn.Option4;

            return View(Qn);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditQuestion(Questions questions)
        {
            TempData["Delete_Message"] = "Question Edited";

            QuestionDTO.UpdateQuestions(questions);

            return RedirectToAction("Question");
        }
        [HttpGet]
        public ActionResult ExamResult()
        {
            List<ExamResult> ExamResultList = QuestionDTO.StudentExamResult();
            List<DataPoint> DataPointList = QuestionDTO.GetExamResultAsDataPoint();
            ViewBag.Datapoints = DataPointList;
            List<DataPoint> ExamStatisticsList = QuestionDTO.GetExamAttendStatts();
            ViewBag.ExamStats = ExamStatisticsList;
            List<DataPoint> AverageList = QuestionDTO.GetAverageOfStudent();
            ViewBag.AverageList = AverageList;
            //JsonConvert.SerializeObject(DataPointList);

            if (ExamResultList.Count < 1)
            {
                ViewBag.Message = "No Record Found!";
            }
            return View(ExamResultList);
        }
        [HttpGet]
        public ActionResult LevelAssign()
        {
            List<LevelAssign> LvlAssignList = LevelQuestionAssignDTO.GetAllLevelAssign();

            return View(LvlAssignList);
        }
        [HttpGet]
        public ActionResult NewLevelAssign()
        {
            List<Level> LvlList = LevelQuestionAssignDTO.FillLevel();
            ViewBag.LevelList = LvlList;
            List<QuestionCategory> QnCatList = LevelQuestionAssignDTO.FillCat();
            ViewBag.QuestionCategory = QnCatList;
            return View();
        }
        [HttpPost]
        public ActionResult NewLevelAssign(LevelAssign levelAssign)
        {
            LevelQuestionAssignDTO.SaveNewLevel(levelAssign);
            return RedirectToAction("LevelAssign");
        }
        public ActionResult DeleteLevel(int id)
        {
            LevelQuestionAssignDTO.DeleteLevel(id);
            return RedirectToAction("LevelAssign");
        }
        //[HttpGet]
        //public PartialViewResult EditUser(int id)
        //{
        //    List<User> UserList = UserDTO.GetOneUser(id);
        //    return PartialView("partials/Edit", UserList);
        //}
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            List<UserDepartment> Deptlist = new List<UserDepartment>();

            Deptlist = UserDTO.SelectAllDepartment();
            ViewBag.UserDepartment = Deptlist;
            List<UserRoll> URoll = new List<UserRoll>();
            URoll = UserDTO.Usroll();
            ViewBag.UserRoll = URoll;
            User user = UserDTO.GetSelectedUser(id);
            return View("EditUser", user);
        }
        [HttpPost]
        public ActionResult EditUser(User user)
        {
            UserDTO.EditUser(user);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditLevel(int Id)
        {
            LevelAssign LvlAssign = LevelQuestionAssignDTO.GetOneLevel(Id);
            List<Level> LvlList = LevelQuestionAssignDTO.FillLevel();
            ViewBag.LevelList = LvlList;
            List<QuestionCategory> QnCatList = LevelQuestionAssignDTO.FillCat();
            ViewBag.QuestionCategory = QnCatList;
            return View(LvlAssign);
        }
        [HttpPost]
        public ActionResult EditLevel(LevelAssign levelAssign)
        {
            LevelQuestionAssignDTO.EditLevel(levelAssign);
            return RedirectToAction("LevelAssign");
        }
        public ActionResult ViewExamHistory()
        {


            List<ExamResult> ExamResultList = QuestionDTO.StudentAllExamResult();

            //JsonConvert.SerializeObject(DataPointList);

            if (ExamResultList.Count < 1)
            {
                ViewBag.Message = "No Record Found!";
            }
            return View(ExamResultList);
        }

        public ActionResult DisabledUserView()
        {
            List<User> Userlist = null;
            Userlist = UserDTO.GetDisabledUser();
            return View(Userlist);
        }
        public static int GetUserBasedDepartment(string DepID)
        {
            return 0;
        }

    }

}