using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Class
{
    public class Studio
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "La longueur maximale ne doit pas dépasser 100 caractères")]
        public int Name { get; set; }

        public virtual List<Game> PublishedGames { get; set; } = new List<Game>();
    }
}
