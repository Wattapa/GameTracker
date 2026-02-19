using GameTracker.Class;
using GameTracker.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GameTracker.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext context;

        public GameRepository(AppDbContext _context)
        {
            context = _context;
        }

        public Game GetGameByID(int _ID)
        {
            return context.games.FirstOrDefault(g => g.ID == _ID);
        }

        public List<Game> GetAll()
        {
            return context.games.AsNoTracking().Include(g => g.Studios).Include(g => g.Categories).Include(g => g.PlaySessions).ToList();
        }

        public void Add(Game _game)
        {
            if (_game == null)
                throw new Exception("Cant add a NULL game.");
            else
            {
                context.games.Add(_game);
                context.SaveChanges();
            }
        }

        public void Add(List<Game> _games)
        {
            if (_games == null)
                throw new Exception("Cant add a NULL list of games.");
            else
            {
                context.games.AddRange(_games);
                context.SaveChanges();
            }
        }

        public void Delete(int _ID)
        {
            Game toDelete = GetGameByID(_ID);

            if (toDelete == null)
                throw new Exception("No game match the id "+ _ID);
            else
            {
                context.games.Remove(toDelete);
                context.SaveChanges();
            }
        }

        public void Update(int _ID, Game _game)
        {
            Game toUpdate = GetGameByID(_ID);

            if (toUpdate == null)
                throw new Exception("No game match the id " + _ID);
            else
            {
                toUpdate = _game;
                context.SaveChanges();
            }
        }
    }
}
