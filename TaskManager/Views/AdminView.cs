using System;

namespace TaskManager.Views
{
    class AdminView
    {
        public void Show()
        {
            while (true)
            {
                Console.Clear();

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Administration View:");
                    Console.WriteLine("[U]ser Management");
                    Console.WriteLine("[T]ask Management");
                    Console.WriteLine("E[x]it");

                    string choice = Console.ReadLine();
                    switch (choice.ToUpper())
                    {
                        case "U":
                            {
                                UserManagerView view = new UserManagerView();
                                view.Show();

                                break;
                            }
                        case "T":
                            {
                                TaskManagerView task = new TaskManagerView();
                                task.Show();

                                break;
                            }
                        case "X":
                            {
                                return;
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
        }
    }
}
