﻿namespace TaskManager.WPF
{
    using System.Net.Http;
    using System.Windows;
    using Caliburn.Micro;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Services;
    using TaskManager.WPF.Strings;
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
                this.DisplayRootViewFor<MainWindowViewModel>();
            }
            catch (HttpRequestException)
            {
                Show.ErrorBox(Error.NoServerConnection);
            }
        }
    }
}
