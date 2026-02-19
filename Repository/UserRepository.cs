using GameTracker.Class;
using GameTracker.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Repository
{
    internal class UserRepository : IUserRepository
    {
        private AppDbContext dbContext;

        public UserRepository(AppDbContext currentContext)
        {
            dbContext = currentContext;
        }


        public void AddUser(User addedUser)
        {
            if (addedUser == null)
            {
                throw new Exception("No user to add");
            }
            else
            {
                dbContext.users.Add(addedUser);
                dbContext.SaveChanges();
            }
        }

        public void AddUser(User[] listOfUser)
        {
            if (listOfUser.Length == 0) throw new Exception("List of User is empty");
            else
            {
                dbContext.AddRange(listOfUser);
                dbContext.SaveChanges();
            }
        }

        public void DeleteUser(int userId)
        {
            User userToDelete = GetUserById(userId);

            if (userToDelete != null)
            {
                dbContext.users.Remove(userToDelete);
                dbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"No user with id {userId} has been found");
            }
        }

        public List<User> GetAllUsers()
        {
            return dbContext.users.AsNoTracking().Include(a => a.playedSession).ToList();
        }

        public User GetUserById(int userId)
        {
            var user = dbContext.users.AsNoTracking().FirstOrDefault(b => b.Id == userId );


            if (user != null)
            {
                return user;
            }
            else
            {
                throw new Exception($"User with the following id {userId} not found.");
            }
        }

        public void UpdateUser(int userId, User userUpdated)
        {
            var user = GetUserById(userId);
            if (user != null && userUpdated != null)
            {
                user = userUpdated;
                dbContext.SaveChanges();
            }
            else throw new Exception($"Either user or AuthorUpdated is null : {user}/{userUpdated} for id {userId}");
        }

        public void reset()
        {
            dbContext.Database.EnsureDeleted();
        }

        public void database()
        {
            
            dbContext.Database.Migrate();
        }
    }
}
