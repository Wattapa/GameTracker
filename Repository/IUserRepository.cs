using GameTracker.Class;

namespace GameTracker.Repository
{
    internal interface IUserRepository
    {
        public void AddUser(User newUser);

        public void UpdateUser(int userId, User userUpdated);

        public void DeleteUser();

        public List<User> GetAllUsers();

        public User GetUserById(int id);
    }
}