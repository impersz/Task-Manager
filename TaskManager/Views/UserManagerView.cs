using System;
using System.Collections.Generic;
using TaskManager.Entity;
using TaskManager.Repository;
using static TaskManager.Tools.Enumerations;

namespace TaskManager.Views
{
    class UserManagerView
    {
        public void Show()
        {
            while (true)
            {
                UserManagerEnum choice = RenderMenu();

                try
                {
                    switch (choice)
                    {
                        case UserManagerEnum.Select:
                            {
                                GetAll();
                                break;
                            }
                        case UserManagerEnum.View:
                            {
                                View();
                                break;
                            }
                        case UserManagerEnum.Insert:
                            {
                                Add();
                                break;
                            }
                        case UserManagerEnum.Update:
                            {
                                Update();
                                break;
                            }
                        case UserManagerEnum.Delete:
                            {
                                Delete();
                                break;
                            }
                        case UserManagerEnum.Exit:
                            {
                                return;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.ReadKey(true);
                }
            }
        }

        private UserManagerEnum RenderMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Users management:");
                Console.WriteLine("[G]et all Users");
                Console.WriteLine("[V]iew User");
                Console.WriteLine("[A]dd User");
                Console.WriteLine("[E]dit User");
                Console.WriteLine("[D]elete User");
                Console.WriteLine("E[x]it");

                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {
                    case "G":
                        {
                            return UserManagerEnum.Select;
                        }
                    case "V":
                        {
                            return UserManagerEnum.View;
                        }
                    case "A":
                        {
                            return UserManagerEnum.Insert;
                        }
                    case "E":
                        {
                            return UserManagerEnum.Update;
                        }
                    case "D":
                        {
                            return UserManagerEnum.Delete;
                        }
                    case "X":
                        {
                            return UserManagerEnum.Exit;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid choice.");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }

        private void GetAll()
        {
            Console.Clear();

            UserRepository usersRepository = new UserRepository("users.txt");
            List<User> users = usersRepository.GetAll();

            foreach (User user in users)
            {
                Console.WriteLine("ID:" + user.Id);
                Console.WriteLine("Username :" + user.Username);
                Console.WriteLine("Password :" + user.Password);
                Console.WriteLine("First Name :" + user.FirstName);
                Console.WriteLine("Last Name :" + user.LastName);
                Console.WriteLine("Is Admin:" + user.IsAdmin);
                Console.WriteLine("########################################");
            }

            Console.ReadKey(true);
        }

        private void View()
        {
            Console.Clear();

            UserRepository usersRepository = new UserRepository("users.txt");
            var all = usersRepository.GetAll();
            for (int i = 0; i < all.Count; i++)
            {
                if (i % 5 == 0 && i != 0)
                    Console.Write($"\n\rId {all[i].Id} - {all[i].FirstName} {all[i].LastName}\t");
                else
                    Console.Write($"Id {all[i].Id} - {all[i].FirstName} {all[i].LastName}\t");
            }
            Console.WriteLine();

            Console.Write("User ID: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            //UserRepository usersRepository = new UserRepository("users.txt");

            User user = usersRepository.GetById(userId);
            if (user == null)
            {
                Console.Clear();
                Console.WriteLine("User not found.");
                Console.ReadKey(true);
                return;
            }

            Console.WriteLine("ID:" + user.Id);
            Console.WriteLine("Username :" + user.Username);
            Console.WriteLine("Password :" + user.Password);
            Console.WriteLine("First Name :" + user.FirstName);
            Console.WriteLine("Last Name :" + user.LastName);
            Console.WriteLine("Is Admin:" + user.IsAdmin);

            Console.ReadKey(true);
        }

        private void Add()
        {
            Console.Clear();

            User user = new User();

            Console.WriteLine("Add new User:");

            Console.Write("Username: ");
            user.Username = Console.ReadLine();

            Console.Write("Password: ");
            user.Password = Console.ReadLine();

            Console.Write("First Name: ");
            user.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            user.LastName = Console.ReadLine();          

            Console.Write("Is Admin (True/False): ");
            user.IsAdmin = Convert.ToBoolean(Console.ReadLine());

            UserRepository usersRepository = new UserRepository("users.txt");
            usersRepository.Save(user);

            Console.WriteLine("User saved successfully.");
            Console.ReadKey(true);
        }

        private void Update()
        {
            Console.Clear();

            Console.Write("User ID: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            UserRepository usersRepository = new UserRepository("users.txt");
            User user = usersRepository.GetById(userId);

            if (user == null)
            {
                Console.Clear();
                Console.WriteLine("User not found.");
                Console.ReadKey(true);
                return;
            }

            Console.WriteLine("Editing User (" + user.Username + ")");
            Console.WriteLine("ID:" + user.Id);

            Console.WriteLine("Username :" + user.Username);
            Console.Write("New Username:");
            string username = Console.ReadLine();

            Console.WriteLine("Password :" + user.Password);
            Console.Write("New Password:");
            string password = Console.ReadLine();

            Console.WriteLine("First Name :" + user.FirstName);
            Console.Write("New First Name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Last Name :" + user.LastName);
            Console.Write("New Last Name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Is Admin :" + user.IsAdmin);
            Console.Write("New Is Admin (True/False):");
            string isAdmin = Console.ReadLine();


            if (!string.IsNullOrEmpty(username))
                user.Username = username;
            if (!string.IsNullOrEmpty(password))
                user.Password = password;
            if (!string.IsNullOrEmpty(firstName))
                user.FirstName = firstName;
            if (!string.IsNullOrEmpty(lastName))
                user.LastName = lastName;
            if (!string.IsNullOrEmpty(isAdmin))
                user.IsAdmin = Convert.ToBoolean(isAdmin);

            usersRepository.Save(user);

            Console.WriteLine("User saved successfully.");
            Console.ReadKey(true);
        }

        private void Delete()
        {
            UserRepository usersRepository = new UserRepository("users.txt");

            Console.Clear();

            Console.WriteLine("Delete User:");
            Console.Write("User Id: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            User user = usersRepository.GetById(userId);
            if (user == null)
            {
                Console.WriteLine("User not found!");
            }
            else
            {
                usersRepository.Delete(user);
                Console.WriteLine("User deleted successfully.");
            }
            Console.ReadKey(true);
        }
    }
}
