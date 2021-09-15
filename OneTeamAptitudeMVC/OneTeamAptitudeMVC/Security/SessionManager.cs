using OneTeamAptitudeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.Scripts
{
    public class SessionManager
    {
        static string UserIDSessionKey = "UserSession";
        static string AuthenticatedUserKey = "AuthenticatedUser";
        static string UserRollIdKey = "UserRollId";
        static string ExamCatId = "ExamCategory";
        static string TotalQuestion = "QuestionNumber";
        static string ExamStatistics = "LevelAssign";
        public static int? UserID
        {
            get
            {
                if (HttpContext.Current == null)
                    return null;

                var sessionData = HttpContext.Current.Session[UserIDSessionKey];
                if (sessionData == null)
                    return null;
                return (int)sessionData;
            }
            set
            {
                HttpContext.Current.Session[UserIDSessionKey] = value;
            }
        }

        public static User AuthenticatedUser
        {
            get
            {
                if (HttpContext.Current == null)
                    return null;

                var sessionData = HttpContext.Current.Session[AuthenticatedUserKey];
                if (sessionData == null)
                    return null;
                return (User)sessionData;
            }
            set
            {
                HttpContext.Current.Session[AuthenticatedUserKey] = value;
            }
        }
        public static ExamStats ExamDetails
        {
            get
            {
                if (HttpContext.Current == null)
                    return null;

                var sessionData = HttpContext.Current.Session[ExamStatistics];
                if (sessionData == null)
                    return null;
                return (ExamStats)sessionData;
            }
            set
            {
                HttpContext.Current.Session[ExamStatistics] = value;
            }
        }

        public static int RollId
        {
            get
            {
                if (HttpContext.Current == null)
                    return 0;

                var sessionData = HttpContext.Current.Session[UserRollIdKey];
                if (sessionData == null)
                    return 0;
                return (int)sessionData;
            }
            set
            {
                HttpContext.Current.Session[UserRollIdKey] = value;
            }
        }
        public static int ExamCat
        {
            get
            {
                if (HttpContext.Current == null)
                    return 0;

                var sessionData = HttpContext.Current.Session[ExamCatId];
                if (sessionData == null)
                    return 0;
                return (int)sessionData;
            }
            set
            {
                HttpContext.Current.Session[ExamCatId] = value;
            }
        }
        public static int NoOfQn
        {
            get
            {
                if (HttpContext.Current == null)
                    return 0;

                var sessionData = HttpContext.Current.Session[TotalQuestion];
                if (sessionData == null)
                    return 0;
                return (int)sessionData;
            }
            set
            {
                HttpContext.Current.Session[TotalQuestion] = value;
            }
        }
    }
}