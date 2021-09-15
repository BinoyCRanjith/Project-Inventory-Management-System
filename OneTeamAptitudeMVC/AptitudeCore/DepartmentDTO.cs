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
    public class DepartmentDTO
    {
        public static void SaveDepartment(string department)
        {
            AptitudeUtilities.SaveDataToTable(StoredProcedure.DepartmentSp, "Department", department, "OperationId", 0);

        }
        public static void UpdateDepartment(int id,string department)
        {
            AptitudeUtilities.SaveDataToTable(StoredProcedure.DepartmentSp, "id", id, "Department", department, "OperationId", 3);

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
        public static void DeleteDepartment(int Id)
        {
            
         AptitudeUtilities.DeleteData(StoredProcedure.DepartmentSp, "Id",Id, "OperationId",2);

        }

    }
}