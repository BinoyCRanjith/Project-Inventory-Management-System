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
    public class StaffInventoryController : Controller
    {
        // GET: StaffInventory
        public ActionResult Index()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "spShowInventory",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<InventoryData>>(request);


            return View(dbResponse.Data);
        }


        [HttpGet]
        public ActionResult SearchInventory(string SearchText)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { SearchText }.ToJson(),
                ProcedureName = "spSearchInventory",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<InventoryData>>(request);


            return View(dbResponse.Data);
        }
    }
}