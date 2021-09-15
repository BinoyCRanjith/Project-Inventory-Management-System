using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.AptitudeCore
{
    public class DbResponseBase<TResult> where TResult : class
    {
        public TResult Data { get; set; }
        public bool Status { get; set; }
        public int RetVal { get; set; }
        public string ErrorMessage { get; set; }
        public int ErrorNumber { get; set; }

    }
}