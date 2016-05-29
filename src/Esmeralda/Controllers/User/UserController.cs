using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Esmeralda.Controllers.Web
{
    public class UserController : Controller
    {
 
        // GET: /<controller>/
        [Authorize(Roles ="User")]
        public IActionResult UserPanel()
        {
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new EsmeraldaContext()));
            //var currentUser = _userManager.FindByNameAsync(User.Identity.Name);
            
            return View();
        }
        public IActionResult Restaurants()
        {
            return View();
        }

        public IActionResult Configuration()
        {
            return View();
        }
    }
}
