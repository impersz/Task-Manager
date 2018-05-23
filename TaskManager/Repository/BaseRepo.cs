using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entity;

namespace TaskManager.Repository
{
    class BaseRepo<T> where T:BaseEntity, new()
    {
        private readonly string filePath;

        public BaseRepo(string filePath)
        {
            this.filePath = filePath;
        }

        public List<T> GetAll()
        {
            List<T> result = new List<T>();

            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    //
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
                    //
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return id;
        }

        public BaseRepo<T> GetById(int id)
        {
            FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            try
            {
                while (!sr.EndOfStream)
                {
                    //
                }
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

            return null;
        }



    }
}
