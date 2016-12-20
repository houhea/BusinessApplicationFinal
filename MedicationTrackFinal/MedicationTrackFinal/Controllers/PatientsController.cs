using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MedicationTrackFinal.Models;

namespace MedicationTrackFinal.Controllers
{
    [Authorize(Roles = "Member, Admin")]
    public class PatientsController : Controller
    {
        private MedicationTrackDataModel db = new MedicationTrackDataModel();
    
        // GET: Patients
        public ActionResult Index()
        {
            var patients = db.Patients.Include(p => p.Medication).Include(p => p.Nurse);
            return View(patients.ToList());
        }
        
        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }
        [Authorize(Roles = "Admin")]
        // GET: Patients/Create
        public ActionResult Create()
        {
            ViewBag.MedicationId = new SelectList(db.Medications, "MedicationId", "Name");
            ViewBag.NurseId = new SelectList(db.Nurses, "NurseId", "FirstName");
            return View();
        }
        [Authorize(Roles = "Admin")]
        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientId,FirstName,LastName,BirthDate,Gender,NurseId,MedicationId")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MedicationId = new SelectList(db.Medications, "MedicationId", "Name", patient.MedicationId);
            ViewBag.NurseId = new SelectList(db.Nurses, "NurseId", "FirstName", patient.NurseId);
            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedicationId = new SelectList(db.Medications, "MedicationId", "Name", patient.MedicationId);
            ViewBag.NurseId = new SelectList(db.Nurses, "NurseId", "FirstName", patient.NurseId);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientId,FirstName,LastName,BirthDate,Gender,NurseId,MedicationId")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MedicationId = new SelectList(db.Medications, "MedicationId", "Name", patient.MedicationId);
            ViewBag.NurseId = new SelectList(db.Nurses, "NurseId", "FirstName", patient.NurseId);
            return View(patient);
        }
        [Authorize(Roles = "Admin")]
        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }
        [Authorize(Roles = "Admin")]
        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
