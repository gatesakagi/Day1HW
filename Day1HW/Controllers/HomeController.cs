using Day1HW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day1HW.Models.ViewModels;
using System.Data.Entity.Core.EntityClient;

namespace Day1HW.Controllers
{
    public class HomeController : Controller
    {
        [ChildActionOnly]
        public ActionResult ShowAccountContent()
        {
            List<AccountBook> accountList = new List<AccountBook>();

            //accountList.Add(new AccountContentViewModel { accountCategory = "支出", accountDate = new DateTime(2016, 1, 1), accountFee = 300, accountNote = "" });
            //accountList.Add(new AccountContentViewModel { accountCategory = "支出", accountDate = new DateTime(2016, 1, 2), accountFee = 1600, accountNote = "" });
            //accountList.Add(new AccountContentViewModel { accountCategory = "支出", accountDate = new DateTime(2016, 1, 3), accountFee = 800, accountNote = "" });
            using (SkillTreeHomeworkEntities context = new SkillTreeHomeworkEntities())
            {
                var query = from item in context.AccountBook
                            select new
                            {
                                a = item.Id,
                                b = item.Categoryyy,
                                c = item.Amounttt,
                                d = item.Dateee,
                                e = item.Remarkkk
                            };
                foreach (var item in query)
                    accountList.Add(new AccountBook { Id = item.a, Categoryyy = item.b, Amounttt = item.c, Dateee = item.d, Remarkkk = item.e });
            }
            return View(accountList);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}