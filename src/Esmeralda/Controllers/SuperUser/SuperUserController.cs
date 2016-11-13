using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Esmeralda.Models;
using Microsoft.AspNet.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Esmeralda.Controllers.SuperUser
{
    public class SuperUserController : Controller
    {
        private EsmeraldaContext _context;

        public SuperUserController(EsmeraldaContext context)
        {
            _context = context;
        }
        [Authorize(Roles ="SuperUser")]
        // GET: /SuperUser/
        public IActionResult SuperUser()
        {
           
                
            return View();
        }
        public IActionResult ManageAdmin()
        {
            var role = _context.Roles.SingleOrDefault(m => m.Name == "Admin");
            var adminRole = _context.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id));

            return View(adminRole);
            
        }

        public IActionResult ManageUser()
        {
            var role = _context.Roles.SingleOrDefault(m => m.Name == "User");
            var userRole = _context.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id));

            return View(userRole);

        }
    }
}
