using System;
using TaskManager.Service;
using TaskManager.Views;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginView loginView = new LoginView();
            loginView.Show();

            if (AuthenticationService.LoggedUser.IsAdmin)
            {
                AdminView adminView = new AdminView();
                adminView.Show();
            }
            else
            {
                TaskManagerView taskManagerView = new TaskManagerView();
                taskManagerView.Show();
            }
        }
    }
}
