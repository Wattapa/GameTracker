using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Class
{
    public class PlaySession
    {
        public int ID { get; set; }
        public string Date { get; set; } = "12/09/2003";
        public int HoursPlayed { get; set; }
        public virtual Game PlayedGame { get; set; }
        public virtual User User { get; set; }

    }
}
