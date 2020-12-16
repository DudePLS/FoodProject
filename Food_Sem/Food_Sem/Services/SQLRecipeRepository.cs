using Food_Sem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Sem.Services
{
    public class SQLRecipeRepository : IRecipeRepository
    {
        private readonly AppDbContext context;
        public SQLRecipeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Recipe Add(Recipe newRecipe)
        {
            context.Recipes.Add(newRecipe);
            context.SaveChanges();
            return newRecipe;
        }

        public Recipe Delete(int id)
        {
            Recipe recipe = context.Recipes.Find(id);
            if(recipe!=null)
            {
                context.Recipes.Remove(recipe);
                context.SaveChanges();
            }
            return recipe;
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
            return context.Recipes;
        }

        public Recipe GetRecipe(int id)
        {
            return context.Recipes.Find(id);
        }

        public IEnumerable<TypeHeadCount> RecipeCountByType(TypeOfDi? type)
        {
            IEnumerable<Recipe> query = context.Recipes;
            if (type.HasValue)
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

        /*public IEnumerable<Recipe> Search(string searchTherm)
        {
            if (string.IsNullOrEmpty(searchTherm))
            {
                return context.Recipes;
            }
            return context.Recipes.Where(e => e.Name.Contains(searchTherm) || e.Id.ToString().Contains(searchTherm));
        }*/
        public IEnumerable<Recipe> Search(string searchTherm,TypeOfDi type)
        {
            if (string.IsNullOrEmpty(searchTherm) && type == TypeOfDi.None)
            {
                return context.Recipes;
            }
            if (string.IsNullOrEmpty(searchTherm) && type != TypeOfDi.None)
            {
                return context.Recipes.Where(e => e.TypeOfDish == type).ToList();
            }
            if (type == TypeOfDi.None)
            {
                return context.Recipes.Where(e => e.Name.Contains(searchTherm) ||
                                                    e.Id.ToString()==searchTherm).ToList();
            }
            return context.Recipes.Where(e => e.Name.Contains(searchTherm) &&
                                              e.TypeOfDish==type).ToList();
        }
        public Recipe Update(Recipe updatedRecipe)
        {
            var recipe = context.Recipes.Attach(updatedRecipe);
            recipe.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedRecipe;
        }
    }
}
