using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ReunionRegistrationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReunionRegistration
        public ActionResult Index()
        {
            return View(db.ReunionRegistrations.ToList());
        }


        public ActionResult RegHome()
        {
            return View();
        }

        public ActionResult RegistrationPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrationPage(ReunionRegistration reg)
        {
            if (ModelState.IsValid)
            {
                // Here, this mail ID used to receive the all mails from the clients
                WebMail.Send("shahidaafroj075@gmail.com"
                    , reg.FullName + " is comming to the reunion program."
                    , reg.Message + "<br/><br/> My Cell Phone Number : " + reg.PhoneNumber
                    + "<br/><br/> & My Email Address : " + reg.EmailAddress
                    , null
                    , null
                    , null
                    , true
                    , null
                    , null
                    , null
                    , null
                    , null
                    , reg.EmailAddress);


                WebMail.Send(reg.EmailAddress
    , "Congratulations!!<br/>" + "Hello, Mr./Mrs. " + reg.FullName + " Your registration confirmed"
    , reg.Message + "<br/><br/> Your Cell Phone Number : " + reg.PhoneNumber
    + "<br/><br/> & Your Email Address : " + reg.EmailAddress
    , null
    , null
    , null
    , true
    , null
    , null
    , null
    , null
    , null
    , "shahidaafroj075@gmail.com");





                //return RedirectToAction("ThankYouPage");
                if (ModelState.IsValid)
                {
                    db.ReunionRegistrations.Add(reg);
                    db.SaveChanges();
                    return RedirectToAction("ThankYouPage");
                }

            }
            return View();
        }

        public ActionResult ThankYouPage()
        {
            return View();
        }




        // GET: ReunionRegistration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReunionRegistration reunionRegistration = db.ReunionRegistrations.Find(id);
            if (reunionRegistration == null)
            {
                return HttpNotFound();
            }
            return View(reunionRegistration);
        }

        // GET: ReunionRegistration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReunionRegistration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReunionRegistrationId,FullName,EmailAddress,PhoneNumber,Message")] ReunionRegistration reunionRegistration)
        {
            if (ModelState.IsValid)
            {
                db.ReunionRegistrations.Add(reunionRegistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reunionRegistration);
        }

        // GET: ReunionRegistration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReunionRegistration reunionRegistration = db.ReunionRegistrations.Find(id);
            if (reunionRegistration == null)
            {
                return HttpNotFound();
            }
            return View(reunionRegistration);
        }

        // POST: ReunionRegistration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReunionRegistrationId,FullName,EmailAddress,PhoneNumber,Message")] ReunionRegistration reunionRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reunionRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reunionRegistration);
        }

        // GET: ReunionRegistration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReunionRegistration reunionRegistration = db.ReunionRegistrations.Find(id);
            if (reunionRegistration == null)
            {
                return HttpNotFound();
            }
            return View(reunionRegistration);
        }

        // POST: ReunionRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReunionRegistration reunionRegistration = db.ReunionRegistrations.Find(id);
            db.ReunionRegistrations.Remove(reunionRegistration);
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
