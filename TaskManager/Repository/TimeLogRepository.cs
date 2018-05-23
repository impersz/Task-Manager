using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entity;

namespace TaskManager.Repository
{
    class TimeLogRepository
    {
        private readonly string filePath;

        public TimeLogRepository(string filePath)
        {
            this.filePath = filePath;
        }

        public List<TimeLog> GetAll()
        {
            List<TimeLog> result = new List<TimeLog>();

            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    TimeLog tl = new TimeLog();
                    tl.Id = Convert.ToInt32(sr.ReadLine());
                    tl.TaskId = Convert.ToInt32(sr.ReadLine());
                    tl.UserId = Convert.ToInt32(sr.ReadLine());
                    tl.HoursWork = Convert.ToInt32(sr.ReadLine());
                    tl.DateOfCreation = Convert.ToDateTime(sr.ReadLine());
                    result.Add(tl);
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return result;
        }

        private int GetNextId()
        {
            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            int id = 1;
            try
            {
                while (!sr.EndOfStream)
                {
                    TimeLog tl = new TimeLog();
                    tl.Id = Convert.ToInt32(sr.ReadLine());
                    tl.TaskId = Convert.ToInt32(sr.ReadLine());
                    tl.UserId = Convert.ToInt32(sr.ReadLine());
                    tl.HoursWork = Convert.ToInt32(sr.ReadLine());
                    tl.DateOfCreation = Convert.ToDateTime(sr.ReadLine());

                    if (id <= tl.Id)
                    {
                        id = tl.Id + 1;
                    }
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return id;
        }

        public TimeLog GetById(int id)
        {
            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    TimeLog tl = new TimeLog();
                    tl.Id = Convert.ToInt32(sr.ReadLine());
                    tl.TaskId = Convert.ToInt32(sr.ReadLine());
                    tl.UserId = Convert.ToInt32(sr.ReadLine());
                    tl.HoursWork = Convert.ToInt32(sr.ReadLine());
                    tl.DateOfCreation = Convert.ToDateTime(sr.ReadLine());

                    if (tl.Id == id)
                    {
                        return tl;
                    }
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return null;
        }

        private void Update(TimeLog item)
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
                    TimeLog tl = new TimeLog();
                    tl.Id = Convert.ToInt32(sr.ReadLine());
                    tl.TaskId = Convert.ToInt32(sr.ReadLine());
                    tl.UserId = Convert.ToInt32(sr.ReadLine());
                    tl.HoursWork = Convert.ToInt32(sr.ReadLine());
                    tl.DateOfCreation = Convert.ToDateTime(sr.ReadLine());

                    if (tl.Id != item.Id)
                    {
                        sw.WriteLine(tl.Id);
                        sw.WriteLine(tl.TaskId);
                        sw.WriteLine(tl.UserId);
                        sw.WriteLine(tl.HoursWork);
                        sw.WriteLine(tl.DateOfCreation);
                    }
                    else
                    {
                        sw.WriteLine(item.Id);
                        sw.WriteLine(item.TaskId);
                        sw.WriteLine(item.UserId);
                        sw.WriteLine(item.HoursWork);
                        sw.WriteLine(item.DateOfCreation);
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

        private void Insert(TimeLog item)
        {
            item.Id = GetNextId();

            FileStream fs = new FileStream(filePath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);

            try
            {
                sw.WriteLine(item.Id);
                sw.WriteLine(item.TaskId);
                sw.WriteLine(item.UserId);
                sw.WriteLine(item.HoursWork);
                sw.WriteLine(item.DateOfCreation);
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }

        public void Delete(TimeLog item)
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
                    TimeLog tl = new TimeLog();
                    tl.Id = Convert.ToInt32(sr.ReadLine());
                    tl.TaskId = Convert.ToInt32(sr.ReadLine());
                    tl.UserId = Convert.ToInt32(sr.ReadLine());
                    tl.HoursWork = Convert.ToInt32(sr.ReadLine());
                    tl.DateOfCreation = Convert.ToDateTime(sr.ReadLine());

                    if (tl.Id != item.Id)
                    {
                        sw.WriteLine(tl.Id);
                        sw.WriteLine(tl.TaskId);
                        sw.WriteLine(tl.UserId);
                        sw.WriteLine(tl.HoursWork);
                        sw.WriteLine(tl.DateOfCreation);
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

        public void Save(TimeLog item)
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
