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
    public class LegionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LegionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Legion
        public async Task<IActionResult> Index()
        {
            var legions = _unitOfWork.LegionRepository.Get();
            return View(legions);
        }

        // GET: Legion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var legion = _unitOfWork.LegionRepository.GetById(id);
            if (legion == null)
            {
                return NotFound();
            }

            return View(legion);
        }

        // GET: Legion/Create
        public IActionResult Create()
        {
            return View(new Legion());
        }

        // POST: Legion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,GeneralJediId,Id")] Legion legion)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.LegionRepository.Insert(legion);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(legion);
        }

        // GET: Legion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var legion = _unitOfWork.LegionRepository.GetById(id);
            if (legion == null)
            {
                return NotFound();
            }
            return View(legion);
        }

        // POST: Legion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,GeneralJediId,Id")] Legion legion)
        {
            if (id != legion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.LegionRepository.Update(legion);
                    _unitOfWork.Save();
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(legion);
        }

        // GET: Legion/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            var legion = _unitOfWork.LegionRepository.GetById(id);

            return View(legion);
        }

        // POST: Legion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                _unitOfWork.LegionRepository.Delete(id);
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
