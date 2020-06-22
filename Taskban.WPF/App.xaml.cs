using Taskban.WPF.Database;
using Taskban.WPF.Services;
using System.Windows;

namespace Taskban.WPF
{
    public partial class App
    {
        public static IWindowService WindowService { get; } = new WindowService();

        public static IUnitOfWork UnitOfWork { get; } = new UnitOfWork();

        protected override void OnStartup(StartupEventArgs e)
        {
            WindowService.ShowMain();

            base.OnStartup(e);
        }
  
        protected override void OnExit(ExitEventArgs e)
        {
            UnitOfWork.Dispose();

            base.OnExit(e);
        }
    }
}
