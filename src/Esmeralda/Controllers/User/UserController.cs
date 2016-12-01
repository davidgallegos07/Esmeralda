using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using Esmeralda.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using Esmeralda.ViewModels;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;
using Esmeralda.Configuration;
using Microsoft.Extensions.OptionsModel;
using Stripe;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Esmeralda.Controllers.Web
{
    public class UserController : Controller
    {
        private IEsmeraldaRepository _repository;
        private EsmeraldaContext _context;
        private PaymentSettings _paymentSettings;


        // GET: /<controller>/

        public UserController(IEsmeraldaRepository repository, EsmeraldaContext context, IOptions<PaymentSettings> paymentSettings)
        {
            _repository = repository;
            _context = context;
            _paymentSettings = paymentSettings.Value;
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
        public IActionResult Buy(int id)
        {
            var meal =  _context.Meals.SingleOrDefault(m => m.MealId == id);
            meal.Price = meal.Price / (decimal) 0.20; 

            ViewBag.StripeKey = _paymentSettings.StripePublicKey;
            return View(meal);
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public IActionResult Charge(MealViewModel vm)
        {
            var user = _context.Users.SingleOrDefault(m => m.Id == User.GetUserId());
            var myCharge = new StripeChargeCreateOptions()
            {
                Amount = (int)vm.Price,
                Currency = "usd",
                SourceTokenOrExistingSourceId = vm.StripeToken,
            };
            var chargeService = new StripeChargeService();
            StripeCharge stripeCharge = chargeService.Create(myCharge);
            vm.Price = vm.Price * (decimal)0.2;
            return View("Estimation", vm);
        }

        public IActionResult Estimation()
        {
            return View();
        }
    }
}
