using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PNA_DayLap_On.Models;

namespace PNA_DayLap_On.Controllers
{
    public class pna_LoaiSanPhamController : Controller
    {
        private readonly PNADay09context _context;

        public pna_LoaiSanPhamController(PNADay09context context)
        {
            _context = context;
        }

        // GET: pna_LoaiSanPham
        public async Task<IActionResult> Index()
        {
            return View(await _context.pna_LoaiSanPhams.ToListAsync());
        }

        // GET: pna_LoaiSanPham/Details/5
        public async Task<IActionResult> Details(long? pnaid)
        {
            if (pnaid == null)
            {
                return NotFound();
            }

            var pna_LoaiSanPham = await _context.pna_LoaiSanPhams
                .FirstOrDefaultAsync(m => m.ID == pnaid);
            if (pna_LoaiSanPham == null)
            {
                return NotFound();
            }

            return View(pna_LoaiSanPham);
        }

        // GET: pna_LoaiSanPham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: pna_LoaiSanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MaLoaiSanPham,TenLoaiSanPham,TrangThai")] pna_LoaiSanPham pna_LoaiSanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pna_LoaiSanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pna_LoaiSanPham);
        }

        // GET: pna_LoaiSanPham/Edit/5
        public async Task<IActionResult> Edit(long? pnaid)
        {
            if (pnaid == null)
            {
                return NotFound();
            }

            var pna_LoaiSanPham = await _context.pna_LoaiSanPhams.FindAsync(pnaid);
            if (pna_LoaiSanPham == null)
            {
                return NotFound();
            }
            return View(pna_LoaiSanPham);
        }

        // POST: pna_LoaiSanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long pnaid, [Bind("ID,MaLoaiSanPham,TenLoaiSanPham,TrangThai")] pna_LoaiSanPham pna_LoaiSanPham)
        {
            if (pnaid != pna_LoaiSanPham.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pna_LoaiSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!pna_LoaiSanPhamExists(pna_LoaiSanPham.ID))
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
            return View(pna_LoaiSanPham);
        }

        // GET: pna_LoaiSanPham/Delete/5
        public async Task<IActionResult> Delete(long? pnaid)
        {
            if (pnaid == null)
            {
                return NotFound();
            }

            var pna_LoaiSanPham = await _context.pna_LoaiSanPhams
                .FirstOrDefaultAsync(m => m.ID == pnaid);
            if (pna_LoaiSanPham == null)
            {
                return NotFound();
            }

            return View(pna_LoaiSanPham);
        }

        // POST: pna_LoaiSanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long pnaid)
        {
            var pna_LoaiSanPham = await _context.pna_LoaiSanPhams.FindAsync(pnaid);
            if (pna_LoaiSanPham != null)
            {
                _context.pna_LoaiSanPhams.Remove(pna_LoaiSanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool pna_LoaiSanPhamExists(long pnaid)
        {
            return _context.pna_LoaiSanPhams.Any(e => e.ID == pnaid);
        }
    }
}
