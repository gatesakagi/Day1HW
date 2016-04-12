using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day1HW.Models.ViewModels
{
    public class AccountContentViewModel
    {
        public string accountCategory { get; set; }
        public decimal accountFee { get; set; }
        public DateTime accountDate { get; set; }
        public string accountNote { get; set; }
    }
}