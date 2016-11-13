using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace Esmeralda.Models
{
    public class EsmeraldaContextSeedData
    {
        private EsmeraldaContext _context;

        private UserManager<ApplicationUser> _userManager;

        public EsmeraldaContextSeedData(EsmeraldaContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public async Task EnsureSeedDataAsync()
        {


            if (await _userManager.FindByEmailAsync("DavidSuper@gmail.com") == null)
            {
                var newUser = new ApplicationUser()
                {
                    UserName = "DavidSuper",
                    Email = "DavidSuper@gmail.com"
                };

                var userManager = await _userManager.CreateAsync(newUser, "P@ssw0rd");
                if (userManager.Succeeded)
                {

                    //ROLES SUPERUSER
                    var rolesStore = new RoleStore<IdentityRole>(_context);
                    await rolesStore.CreateAsync(new IdentityRole("SuperUser"));
                    await _userManager.AddToRoleAsync(newUser, "SuperUser");

                    //ROLES ADMIN
                    await rolesStore.CreateAsync(new IdentityRole("Admin"));

                    //ROLES USER
                    await rolesStore.CreateAsync(new IdentityRole("User"));


                    _context.SaveChanges();
                };

            }
           
        }
    }
}


