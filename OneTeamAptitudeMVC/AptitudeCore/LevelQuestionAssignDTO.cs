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
    public class LevelQuestionAssignDTO
    {
        public static List<LevelAssign> GetAllLevelAssign()
        {
            List<LevelAssign> LvlList = new List<LevelAssign>();
            DataTable Ds= AptitudeUtilities.Datafill(StoredProcedure.LevelQuestionSp, "OperationId", 1);

            foreach (DataRow row in Ds.Rows)
            {
                LevelAssign LvlAssgn = new LevelAssign();
                LvlAssgn.Category = new QuestionCategory();
                LvlAssgn.Level = new Level();
                LvlAssgn.Category.Name = row["CatogoryName"].ToString();
                LvlAssgn.Category.Id = Convert.ToInt16(row["CatId"]);
                LvlAssgn.LevelQnId = Convert.ToInt16(row["id"]);
                LvlAssgn.Instruction = row["instruction"].ToString();
                LvlAssgn.Level.Id = Convert.ToInt16(row["LevelId"]);
                LvlAssgn.Level.Name = row["LevelOfExam"].ToString();
                LvlAssgn.Totalmark = Convert.ToInt16(row["totalQn"]);
                LvlAssgn.Passmark = Convert.ToInt16(row["passmark"]);
                LvlAssgn.TimeForExam = 10;
                    //Convert.ToInt16(row["TimeForExam"]);
                LvlList.Add(LvlAssgn);
            }
            return LvlList;
        }
        public static LevelAssign GetOneLevel(int Id)
        {
           DataTable ds= AptitudeUtilities.Datafill(StoredProcedure.LevelQuestionSp, "OperationId", 4,"id",Id);
            LevelAssign LvlAssgn = new LevelAssign();

            foreach (DataRow row in ds.Rows)
            {
                   LvlAssgn.Category = new QuestionCategory();
                   LvlAssgn.Level = new Level();
                   LvlAssgn.Category.Name = row["CatogoryName"].ToString();
                   LvlAssgn.Category.Id = Convert.ToInt16(row["CatId"]);
                   LvlAssgn.LevelQnId = Convert.ToInt16(row["id"]);
                   LvlAssgn.Instruction = row["instruction"].ToString();
                   LvlAssgn.Level.Id = Convert.ToInt16(row["LevelId"]);
                   LvlAssgn.Level.Name = row["LevelOfExam"].ToString();
                   LvlAssgn.Totalmark = Convert.ToInt16(row["totalQn"]);
                   LvlAssgn.Passmark = Convert.ToInt16(row["passmark"]);
                   LvlAssgn.TimeForExam = 10;
                   //Convert.ToInt16(row["TimeForExam"]);

            }
            return LvlAssgn;
        }
        public static void EditLevel(LevelAssign levelAssign)
        {
           Boolean b= AptitudeUtilities.SaveDataToTable(StoredProcedure.LevelQuestionSp, "catId",levelAssign.Category.Id
                , "LevelId",levelAssign.Level.Id, "Mark",levelAssign.Passmark
                , "totalQn",levelAssign.Totalmark, "OperationId", 3, "id",levelAssign.LevelQnId, "instruction",levelAssign.Instruction);

        }
        public static List<Level> FillLevel()
        {
            List<Level> LevelList = new List<Level>();

            DataTable Ds =AptitudeUtilities.Datafill(StoredProcedure.ListAllLevel);
            foreach (DataRow row in Ds.Rows)
            {
                Level Lvl = new Level();
                Lvl.Id = Convert.ToInt16(row["id"]);
                Lvl.Name = row["LevelOfExam"].ToString();
                LevelList.Add(Lvl);
            }
            return LevelList;
        }
        public static List<QuestionCategory> FillCat()
        {
            List<QuestionCategory> CatList = new List<QuestionCategory>();
            DataTable Ds= AptitudeUtilities.Datafill(StoredProcedure.ListQuestionCategory, "OperationId", 1);
            foreach (DataRow row in Ds.Rows)
            {
                QuestionCategory QnCat = new QuestionCategory();
                QnCat.Id = Convert.ToInt16(row["id"]);
                QnCat.Name = row["CatogoryName"].ToString();
                CatList.Add(QnCat);

            }
            return CatList;
        }
        public static void SaveNewLevel(LevelAssign levelAssign)
        {
            AptitudeUtilities.SaveDataToTable(StoredProcedure.LevelQuestionSp, "catId",levelAssign.Category.Id, "LevelId",levelAssign.Level.Id, "Mark",levelAssign.Passmark, "totalQn",levelAssign.Totalmark, "instruction",levelAssign.Instruction, "OperationId", 0);


        }
        public static void DeleteLevel(int id)
        {
            AptitudeUtilities.DeleteData(StoredProcedure.LevelQuestionSp, "id", id,"OperationId",2);
        }
    }
}