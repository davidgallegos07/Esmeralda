using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esmeralda.Models
{
    public class EsmeraldaContextSeedData
    {
        private EsmeraldaContext _context;
        private RoleManager<ApplicationUser> _roleManager;
        private UserManager<ApplicationUser> _userManager;

        public EsmeraldaContextSeedData(EsmeraldaContext context, UserManager<ApplicationUser> userManager
            ,RoleManager<ApplicationUser> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task EnsureSeedDataAsync()
        {


            if (await _userManager.FindByEmailAsync("superuser@gmail.com") == null)
            {
                var newUser = new ApplicationUser()
                {
                    UserName = "SuperUser",
                    Email = "superuser@gmail.com",

                    //UserProfile = new UserProfile()
                    //{

                    //}
                };

                var userManager = await _userManager.CreateAsync(newUser, "P@ssw0rd");
                if (userManager.Succeeded)
                {
                    ////ROLES SUPERUSER
                    if(! await _roleManager.RoleExistsAsync("SuperUser"))
                    {
                        var rolesStore = new RoleStore<IdentityRole>(_context);
                        await rolesStore.CreateAsync(new IdentityRole("SuperUser"));
                    }
                    await _userManager.AddToRoleAsync(newUser, "SuperUser");

                    //ROLES USER
                    //var rolesStore = new RoleStore<IdentityRole>(_context);
                    //await rolesStore.CreateAsync(new IdentityRole("User"));
                    //await _userManager.AddToRoleAsync(newUser, "User");

                    //ROLES ADMIN
                    //var rolesStore = new RoleStore<IdentityRole>(_context);
                    //await rolesStore.CreateAsync(new IdentityRole("Admin"));
                    //await _userManager.AddToRoleAsync(newUser, "Admin");

                    //var x = new UserProfile()
                    //{
                    //    ApplicationUserId = newUser.Id
                    //};
                    // _context.UserProfiles.Add(x);
                    _context.SaveChanges();
                };

                //_context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Name = "Admin" });
                ////await _userManager.AddToRoleAsync(newUser, "Admin");
                //await _userManager.CreateAsync(newUser, "P@ssw0rd");
                //var role = _context.Roles.SingleOrDefault(m => m.Name == "Admin");
                //newUser.Roles.Add(new IdentityUserRole { RoleId = role.Id });

            }

        }
    }
}

