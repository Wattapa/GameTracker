// See https://aka.ms/new-console-template for more information
using GameTracker.Class;
using GameTracker.Context;
using GameTracker.Repository;
using GameTracker.Tools;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");


AppDbContext context = new AppDbContext();
UserRepository repoUser = new UserRepository(context);
CategoryRepository repoCateg = new CategoryRepository(context);

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

repoUser.DeleteUser(3);
DisplayConsole.DisplayUsers(context);
DisplayConsole.DisplayCategories(context);



