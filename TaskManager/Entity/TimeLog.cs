using System;
using System.Text;

namespace TaskManager.Entity
{
    public class TimeLog
    {
        //task timeWorked user timeTotal updateDate
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public int HoursWork { get; set; }
        public DateTime DateOfCreation{ get; set; }

        public string Write()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("id: "+ Id);
            str.AppendLine("" + TaskId);
            str.AppendLine("" + UserId);
            str.AppendLine("" + HoursWork);
            str.AppendLine("" + DateOfCreation);

            return str.ToString();
        }
    }
}
