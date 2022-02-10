#nullable disable
using System;
using System.Collections.Generic;
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
        private readonly SWContext _context;
        private ICloneRepository _cloneRepository;

        public ClonesController(SWContext context)
        {
            _context = context;
        }
        public ClonesController(ICloneRepository cloneRepository)
        {
            _cloneRepository = cloneRepository;
        }

        // GET: Clones
        public async Task<IActionResult> Index()
        {
            var sWContext = _context.Clones.Include(c => c.Base).Include(c => c.Legion).Include(c => c.Starship);
            var clones = from s in _cloneRepository.GetClones()
                         select s;
            return View(await sWContext.ToListAsync());
        }

        // GET: Clones/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var clone = _cloneRepository.GetCloneByID(id);
            if (clone == null)
            {
                return NotFound();
            }

            return View(clone);
        }

        // GET: Clones/Create
        public IActionResult Create()
        {
            ViewData["BaseId"] = new SelectList(_context.Base, "Id", "Id");
            ViewData["LegionId"] = new SelectList(_context.Legions, "Id", "Id");
            ViewData["StarshipId"] = new SelectList(_context.Starships, "Id", "Id");
            return View();
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
                _cloneRepository.InsertClone(clone);
                _cloneRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BaseId"] = new SelectList(_context.Base, "Id", "Id", clone.BaseId);
            ViewData["LegionId"] = new SelectList(_context.Legions, "Id", "Id", clone.LegionId);
            ViewData["StarshipId"] = new SelectList(_context.Starships, "Id", "Id", clone.StarshipId);
            return View(clone);
        }

        // GET: Clones/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clone = _cloneRepository.GetCloneByID(id);
            if (clone == null)
            {
                return NotFound();
            }
            ViewData["BaseId"] = new SelectList(_context.Base, "Id", "Id", clone.BaseId);
            ViewData["LegionId"] = new SelectList(_context.Legions, "Id", "Id", clone.LegionId);
            ViewData["StarshipId"] = new SelectList(_context.Starships, "Id", "Id", clone.StarshipId);
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
                    _cloneRepository.UpdateClone(clone);
                    _cloneRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CloneExists(clone.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BaseId"] = new SelectList(_context.Base, "Id", "Id", clone.BaseId);
            ViewData["LegionId"] = new SelectList(_context.Legions, "Id", "Id", clone.LegionId);
            ViewData["StarshipId"] = new SelectList(_context.Starships, "Id", "Id", clone.StarshipId);
            return View(clone);
        }

        // GET: Clones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clone = await _context.Clones
                .Include(c => c.Base)
                .Include(c => c.Legion)
                .Include(c => c.Starship)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clone == null)
            {
                return NotFound();
            }

            return View(clone);
        }

        // POST: Clones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                _cloneRepository.DeleteClone(id);
                _cloneRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction("Delete", new { id = id });
            }
        }

        private bool CloneExists(int id)
        {
            return _context.Clones.Any(e => e.Id == id);
        }

        protected override void Dispose(bool disposing)
        {
            _cloneRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
