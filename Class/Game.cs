using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Class
{
    class Game
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "La longueur maximale ne doit pas dépasser 200 caractères")]
        public string Title { get; set; } = "Undefined";
        
        public int ReleaseYear { get; set; }

        public List<Category> Categories { get; set; } = new()
    }
}
