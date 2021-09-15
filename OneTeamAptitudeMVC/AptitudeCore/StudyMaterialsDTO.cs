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
    public class StudyMaterialsDTO
    {
        public static void SaveStudyMaterials(StudyMaterials studyMaterials)
        {
            AptitudeUtilities.SaveDataToTable(StoredProcedure.StudyMaterials, "CatID", studyMaterials.StudyMaterialCat.Id, "MaterialData", studyMaterials.StudyMaterialsData, "OperationId", 0);
        }

        public static StudyMaterials GetStudyMaterialData(int id)
        {
            StudyMaterials study = new StudyMaterials();

            DataTable dt = AptitudeUtilities.Datafill(StoredProcedure.StudyMaterials, "CatID", id, "OperationId", 1);
            foreach (DataRow row in dt.Rows)
            {


                study.StudyMaterialsData = row["MaterialData"].ToString();
            }
            return study;
        }
        public  static  List<StudyMaterials>  GetStudyMaterialsList()
        {
            List<StudyMaterials> studyList = new List<StudyMaterials>();
            DataTable dt = AptitudeUtilities.Datafill(StoredProcedure.StudyMaterials, "OperationId", 2);
            foreach (DataRow row in dt.Rows)
            {
                StudyMaterials study = new StudyMaterials();
                study.StudyMaterialCat = new QuestionCategory();
                study.StudyMaterialCat.Id = Convert.ToInt16(row["CatID"].ToString());
                study.StudyMaterialCat.Name = row["CatogoryName"].ToString();
                studyList.Add(study);
            }
            return studyList;
        }
    }
}


