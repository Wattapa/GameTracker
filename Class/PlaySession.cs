using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Class
{
    class PlaySession
    {
        public int ID { get; set; }
        public string Date { get; set; } = "12/09/2003";
        public int HoursPlayed { get; set; }
        public Game PlayedGame { get; set; }
        public User User { get; set; }

    }
}
