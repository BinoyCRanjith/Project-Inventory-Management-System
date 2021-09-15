using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.AptitudeCore
{
    public class OutputParameter
    {
        public int RetVal { get; set; }
        public DataType DataType { get; set; }
        public int ErrorNumber { get; set; }
        public string ErrorMessage { get; set; }
    }
}