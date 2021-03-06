using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InternalNamuWebsiteAPI.Models;
using InternalNamuWebsiteAPI.Models.DTO;
using InternalNamuWebsiteAPI.Context;

namespace InternalNamuWebsiteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FrogdollarsController : Controller
    {
        private readonly OpenIdContext _context;

        public FrogdollarsController(OpenIdContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var openIdContext = _context.VirtualFds;
            return Ok(await openIdContext.ToListAsync());
        }

        [HttpGet("/api/frogdollars/{email}")]
        public async Task<IActionResult> GetByUser(string email)
        {
            var frogdollarList = await _context.VirtualFds.Include(i => i.UserNameNavigation).Where(i => i.UserNameNavigation.Mail == email).OrderByDescending(i => i.DateCreated).ToListAsync();
            var frogdollarsAmount = frogdollarList.Sum(i => i.Quantity);

            return Ok(new {
                frogdollarList,
                frogdollarsAmount
            });
        }

        [HttpPost("/api/frogdollars/SendFrogdollars")]
        public async Task<IActionResult> SendFrogdollars(FrogdollarRequestDTO frogdollarRequestDTO)
        {
            var result = false;
            var userFrom = await _context.UserOpenIds.Where(i => i.Mail == frogdollarRequestDTO.EmailFrom).FirstOrDefaultAsync();
            var userTo = await _context.UserOpenIds.Where(i => i.Mail == frogdollarRequestDTO.EmailTo).FirstOrDefaultAsync();

            if (userFrom.Fdcredits >= frogdollarRequestDTO.Quantity)
            {
                var newfrogdollars = new VirtualFd()
                {
                    Granter = userFrom.UserName,
                    UserName = userTo.UserName,
                    Quantity = frogdollarRequestDTO.Quantity,
                    Description = frogdollarRequestDTO.Description,
                    DateCreated = DateTime.Now
                };

                await _context.VirtualFds.AddAsync(newfrogdollars);
                await _context.SaveChangesAsync();

                result = true;
            }

            return Ok(new { result = result });
        }

        // GET: Frogdollars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var virtualFd = await _context.VirtualFds
                .Include(v => v.GranterNavigation)
                .Include(v => v.UserNameNavigation)
                .FirstOrDefaultAsync(m => m.Fdid == id);
            if (virtualFd == null)
            {
                return NotFound();
            }

            return View(virtualFd);
        }

        // GET: Frogdollars/Create
        public IActionResult Create()
        {
            ViewData["Granter"] = new SelectList(_context.UserOpenIds, "UserName", "UserName");
            ViewData["UserName"] = new SelectList(_context.UserOpenIds, "UserName", "UserName");
            return View();
        }

        // POST: Frogdollars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Fdid,UserName,Granter,Quantity,Description,DateCreated")] VirtualFd virtualFd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(virtualFd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Granter"] = new SelectList(_context.UserOpenIds, "UserName", "UserName", virtualFd.Granter);
            ViewData["UserName"] = new SelectList(_context.UserOpenIds, "UserName", "UserName", virtualFd.UserName);
            return View(virtualFd);
        }

        // GET: Frogdollars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var virtualFd = await _context.VirtualFds.FindAsync(id);
            if (virtualFd == null)
            {
                return NotFound();
            }
            ViewData["Granter"] = new SelectList(_context.UserOpenIds, "UserName", "UserName", virtualFd.Granter);
            ViewData["UserName"] = new SelectList(_context.UserOpenIds, "UserName", "UserName", virtualFd.UserName);
            return View(virtualFd);
        }

        // POST: Frogdollars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Fdid,UserName,Granter,Quantity,Description,DateCreated")] VirtualFd virtualFd)
        {
            if (id != virtualFd.Fdid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(virtualFd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VirtualFdExists(virtualFd.Fdid))
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
            ViewData["Granter"] = new SelectList(_context.UserOpenIds, "UserName", "UserName", virtualFd.Granter);
            ViewData["UserName"] = new SelectList(_context.UserOpenIds, "UserName", "UserName", virtualFd.UserName);
            return View(virtualFd);
        }

        // GET: Frogdollars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var virtualFd = await _context.VirtualFds
                .Include(v => v.GranterNavigation)
                .Include(v => v.UserNameNavigation)
                .FirstOrDefaultAsync(m => m.Fdid == id);
            if (virtualFd == null)
            {
                return NotFound();
            }

            return View(virtualFd);
        }

        // POST: Frogdollars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var virtualFd = await _context.VirtualFds.FindAsync(id);
            _context.VirtualFds.Remove(virtualFd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VirtualFdExists(int id)
        {
            return _context.VirtualFds.Any(e => e.Fdid == id);
        }
    }
}
