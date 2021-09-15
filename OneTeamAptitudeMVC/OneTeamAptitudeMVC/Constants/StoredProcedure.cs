using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.Constants
{
    public class StoredProcedure
    {
        public const string userLogin = "userLogin";
        public const string QeustionFillSp = "QnFillProcedure";
        public const string ExamHistorySp = "StudExamHistory";
        public const string LevelQuestionSp = "LavelQuestions";
        public const string ListAllLevel = "SelectLevel";
        public const string ListQuestionCategory = "questionCategoryTableProcedure";
        public const string AptitudeQnTableSP= "ApptitudeQuestionTableProcedure";
        public const string ExamTableProcedure = "ExamTableProcedure";
        public const string ListAllUserSP = "selectAllUser";
        public const string SelectUser = "selectUser";
        public const string UserTableProcedure = "userTableProcedure";
        public const string UserRollSp = "selectUserRoll";
        public const string DepartmentSp = "departmentTableProcedure";
        public const string StudyMaterials = "StudyMaterialMultiAction";

    }
}