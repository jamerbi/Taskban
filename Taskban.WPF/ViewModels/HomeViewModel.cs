using Taskban.WPF.Commands;
using System;
using System.Windows.Input;

namespace Taskban.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand NewBoardCommand { get; }

        public HomeViewModel(Action goNewBoarView)
        {
            NewBoardCommand = new RelayCommand(o => goNewBoarView(), o => true);
        }
    }
}