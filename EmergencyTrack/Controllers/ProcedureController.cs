using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyTrack.Api.Controllers
{
    public class ProcedureController : Controller
    {
        // GET: ProcedureController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProcedureController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProcedureController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProcedureController/Create
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

        // GET: ProcedureController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProcedureController/Edit/5
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

        // GET: ProcedureController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProcedureController/Delete/5
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
