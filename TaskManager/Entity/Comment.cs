using System;

namespace TaskManager.Entity
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
    }
}
