namespace TaskManager.WPF.ViewModels
{
    using System.Windows;
    using Caliburn.Micro;
    using TaskManager.WPF.Exceptions;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Models;

    public class LoginViewModel : Screen
    {
        private MainWindowViewModel vm;

        public LoginViewModel()
        {
        }

        public LoginViewModel(MainWindowViewModel vm)
        {
            this.vm = vm;
        }

        public bool IsFormEnabled { get; set; } = true;

        public string LoginTextBox { get; set; }

        public string PasswordTextBox { get; set; }

        public async void LoginButton()
        {
            this.IsFormEnabled = false;
            this.NotifyOfPropertyChange(() => this.IsFormEnabled);

            var helper = new LoginHelper();

            try
            {
                var validationResult = await helper.ExternalLogin(this);

                if (validationResult.IsValid)
                {
                    await this.TryCloseAsync();
                    Show.SuccesBox(validationResult.Message);

                    if (LoggedUser.Instance.GetUserTask().IsTaskTakenByUser())
                    {
                        this.vm.IsActiveTaskButtonVisible = Visibility.Visible;
                        this.vm.NotifyOfPropertyChange(() => this.vm.IsActiveTaskButtonVisible);
                    }
                }
                else
                {
                    Show.ErrorBox(validationResult.Message);

                    this.IsFormEnabled = true;
                    this.NotifyOfPropertyChange(() => this.IsFormEnabled);
                }
            }
            catch (ExternalLoginException exception)
            {
                Show.ErrorBox(exception.Message);

                this.IsFormEnabled = true;
                this.NotifyOfPropertyChange(() => this.IsFormEnabled);
            }
        }

        public void RegisterButton() => Show.RegistrationBox();

        public void CancelButton() => Application.Current.Shutdown();
    }
}
