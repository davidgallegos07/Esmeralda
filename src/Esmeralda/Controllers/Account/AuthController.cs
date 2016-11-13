using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Identity;
using Esmeralda.ViewModels;
using Esmeralda.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Esmeralda.Controllers.Account
{
    public class AuthController : Controller
    {
        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;
        private EsmeraldaContext _context;
        private IEsmeraldaRepository _repository;
   


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public AuthController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager
            , EsmeraldaContext context, IEsmeraldaRepository repository) //agregar ctor sign in
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
            _repository = repository;
        }
        //  GET: /Auth/Login
        public IActionResult Login() // method si el usuario trata de ingresar aunque ya este logeado
        {

            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("AdminPanel", "Admin");
                }

                else if (User.IsInRole("User"))
                {
                    return RedirectToAction("UserPanel", "User");
                }

                else if (User.IsInRole("SuperUser"))
                {
                    return RedirectToAction("SuperUser", "SuperUser");
                }

            }
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel vm) // this metod si el usuario apenas ingresara por primera vez
        {                                            // se agrega await y async
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(vm.UserName,
                                                                            vm.Password, true, false);

                if (signInResult.Succeeded)
                {

                    return RedirectToAction("Login", "Auth");
                }

                {
                    ModelState.AddModelError("", "Usuario o contraseña incorrecto");
                }
            }

            return View();
        }
        public async Task<ActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }
            return RedirectToAction("Index", "App");
        }
        //  GET: /Auth/Register
        public IActionResult Register()
        {
            return View();
        }

        //  GET: /Auth/RegisterUser
        public IActionResult RegisterUser()
        {
            RegisterUserViewModel rs = new RegisterUserViewModel();
            ViewBag.AllMonths = rs.AllMonths;
            ViewBag.AllYears = rs.AllYears;
            return View();
        }

        //  GET: /Auth/RegisterAdmin
        public IActionResult RegisterAdmin()
        {
            return View();
        }

        //  POST: /Auth/RegisterUser
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser(RegisterUserViewModel vm)
        {

            if (ModelState.IsValid)
            {
                var userVerfication = _repository.FindUserName(vm.UserName);
                var emailVerification = _repository.FindUserEmail(vm.Email);

                var newUser = new ApplicationUser()
                {
                    Email = vm.Email,
                    UserName = vm.UserName,
                    LastName = vm.LastName,

                };
                if (userVerfication == null && emailVerification == null)
                {
                    var result = await _userManager.CreateAsync(newUser, vm.Password);

                    if (result.Succeeded)
                    {
                        
                        await _userManager.AddToRoleAsync(newUser, "User");

                        var user = new UserProfile()
                        {
                            ApplicationUserId = newUser.Id
                        };
                        _context.UserProfiles.Add(user);
                        await _context.SaveChangesAsync();

                        var cc = new CreditCard()
                        {
                            CardNumber = vm.CardNumber,
                            CardExpirtationMonth = vm.CardExpirationMonth,
                            CardExpirationYear = vm.CardExpirationYear,
                            CVC = vm.CVC
                        };
                        _context.CretditCards.Add(cc);
                        await _context.SaveChangesAsync();

                        var userProfileCreditCard = new UserProfileCreditCard()
                        {
                            UserProfileId = user.UserProfileId,
                            CreditCardId = cc.CreditCardId
                        };

                        _context.UserProfileCreditCards.Add(userProfileCreditCard);
                        await _context.SaveChangesAsync();

                        return RedirectToAction("Login");
                    }
                    AddErrors(result);
                }
                else
                {
                    if (userVerfication != null)
                    {
                        ModelState.AddModelError("", "Email ya esta registrado.");
                    }
                    if (emailVerification != null)
                    {
                        ModelState.AddModelError("", "Usuario " + vm.UserName.ToLower() + " alguien mas lo utiliza.");
                    }
                }
            }

           
            ViewBag.AllMonths = vm.AllMonths;
            ViewBag.AllYears = vm.AllYears;
            return View(vm);
        }
        //  GET: /Auth/Confirmation
        public IActionResult Confirmation()
        {
            
            return View();
        }
        //  POST: /Auth/RegisterAdmin
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAdmin(RegisterAdminViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var userVerfication = _repository.FindUserName(vm.UserName);
                var emailVerification = _repository.FindUserEmail(vm.Email);

                var newUser = new ApplicationUser()
                {
                    Email = vm.Email,
                    UserName = vm.UserName,
                    Address = vm.Address

                };
                if (userVerfication == null && emailVerification == null)
                {
                    var result = await _userManager.CreateAsync(newUser, vm.Password);

                    if (result.Succeeded)
                    {
                  
                        await _userManager.AddToRoleAsync(newUser, "Admin");
                        var Admin = new AdminProfile()
                        {
                            ApplicationUserId = newUser.Id,
                            ImageUrl = "/img/restaurants/userdefault.png"
                        };
                        _context.AdminProfiles.Add(Admin);
                        await _context.SaveChangesAsync();

                        return RedirectToAction("Login"); //changed before confirmation view
                    }
                    AddErrors(result);
                }
                else
                {
                    if (userVerfication != null)
                    {
                        ModelState.AddModelError("", "El correo electronico ya esta registrado.");
                    }
                    if (emailVerification != null)
                    {
                        ModelState.AddModelError("", "El Usuario " + vm.UserName.ToLower() + " alguien mas lo utiliza.");
                    }
                }


            }

            return View(vm);
        }

        //GET://TermsConditions
        public IActionResult TermsConditions()
        {
            return View();
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);

            }
        }

    }

}