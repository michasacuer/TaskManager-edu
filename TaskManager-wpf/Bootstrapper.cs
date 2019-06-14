namespace TaskManager.WPF
{
    using System;
    using System.Net.Http;
    using System.Windows;
    using Caliburn.Micro;
    using TaskManager.WPF.Exceptions;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Services;
    using TaskManager.WPF.ViewModels;

    internal class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            this.Initialize();
        }

        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            var client = new HttpDataService();

            try
            {
                await client.TestServerConnection();
                await this.DisplayRootViewFor<MainWindowViewModel>();
            }
            catch (Exception exception)
            {
                if (exception is InternalServerErrorException)
                {
                    Show.ErrorBox(exception.Message);
                }

                if (exception is HttpRequestException)
                {
                    Show.ErrorBox("Uruchom localhost (PowerShell > dotnet run)!");
                }
            }
        }
    }
}
