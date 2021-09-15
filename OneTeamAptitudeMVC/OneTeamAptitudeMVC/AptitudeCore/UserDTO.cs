using Newtonsoft.Json;
using OneTeamAptitudeMVC.Constants;
using OneTeamAptitudeMVC.Helper;
using OneTeamAptitudeMVC.Models;
using OneTeamAptitudeMVC.Scripts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace OneTeamAptitudeMVC.AptitudeCore
{
    public class UserDTO
    {
        int? UserSessionId;
        public UserDTO()
        {
            UserSessionId = SessionManager.UserID;
        }

        public static List<User> GetDisabledUser()
        {
            List<User> Userlist = new List<User>();

            List<User> UserList = new List<User>();
            DataTable dt = AptitudeUtilities.Datafill(StoredProcedure.ListAllUserSP, "OperationId", 5);
            foreach (DataRow row in dt.Rows)

            {
                User user = new User();
                user.Id = Convert.ToInt16(row["Id"]);
                user.DepartmentName = row["DepartmentName"].ToString();
                user.Email = row["Email"].ToString();
                user.Name = row["Name"].ToString();
                user.Phone = row["Phone"].ToString();
                user.RollName = row["RollName"].ToString();
                user.Password = row["Password"].ToString();
                Userlist.Add(user);
            }

            return Userlist;
        }
        public static List<User> GetAllUser(string Json)
        {
            List<User> Userlist = new List<User>();

            List<User> UserList = new List<User>();
            DataTable dt = AptitudeUtilities.Datafill(StoredProcedure.ListAllUserSP, "OperationId", 1);
            foreach (DataRow row in dt.Rows)
           
            {
                User user = new User();
                user.Id = Convert.ToInt16(row["Id"]);
                user.DepartmentName = row["DepartmentName"].ToString();
                user.Email = row["Email"].ToString();
                user.Name = row["Name"].ToString();
                user.Phone = row["Phone"].ToString();
                user.RollName = row["RollName"].ToString();
                user.Password = row["Password"].ToString();
                Userlist.Add(user);
            }

            return Userlist;
        }

        public static List<UserDepartment> SelectAllDepartment()
        {
            List<UserDepartment> DipartmentList = new List<UserDepartment>();
            DataTable ds = AptitudeUtilities.Datafill(StoredProcedure.DepartmentSp, "OperationId", 1);
            foreach (DataRow row in ds.Rows)
            {
                UserDepartment Dept = new UserDepartment();

                Dept.DepartmentId = Convert.ToInt16(row["id"]);
                Dept.DepartmentName = row["DepartmentName"].ToString();
                DipartmentList.Add(Dept);
            }
            return DipartmentList;
        }
        public static List<UserRoll> Usroll()
        {
            List<UserRoll> UsRoll = new List<UserRoll>();


            DataTable ds = AptitudeUtilities.Datafill(StoredProcedure.UserRollSp);
            foreach (DataRow row in ds.Rows)
            {
                UserRoll usr = new UserRoll();
                usr.RollId = Convert.ToInt16(row["id"]);
                usr.RollName = row["RollName"].ToString();
                UsRoll.Add(usr);

            }

            return UsRoll;
        }
        public static void SaveUser(User user)
        {
            string Password = UserDTO.CreatePassword(8);
            //DatabaseOperations.SaveDataToTable("", "OperationId", 4, "Name", Us.Name, "RollId", Us.RollId, "DepartmentId", Us.DepartmentId, "Email", Us.Email, "Phone", Us.Phone, "password", Us.password, "id", Us.id);
            Boolean B = AptitudeUtilities.SaveDataToTable(StoredProcedure.UserTableProcedure, "OperationId", user.Action, "Name", user.Name, "RollId", user.RollId, "DepartmentId", user.DepartmentId, "Email", user.Email, "phoneNo", user.Phone, "password", Password);
            if (B)
            {
                string body = "Hello,\n" +
                    "Your Profile has been created in One Team Aptitude Training portal. \n The UserID will be your email and password  is:" + Password + "\n" +
                    "Click this Url to login to the Aptitude Training portal - http://www.firstround.in/  \n\n\n" +
                    "Thanks, \n" +
                    "Recruitment Team \n" +
                    "One Team Solutions";
               AptitudeUtilities.SendMail("Your Accout Is Activated", body, user.Email);
            }

        }
        public static List<User> GetOneUser(int Id)
        {
            List<User> UserList = new List<User>();
            DataTable ds = AptitudeUtilities.Datafill(StoredProcedure.SelectUser, "id", Id);
            foreach (DataRow row in ds.Rows)
            {
                User user = new User();
                user.Id = Convert.ToInt16(row["Id"]);
                user.Name = row["Name"].ToString();
                user.Email = row["Email"].ToString();
                user.Phone = row["Phone"].ToString();
                user.RollName = row["RollName"].ToString();
                user.DepartmentName = row["DepartmentName"].ToString();
                user.RollId = Convert.ToInt16(row["RollId"]);
                user.DepartmentId = Convert.ToInt16(row["DepartmentId"]);

                UserList.Add(user);



            }
            return UserList;

        }

        public static User GetSelectedUser(int Id)
        {
            List<User> UserList = new List<User>();
            DataTable ds = AptitudeUtilities.Datafill(StoredProcedure.SelectUser, "id", Id);
            User user = new User();

            foreach (DataRow row in ds.Rows)
            {
                user.Id = Convert.ToInt16(row["Id"]);
                user.Name = row["Name"].ToString();
                user.Email = row["Email"].ToString();
                user.Phone = row["Phone"].ToString();
                user.RollName = row["RollName"].ToString();
                user.DepartmentName = row["DepartmentName"].ToString();
                user.RollId = Convert.ToInt16(row["RollId"]);
                user.DepartmentId = Convert.ToInt16(row["DepartmentId"]);
                user.Password = row["Password"].ToString();


            }
            return user;

        }



        public static ExamStats GetExamStats()
        {
            ExamStats examStats = new ExamStats();

            UserDTO Dto = new UserDTO();
            DataTable ds = AptitudeUtilities.Datafill(StoredProcedure.ExamTableProcedure, "userId", Dto.UserSessionId, "OperationId", 1);
            if (ds.Rows.Count > 0)
            {
                examStats.Level = new Level();
                examStats.Level.Id = Convert.ToInt16(ds.Rows[0]["id"]);
                examStats.QuestionCategory = new QuestionCategory();
                examStats.QuestionCategory.Name = ds.Rows[0]["CatogoryName"].ToString();
                examStats.QuestionCategory.Id = Convert.ToInt16(ds.Rows[0]["CatId"]);
                examStats.Passmark = Convert.ToInt16(ds.Rows[0]["passmark"]);
                examStats.Level = new Level();
                examStats.Level.Name = ds.Rows[0]["LevelOfExam"].ToString();
                examStats.Level.Id = Convert.ToInt16(ds.Rows[0]["LevelId"]);
                examStats.TimeForExam = Convert.ToInt16(ds.Rows[0]["TimeForExam"]);
                examStats.TotalQuestion = Convert.ToInt16(ds.Rows[0]["totalQn"]);
            }
            return examStats;
        }
        public static void EditUser(User user)
        {

           Boolean B= AptitudeUtilities.SaveDataToTable(StoredProcedure.UserTableProcedure, "OperationId", 4,
                "@id",user.Id, 
                "Name",user.Name, "RollId", user.RollId, "DepartmentId"
                , user.DepartmentId, "Email",user.Email
                , "phoneNo",user.Phone, "password", user.Password);
            if (B)
            {
                string body = "Hello,\n" +
                    "Your Profile has been created in One Team Aptitude Training portal. \n The UserID will be your email and password  is:" + user.Password + "\n" +
                    "Click this Url to login to the Aptitude Training portal - http://www.firstround.in/  \n\n\n" +
                    "Thanks, \n" +
                    "Recruitment Team \n" +
                    "One Team Solutions";


                
                AptitudeUtilities.SendMail("Your Accout Is Activated", body, user.Email);
            }
        }
        public static string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnABCDEFGHIJKLMNPQRSTUVWXYZ123456789";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
        public static void Deleteuser(int Id)
        {
            AptitudeUtilities.DeleteData(StoredProcedure.ListAllUserSP, "OperationId", 3, "Id", Id, "Status", 1);
        }
        public static void EnableUser(int Id)
        {
            AptitudeUtilities.DeleteData(StoredProcedure.ListAllUserSP, "OperationId", 3, "Id", Id, "Status", 0);
        }
        public static void ChangeUserStatus(int Id)
        {
            //AptitudeUtilities.SaveDataToTable(StoredProcedure.ListAllUserSP, "Action", 3, "Id", Id);
        }
    }
}