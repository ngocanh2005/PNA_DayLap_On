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
    public class pna_SanPhamController : Controller
    {
        private readonly PNADay09context _context;

        public pna_SanPhamController(PNADay09context context)
        {
            _context = context;
        }

        // GET: pna_SanPham
        public async Task<IActionResult> Index()
        {
            var pNADay09context = _context.pna_SanPhams.Include(p => p.LoaiSanPham);
            return View(await pNADay09context.ToListAsync());
        }

        // GET: pna_SanPham/Details/5
        public async Task<IActionResult> Details(long? pnaid)
        {
            if (pnaid == null)
            {
                return NotFound();
            }

            var pna_SanPham = await _context.pna_SanPhams
                .Include(p => p.LoaiSanPham)
                .FirstOrDefaultAsync(m => m.ID == pnaid);
            if (pna_SanPham == null)
            {
                return NotFound();
            }

            return View(pna_SanPham);
        }

        // GET: pna_SanPham/Create
        public IActionResult Create()
        {
            ViewData["LoaiSanPhamID"] = new SelectList(_context.pna_LoaiSanPhams, "ID", "ID");
            return View();
        }

        // POST: pna_SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MaSanPham,TenSanPham,HinhAnh,Dongia,SoLuong,LoaiSanPhamID")] pna_SanPham pna_SanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pna_SanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoaiSanPhamID"] = new SelectList(_context.pna_LoaiSanPhams, "ID", "ID", pna_SanPham.LoaiSanPhamID);
            return View(pna_SanPham);
        }

        // GET: pna_SanPham/Edit/5
        public async Task<IActionResult> Edit(long? pnaid)
        {
            if (pnaid == null)
            {
                return NotFound();
            }

            var pna_SanPham = await _context.pna_SanPhams.FindAsync(pnaid);
            if (pna_SanPham == null)
            {
                return NotFound();
            }
            ViewData["LoaiSanPhamID"] = new SelectList(_context.pna_LoaiSanPhams, "ID", "ID", pna_SanPham.LoaiSanPhamID);
            return View(pna_SanPham);
        }

        // POST: pna_SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ID,MaSanPham,TenSanPham,HinhAnh,Dongia,SoLuong,LoaiSanPhamID")] pna_SanPham pna_SanPham)
        {
            if (id != pna_SanPham.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pna_SanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!pna_SanPhamExists(pna_SanPham.ID))
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
            ViewData["LoaiSanPhamID"] = new SelectList(_context.pna_LoaiSanPhams, "ID", "ID", pna_SanPham.LoaiSanPhamID);
            return View(pna_SanPham);
        }

        // GET: pna_SanPham/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pna_SanPham = await _context.pna_SanPhams
                .Include(p => p.LoaiSanPham)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pna_SanPham == null)
            {
                return NotFound();
            }

            return View(pna_SanPham);
        }

        // POST: pna_SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var pna_SanPham = await _context.pna_SanPhams.FindAsync(id);
            if (pna_SanPham != null)
            {
                _context.pna_SanPhams.Remove(pna_SanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool pna_SanPhamExists(long id)
        {
            return _context.pna_SanPhams.Any(e => e.ID == id);
        }
    }
}
