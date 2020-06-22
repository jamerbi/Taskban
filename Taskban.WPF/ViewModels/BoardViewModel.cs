using System;
using Taskban.WPF.Commands;
using Taskban.WPF.Entities;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Taskban.WPF.Views;

namespace Taskban.WPF.ViewModels
{
    public class BoardViewModel : ViewModelBase
    {
        public BoardWindow BoardWindow { get; set; }

        private Board _board;

        public Board Board
        {
            get => _board;
            set
            {
                _board = value;
                OnPropertyChanged();
            }
        }
        
        private Task _selectedTask = new Task();

        public Task SelectedTask
        {
            get => _selectedTask;
            set
            {
                _selectedTask = value;
                OnPropertyChanged();
            }
        }

        private SubTask _newSubTask = new SubTask();

        public SubTask NewSubTask
        {
            get => _newSubTask;
            set
            {
                _newSubTask = value;
                OnPropertyChanged();
            }
        }

        private int _taskViewWidth;

        public int TaskViewWidth
        {
            get => _taskViewWidth;
            set
            {
                _taskViewWidth = value;
                OnPropertyChanged();
            }
        }

        public ICommand CloseBoardCommand { get; }
        public ICommand AddTagCommand { get; }
        public ICommand AddSubTaskCommand { get; }
        public ICommand DeleteSubTaskCommand { get; }
        public ICommand DeleteTagCommand { get; }
        public ICommand DeleteTaskCommand { get; }
        public ICommand CloseTaskViewCommand { get; }
        public ICommand AddTaskCommand { get; }
        public ICommand SaveBoardCommand { get; }

        public BoardViewModel()
        {
            CloseBoardCommand = new RelayCommand(CloseBoardShowMain, o => true);
            AddTaskCommand = new RelayCommand(AddTask, o => true);
            AddTagCommand = new RelayCommand(AddNewTag, o => !string.IsNullOrWhiteSpace(o.ToString()));
            AddSubTaskCommand = new RelayCommand(AddNewSubTask, o => !string.IsNullOrWhiteSpace(_newSubTask.Title));
            SaveBoardCommand = new RelayCommand(SaveBoard, o => true);
            DeleteSubTaskCommand = new RelayCommand(o => SelectedTask.SubTasks.Remove((SubTask) o), o => true);
            DeleteTagCommand = new RelayCommand(o => SelectedTask.Tags.Remove((Tag) o), o => true);
            DeleteTaskCommand = new RelayCommand(RemoveSelectedTask, o => SelectedTask != null);
            CloseTaskViewCommand = new RelayCommand(o => TaskViewWidth = 0, o => true);
        }

        private void CloseBoardShowMain(object parameter)
        {
           SaveBoard(parameter);
            App.WindowService.ShowMainCloseBoard();
        }

        private void RemoveSelectedTask(object parameter)
        {
            Board.Tasks.Remove(SelectedTask);
            TaskViewWidth = 0;
        }

        private void AddNewSubTask(object parameter)
        {
            SelectedTask.SubTasks.Add(new SubTask {Completed = NewSubTask.Completed, Title = NewSubTask.Title});
            BoardWindow.ClearSubTaskEntry();
        }

        private void AddNewTag(object parameter)
        {
            SelectedTask.Tags.Add(new Tag {Name = parameter.ToString()});
            BoardWindow.ClearTaskTagEntry();
        }

        private void AddTask(object parameter)
        {
            var task = new Task
            {
                BoardId = Board.Id, Category = (string) parameter, CreatedAt = DateTime.Now,
                Description = "", Title = "", SubTasks = new ObservableCollection<SubTask>(),
                Priority = "None", Tags = new ObservableCollection<Tag>()
            };

            Board.Tasks.Insert(0 ,task);
            SelectedTask = task;
            TaskViewWidth = 250;
        }

        public void SaveBoard(object parameter)
        {
            App.UnitOfWork.Boards.Update(Board);
        }
    }
}