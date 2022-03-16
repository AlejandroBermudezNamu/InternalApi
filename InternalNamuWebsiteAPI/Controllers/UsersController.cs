using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalNamuWebsiteAPI.Models;

namespace InternalNamuWebsiteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly OpenIdContext _context;

        public UsersController(OpenIdContext context)
        {
            _context = context;
        }

  

        [HttpGet("/api/users/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            return Ok(await _context.UserOpenIds.Where(i => i.Mail == email).ToListAsync());
        }

        [HttpGet("/api/users/active")]
        public async Task<IActionResult> GetAllActiveUsers()
        {
            var users = await _context.UserOpenIds.Where(i => i.Status == 0
            && i.Mail!= "rodrigoespinoza@namutravel.com"
            && i.Mail != ""
            ).Select(i => new
            {
                Email = i.Mail,
                Name = i.Nam
            })
            .OrderBy(i => i.Name)
            .ToListAsync();

            return Ok(users);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOpenId = await _context.UserOpenIds
                .FirstOrDefaultAsync(m => m.UserName == id);
            if (userOpenId == null)
            {
                return NotFound();
            }

            return View(userOpenId);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Pass,Nam,Mail,Extention,Status,Country,LoginFlr,PasswordFlr,LoginMantis,PasswordMantis,LoginMail,PasswordMail,LoginCrp,PasswordCrp,LoginCrvwiki,PasswordCrvwiki,LoginBaseCamp,PasswordBaseCamp,LoginFrogLog,PasswordFrogLog,LoginBlog,PasswordBlog,LoginJabber,PasswordJabber,IsAdmin,Fdcredits,CanRedeem,CanGrantFdcredits,CanSetGoals,Manager,CanUseFrogQuery,ManagerImpersonates")] UserOpenId userOpenId)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userOpenId);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userOpenId);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOpenId = await _context.UserOpenIds.FindAsync(id);
            if (userOpenId == null)
            {
                return NotFound();
            }
            return View(userOpenId);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserName,Pass,Nam,Mail,Extention,Status,Country,LoginFlr,PasswordFlr,LoginMantis,PasswordMantis,LoginMail,PasswordMail,LoginCrp,PasswordCrp,LoginCrvwiki,PasswordCrvwiki,LoginBaseCamp,PasswordBaseCamp,LoginFrogLog,PasswordFrogLog,LoginBlog,PasswordBlog,LoginJabber,PasswordJabber,IsAdmin,Fdcredits,CanRedeem,CanGrantFdcredits,CanSetGoals,Manager,CanUseFrogQuery,ManagerImpersonates")] UserOpenId userOpenId)
        {
            if (id != userOpenId.UserName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userOpenId);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserOpenIdExists(userOpenId.UserName))
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
            return View(userOpenId);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOpenId = await _context.UserOpenIds
                .FirstOrDefaultAsync(m => m.UserName == id);
            if (userOpenId == null)
            {
                return NotFound();
            }

            return View(userOpenId);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userOpenId = await _context.UserOpenIds.FindAsync(id);
            _context.UserOpenIds.Remove(userOpenId);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserOpenIdExists(string id)
        {
            return _context.UserOpenIds.Any(e => e.UserName == id);
        }
    }
}
