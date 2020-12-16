using Food_Sem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Sem.Services
{
    public interface IRecipeRepository
    {
        //IEnumerable<Recipe> Search(string searchTherm);
        IEnumerable<Recipe> Search(string searchTherm,TypeOfDi type);
        IEnumerable<Recipe> GetAllRecipes();
        Recipe GetRecipe(int id);
        Recipe Update(Recipe updatedRecipe);
        Recipe Add(Recipe newRecipe);
        Recipe Delete(int id);
        IEnumerable<TypeHeadCount> RecipeCountByType(TypeOfDi? type);
    }
}
