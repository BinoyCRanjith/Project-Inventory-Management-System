using Newtonsoft.Json;
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
    [AptitudeAuthorizeAttributes(Roles = "Admin,Staff")]
    public class DepartmentController : Controller
    {

        int? UserId;

        public DepartmentController()
        {
            User user = new Models.User();

            if (SessionManager.UserID != null && (SessionManager.RollId == 2 || SessionManager.RollId == 3))
            {
                UserId = SessionManager.UserID;
                user = SessionManager.AuthenticatedUser;
            }
            else
            {
                RedirctUser();
            }
        }
        public ActionResult RedirctUser()
        {
            return RedirectToAction("Login", "Account");
        }
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult SaveDepartment(string id)
        //{
        //    DepartmentDTO.SaveDepartment(id);
        //    //List<UserDepartment> userDeptList = DepartmentDTO.SelectAllDepartment();

        //    //return userDeptList; 
        //    return RedirectToAction("UserRegistration", "Admin");
        //}
  
        public JsonResult SaveDepartment(string id)
        {
            DepartmentDTO.SaveDepartment(id);
            List<UserDepartment> userDeptList = DepartmentDTO.SelectAllDepartment();
          
            return Json(new { success=true, data=userDeptList }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteDepartment(int id)
        {
            DepartmentDTO.DeleteDepartment(id);
            List<UserDepartment> userDeptList = DepartmentDTO.SelectAllDepartment();

            return Json(new { success = true, data = userDeptList }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateDepartment(int id,string DeptName)
        {
            DepartmentDTO.UpdateDepartment(id, DeptName);
            List<UserDepartment> userDeptList = DepartmentDTO.SelectAllDepartment();

            return Json(new { success = true, data = userDeptList }, JsonRequestBehavior.AllowGet);
        }

        


    }
}