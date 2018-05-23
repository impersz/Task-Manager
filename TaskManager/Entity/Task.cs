using System;
using System.Collections.Generic;

namespace TaskManager.Entity
{
    public class Task
    {

        //id name info score userResponsible userOwner DateOfCreation dateLastUpdate status savedProgresses comments Comment
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Grade { get; set; }
        public int UserAssignedID { get; set; }
        public int UserCreatorID { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateLastUpdate { get; set; }
        public bool IsCompleted { get; set; }

       
    }
} 