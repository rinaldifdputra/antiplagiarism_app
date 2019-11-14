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
    public class SlidersController : Controller
    {
        private antiplagiarism_dbEntities db = new antiplagiarism_dbEntities();

        // GET: Sliders
        public ActionResult Index()
        {
            var sliders = db.sliders.Include(s => s.user);
            return View(sliders.ToList());
        }

        // GET: Sliders/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            slider slider = db.sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: Sliders/Create
        public ActionResult Create()
        {
            ViewBag.ID_user = new SelectList(db.users, "ID_user", "username");
            return View();
        }

        // POST: Sliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sliderID,sliderTitle,sliderHtml,sliderImg,active,last_update,ID_user")] slider slider)
        {
            if (ModelState.IsValid)
            {
                string user = User.Identity.Name.ToString();
                int userId = Convert.ToInt32(db.users.Single(a => a.username == user).ID_user);

                slider.ID_user = userId;
                slider.last_update = Convert.ToDateTime(DateTime.Now);
                db.sliders.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_user = new SelectList(db.users, "ID_user", "username", slider.ID_user);
            return View(slider);
        }

        // GET: Sliders/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            slider slider = db.sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_user = new SelectList(db.users, "ID_user", "username", slider.ID_user);
            return View(slider);
        }

        // POST: Sliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sliderID,sliderTitle,sliderHtml,sliderImg,active,last_update,ID_user")] slider slider)
        {
            if (ModelState.IsValid)
            {
                string user = User.Identity.Name.ToString();
                int userId = Convert.ToInt32(db.users.Single(a => a.username == user).ID_user);

                slider.ID_user = userId;
                slider.last_update = Convert.ToDateTime(DateTime.Now);
                db.Entry(slider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_user = new SelectList(db.users, "ID_user", "username", slider.ID_user);
            return View(slider);
        }

        // GET: Sliders/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            slider slider = db.sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            slider slider = db.sliders.Find(id);
            db.sliders.Remove(slider);
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
