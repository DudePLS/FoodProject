using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food_Sem.Models;
using Food_Sem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Food_Sem.Pages.Recipes
{
    public class DetailsModel : PageModel
    {
        private readonly IRecipeRepository recipeRepository;
        public DetailsModel(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        public Recipe Recipe { get; private set; }
      
        public IActionResult OnGet(int id)
        {
            Recipe = recipeRepository.GetRecipe(id);
            if (Recipe == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}
