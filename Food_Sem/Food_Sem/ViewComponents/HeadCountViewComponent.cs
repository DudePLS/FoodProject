using Food_Sem.Models;
using Food_Sem.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Sem.ViewComponents
{
    public class HeadCountViewComponent : ViewComponent
    {
        private readonly IRecipeRepository recipeRepository;
        public HeadCountViewComponent(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        public IViewComponentResult Invoke(TypeOfDi? type=null)
        {
            var result = recipeRepository.RecipeCountByType(type);
            return View(result);
        }
    }
}
