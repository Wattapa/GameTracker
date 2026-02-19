using GameTracker.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Repository
{
    interface IStudioRepository
    {
        public Studio GetStudioByID(int _ID);
        public List<Studio> GetAll();
        public void Add(Studio _studio);
        public void Update(int _ID, Studio _studio);
        public void Delete(int _ID);
    }
}
