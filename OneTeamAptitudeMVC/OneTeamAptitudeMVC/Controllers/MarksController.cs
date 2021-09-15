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
    public class MarksController : Controller
    {
        // GET: Marks
        public ActionResult MarkHomeMain()

        {


            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "UserMarkList",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<MarkData>>(request);


            return View(dbResponse.Data);
        }

        [HttpGet]
        public ActionResult InsertMark(int ID = 0)
        {
            MarkData Marks = new MarkData();

            //SetViewBag();
            if (ID > 0)
            {
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = new { ID }.ToJson(),
                    ProcedureName = "MarkDetails",
                    RequestType = DbRequestType.Select
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<MarkData>(request);
                Marks = dbResponse.Data;
            }
            return View(Marks);
        }
        [HttpPost]
        public ActionResult Save(Marks MarkData)
        {

            DbRequestBase request = new DbRequestBase
            {
                InputJson = MarkData.ToJson(),
                ProcedureName = "MarkSave",
                RequestType = DbRequestType.Insert
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<Marks>>(request);
            TempData["Message"] = MarkData.ID > 0 ? "Mark updated Successfully" : "new mark saved successfully";
            return RedirectToAction("MarkHomeMain");
        }

        public ActionResult Delete(int ID)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { ID }.ToJson(),
                ProcedureName = "DeleteMarks",
                RequestType = DbRequestType.Delete

            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<MarkData>>(request);
            return RedirectToAction("MarkHomeMain");
        }
    }
}