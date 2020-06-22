using System;
using System.Collections.ObjectModel;

namespace Taskban.WPF.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public ObservableCollection<Tag> Tags { get; set; }
        public ObservableCollection<SubTask> SubTasks { get; set; }
    }
}