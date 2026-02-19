using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GameTracker.Class;

namespace GameTracker.Class
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "La longueur max de l'username de la catégorie ne doit pas dépasser de 100 caractères")]
        public string Username { get; set; }

        public virtual List<PlaySession> playedSession { get; set; } = new();

        public override string ToString()
        {
            return $"Username {Id} : {Username}";
        }
    }
}
