using Taskban.WPF.Commands;
using Taskban.WPF.Entities;
using System;
using System.Windows.Input;

namespace Taskban.WPF.ViewModels
{
    public class NewBoardViewModel : ViewModelBase
    {
        public Board Board
        {
            get => _board;
            set
            {
                _board = value;
                OnPropertyChanged();
            }
        }

        private Board _board = new Board();

        public ICommand CancelCommand { get; }

        public ICommand SaveCommand { get; }

        public NewBoardViewModel(Action goHomeView)
        {
            CancelCommand = new RelayCommand(o => goHomeView(), o => true);
            SaveCommand = new RelayCommand(o => SaveBoard(), o => !string.IsNullOrWhiteSpace(Board.Name));
        }

        private void SaveBoard()
        {
            App.WindowService.ShowBoard(App.UnitOfWork.Boards.Insert(Board));
        }
    }
}