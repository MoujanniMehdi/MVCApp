using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Controllers
{
    public class ProjetsController : Controller
    {
        private readonly SchoolContext _context;

        public ProjetsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Projets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Projet.ToListAsync());
        }

        // GET: Projets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projet = await _context.Projet
                .SingleOrDefaultAsync(m => m.ID == id);
            if (projet == null)
            {
                return NotFound();
            }

            return View(projet);
        }

        // GET: Projets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,nameProjet,theme,description")] Projet projet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projet);
        }

        // GET: Projets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projet = await _context.Projet.SingleOrDefaultAsync(m => m.ID == id);
            if (projet == null)
            {
                return NotFound();
            }
            return View(projet);
        }

        // POST: Projets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,nameProjet,theme,description")] Projet projet)
        {
            if (id != projet.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetExists(projet.ID))
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
            return View(projet);
        }

        // GET: Projets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projet = await _context.Projet
                .SingleOrDefaultAsync(m => m.ID == id);
            if (projet == null)
            {
                return NotFound();
            }

            return View(projet);
        }

        // POST: Projets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projet = await _context.Projet.SingleOrDefaultAsync(m => m.ID == id);
            _context.Projet.Remove(projet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetExists(int id)
        {
            return _context.Projet.Any(e => e.ID == id);
        }
    }
}
