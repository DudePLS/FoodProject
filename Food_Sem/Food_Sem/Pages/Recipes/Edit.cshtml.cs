using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Food_Sem.Models;
using Food_Sem.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Food_Sem.Pages.Recipes
{
    public class EditModel : PageModel
    {
        private readonly IRecipeRepository recipeRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EditModel(IRecipeRepository recipeRepository,
                         IWebHostEnvironment webHostEnvironment)
        {
            this.recipeRepository = recipeRepository;
            this.webHostEnvironment = webHostEnvironment;
        }
        [BindProperty]
        public Recipe Recipe { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Recipe = recipeRepository.GetRecipe(id.Value);
            }
            else
            {
                Recipe=new Recipe();
            }

            if (Recipe == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    recipe.PhotoPath = ProcessUploadedFile();
                }

                if (Recipe.Id > 0)
                {
                    Recipe = recipeRepository.Update(recipe);
                }
                else
                {
                    Recipe = recipeRepository.Add(recipe);
                }
                return RedirectToPage("Index");
            }
            return Page();
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;

            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
