// See https://aka.ms/new-console-template for more information
using GameTracker.Class;
using GameTracker.Context;
using GameTracker.Repository;
using GameTracker.Tools;
using Microsoft.EntityFrameworkCore;

AppDbContext context = new AppDbContext();
UserRepository repoUser = new UserRepository(context);
CategoryRepository repoCateg = new CategoryRepository(context);
GameRepository repoGame = new GameRepository(context);
StudioRepository repoStudio = new StudioRepository(context);
PlaySessionRepository repoPlaySession = new PlaySessionRepository(context);

context.Database.EnsureDeleted();
context.Database.Migrate();

//Initialisation 
if (repoUser.GetAllUsers().FirstOrDefault() != null)
{
    Console.WriteLine("Current database already know somes users");
}
else
{
    //Batch User
    List<User> listOfUser = new List<User> {
        new() { Id = 1, Username = "Wapata" },
        new() { Id = 2, Username = "Rankerry" },
        new() { Id = 3, Username = "Norbert" }
    };
    repoUser.AddUser([.. listOfUser]);
}

if (repoCateg.GetAll().FirstOrDefault() != null)
{
    Console.WriteLine("Current database already know somes categories");
}
else
{
    //Batch Categ
    List<Category> listOfCategories = new List<Category> {
        new() { Id = 1, Name = "Roguelike" },
        new() { Id = 2, Name = "FPS" },
        new() { Id = 3, Name = "Hero Shooter" },
        new() { Id = 4, Name = "Bullet Hell" },
        new() { Id = 5, Name = "RPG" },
        new() { Id = 6, Name = "Multijoueur" }
    };
    repoCateg.Add([.. listOfCategories]);
}

if (repoStudio.GetAll().FirstOrDefault() != null)
{
    Console.WriteLine("Current database already know somes studios");
} else
{
    //Batch Studio
    List<Studio> listOfStudio = new List<Studio> {
        new() { ID = 1, Name = "Nintendo" },
        new() { ID = 2, Name = "Naughty Dog" },
        new() { ID = 3, Name = "Alexey Pajitnov" },
        new() { ID = 4, Name = "From Software" },
        new() { ID = 5, Name = "CD Projekt Red" },
        new() { ID = 6, Name = "Bioware" },
        new() { ID = 7, Name = "Konami" },
        new() { ID = 8, Name = "Valve" },
    };
    repoStudio.Add([.. listOfStudio]);
}

if (repoGame.GetAll().FirstOrDefault() != null)
{
    Console.WriteLine("Current database already know somes games");
} else
{
    var rogueLikeCategorie = repoCateg.GetCategoryByID(1);
    var FPSCategorie = repoCateg.GetCategoryByID(2);
    var herosShooterCategorie = repoCateg.GetCategoryByID(3);
    var bulletHellCategorie = repoCateg.GetCategoryByID(4);
    var RPGCategorie = repoCateg.GetCategoryByID(5);
    var multijoueurCategorie = repoCateg.GetCategoryByID(6);

    var nintendo = repoStudio.GetStudioByID(1);
    var naughtyDog = repoStudio.GetStudioByID(2);
    var ceGars = repoStudio.GetStudioByID(3);
    var fromSofware = repoStudio.GetStudioByID(4);
    var cdProjectRed = repoStudio.GetStudioByID(5);
    var bioware = repoStudio.GetStudioByID(6);
    var konami = repoStudio.GetStudioByID(7);
    var valve = repoStudio.GetStudioByID(8);

    //Batch Game
    List<Game> listOfGames = new List<Game> {
        new Game() { ID = 1, Title = "The Legend of Zelda: Breath of the Wild ", ReleaseYear = 2017, Categories = new List<Category> {rogueLikeCategorie, RPGCategorie}, Studios = new List<Studio> { nintendo } },
        new Game() { ID = 2, Title = "The Last of Us", ReleaseYear = 2013, Categories = new List<Category> { FPSCategorie, bulletHellCategorie }, Studios = new List<Studio> { naughtyDog } },
        new Game() { ID = 3, Title = "Tetris", ReleaseYear = 1985, Categories = new List<Category> { herosShooterCategorie, RPGCategorie}, Studios = new List<Studio> { ceGars } },
        new Game() { ID = 4, Title = "Bloodborne ", ReleaseYear = 2015, Categories = new List<Category> {rogueLikeCategorie, herosShooterCategorie }, Studios = new List<Studio> { fromSofware } },
        new Game() { ID = 5, Title = "The Witcher III: Wild Hunt", ReleaseYear = 2015, Categories = new List<Category> { FPSCategorie, RPGCategorie}, Studios = new List<Studio> { cdProjectRed } },
        new Game() { ID = 6, Title = "Mass Effect 2", ReleaseYear = 2010, Categories = new List<Category> { multijoueurCategorie, RPGCategorie}, Studios = new List<Studio> { bioware } },
        new Game() { ID = 7, Title = "Metal Gear Solid", ReleaseYear = 1998, Categories = new List<Category> {rogueLikeCategorie, FPSCategorie }, Studios = new List<Studio> { konami } },
        new Game() { ID = 8, Title = "Portal 2", ReleaseYear = 2011, Categories = new List<Category> {rogueLikeCategorie, herosShooterCategorie }, Studios = new List<Studio> { valve } },
        new Game() { ID = 9, Title = "Dark Souls", ReleaseYear = 2011, Categories = new List<Category> { bulletHellCategorie, multijoueurCategorie }, Studios = new List<Studio> { fromSofware } }
    };
    repoGame.Add([.. listOfGames]);
}


User? userUpdated = repoUser.GetUserById(2);
if(userUpdated != null)
{
    userUpdated.Username = "Jean Bas";
    repoUser.UpdateUser(userUpdated.Id, userUpdated);
}

Category? categoryUpdated = repoCateg.GetCategoryByID(2);
if(categoryUpdated != null)
{
    categoryUpdated.Name = "FIALS";
    repoCateg.Update(categoryUpdated.Id, categoryUpdated);  
}

repoCateg.Delete(3);
DisplayConsole.DisplayUsers(context);
DisplayConsole.DisplayCategories(context);

