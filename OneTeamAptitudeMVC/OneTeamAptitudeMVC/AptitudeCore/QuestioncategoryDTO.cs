
using OneTeamAptitudeMVC.Helper;
using OneTeamAptitudeMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.AptitudeCore
{
    public class QuestioncategoryDTO
    {
        public static List<QuestionCategory> SaveQuestionCategory(string Cat)
        {
            AptitudeUtilities.SaveDataToTable("questionCategoryTableProcedure", "category", Cat, "OperationId", 0);
            List<QuestionCategory> QnCat = FillQuestions();
            return QnCat;
        }
        public static List<QuestionCategory> FillQuestions()
        {
            List<QuestionCategory> QnCat = new List<QuestionCategory>();

            DataTable ds = AptitudeUtilities.Datafill("questionCategoryTableProcedure", "OperationId", 1);
            foreach (DataRow row in ds.Rows)
            {
                QuestionCategory QuestionCat = new QuestionCategory();
                QuestionCat.Name = row["CatogoryName"].ToString();
                QuestionCat.Id = Convert.ToInt16(row["Id"]);
                QnCat.Add(QuestionCat);
            }
            return QnCat;
        }
        public static List<QuestionCategory> DeleteQnCategory(int id)
        {
            AptitudeUtilities.DeleteData("questionCategoryTableProcedure", "id", id, "OperationId", 2);

            List<QuestionCategory> QnCat = FillQuestions();
            return QnCat;
        }
        public static List<QuestionCategory> UpdateCategory(int id, string Cat)
        {
            AptitudeUtilities.SaveDataToTable("questionCategoryTableProcedure", "id", id, "category",Cat, "OperationId", 3);


            List<QuestionCategory> QnCat = FillQuestions();
            return QnCat;
        }
    }
}