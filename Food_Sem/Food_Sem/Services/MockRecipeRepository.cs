using Food_Sem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Sem.Services
{
    public class MockRecipeRepository
    {
        private List<Recipe> _recipeList;

        public MockRecipeRepository()
        {
            _recipeList = new List<Recipe>()
            {
                new Recipe() { Id = 1, Name = "Borsh", TypeOfDish = TypeOfDi.MainDishes,
                    PhotoPath="john.png",CookingTime =5,RecipeText="DJBJ" },
                new Recipe() { Id = 2, Name = "D", TypeOfDish = TypeOfDi.MainDishes,
                    PhotoPath="mary.png",CookingTime =235,RecipeText="fdzfs" },
                new Recipe() { Id = 3, Name = "fds", TypeOfDish = TypeOfDi.MainDishes,
                    PhotoPath="sam.png",CookingTime =235,RecipeText="dfsxzfsd" },
                new Recipe() { Id = 4, Name = "444", TypeOfDish = TypeOfDi.MainDishes,
                    CookingTime =235,RecipeText="fdsfsdf /n"+
                    "dafafaf" },

            };
        }

        public Recipe Add(Recipe newRecipe)
        {
            newRecipe.Id = _recipeList.Max(e => e.Id) + 1;
            _recipeList.Add(newRecipe);
            return newRecipe;
        }

        public Recipe Delete(int id)
        {
            Recipe recipeToDelete = _recipeList.FirstOrDefault(e => e.Id == id);

            if(recipeToDelete !=null)
            {
                _recipeList.Remove(recipeToDelete);
            }

            return recipeToDelete;
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _recipeList;
        }
        public Recipe GetRecipe(int id)
        {
            return _recipeList.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<TypeHeadCount> RecipeCountByType(TypeOfDi? type)
        {
            IEnumerable<Recipe> query = _recipeList;
            if(type.HasValue)
            {
                query = query.Where(e => e.TypeOfDish == type.Value);
            }
            return query.GroupBy(e => e.TypeOfDish)
                .Select(g => new TypeHeadCount()
                {
                    TypeOfDish = g.Key.Value,
                    Count = g.Count()
                }).ToList();
                ; 
        }

        public IEnumerable<Recipe> Search(string searchTherm)
        {
            if (string.IsNullOrEmpty(searchTherm)) 
            {
                return _recipeList;
            }
            return _recipeList.Where(e => e.Name.Contains(searchTherm) ||
                                          e.Id.ToString().Contains(searchTherm));
        }

        public Recipe Update(Recipe updatedRecipe)
        {
            Recipe recipe = _recipeList.FirstOrDefault(e => e.Id == updatedRecipe.Id);

            if (recipe != null)
            {
                recipe.Name = updatedRecipe.Name;
                recipe.CookingTime = updatedRecipe.CookingTime;
                recipe.TypeOfDish = updatedRecipe.TypeOfDish;
                recipe.RecipeText = updatedRecipe.RecipeText;
                recipe.PhotoPath = updatedRecipe.PhotoPath;
            }
            return recipe;
        }
    }
}
