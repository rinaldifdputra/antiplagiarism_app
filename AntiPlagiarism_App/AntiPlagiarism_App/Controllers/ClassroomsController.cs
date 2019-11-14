using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AntiPlagiarism_App.Models;
using PagedList;
using PagedList.Mvc;

namespace AntiPlagiarism_App.Controllers
{
    [Authorize]
    public class ClassroomsController : Controller
    {
        private antiplagiarism_dbEntities db = new antiplagiarism_dbEntities();

        // GET: classrooms
        public ActionResult Index(int? page, string searchString)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            string user = User.Identity.Name.ToString();
            var query = from a in db.users
                        join b in db.roles
                        on a.roleID equals b.roleID
                        where a.username == user
                        && b.roleNm == "Guru"
                        select b.roleNm;
            if (query.ToList().Count > 0)
            {
                var classrooms = from a in db.v_classroom
                                 select a;
                if(!String.IsNullOrEmpty(searchString))
                {
                    classrooms = classrooms.Where(a => a.classNm.Contains(searchString));
                }
                var cls = classrooms.ToList().OrderByDescending(a => a.classID);
                var data = cls.ToPagedList(pageIndex, pageSize);

                return View(data);
                //var classrooms = db.v_classroom.ToList().OrderByDescending(a => a.classID);
                //return View(classrooms.ToPagedList(pageIndex, pageSize));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: classrooms/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            classroom classroom = db.classrooms.Find(id);
            if (classroom == null)
            {
                return HttpNotFound();
            }
            return View(classroom);
        }

        // GET: classrooms/Create
        public ActionResult Create()
        {
            string user = User.Identity.Name.ToString();
            var query = from a in db.users
                        join b in db.roles
                        on a.roleID equals b.roleID
                        where a.username == user
                        && b.roleNm == "Guru"
                        select b.roleNm;
            if (query.ToList().Count > 0)
            {
                ViewBag.ID_user = new SelectList(db.users, "ID_user", "username");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: classrooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "classID,classNm,info,startDt,endDt,active,isPrivate,last_update,ID_user")] classroom classroom)
        {
            if (ModelState.IsValid)
            {
                string user = User.Identity.Name.ToString();
                int userId = Convert.ToInt32(db.users.Single(a => a.username == user).ID_user);

                classroom.ID_user = userId;
                classroom.last_update = Convert.ToDateTime(DateTime.Now);
                db.classrooms.Add(classroom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_user = new SelectList(db.users, "ID_user", "username", classroom.ID_user);
            return View(classroom);
        }

        // GET: classrooms/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string user = User.Identity.Name.ToString();
            var query = from a in db.users
                        join b in db.roles
                        on a.roleID equals b.roleID
                        where a.username == user
                        && b.roleNm == "Guru"
                        select b.roleNm;
            if (query.ToList().Count > 0)
            {
                classroom classroom = db.classrooms.Find(id);
                if (classroom == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ID_user = new SelectList(db.users, "ID_user", "username", classroom.ID_user);
                return View(classroom);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: classrooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "classID,classNm,info,startDt,endDt,active,isPrivate,last_update,ID_user")] classroom classroom)
        {
            if (ModelState.IsValid)
            {
                string user = User.Identity.Name.ToString();
                int userId = Convert.ToInt32(db.users.Single(a => a.username == user).ID_user);

                classroom.ID_user = userId;
                classroom.last_update = Convert.ToDateTime(DateTime.Now);
                db.Entry(classroom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_user = new SelectList(db.users, "ID_user", "username", classroom.ID_user);
            return View(classroom);
        }

        // GET: classrooms/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            classroom classroom = db.classrooms.Find(id);
            if (classroom == null)
            {
                return HttpNotFound();
            }
            return View(classroom);
        }

        // POST: classrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            classroom classroom = db.classrooms.Find(id);
            db.classrooms.Remove(classroom);
            db.SaveChanges();
            return RedirectToAction("Index");
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
