using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using SikayetSitesiMvc.Models;

namespace SikayetSitesiMvc.Controllers
{
    public class ComplaintController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Complaint
        public ActionResult Index()
        {
            return View(db.Complaints.ToList());
        }

        // GET: Complaint/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // GET: Complaint/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Complaint/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Complaint complaint, HttpPostedFileBase image)
        {

           
            if (image != null)
            {
                WebImage img = new WebImage(image.InputStream);
                FileInfo fotoinfo = new FileInfo(image.FileName);

                string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                img.Resize(800, 350);
                img.Save("../Uploads/Photo/" + newfoto);
                complaint.Photo = "../Uploads/Photo/" + newfoto;

            }
            db.Complaints.Add(complaint);
            db.SaveChanges();
            return RedirectToAction("Index");

            
        }

        // GET: Complaint/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // POST: Complaint/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Complaint complaint,HttpPostedFileBase image)

        {
            var updatecomplaint = db.Complaints.Where(s => s.ComplaintID == id).SingleOrDefault();
            if (image != null)
            {
                if (System.IO.File.Exists(Server.MapPath(complaint.Photo)))
                {
                    System.IO.File.Delete(Server.MapPath(complaint.Photo));
                }

                WebImage img = new WebImage(image.InputStream);
                FileInfo photoInfo = new FileInfo(image.FileName);

                string newfoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                img.Resize(800, 350); //resim boyutu için
                img.Save("~/Uploads/Photo/" + newfoto);
                updatecomplaint.Photo = "/Uploads/Photo/" + newfoto;
                updatecomplaint.CabStand = complaint.CabStand;
                updatecomplaint.Content =complaint.Content;
                updatecomplaint.Date = updatecomplaint.Date;
                updatecomplaint.LineNumber = complaint.LineNumber;
                updatecomplaint.PlateNo = complaint.PlateNo;
                updatecomplaint.TasitTuru = complaint.TasitTuru;
                updatecomplaint.Title = complaint.Title;
               
                db.SaveChanges();
            }


            return RedirectToAction("Index");
        }

        // GET: Complaint/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // POST: Complaint/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Complaint complaint = db.Complaints.Find(id);
            db.Complaints.Remove(complaint);
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
