using System;
using Taskban.WPF.Entities;
using Taskban.WPF.ViewModels;
using Syncfusion.UI.Xaml.Kanban;

namespace Taskban.WPF.Views
{
    public partial class BoardWindow
    {
        public BoardWindow()
        {
            InitializeComponent();
        }

        private void SfKanban_OnCardTapped(object sender, KanbanTappedEventArgs e)
        {
            var viewModel = (BoardViewModel) DataContext;
            viewModel.SelectedTask = (Task) e.SelectedCard.Content;
            viewModel.TaskViewWidth = 250;
            ClearTaskTagEntry();
            ClearSubTaskEntry();
        }

        public void ClearSubTaskEntry()
        {
            SubTaskIsCompletedCheckBox.IsChecked = false;
            SubTaskTitleTextBox.Text = "";
        }

        public void ClearTaskTagEntry()
        {
            TaskTagTextBox.Text = "";
        }

        private void BoardWindow_OnClosed(object sender, EventArgs e)
        {
            var viewModel = (BoardViewModel) DataContext;
            viewModel.SaveBoard(null);
        }

        private void AboutMenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var window = new AboutWindow();
            window.ShowDialog();
        }
    }
}