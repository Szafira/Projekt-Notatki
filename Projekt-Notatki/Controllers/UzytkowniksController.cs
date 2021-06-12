using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt_Notatki.Data.Migrations;
using Projekt_Notatki.Models;

namespace Projekt_Notatki.Controllers
{
    public class UzytkowniksController : Controller
    {
        private readonly UzytkownikContext _context;

        public UzytkowniksController(UzytkownikContext context)
        {
            _context = context;
        }

        // GET: Uzytkowniks
        public async Task<IActionResult> Index()
        {
            return View(await _context.uzytkownik.ToListAsync());
        }

        // GET: Uzytkowniks/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownik = await _context.uzytkownik
                .FirstOrDefaultAsync(m => m.id_uzytkownik == id);
            if (uzytkownik == null)
            {
                return NotFound();
            }

            return View(uzytkownik);
        }

        // GET: Uzytkowniks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Uzytkowniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_uzytkownik,nazwa_uzytkownika,email,haslo")] uzytkownik uzytkownik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uzytkownik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uzytkownik);
        }

        // GET: Uzytkowniks/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownik = await _context.uzytkownik.FindAsync(id);
            if (uzytkownik == null)
            {
                return NotFound();
            }
            return View(uzytkownik);
        }

        // POST: Uzytkowniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("id_uzytkownik,nazwa_uzytkownika,email,haslo")] uzytkownik uzytkownik)
        {
            if (id != uzytkownik.id_uzytkownik)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uzytkownik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!uzytkownikExists(uzytkownik.id_uzytkownik))
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
            return View(uzytkownik);
        }

        // GET: Uzytkowniks/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownik = await _context.uzytkownik
                .FirstOrDefaultAsync(m => m.id_uzytkownik == id);
            if (uzytkownik == null)
            {
                return NotFound();
            }

            return View(uzytkownik);
        }

        // POST: Uzytkowniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var uzytkownik = await _context.uzytkownik.FindAsync(id);
            _context.uzytkownik.Remove(uzytkownik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool uzytkownikExists(decimal id)
        {
            return _context.uzytkownik.Any(e => e.id_uzytkownik == id);
        }
    }
}
