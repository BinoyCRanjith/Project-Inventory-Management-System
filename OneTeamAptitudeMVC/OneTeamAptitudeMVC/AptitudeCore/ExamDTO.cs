using OneTeamAptitudeMVC.Constants;
using OneTeamAptitudeMVC.Helper;
using OneTeamAptitudeMVC.Models;
using OneTeamAptitudeMVC.Scripts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.AptitudeCore
{
    public class ExamDTO
    {
        int? UserId;
        public ExamDTO()
        {
            UserId = SessionManager.UserID;
        }
        public static List<Questions> FillQuestions(int CatId, int NoOfqns)
        {
            List<Questions> QnsList = new List<Questions>();
            DataTable ds = AptitudeUtilities.Datafill(StoredProcedure.QeustionFillSp, "catId", CatId, "NoOfQn", NoOfqns);
            foreach (DataRow row in ds.Rows)
            {
                Questions questions = new Questions();
                questions.Id = Convert.ToInt16(row["Id"]);
                questions.CatagoryId = Convert.ToInt16(row["CatagoryId"]);
                questions.Question = row["Question"].ToString();
                questions.Option1 = row["Option1"].ToString();
                questions.Option2 = row["Option2"].ToString();
                questions.Option3 = row["Option3"].ToString();
                questions.Option4 = row["Option4"].ToString();
                questions.AnswerKey = row["AnswerKey"].ToString();
                questions.CatogoryName = row["CatogoryName"].ToString();
                QnsList.Add(questions);
            }
            return QnsList;
        }
        public static List<ExamResult> ExamResultOfStud()
        {
            ExamDTO ExDto = new ExamDTO();
            List<ExamResult> Examlist = new List<Models.ExamResult>();
          DataTable ds= AptitudeUtilities.Datafill(StoredProcedure.ExamHistorySp, "userId", ExDto.UserId, "OperationId", 1);
            foreach (DataRow row in ds.Rows)
            {
                ExamResult ExRes = new ExamResult();
                ExRes.Category = row["CatogoryName"].ToString();
                ExRes.Total = Convert.ToInt16(row["total"]);
                ExRes.DateOfExam=Convert.ToDateTime(row["ExamDate"]);
                ExRes.Markscored= Convert.ToInt16(row["MarkScored"]);
                Examlist.Add(ExRes);
            }

            return Examlist;
        }
        public static List<DataPoint> ExamHistory()
        {
            List<DataPoint> DataPointList = new List<DataPoint>();
            DataTable ds = AptitudeUtilities.Datafill(StoredProcedure.ExamHistorySp, "OperationId",1, "userId", SessionManager.UserID);
            foreach (DataRow row in ds.Rows)
            {

                DataPoint Dp = new DataPoint(Convert.ToInt16(row["MarkScored"].ToString()),(row["ExamDate"].ToString()));
                DataPointList.Add(Dp);
            }
            return DataPointList;
        }
                public static Boolean GetTodaysExam()
        {
            DataTable ds = AptitudeUtilities.Datafill("SelectStudExamResultToday", "userId",SessionManager.UserID);
            if (ds.Rows.Count>0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void SubmitExam(string Result)
        {
            string[] tokens = Result.Split(',');
           
            AptitudeUtilities.SaveDataToTable("StudExamHistory", "OperationId", 0, "userId", SessionManager.UserID, "levelQnId",Convert.ToInt16(SessionManager.ExamDetails.Level.Id), "status", 1, "MarkScored",Convert.ToInt32(tokens[0]), "total", Convert.ToInt16(SessionManager.ExamDetails.TotalQuestion));
            if(Convert.ToInt16(tokens[0])>= Convert.ToInt32(SessionManager.ExamDetails.Passmark))
            {
                AptitudeUtilities.SaveDataToTable("ExamTableProcedure", "userId",SessionManager.UserID, "OperationId", 3);

            }
        }
        public static List<ExamStats> QuickExamForStudent()
        {
            List<ExamStats> ExamStatList =new List<ExamStats>();
             DataTable dt = AptitudeUtilities.Datafill("ExamTableProcedure", "userId", SessionManager.UserID, "OperationId", 4);
            foreach (DataRow row in dt.Rows)
            {
                ExamStats ExStat = new ExamStats();
                ExStat.QuestionCategory = new QuestionCategory();
                ExStat.Level = new Level();
                ExStat.Level.Id                 =    Convert.ToInt16(row["LevelId"]);
                ExStat.Level.Name               =    row["LevelOfExam"].ToString();
                ExStat.QuestionCategory.Id      =    Convert.ToInt16(row["CatId"]);
                ExStat.QuestionCategory.Name    =    row["CatogoryName"].ToString();
                ExStat.Passmark                 =    Convert.ToInt16(row["passmark"]);
                ExStat.TimeForExam              =    Convert.ToInt16(row["TimeForExam"]);
                ExStat.TotalQuestion            =    Convert.ToInt16(row["totalQn"]);
                ExamStatList.Add(ExStat);
                
            }
           
            return ExamStatList;
        }



    }

}