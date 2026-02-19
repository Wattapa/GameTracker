using GameTracker.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Repository
{
    interface IPlaySessionRepository
    {
        public PlaySession GetPlaySessionByID(int _ID);
        public List<PlaySession> GetAll();
        public void Add(PlaySession _playSession);
        public void Update(int _ID, PlaySession _playSession);
        public void Delete(int _ID);
    }
}
