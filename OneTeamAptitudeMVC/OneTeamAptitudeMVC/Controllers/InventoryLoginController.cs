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
using System.Windows;
using System.Threading.Tasks;



namespace OneTeamAptitudeMVC.Controllers
{
    public class InventoryLoginController : Controller
    {
        // Get: InventoryLogin
        [HttpGet]
        public ActionResult LoginHomeMain ()
        {
            return View();
        }
    
        [HttpPost]
        public ActionResult LoginHome(StaffDataView StaffData)
        
        {
            
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = StaffData.ToJson(),
                    ProcedureName = "spLogin",
                    RequestType = DbRequestType.Select
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<StaffData>(request);


            if (dbResponse.Data != null)
            {
                if (dbResponse.Data.Type.Equals("3"))
                {
                    return RedirectToAction("AdminHomeMain", "AdminHome");
                }
                else if (dbResponse.Data.Type.Equals("2"))
                {
                    return RedirectToAction("StaffHomeMain", "StaffHome");

                }
                
            }
            else
            {
                
                TempData["Message"]="Invalid UserName or Password";
                return RedirectToAction("LoginHomeMain");
            }

            return View(dbResponse.Data);
        }

         
    }
}
