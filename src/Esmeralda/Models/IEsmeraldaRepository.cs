using System.Collections.Generic;
using Microsoft.AspNet.Mvc.Rendering;
using System.Threading.Tasks;

namespace Esmeralda.Models
{
    public interface IEsmeraldaRepository
    {
        Task<Meal> FindMeal(int id);
        IEnumerable<SelectListItem> GetMealsCategory(string userName, int selected);
        ApplicationUser FindUserName(string name);
        ApplicationUser FindUserEmail(string email);
    }
}