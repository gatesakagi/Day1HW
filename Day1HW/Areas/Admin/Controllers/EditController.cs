using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1HW.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admins")]
    public class EditController : Controller
    {
        // GET: Admin/Edit
        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                return View();
            } else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            
        }
    }
}