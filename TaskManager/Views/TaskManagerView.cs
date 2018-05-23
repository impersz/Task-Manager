using System;
using System.Collections.Generic;
using TaskManager.Repository;
using static TaskManager.Tools.Enumerations;
using TaskManager.Entity;
namespace TaskManager.Views
{
    class TaskManagerView
    {
        public void Show()
        {
            while (true)
            {
                TaskManagerEnum choice = RenderMenu();

                try
                {
                    switch (choice)
                    {
                        case TaskManagerEnum.Select:
                            {
                                GetAll();
                                break;
                            }
                        case TaskManagerEnum.View:
                            {
                                View();
                                break;
                            }
                        case TaskManagerEnum.Insert:
                            {
                                Add();
                                break;
                            }
                        case TaskManagerEnum.Update:
                            {
                                Update();
                                break;
                            }
                        case TaskManagerEnum.Delete:
                            {
                                Delete();
                                break;
                            }
                        case TaskManagerEnum.Exit:
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

        private TaskManagerEnum RenderMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Tasks management:");
                Console.WriteLine("[G]et all Tasks");
                Console.WriteLine("[V]iew Tasks");
                Console.WriteLine("[A]dd Tasks");
                Console.WriteLine("[U]pdate Tasks");
                Console.WriteLine("[D]elete Tasks");
                Console.WriteLine("E[x]it");

                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {
                    case "G":
                        {
                            return TaskManagerEnum.Select;
                        }
                    case "V":
                        {
                            return TaskManagerEnum.View;
                        }
                    case "A":
                        {
                            return TaskManagerEnum.Insert;
                        }
                    case "U":
                        {
                            return TaskManagerEnum.Update;
                        }
                    case "D":
                        {
                            return TaskManagerEnum.Delete;
                        }
                    case "X":
                        {
                            return TaskManagerEnum.Exit;
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

            TaskRepository taskRepository = new TaskRepository("tasks.txt");
            List<Task> tasks = taskRepository.GetAll();

            foreach (Task task in tasks)
            {
                Console.WriteLine("ID:" + task.Id);
                Console.WriteLine("Name: " + task.Name);
                Console.WriteLine("Created by (user id): " + task.UserCreatorID);
                Console.WriteLine("Assigned (user id):" + task.UserAssignedID);
                Console.WriteLine("Created on:" + task.DateOfCreation);
                Console.WriteLine("Last updated:" + task.DateLastUpdate);
                Console.WriteLine("Status: " + task.IsCompleted);
                Console.WriteLine("########################################");
            }

            Console.ReadKey(true);
        }

        private void View()
        {
            Console.Clear();

            TaskRepository taskRepository = new TaskRepository("tasks.txt");
            var all = taskRepository.GetAll();
            for (int i = 0; i < all.Count; i++)
            {
                if (i % 5 == 0 && i != 0)
                    Console.Write($"\n\rId {all[i].Id} - {all[i].Name}\t");
                else
                    Console.Write($"Id {all[i].Id} - {all[i].Name}\t");
            }
            Console.WriteLine();
            Console.WriteLine("------------------------------------------");
            

            Console.Write("Task ID: ");
            int taskId = Convert.ToInt32(Console.ReadLine());

            Task task = taskRepository.GetById(taskId);
            if (task == null)
            {
                Console.Clear();
                Console.WriteLine("Task not found.");
                Console.ReadKey(true);
                return;
            }

            Console.WriteLine("ID:" + task.Id);
            Console.WriteLine("Name: " + task.Name);
            Console.WriteLine("Created by (user id): " + task.UserCreatorID);
            Console.WriteLine("Assigned (user id):" + task.UserAssignedID);
            Console.WriteLine("Created on:" + task.DateOfCreation);
            Console.WriteLine("Last updated:" + task.DateLastUpdate);
            Console.WriteLine("Status: " + task.IsCompleted);

            Console.WriteLine("----------------------------------------");

            TimeLogManagerView timeLog = new TimeLogManagerView();
            timeLog.Show(task);
            //RenderMenuTaskOptions();
            //Call Render Menu for the timelog/comment

            Console.ReadKey(true);
        }

        private void Add()
        {
            Console.Clear();

            Task task = new Task();

            Console.WriteLine("Add new Task:");

            Console.Write("Name: ");
            task.Name = Console.ReadLine();

            Console.Write("Description: ");
            task.Description = Console.ReadLine();

            Console.Write("Grade (hours): ");
            task.Grade = Convert.ToInt32(Console.ReadLine());

            Console.Write("Created by (user id): ");
            task.UserCreatorID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Assigned (user id): ");
            task.UserAssignedID = Convert.ToInt32(Console.ReadLine());

            //Console.Write("Created on: ");
            //task.DateOfCreation = Convert.ToDateTime(Console.ReadLine());
            task.DateLastUpdate = DateTime.Now;

            task.IsCompleted = false;

            TaskRepository taskRepository = new TaskRepository("tasks.txt");
            taskRepository.Save(task);

            Console.WriteLine("Task saved successfully.");
            Console.ReadKey(true);
        }

        private void Update()
        {
            Console.Clear();

            Console.Write("Task ID: ");
            int taskId = Convert.ToInt32(Console.ReadLine());

            TaskRepository taskRepository = new TaskRepository("task.txt");
            Task task = taskRepository.GetById(taskId);

            if (task == null)
            {
                Console.Clear();
                Console.WriteLine("Task not found.");
                Console.ReadKey(true);
                return;
            }

            Console.WriteLine("Editing Task (" + task.Name + ")");
            Console.WriteLine("ID:" + task.Id);

            Console.WriteLine("Name :" + task.Name);
            Console.Write("New name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Assigned(user id) :" + task.UserCreatorID);
            Console.Write("New assigned user: ");
            int assignedId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Status :" + task.IsCompleted);
            Console.Write("New status: ");
            bool status = Convert.ToBoolean(Console.ReadLine());

            if (!string.IsNullOrEmpty(name))
                task.Name = name;
            if (!string.IsNullOrEmpty(Convert.ToString(assignedId)))
                task.UserAssignedID = assignedId;
            if (!string.IsNullOrEmpty(Convert.ToString(status)))
                task.IsCompleted = status;

            taskRepository.Save(task);

            Console.WriteLine("Task updated successfully.");
            Console.ReadKey(true);
        }

        private void Delete()
        {
            TaskRepository taskRepository = new TaskRepository("task.txt");

            Console.Clear();

            Console.WriteLine("Delete Task:");
            Console.Write("Task Id: ");
            int taskId = Convert.ToInt32(Console.ReadLine());

            Task task = taskRepository.GetById(taskId);
            if (task == null)
            {
                Console.WriteLine("Task not found!");
            }
            else
            {
                taskRepository.Delete(task);
                Console.WriteLine("Task deleted successfully.");
            }
            Console.ReadKey(true);
        }
        
        /*
        private TimeLogCommentManagerEnum RenderMenuTaskOptions()
        {

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Options:");
                Console.WriteLine(" TimeLog     Comments");
                Console.WriteLine("  [GT] Get all [GC]");
                Console.WriteLine("  [VT]   View  [VC]");
                Console.WriteLine("  [AT]   Add   [AC]");
                Console.WriteLine("  [ET]   Edit  [EC]");
                Console.WriteLine("  [DT]  Delete [DC]");
                Console.WriteLine(" Exit [X]");

                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {
                    case "GT": return TimeLogCommentManagerEnum.SelectTimeLog;
                    case "GC": return TimeLogCommentManagerEnum.SelectComment;
                    case "VT": return TimeLogCommentManagerEnum.ViewTimeLog;
                    case "VC": return TimeLogCommentManagerEnum.ViewComment;
                    case "AT": return TimeLogCommentManagerEnum.InsertTimeLog;
                    case "AC": return TimeLogCommentManagerEnum.SelectComment;
                    case "ET": return TimeLogCommentManagerEnum.UpdateTimeLog;
                    case "EC": return TimeLogCommentManagerEnum.UpdateComment;
                    case "DT": return TimeLogCommentManagerEnum.DeleteTimeLog;
                    case "DC": return TimeLogCommentManagerEnum.DeleteComment;
                    case "X": return TimeLogCommentManagerEnum.Exit;
                    default:
                        {
                            Console.WriteLine("Invalid choice.");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }*/
    }
}
