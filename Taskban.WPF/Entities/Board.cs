using System;
using System.Collections.ObjectModel;

namespace Taskban.WPF.Entities
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; } = DateTime.Now;
        public ObservableCollection<Task> Tasks { get; set; } = new ObservableCollection<Task>();
    }
}