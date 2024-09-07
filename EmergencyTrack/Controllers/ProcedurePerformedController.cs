﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyTrack.Api.Controllers
{
    public class ProcedurePerformedController : Controller
    {
        // GET: ProcedurePerformedController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProcedurePerformedController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProcedurePerformedController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProcedurePerformedController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProcedurePerformedController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProcedurePerformedController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProcedurePerformedController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProcedurePerformedController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}