using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AntiPlagiarism_App.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Layout
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Header()
        {
            return PartialView();
        }

        public ActionResult _LeftSide()
        {
            return PartialView();
        }
    }
}