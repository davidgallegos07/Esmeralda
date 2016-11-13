using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using Esmeralda.Models;
using System.Security.Claims; // getusername
using Microsoft.Data.Entity; // include linq
using Esmeralda.ViewModels;
using System;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Esmeralda.Controllers.Web
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private EsmeraldaContext _context;
        private IEsmeraldaRepository _repository;

        public AdminController(IEsmeraldaRepository repository, EsmeraldaContext context)
        {
            _context = context;
            _repository = repository;
        }


        // GET: /<AdminPanel>/
        public IActionResult AdminPanel()
        {
            //var meal = from m in _context.Meals
            //           select m;
            //if (!String.IsNullOrEmpty(search))
            //{
            //    meal = meal.Where(m => m.MealName.Contains(search));
            //}
            return View();
        }
        // GET: /Manage/
        public IActionResult Manage(string search)
        {
            //var viewmodel = new ManageDataViewModel(); // cat & meals
            //viewmodel.Meals = _context.Meals
            //    .Where(c => c.Category.UserName == User.GetUserName());
            var meal = _context.Meals
                .Where(c => c.Category.UserName == User.GetUserName());
            if (!String.IsNullOrEmpty(search))
            {
                meal = meal.Where(m => m.MealName.Contains(search));
            }
            return View(meal);
        }
        // GET: /Create/
        public IActionResult Create()
        {

            ViewBag.Category = _repository.GetMealsCategory(User.GetUserName(), -1);

            return View();
        }
        // POST: /Create/
        [HttpPost]
        public IActionResult Create(MealViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var meal = new Meal()
                {
                    MealName = vm.MealName,
                    Description = vm.Description,
                    Price = vm.Price,
                    Cal = vm.Cal,
                    CategoryId = vm.CategoryId
                };

                _context.Meals.Add(meal);
                _context.SaveChanges();

            }
            return RedirectToAction("Manage");
        }
        // GET: /Edit/
        public async Task<ActionResult> Edit(int id)
        {
            Meal meal = await _repository.FindMeal(id);
            if (meal == null)
            {
                return HttpNotFound();
            }

            ViewBag.Category = _repository.GetMealsCategory(User.GetUserName(), meal.CategoryId);
            return View(meal);
        }

        // POST: /Update/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id,
           [Bind("MealName", "Description", "Price", "Cal", "CategoryId")] Meal meal)
        {
            //meal.MealId = id
            //Meal findid = await _repository.FindMeal(id);
            //if(findid == null)
            //{
            //    return HttpNotFound(); 
            //}
            if (ModelState.IsValid)
            {
                meal.MealId = id;
                _context.Entry(meal).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Manage");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Los cambios no pueden ser realizados");
            }

            return View(meal);
        }
        // GET: /Details/
        public async Task<IActionResult> Details(int id)
        {
            Meal meal = await _repository.FindMeal(id);
            //if(meal == null)
            //{
            //    return HttpNotFound();
            //}
            ViewBag.Category = _repository.GetMealsCategory(User.GetUserName(), meal.CategoryId);

            return View(meal);
        }
        // GET: /Delete/
        public async Task<IActionResult> Delete(int id)
        {
            Meal meal = await _repository.FindMeal(id);
            //if(meal == null)
            //{
            //    return HttpNotFound();
            //}
            _context.Meals.Remove(meal);
            _context.SaveChanges();
            return RedirectToAction("Manage");
        }
        // GET: /Category/
        public IActionResult Category()
        {
           
            return View();
        }

        // POST: /Category/
        [HttpPost]
        public IActionResult Category(CategoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var admin = _context.AdminProfiles
                                           .Where(a => a.ApplicationUserId == User.GetUserId())
                                           .Select(a => a.AdminProfileId).SingleOrDefault(); // singleor ??
                var cat = new Category
                {
                    Name = vm.Name,
                    UserName = User.GetUserName(),
                    AdminProfileId = admin
                };
                _context.Categories.Add(cat);                   
                _context.SaveChanges();
                return RedirectToAction("Manage");
            }

            return View(vm);
        }

        public async Task<IActionResult> Configuration()
        {
            ApplicationUser user = await _repository.FindUser(User.GetUserId());
            return View(user);
        }
        public IActionResult Reports()
        {
            return View();
        }
        
    }
}
