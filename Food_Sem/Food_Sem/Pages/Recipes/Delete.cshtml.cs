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
    public class DeleteModel : PageModel
    {
        private readonly IRecipeRepository recipeRepository;
        public DeleteModel(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        [BindProperty]
        public Recipe Recipe { get; set; }
        public IActionResult OnGet(int id)
        {
            Recipe = recipeRepository.GetRecipe(id);

            if(Recipe==null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            Recipe deletedRecipe = recipeRepository.Delete(Recipe.Id);

            if (deletedRecipe == null)
            {
                return RedirectToPage("/NotFound");
            }

            return RedirectToPage("Index");
        }
    }
}
