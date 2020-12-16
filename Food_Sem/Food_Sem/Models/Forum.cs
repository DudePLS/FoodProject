using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Sem.Models
{
    public class Forum
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> Content { get; set; }
    }
}
