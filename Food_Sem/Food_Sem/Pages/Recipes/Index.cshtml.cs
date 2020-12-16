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
    public class IndexModel : PageModel
    {
        private readonly IRecipeRepository recipeRepository;

        public IEnumerable<Recipe> Recipes { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        [BindProperty(SupportsGet = true)]
        public TypeOfDi type { get; set; }

        public IndexModel(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        public void OnGet()
        {
            Recipes = recipeRepository.Search(SearchTerm,type);
        }
    }
}
