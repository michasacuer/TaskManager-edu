namespace TaskManager.WPF
{
    using System.Windows;
    using Caliburn.Micro;
    using TaskManager.WPF.ViewModels;

    internal class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            this.Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            this.DisplayRootViewFor<MainWindowViewModel>();
        }
    }
}
