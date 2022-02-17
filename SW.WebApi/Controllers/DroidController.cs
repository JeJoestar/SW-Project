#nullable disable
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SW.DAL;

namespace SW.WebAPI.Controllers
{
    public class DroidController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public DroidController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Droids
        public async Task<IActionResult> Index()
        {
            var droids = _unitOfWork.DroidRepository.Get();
            return View(droids);
        }

        // GET: Droids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var droid = _unitOfWork.DroidRepository.GetById(id);
            if (droid == null)
            {
                return NotFound();
            }

            return View(droid);
        }

        // GET: Droids/Create
        public IActionResult Create()
        {
            return View(new Droid());
        }

        // POST: Droids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Model,BaseId,StarshipId,Equipment,Id")] Droid droid)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.DroidRepository.Insert(droid);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(droid);
        }

        // GET: Droids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var droid = _unitOfWork.DroidRepository.GetById(id);
            if (droid  == null)
            {
                return NotFound();
            }
            return View(droid);
        }

        // POST: Droids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Model,BaseId,StarshipId,Equipment,Id")] Droid droid)
        {
            if (id != droid.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.DroidRepository.Update(droid);
                    _unitOfWork.Save();
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(droid);
        }

        // GET: Droids/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            var droid = _unitOfWork.DroidRepository.GetById(id);

            return View(droid);
        }

        // POST: Droids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                _unitOfWork.DroidRepository.Delete(id);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
