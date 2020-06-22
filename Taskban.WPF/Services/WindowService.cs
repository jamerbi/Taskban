using Taskban.WPF.Entities;
using Taskban.WPF.ViewModels;
using Taskban.WPF.Views;

namespace Taskban.WPF.Services
{
    public class WindowService : IWindowService
    {
        private MainWindow _mainWindow;
        private BoardWindow _boardWindow;
        private SettingsWindows _settingsWindows;

        public void ShowMain()
        {
            _mainWindow = new MainWindow {DataContext = new MainViewModel()};
            _mainWindow.Show();
        }

        public void ShowBoard(Board board)
        {
            _boardWindow = new BoardWindow();
            _boardWindow.DataContext = new BoardViewModel {BoardWindow = _boardWindow, Board = board};
            _boardWindow.Show();
            _mainWindow.Close();
        }

        public void ShowMainCloseBoard()
        {
            ShowMain();
            _boardWindow.Close();
        }

        public void ShowSettings()
        {
            _settingsWindows = new SettingsWindows {DataContext = _boardWindow.DataContext};
            _settingsWindows.ShowDialog();
        }
    }
}