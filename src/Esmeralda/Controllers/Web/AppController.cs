using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Esmeralda.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Esmeralda.Controllers.Web
{
    public class AppController : Controller
    {
        private EsmeraldaContext _context;

        public AppController(EsmeraldaContext context)
        {
            _context = context;
        } 
        // GET: /<controller>/
        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult Restaurants()
        {
            var restaurants = _context.AdminProfiles.ToList();
            return View(restaurants);
        }
        public IActionResult Meals(int id)
        {
            var meals = _context.Meals.Where(m => m.Category.AdminProfileId == id);
            return View();
        }
    }
}
