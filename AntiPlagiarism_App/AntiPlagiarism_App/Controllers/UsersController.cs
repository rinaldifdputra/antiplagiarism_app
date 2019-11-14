using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AntiPlagiarism_App.Models;

namespace AntiPlagiarism_App.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private antiplagiarism_dbEntities db = new antiplagiarism_dbEntities();

        // GET: users
        
        public ActionResult Index()
        {
            var users = db.users.Include(u => u.role);
            return View(users.ToList());
        }

        // GET: users/Details/5
        
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: users/Create
        
        public ActionResult Create()
        {
            ViewBag.roleID = new SelectList(db.roles, "roleID", "roleNm");
            return View();
        }

        // POST: users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_user,username,password,roleID,email,phone,active,created_date")] user user)
        {
            var query = from a in db.users
                        where a.username == user.username
                        select a;
            if(query.ToList().Count > 0)
            {
                ViewBag.Warning = "Warning";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    user.created_date = Convert.ToDateTime(DateTime.Now);
                    db.users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.roleID = new SelectList(db.roles, "roleID", "roleNm", user.roleID);
            return View(user);
        }

        // GET: users/Edit/5
        
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.roleID = new SelectList(db.roles, "roleID", "roleNm", user.roleID);
            return View(user);
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_user,username,password,roleID,email,phone,active,created_date")] user user)
        {
            if (ModelState.IsValid)
            {
                user.created_date = Convert.ToDateTime(DateTime.Now);
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.roleID = new SelectList(db.roles, "roleID", "roleNm", user.roleID);
            return View(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
