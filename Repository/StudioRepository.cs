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
    public class StudioRepository : IStudioRepository
    {
        private readonly AppDbContext context;

        public StudioRepository(AppDbContext _context)
        {
            context = _context;
        }

        public Studio GetStudioByID(int _ID)
        {
            return context.studios.FirstOrDefault(g => g.ID == _ID);
        }

        public List<Studio> GetAll()
        {
            return context.studios.AsNoTracking().Include(s => s.PublishedGames).ToList();
        }

        public void Add(Studio _studio)
        {
            if (_studio == null)
                throw new Exception("Cant add a NULL studio.");
            else
            {
                context.studios.AddRange(_studio);
                context.SaveChanges();
            }
        }

        public void Add(List<Studio> _studios)
        {
            if (_studios == null)
                throw new Exception("Cant add a NULL list of studios.");
            else
            {
                context.studios.AddRange(_studios);
                context.SaveChanges();
            }
        }

        public void Update(int _ID, Studio _studio)
        {
            Studio toUpdate = GetStudioByID(_ID);

            if (toUpdate == null)
                throw new Exception("No studio match the id " + _ID);
            else
            {
                toUpdate = _studio;
                context.SaveChanges();
            }
        }

        public void Delete(int _ID)
        {
            Studio toDelete = GetStudioByID(_ID);

            if (toDelete == null)
                throw new Exception("No studio match the id " + _ID);
            else
            {
                context.studios.Remove(toDelete);
                context.SaveChanges();
            }
        }
    }
}
