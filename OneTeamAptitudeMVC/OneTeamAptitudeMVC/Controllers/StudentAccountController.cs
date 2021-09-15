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
using System.Data.SqlClient;

namespace OneTeamAptitudeMVC.Controllers
{
    public class StudentAccountController : Controller
    {
        // GET: StudentAccount
        public ActionResult Login()
        {

            var user = new UserData();

            Session["Email"] = user;
            Session["Password"] = user;

            if (Session["Email"] == null)

            {
                return RedirectToAction("Login");
            }
            else if (Session["Password"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();

        }
    }
}