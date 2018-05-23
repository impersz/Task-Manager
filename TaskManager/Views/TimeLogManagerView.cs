using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entity;
using TaskManager.Repository;
using static TaskManager.Tools.Enumerations;

namespace TaskManager.Views
{
    class TimeLogManagerView
    {
        public void Show(Entity.Task task)
        {
            while (true)
            {
                TimeLogCommentManagerEnum choice = RenderMenuTaskOptions();

                try
                {
                    switch (choice)
                    {
                        case TimeLogCommentManagerEnum.SelectTimeLog:
                            {
                                GetAll();
                                break;
                            }
                        case TimeLogCommentManagerEnum.ViewTimeLog:
                            {
                                //View();
                                break;
                            }
                        case TimeLogCommentManagerEnum.InsertTimeLog:
                            {
                                Add(task);
                                break;
                            }
                        case TimeLogCommentManagerEnum.UpdateTimeLog:
                            {
                               // Update();
                                break;
                            }
                        case TimeLogCommentManagerEnum.DeleteTimeLog:
                            {
                              //  Delete();
                                break;
                            }
                        case TimeLogCommentManagerEnum.Exit:
                            {
                                TaskManagerView taskView = new TaskManagerView();
                                taskView.Show();
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

        private TimeLogCommentManagerEnum RenderMenuTaskOptions()
        {

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Options:");
                Console.WriteLine(" TimeLog     Comments");
                Console.WriteLine("  [GT] Get all [GC]");
              //Console.WriteLine("  [VT]   View  [VC]");
                Console.WriteLine("  [AT]   Add   [AC]");
              //Console.WriteLine("  [ET]   Edit  [EC]");
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
        }

        private void GetAll()
        {

            Console.Clear();

            TaskRepository taskRepository = new TaskRepository("tasks.txt");
            List<Entity.Task> tasks = taskRepository.GetAll();
            UserRepository userRepository = new UserRepository("users.txt");
            List<Entity.User> users = userRepository.GetAll();
            TimeLogRepository timeLogRepository = new TimeLogRepository("timelogs.txt");
            List<TimeLog> timelogs = timeLogRepository.GetAll();

            for (int i = 0; i < timelogs.Count; i++)
            {
                Console.WriteLine("ID:"+ timelogs[i].TaskId);
                Console.WriteLine("User: " + users[i].FirstName + users[i].LastName);
                Console.WriteLine("Task: " + tasks[i].Name);
                Console.WriteLine("Worked hours: " + timelogs[i].HoursWork);
                Console.WriteLine("Created on:" + timelogs[i].DateOfCreation);
                Console.WriteLine("----------------------------------------");
            }

            /*foreach (TimeLog timeLog in timelogs)
            {
                Console.WriteLine("ID:" + timeLog.Id);
                Console.WriteLine("User: " + timeLog.UserId);
                Console.WriteLine("Task: " + timeLog.TaskId);
                Console.WriteLine("Worked hours: " + timeLog.HoursWork);
                Console.WriteLine("Created on:" + timeLog.DateOfCreation);
                Console.WriteLine("########################################");
            }*/

            Console.ReadKey(true);
            //Console.Clear();
        }

        private void Add(Entity.Task task)
        {
            Console.Clear();

            TimeLog timeLog = new TimeLog();

            UserRepository userRepository = new UserRepository("users.txt");
            var all = userRepository.GetAll();
            for (int i = 0; i < all.Count; i++)
            {
                if (i % 5 == 0 && i != 0)
                    Console.Write($"\n\rId {all[i].Id} - {all[i].Username}\t");
                else
                    Console.Write($"Id {all[i].Id} - {all[i].Username}\t");
            }
            Console.WriteLine();


            Console.WriteLine("Add new TimeLog:");

            Console.Write("User id: ");
            timeLog.UserId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Hours of work: ");
            timeLog.HoursWork = Convert.ToInt32(Console.ReadLine());

            timeLog.DateOfCreation = DateTime.Now;
            timeLog.TaskId = task.Id;

            TimeLogRepository timeLogRepository = new TimeLogRepository("timelogs.txt");
            timeLogRepository.Save(timeLog);

            Console.WriteLine("TimeLog saved successfully.");
            Console.ReadKey(true);
        }

        private void View()
        {
            //TimeLogRepository timeLogRepository = new TimeLogRepository("timelogs.txt");
        }

        private void Delete()
        {
            TimeLogRepository timeLogRepository = new TimeLogRepository("timelogs.txt");

            Console.Clear();

            Console.WriteLine("Delete TimeLog:");
            Console.Write("TimeLog Id: ");
            int timeLogId = Convert.ToInt32(Console.ReadLine());

            TimeLog timeLog = timeLogRepository.GetById(timeLogId);
            if (timeLog == null)
            {
                Console.WriteLine("TimeLog not found!");
            }
            else
            {
                timeLogRepository.Delete(timeLog);
                Console.WriteLine("TimeLog deleted successfully.");
            }
            Console.ReadKey(true);
        }


    }
}
