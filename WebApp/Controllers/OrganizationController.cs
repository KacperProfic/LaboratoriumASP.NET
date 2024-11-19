using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly AppDbContext _context;

        public OrganizationController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Organization
        public async Task<IActionResult> Index()
        {
            var organizations = await _context.Organizations.ToListAsync();
            var organizationModels = organizations.Select(OrganizationMapper.FromEntity).ToList();
            return View(organizationModels);
        }

        // GET: Organization/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationEntity = await _context.Organizations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizationEntity == null)
            {
                return NotFound();
            }

            var organizationModel = OrganizationMapper.FromEntity(organizationEntity);
            return View(organizationModel);
        }

        // GET: Organization/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organization/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NIP,REGON, Address")] OrganizationModel organizationModel)
        {
            if (ModelState.IsValid)
            {
                var organizationEntity = OrganizationMapper.ToEntity(organizationModel);
                _context.Add(organizationEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organizationModel);
            
        }

        // GET: Organization/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationEntity = await _context.Organizations.FindAsync(id);
            if (organizationEntity == null)
            {
                return NotFound();
            }

            var organizationModel = OrganizationMapper.FromEntity(organizationEntity);
            return View(organizationModel);
        }

        // POST: Organization/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NIP,REGON, Address")] OrganizationModel organizationModel)
        {
            if (id != organizationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var organizationEntity = OrganizationMapper.ToEntity(organizationModel);
                    _context.Update(organizationEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizationEntityExists(organizationModel.Id))
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
            return View(organizationModel);
        }

        // GET: Organization/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationEntity = await _context.Organizations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizationEntity == null)
            {
                return NotFound();
            }

            var organizationModel = OrganizationMapper.FromEntity(organizationEntity);
            return View(organizationModel);
        }

        // POST: Organization/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizationEntity = await _context.Organizations.FindAsync(id);
            if (organizationEntity != null)
            {
                _context.Organizations.Remove(organizationEntity);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizationEntityExists(int id)
        {
            return _context.Organizations.Any(e => e.Id == id);
        }
    }
}