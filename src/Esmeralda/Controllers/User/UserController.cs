using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using Esmeralda.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using Esmeralda.ViewModels;
using Microsoft.IdentityModel.Protocols;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Esmeralda.Controllers.Web
{
    public class UserController : Controller
    {
        private IEsmeraldaRepository _repository;
        private EsmeraldaContext _context;

        // GET: /<controller>/

        public UserController(IEsmeraldaRepository repository, EsmeraldaContext context)
        {
            _repository = repository;
            _context = context;
        }
        [Authorize(Roles = "User")]
        public IActionResult UserPanel()
        {

            
            return View();
        }
        public IActionResult Restaurants()
        {
            var role = _context.Roles.SingleOrDefault(m => m.Name == "Admin");
            var adminRole = _context.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id));
            return View(adminRole);
        }

        public async Task<IActionResult> Configuration()
        {
            var user = await _repository.FindUser(User.GetUserId());

            return View(user);
        }
        public IActionResult Meals(int id)
        {
            var meals = _context.Meals.Where(a => a.Category.AdminProfileId == id);
                         
            return View(meals);
        }
        [Authorize]
        public async Task<IActionResult> BuyNow(int id)
        {
            Meal meal = await _repository.FindMeal(id);
            ViewBag.Category = _repository.GetMealsCategory(User.GetUserName(), meal.CategoryId);

            return View(meal);
        }
        public async Task<ActionResult> Buy(int id)
        {
            Meal meal = await _repository.FindMeal(id);

            //ViewBag.Category = _repository.GetMealsCategory(User.GetUserName(), meal.CategoryId);
            return View(meal);
        }
    }
}
