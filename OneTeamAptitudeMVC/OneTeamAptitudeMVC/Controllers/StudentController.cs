using OneTeamAptitudeMVC.AptitudeCore;
using OneTeamAptitudeMVC.Constants;
using OneTeamAptitudeMVC.Helper;
using OneTeamAptitudeMVC.Models;
using OneTeamAptitudeMVC.Web.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneTeamAptitudeMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentJson
        public ActionResult HomeMain()

        {


            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "StudentList",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<UserData>>(request);


            return View(dbResponse.Data);
        }

        [HttpGet]
        public ActionResult InsertStudent(int ID = 0)
        {
            UserData StudentData = new UserData();

            //SetViewBag();
            if (ID > 0)
            {
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = new { ID }.ToJson(),
                    ProcedureName = "StudentDetails",
                    RequestType = DbRequestType.Select
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<UserData>(request);
                StudentData = dbResponse.Data;
            }
            return View(StudentData);
        }
        [HttpPost]
        public ActionResult Save(StudentData UserData)
        {

            DbRequestBase request = new DbRequestBase
            {
                InputJson = UserData.ToJson(),
                ProcedureName = "spStudentSave",
                RequestType = DbRequestType.Insert
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<StudentData>>(request);
            TempData["Message"] = UserData.ID > 0 ? "User updated Successfully" : "new user saved successfully";
            return RedirectToAction("HomeMain");
        }

        public ActionResult Delete(int ID)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { ID }.ToJson(),
                ProcedureName = "DeleteStudent",
                RequestType = DbRequestType.Delete

            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<SubjectData>>(request);
            return RedirectToAction("HomeMain");
        }
    }
}