using GameTracker.Context;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Tools
{
    internal class DisplayConsole
    {
        public static void DisplayUsers(AppDbContext currentContext)
        {
            Console.WriteLine("Affichage des Users");
            currentContext.users.ToList().ForEach((user) => Console.WriteLine($"User : {user.Id} / {user.Username} / PlayedSessionsCount : {user.playedSession.Count}"));
        }

        public static void DisplayCategories(AppDbContext currentContext)
        {
            Console.WriteLine("Affichage des categories");
            currentContext.categories.ToList().ForEach((categ) => Console.WriteLine($"Category : {categ.Id} / {categ.Name} / GamesCount : {categ.GameCollection.Count}"));

        }
    }
}
