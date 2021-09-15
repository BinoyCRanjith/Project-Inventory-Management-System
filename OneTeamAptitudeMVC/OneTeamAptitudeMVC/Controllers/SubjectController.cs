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
    public class SubjectController  : Controller
    {
       

        // GET: StudentJson
        public ActionResult SubjectHomeMain()

        {


            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "SubjectList",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<SubjectData>>(request);


            return View(dbResponse.Data);
        }
            [HttpGet]
            public ActionResult InsertSubject(int ID = 0)
        {
            SubjectData Subject = new SubjectData();

            //SetViewBag();
            if (ID > 0)
            {
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = new { ID }.ToJson(),
                    ProcedureName = "SubjectDetails",
                    RequestType = DbRequestType.Select
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<SubjectData>(request);
                Subject = dbResponse.Data;
            }
            return View(Subject);
        }
        [HttpPost]
            public ActionResult Save(Subject SubjectData)
            {

                DbRequestBase request = new DbRequestBase
                {
                    InputJson = SubjectData.ToJson(),
                    ProcedureName = "SubjectSave",
                    RequestType = DbRequestType.Insert
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<List<Subject>>(request);
                TempData["Message"] = SubjectData.ID > 0 ? "Subject updated Successfully" : "new Subject saved successfully";
                return RedirectToAction("SubjectHomeMain");
            }

            public ActionResult Delete(int ID)
            {
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = new { ID }.ToJson(),
                    ProcedureName = "DeleteSubject",
                    RequestType = DbRequestType.Delete

                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<List<SubjectData>>(request);
                return RedirectToAction("SubjectHomeMain");
            }
        }
    }