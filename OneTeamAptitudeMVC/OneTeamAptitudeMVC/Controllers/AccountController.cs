using OneTeamAptitudeMVC.AptitudeCore;
using OneTeamAptitudeMVC.Helper;
using OneTeamAptitudeMVC.Models;
using OneTeamAptitudeMVC.Scripts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneTeamAptitudeMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            SessionManager.AuthenticatedUser =null;
            SessionManager.UserID = null;
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {

            int RollId;
           User user= AccountDTO.AuthenticatUser(login.UserName,login.Password,out RollId);
            if(user!=null)
            {
                SessionManager.AuthenticatedUser = user;
                SessionManager.RollId = RollId;
                SessionManager.UserID = user.Id;
                if(RollId==2 || RollId==3)
                {
                    return RedirectToAction("ExamResult", "Admin");
                }
                else if(RollId==1)
                {
                    return RedirectToAction("Index", "User");

                }
            }
            ModelState.AddModelError(string.Empty, "Username or password is invalid");
            return View();
        }
        [HttpGet]
        public ActionResult LogOut()
        {
            SessionManager.AuthenticatedUser = null;
            SessionManager.RollId = 0;
            SessionManager.UserID = null;
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SavePassword()
        {
            DataTable ds = AptitudeUtilities.Datafill("selectUser", "id",Convert.ToInt16(SessionManager.UserID));
            string email = ds.Rows[0][5].ToString();
            string s = Request["txtPassword"].ToString();
            AptitudeUtilities.SaveDataToTable("userTableProcedure", "OperationId", 3, "id", Convert.ToInt16(SessionManager.UserID), "password",Request["txtPassword"].ToString());
            AptitudeUtilities.SendMail("Password changed", "Your password for one team apptitude portal has been successfully changed" + Request["txtPassword"].ToString(), email);
            return RedirectToAction("Index", "User");
        }

    }
}