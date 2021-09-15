using OneTeamAptitudeMVC.Constants;
using OneTeamAptitudeMVC.Helper;
using OneTeamAptitudeMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.AptitudeCore
{
    public class AccountDTO
    {
        public static User AuthenticatUser(string Username ,string password,out int RollId)
        {
            int Id = 0;
            User Us = new User();
            Us = null;
            DataTable ds = AptitudeUtilities.Datafill(StoredProcedure.userLogin, "email", Username, "password", password);
            foreach (DataRow row in ds.Rows)
            {
                User Us1 = new User();
                Us1.Id =Convert.ToInt16(row["Id"]);
                Us1.Name =row["Name"].ToString();
                Us1.DepartmentName=row["DepartmentName"].ToString();
                Us1.Phone = row["Phone"].ToString();
                Us1.Email = row["Email"].ToString();
                Us1.RollName = row["RollName"].ToString();
                Us1.RollId = Convert.ToInt16(row["RollId"]);
                Us1.DepartmentId = Convert.ToInt16(row["DepartmentId"]);
                Id = Us1.RollId;
                Us = Us1;
            }
            RollId = Id;
           
            return Us;
        }

    }
}










      