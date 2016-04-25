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
            List<AccountContentViewModel> accountList = new List<AccountContentViewModel>();

            //accountList.Add(new AccountContentViewModel { accountCategory = "支出", accountDate = new DateTime(2016, 1, 1), accountFee = 300, accountNote = "" });
            //accountList.Add(new AccountContentViewModel { accountCategory = "支出", accountDate = new DateTime(2016, 1, 2), accountFee = 1600, accountNote = "" });
            //accountList.Add(new AccountContentViewModel { accountCategory = "支出", accountDate = new DateTime(2016, 1, 3), accountFee = 800, accountNote = "" });
            using (SkillTreeHomeworkEntities context = new SkillTreeHomeworkEntities())
            {
                var query = from item in context.AccountBook
                            orderby item.Dateee descending
                            select item;                            ;
                foreach (var item in query)
                    accountList.Add(new AccountContentViewModel { accountCategory = item.Categoryyy, accountFee = item.Amounttt, accountDate = item.Dateee, accountNote = item.Remarkkk });
            }
            return View(accountList);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AccountContentViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            var accountBookNew = new AccountBook
            {
                Id = Guid.NewGuid(),
                Categoryyy = data.accountCategory,
                Amounttt = (int)data.accountFee,
                Dateee = data.accountDate,
                Remarkkk = data.accountNote
            };

            SkillTreeHomeworkEntities db = new SkillTreeHomeworkEntities();
            db.AccountBook.Add(accountBookNew);
            db.SaveChanges();

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