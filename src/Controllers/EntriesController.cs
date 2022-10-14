using FitnessFrog.Data;
using FitnessFrog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessFrog.Controllers
{
    public class EntriesController : Controller
    {
        private EntriesRepository _entriesRepository = null;
        public EntriesController()
        {
            _entriesRepository = new EntriesRepository();
        }

        public ActionResult Index()
        {
            List<Entry> entries = _entriesRepository.GetEntries();

            //Calculate the totla activity
            double totalActivity = 0;

            //double totalActivity = entries
            //    .Where(e => e.Exclude == false)
            //    .Sum(e => e.Duration);


            //Datermine the number of days that have entires
            //int numberOfActivityDays = entries
            //    .Select(e => e.Date)
            //    .Distinct()
            //    .Count();


            return View();
        }

        public ActionResult Add()
        {
            var entry = new Entry()
            {
                Date = DateTime.Today

            };

            SetupActivitiesSelectListItems();
            return View();
        }

        [HttpPost]
        public ActionResult Add(Entry entry)
        {
            ValidateEntry(entry);

            if (ModelState.IsValid)
            {
                _entriesRepository.AddEntry(entry);
                TempData["Message"] = "Your entry wass successfully added";
                return RedirectToAction("Index");
            }

            SetupActivitiesSelectListItems();

            return View(entry);
        }

       

        public ActionResult Edit(int? id)
        {
            if (id is null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            Entry entry = _entriesRepository.GetEntry((int)id);
            if (entry == null)
            {
                return HttpNotFound();
            }

            SetupActivitiesSelectListItems();

            return View(entry);
        }

        [HttpPost]
        public ActionResult Edit(Entry entry)
        {
            ValidateEntry(entry);

            if (ModelState.IsValid)
            {
                _entriesRepository.UpdateEntry(entry);
                TempData["Message"] = "Your entry wass successfully Updated";
                return RedirectToAction("Index");
            }
            
            SetupActivitiesSelectListItems();

            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id is null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            
            Entry entry = _entriesRepository.GetEntry((int)id);

            if (entry == null)
            {
                return HttpNotFound();
            }

            return View(entry);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _entriesRepository.DeleteEntry(id);
            TempData["Message"] = "Your entry wass successfully Deleted";
            return RedirectToAction("Index");
        }

        public void ValidateEntry(Entry entry)
        {
            if (ModelState.IsValidField("Duration") && entry.Duration <= 0)
            {
                ModelState.AddModelError("Duration", "The Duration filed value must  be greater than '0'. ");
            }
        }
        private void SetupActivitiesSelectListItems()
        {
            ViewBag.ActivitiesSelectListItems = new SelectList(
                                    Data.Data.Activities, "Id", "Name");
        }
    }
}