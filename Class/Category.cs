using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Class
{
    internal class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "La longueur max du nom de la catégorie ne doit pas dépasser de 100 caractères")]
        public string Name { get; set; }

         public virtual List<Game> GameCollection { get; set; } = new();

        public override string ToString()
        {
            return $"Category {Id} : {Name}";
        }
    }
}
