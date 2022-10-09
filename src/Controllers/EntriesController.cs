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
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Entry entry)
        {
            if (ModelState.IsValid)
            {
                _entriesRepository.AddEntry(entry);

            }
            return View(entry);
        }

        public ActionResult Edit(int? id)
        {
            if (id is null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            return View();
        }
        public ActionResult Delete(int? id)
        {
            if (id is null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            return View();
        }
    }
}