using GameTracker.Class;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Repository
{
    internal interface IGameRepository
    {
        public Game GetGameByID(int _ID);
        public List<Game> GetAll();
        public void Add(Game _game);
        public void Update(int _ID, Game _game);
        public void Delete(int _ID);
    }
}
