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
    public class JediController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public JediController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Jedi
        public async Task<IActionResult> Index()
        {
            var jedis = _unitOfWork.JediRepository.Get();
            return View(jedis);
        }

        // GET: Jedi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var jedi = _unitOfWork.DroidRepository.GetById(id);
            if (jedi == null)
            {
                return NotFound();
            }

            return View(jedi);
        }

        // GET: Jedi/Create
        public IActionResult Create()
        {
            return View(new Jedi());
        }

        // POST: Jedi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,PadawanId,TeacherId,LegionId,Id")] Jedi jedi)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.JediRepository.Insert(jedi);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(jedi);
        }

        // GET: Jedi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var jedi = _unitOfWork.JediRepository.GetById(id);
            if (jedi == null)
            {
                return NotFound();
            }
            return View(jedi);
        }

        // POST: Jedi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,PadawanId,TeacherId,LegionId,Id")] Jedi jedi)
        {
            if (id != jedi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.JediRepository.Update(jedi);
                    _unitOfWork.Save();
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jedi);
        }

        // GET: Jedi/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            var jedi = _unitOfWork.JediRepository.GetById(id);

            return View(jedi);
        }

        // POST: Jedi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                _unitOfWork.JediRepository.Delete(id);
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
