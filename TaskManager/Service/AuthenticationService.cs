using System;
using TaskManager.Entity;
using TaskManager.Repository;

namespace TaskManager.Service
{
    class AuthenticationService
    {
        public static User LoggedUser { get; private set; }

        public static void AuthenticateUser(string username, string password)
        {
            UserRepository userRepo = new UserRepository("users.txt");
            AuthenticationService.LoggedUser = userRepo.GetByUsernameAndPassword(username, password);
        }
    }
}
