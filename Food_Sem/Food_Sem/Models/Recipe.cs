using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Sem.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [Required, MinLength(3, ErrorMessage = "Name must contain at least 3 characters")]
        public string Name { get; set; }
        //[Required]
        // [Display(Name = "Название рецепта")]
        //[RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        //   ErrorMessage = "Invalid email format")]
        [Required]
        //[RegularExpression(@"/[^\d]/",
           //ErrorMessage = "Invalid time format")]
        public int CookingTime { get; set; }
        [Required, MaxLength(150, ErrorMessage = "Recipe must contain less than 150 characters")]
        public string RecipeText { get; set; }
        public string PhotoPath { get; set; }
        [Required]
        public TypeOfDi? TypeOfDish { get; set; }
    }
}
