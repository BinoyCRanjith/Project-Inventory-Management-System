using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.AptitudeCore
{
    public sealed class DbResponse<TResult> : DbResponseBase<TResult> where TResult : class
    {
        public OutputParameter OutPutParameters { get; set; }
    }
}