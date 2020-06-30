using Taskban.WPF.Commands;
using Taskban.WPF.Entities;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Taskban.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Board> ListBoxSource { get; set; }

        private Board _selectedBoard = new Board();

        public Board SelectedBoard
        {
            get => _selectedBoard;
            set
            {
                _selectedBoard = value;
                OnPropertyChanged();
            }
        }

        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand OpenBoardCommand { get; }
        public ICommand DeleteBoardCommand { get; }

        private readonly HomeViewModel _homeViewModel;
        private readonly NewBoardViewModel _boardViewModel;

        public MainViewModel()
        {
            _homeViewModel = new HomeViewModel(GoToBoardView);
            _boardViewModel = new NewBoardViewModel(GoToHomeView);

            CurrentViewModel = _homeViewModel;

            OpenBoardCommand = new RelayCommand(o => App.WindowService.ShowBoard(SelectedBoard), o => true);
            DeleteBoardCommand = new RelayCommand(DeleteBoard, o => true);

            ListBoxSource = new ObservableCollection<Board>(App.UnitOfWork.Boards.Get(orderBy: board => board.CreatedAt, ascending: false));
        }

        private void GoToBoardView()
        {
            CurrentViewModel = _boardViewModel;
        }

        private void GoToHomeView()
        {
            CurrentViewModel = _homeViewModel;
        }

        private void DeleteBoard(object parameter)
        {
            var board = (Board) parameter;
            ListBoxSource.Remove(board);
            App.UnitOfWork.Boards.Delete(board.Id);
        }
    }
}