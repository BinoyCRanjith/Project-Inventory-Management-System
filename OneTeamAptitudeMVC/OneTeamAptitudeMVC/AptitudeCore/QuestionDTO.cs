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
    public class QuestionDTO
    {
        public static List<Questions> GetAllQuestions()
        {
            List<Questions> ListQn = new List<Questions>();
            DataTable Dt = AptitudeUtilities.Datafill(StoredProcedure.AptitudeQnTableSP, "OperationId", 1);
            foreach (DataRow row in Dt.Rows)
            {
                Questions Qns = new Questions();

                Qns.Id = Convert.ToInt16(row["Id"]);
                Qns.AnswerKey = row["AnswerKey"].ToString();
                Qns.Option1 = row["Option1"].ToString();
                Qns.Option2 = row["Option2"].ToString();
                Qns.Option3 = row["Option3"].ToString();
                Qns.Option4 = row["Option4"].ToString();
                Qns.Question = row["Question"].ToString();
                Qns.CatogoryName = row["CatogoryName"].ToString();
                Qns.CatagoryId = Convert.ToInt16(row["CatagoryId"]);
                ListQn.Add(Qns);

            }
            return ListQn;
        }
        public static Questions GetQnUsingId(int Qid)
        {
            Questions Qns = new Questions();

            DataTable Dt = AptitudeUtilities.Datafill(StoredProcedure.AptitudeQnTableSP, "OperationId", 4, "id", Qid);
            foreach (DataRow row in Dt.Rows)
            {

                Qns.Id = Convert.ToInt16(row["Id"]);
                Qns.AnswerKey = row["AnswerKey"].ToString();
                Qns.Option1 = row["Option1"].ToString();
                Qns.Option2 = row["Option2"].ToString();
                Qns.Option3 = row["Option3"].ToString();
                Qns.Option4 = row["Option4"].ToString();
                Qns.Question = row["Question"].ToString();
                //Qns.CatogoryName = row["CatogoryName"].ToString();
                Qns.CatagoryId = Convert.ToInt16(row["CatagoryId"]);

            }
            return Qns;
        }

        public static List<QuestionCategory> GetAllQnCategory()
        {
            List<QuestionCategory> ListQnCat = new List<QuestionCategory>();
            DataTable ds = AptitudeUtilities.Datafill(StoredProcedure.ListQuestionCategory, "OperationId", 1);
            foreach (DataRow row in ds.Rows)
            {
                QuestionCategory QnCat = new QuestionCategory();
                QnCat.Id = Convert.ToInt16(row["Id"]);
                QnCat.Name = row["CatogoryName"].ToString();
                ListQnCat.Add(QnCat);
            }
            return ListQnCat;

        }
        public static Boolean DeleteQn(int id)
        {
            AptitudeUtilities.DeleteData(StoredProcedure.AptitudeQnTableSP, "id", id, "OperationId", 2);
            return true;
        }
        public static List<ExamResult> StudentExamResult()
        {
            List<ExamResult> ExList = new List<ExamResult>();
            DataTable ds = AptitudeUtilities.Datafill(StoredProcedure.ExamHistorySp, "OperationId", 2);
            foreach (DataRow row in ds.Rows)
            {
                ExamResult ER = new ExamResult();
                ER.DateOfExam = Convert.ToDateTime(row["ExamDate"]);
                ER.Category = row["CatogoryName"].ToString();
                ER.LevelOfExam = row["LevelOfExam"].ToString();
                ER.Markscored = Convert.ToInt16(row["MarkScored"].ToString());
                ER.Total = Convert.ToInt16(row["total"].ToString());
                ER.Name = row["Name"].ToString();
                ExList.Add(ER);

            }
            return ExList;
        }
        public static List<ExamResult> StudentAllExamResult()
        {
            List<ExamResult> ExList = new List<ExamResult>();
            DataTable ds = AptitudeUtilities.Datafill(StoredProcedure.ExamHistorySp, "OperationId", 6);
            foreach (DataRow row in ds.Rows)
            {
                ExamResult ER = new ExamResult();
                ER.DateOfExam = Convert.ToDateTime(row["ExamDate"]);
                ER.Category = row["CatogoryName"].ToString();
                ER.LevelOfExam = row["LevelOfExam"].ToString();
                ER.Markscored = Convert.ToInt16(row["MarkScored"].ToString());
                ER.Total = Convert.ToInt16(row["total"].ToString());
                ER.Name = row["Name"].ToString();
                ExList.Add(ER);

            }
            return ExList;
        }
        public static List<DataPoint> GetExamResultAsDataPoint()
        {
            List<DataPoint> DataPointList = new List<DataPoint>();
            DataTable ds = AptitudeUtilities.Datafill(StoredProcedure.ExamHistorySp, "OperationId", 2);
            foreach (DataRow row in ds.Rows)
            {

                DataPoint Dp = new DataPoint(Convert.ToInt16(row["MarkScored"].ToString()), row["Name"].ToString());
                DataPointList.Add(Dp);
            }
            return DataPointList;
        }
        public static List<DataPoint> GetExamAttendStatts()
        {
            List<DataPoint> DataPointList = new List<DataPoint>();
            DataTable ds = AptitudeUtilities.Datafill(StoredProcedure.ExamHistorySp, "OperationId", 4);
            foreach (DataRow row in ds.Rows)
            {

                DataPoint Dp = new DataPoint(Convert.ToInt16(row["AttendedStud"]),Convert.ToInt16(row["Total"]), row["DepartmentName"].ToString());
                DataPointList.Add(Dp);
            }
            return DataPointList;
        }
        public static List<DataPoint> GetAverageOfStudent()
        {
            List<DataPoint> DataPointList = new List<DataPoint>();
            DataTable ds = AptitudeUtilities.Datafill(StoredProcedure.ExamHistorySp, "OperationId", 5);
            foreach (DataRow row in ds.Rows)
            {

                DataPoint Dp = new DataPoint(Convert.ToInt16(row["AvereageMark"]), row["Name"].ToString());
                DataPointList.Add(Dp);
            }
            return DataPointList;
        }
        public static void SaveQuestions(Questions questions)
        {
            AptitudeUtilities.SaveDataToTable(StoredProcedure.AptitudeQnTableSP, "CatagoryId"
                , questions.CatagoryId, "Question", questions.Question, "Option1"
                , questions.Option1, "Option2", questions.Option2, "Option3", questions.Option3,
                "Option4", questions.Option4, "AnswerKey", questions.AnswerKey, "OperationId", 0);
        }
        public static void UpdateQuestions(Questions questions)
        {
            AptitudeUtilities.SaveDataToTable(StoredProcedure.AptitudeQnTableSP, "CatagoryId"
               , questions.CatagoryId, "Question", questions.Question, "Option1"
               , questions.Option1, "Option2", questions.Option2, "Option3", questions.Option3,
               "Option4", questions.Option4, "AnswerKey", questions.AnswerKey, "OperationId", 3,"id",questions.Id);
        }
    }
}