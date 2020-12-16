using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Sem.Models
{
    public class User
    {
        
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [Required, MinLength(3, ErrorMessage = "Name must contain at least 3 characters")]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public byte[] ProfileImage;
    }
}
