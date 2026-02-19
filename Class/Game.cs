using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GameTracker.Class
{
    public class Game
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "La longueur maximale ne doit pas dépasser 200 caractères")]
        public string Title { get; set; } = "Undefined";
        
        public int ReleaseYear { get; set; }

        public virtual List<Studio> Studios { get; set; } = new List<Studio>();

        public virtual List<PlaySession> PlaySessions { get; set; } = new List<PlaySession>();

        public virtual List<Category> Categories { get; set; } = new List<Category>();

        public override string ToString()
        {
            return $"Games {ID}|{Title} : {ReleaseYear}";
        }

    }
}
