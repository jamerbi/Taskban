using Taskban.WPF.Entities;

namespace Taskban.WPF.Services
{
    public interface IWindowService
    {
        void ShowMain();
        void ShowBoard(Board board);
        void ShowMainCloseBoard();
    }
}