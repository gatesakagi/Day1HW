using Day1HW.Models;
using Day1HW.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1HW.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admins")]
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                List<AccountContentViewModel> accountList = new List<AccountContentViewModel>();
                using (SkillTreeHomeworkEntities context = new SkillTreeHomeworkEntities())
                {
                    var query = from item in context.AccountBook
                                orderby item.Dateee descending
                                select item;
                    foreach (var item in query)
                        accountList.Add(new AccountContentViewModel { accountCategory = item.Categoryyy, accountFee = item.Amounttt, accountDate = item.Dateee, accountNote = item.Remarkkk });
                }
                return View(accountList);
            }
            else
            {
                return RedirectToAction("Index", new { controller = "Home", area = "" });
            }
        }
    }
}