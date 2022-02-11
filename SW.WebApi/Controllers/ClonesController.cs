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
    public class ClonesController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        // GET: Clones
        public async Task<IActionResult> Index()
        {

            var clones = _unitOfWork.CloneRepository.Get();
            return View(clones);
        }

        // GET: Clones/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var clone = _unitOfWork.CloneRepository.GetByID(id);
            if (clone == null)
            {
                return NotFound();
            }

            return View(clone);
        }

        // GET: Clones/Create
        public IActionResult Create()
        {
            return View(new Clone());
        }

        // POST: Clones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Number,LegionId,BaseId,StarshipId,Equipment,Qualification,Id")] Clone clone)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CloneRepository.Insert(clone);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(clone);
        }

        // GET: Clones/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var clone = _unitOfWork.CloneRepository.GetByID(id);
            if (clone == null)
            {
                return NotFound();
            }
            return View(clone);
        }

        // POST: Clones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Number,LegionId,BaseId,StarshipId,Equipment,Qualification,Id")] Clone clone)
        {
            if (id != clone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.CloneRepository.Update(clone);
                    _unitOfWork.Save();
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clone);
        }

        // GET: Clones/Delete/5
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            Clone clone = _unitOfWork.CloneRepository.GetByID(id);

            return View(clone);
        }

        // POST: Clones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                _unitOfWork.CloneRepository.Delete(id);
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
