using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Rendering;
namespace Esmeralda.Models
{
    public class EsmeraldaRepository : IEsmeraldaRepository
    {
        private EsmeraldaContext _context;
        public EsmeraldaRepository(EsmeraldaContext context)
        {
            _context = context;
        }

        public Task<Meal> FindMeal(int id)
        {
            return _context.Meals.SingleOrDefaultAsync(m => m.MealId == id);
        }

        public Task<ApplicationUser> FindUser(string id)
        {
            return _context.Users.SingleOrDefaultAsync(m => m.Id == id);
        }

        public IEnumerable<SelectListItem> GetMealsCategory(string userName, int selected)
        {
            var category = _context.Categories.ToList()
                .Where(c => c.UserName == userName)
                    .OrderBy(c => c.Name)
                    .Select(c => new SelectListItem
                    {
                        Text = String.Format("{0}", c.Name),
                        Value = c.CategoryId.ToString(),
                        Selected = c.CategoryId == selected
                    });
            return category;

        }

        public ApplicationUser FindUserName(string user)
        {
            var userVerification = _context.Users
                .Where(u => u.UserName == user)
                .FirstOrDefault();
            
            return userVerification;
        }
        public ApplicationUser FindUserEmail(string email)
        {
            var userVerification = _context.Users
                .Where(u => u.Email == email)
                .FirstOrDefault();

            return userVerification;
        }

    }
}
