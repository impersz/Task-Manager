using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TaskManager.Entity;

namespace TaskManager.Repository
{
    class TaskRepository
    {
        private readonly string filePath;

        public TaskRepository(string filePath)
        {
            this.filePath = filePath;
        }

        public List<Task> GetAll()
        {
            List<Task> result = new List<Task>();

            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    Task task = new Task();
                    
                    task.Id = Convert.ToInt32(sr.ReadLine());
                    task.Name = sr.ReadLine();
                    task.Description = sr.ReadLine();
                    task.Grade = Convert.ToInt32(sr.ReadLine());
                    task.UserAssignedID = Convert.ToInt32(sr.ReadLine());
                    task.UserCreatorID = Convert.ToInt32(sr.ReadLine());
                    task.DateOfCreation = Convert.ToDateTime(sr.ReadLine());
                    task.DateLastUpdate = Convert.ToDateTime(sr.ReadLine());
                    task.IsCompleted = Convert.ToBoolean(sr.ReadLine());

                    result.Add(task);
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }
                return result;
        }

        public int GetNextId()
        {
            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            int id = 1;
            try
            {
                while (!sr.EndOfStream)
                {
                    Task task = new Task();
                    task.Id = Convert.ToInt32(sr.ReadLine());
                    task.Name = sr.ReadLine();
                    task.Description = sr.ReadLine();
                    task.Grade = Convert.ToInt32(sr.ReadLine());
                    task.UserAssignedID = Convert.ToInt32(sr.ReadLine());
                    task.UserCreatorID = Convert.ToInt32(sr.ReadLine());
                    task.DateOfCreation = Convert.ToDateTime(sr.ReadLine());
                    task.DateLastUpdate = Convert.ToDateTime(sr.ReadLine());
                    task.IsCompleted = Convert.ToBoolean(sr.ReadLine());

                    if (id <= task.Id) id = task.Id + 1;
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return id;
        }

        public Task GetById(int id)
        {
            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    Task task = new Task();
                    task.Id = Convert.ToInt32(sr.ReadLine());
                    task.Name = sr.ReadLine();
                    task.Description = sr.ReadLine();
                    task.Grade = Convert.ToInt32(sr.ReadLine());
                    task.UserAssignedID = Convert.ToInt32(sr.ReadLine());
                    task.UserCreatorID = Convert.ToInt32(sr.ReadLine());
                    task.DateOfCreation = Convert.ToDateTime(sr.ReadLine());
                    task.DateLastUpdate = Convert.ToDateTime(sr.ReadLine());
                    task.IsCompleted = Convert.ToBoolean(sr.ReadLine());

                    if (task.Id == id) return task;
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return null;
        }

        private void Update(Task item)
        {
            string tempFilePath = "temp." + filePath;

            FileStream ifs = new FileStream(filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(ifs);

            FileStream ofs = new FileStream(tempFilePath, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(ofs);

            try
            {
                while (!sr.EndOfStream)
                {
                    Task task = new Task();
                    task.Id = Convert.ToInt32(sr.ReadLine());
                    task.Name = sr.ReadLine();
                    task.Description = sr.ReadLine();
                    task.Grade = Convert.ToInt32(sr.ReadLine());
                    task.UserAssignedID = Convert.ToInt32(sr.ReadLine());
                    task.UserCreatorID = Convert.ToInt32(sr.ReadLine());
                    task.DateOfCreation = Convert.ToDateTime(sr.ReadLine());
                    task.DateLastUpdate = Convert.ToDateTime(sr.ReadLine());
                    task.IsCompleted = Convert.ToBoolean(sr.ReadLine());

                    if (task.Id != item.Id)
                    {
                        sw.WriteLine(task.Id);
                        sw.WriteLine(task.Name);
                        sw.WriteLine(task.Description);
                        sw.WriteLine(task.Grade);
                        sw.WriteLine(task.UserAssignedID);
                        sw.WriteLine(task.UserCreatorID);
                        sw.WriteLine(task.DateOfCreation);
                        sw.WriteLine(task.DateLastUpdate);
                        sw.WriteLine(task.IsCompleted);
                    }
                    else
                    {
                        sw.WriteLine(task.Id);
                        sw.WriteLine(task.Name);
                        sw.WriteLine(task.Description);
                        sw.WriteLine(task.Grade);
                        sw.WriteLine(task.UserAssignedID);
                        sw.WriteLine(task.UserCreatorID);
                        sw.WriteLine(task.DateOfCreation);
                        sw.WriteLine(task.DateLastUpdate);
                        sw.WriteLine(task.IsCompleted);
                    }
                }
            }
            finally
            {
                sw.Close();
                ofs.Close();
                sr.Close();
                ifs.Close();
            }

            File.Delete(filePath);
            File.Move(tempFilePath, filePath);
        }

        private void Insert(Task item)
        {
            item.Id = GetNextId();

            FileStream fs = new FileStream(filePath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);

            try
            {
                sw.WriteLine(item.Id);
                sw.WriteLine(item.Name);
                sw.WriteLine(item.Description);
                sw.WriteLine(item.Grade);
                sw.WriteLine(item.UserAssignedID);
                sw.WriteLine(item.UserCreatorID);
                sw.WriteLine(item.DateOfCreation);
                sw.WriteLine(item.DateLastUpdate);
                sw.WriteLine(item.IsCompleted);
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }

        public void Delete(Task item)
        {
            string tempFilePath = "temp." + filePath;

            FileStream ifs = new FileStream(filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(ifs);

            FileStream ofs = new FileStream(tempFilePath, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(ofs);

            try
            {
                while (!sr.EndOfStream)
                {
                    Task task = new Task();
                    task.Id = Convert.ToInt32(sr.ReadLine());
                    task.Name = sr.ReadLine();
                    task.Description = sr.ReadLine();
                    task.Grade = Convert.ToInt32(sr.ReadLine());
                    task.UserAssignedID = Convert.ToInt32(sr.ReadLine());
                    task.UserCreatorID = Convert.ToInt32(sr.ReadLine());
                    task.DateOfCreation = Convert.ToDateTime(sr.ReadLine());
                    task.DateLastUpdate = Convert.ToDateTime(sr.ReadLine());
                    task.IsCompleted = Convert.ToBoolean(sr.ReadLine());

                    if (task.Id != item.Id)
                    {
                        sw.WriteLine(task.Id);
                        sw.WriteLine(task.Name);
                        sw.WriteLine(task.Description);
                        sw.WriteLine(task.Grade);
                        sw.WriteLine(task.UserAssignedID);
                        sw.WriteLine(task.UserCreatorID);
                        sw.WriteLine(task.DateOfCreation);
                        sw.WriteLine(task.DateLastUpdate);
                        sw.WriteLine(task.IsCompleted);
                    }
                }
            }
            finally
            {
                sw.Close();
                ofs.Close();
                sr.Close();
                ifs.Close();
            }

            File.Delete(filePath);
            File.Move(tempFilePath, filePath);
        }

        public void Save(Task item)
        {
            if (item.Id > 0)
            {
                Update(item);
            }
            else
            {
                Insert(item);
            }
        }

    }
}
