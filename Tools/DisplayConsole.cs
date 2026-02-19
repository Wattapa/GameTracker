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

        public static void DisplayGames(AppDbContext currentContext)
        {
            Console.WriteLine("Affichage des jeux");
            currentContext.games.ToList().ForEach((game) => Console.WriteLine($"Game : {game.ID} : {game.Title}  Released : {game.ReleaseYear} by {game.Studios.Count} differents studios. Categories : {game.Categories.Count} | Played by {game.PlaySessions.Count} players "));

        }

        public static void DisplayStudio(AppDbContext currentContext)
        {
            Console.WriteLine("Affichage des Studios");
            currentContext.studios.ToList().ForEach((studio) => Console.WriteLine($"Studio : {studio.ID} : {studio.Name} Games created : {studio.PublishedGames.Count} ! "));

        }

        public static void DisplayPlayedSessions(AppDbContext currentContext)
        {
            Console.WriteLine("Affichage des jeux joués");
            currentContext.playSessions.ToList().ForEach((ps) => Console.WriteLine($"Game : {ps.ID} : {ps.User.Username}  has played : {ps.PlayedGame} for {ps.HoursPlayed} hours"));

        }
    }
}
