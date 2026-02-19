using GameTracker.Class;
using GameTracker.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GameTracker.Repository
{
    public class PlaySessionRepository : IPlaySessionRepository
    {
        private readonly AppDbContext context;

        public PlaySessionRepository(AppDbContext _context)
        {
            context = _context;
        }

        public PlaySession GetPlaySessionByID(int _ID)
        {
            return context.playSessions.FirstOrDefault(g => g.ID == _ID);
        }

        public List<PlaySession> GetAll()
        {
            return context.playSessions.AsNoTracking().Include(ps => ps.PlayedGame).Include(ps => ps.User).ToList();
        }

        public void Add(PlaySession _playSession)
        {
            if (_playSession == null)
                throw new Exception("Cant add a NULL play session.");
            else
            {
                context.playSessions.AddRange(_playSession);
                context.SaveChanges();
            }
        }

        public void Add(List<PlaySession> _playSessions)
        {
            if (_playSessions == null)
                throw new Exception("Cant add a NULL list of play sessions.");
            else
            {
                context.playSessions.AddRange(_playSessions);
                context.SaveChanges();
            }
        }

        public void Update(int _ID, PlaySession _playSession)
        {
            PlaySession toUpdate = GetPlaySessionByID(_ID);

            if (toUpdate == null)
                throw new Exception("No game match the id " + _ID);
            else
            {
                toUpdate = _playSession;
                context.SaveChanges();
            }
        }

        public void Delete(int _ID)
        {
            PlaySession toDelete = GetPlaySessionByID(_ID);

            if (toDelete == null)
                throw new Exception("No game match the id " + _ID);
            else
            {
                context.playSessions.Remove(toDelete);
                context.SaveChanges();
            }
        }
    }
}
