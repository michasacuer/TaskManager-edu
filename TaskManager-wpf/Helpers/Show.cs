namespace TaskManager.WPF.Helpers
{
    using Caliburn.Micro;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.ViewModels;

    public static class Show
    {
        public static void ErrorBox(string alert) => manager.ShowDialogAsync(new ErrorBoxViewModel(alert), null, null);

        public static void SuccesBox(string alert) => manager.ShowDialogAsync(new SuccesBoxViewModel(alert), null, null);

        public static void RegistrationBox() => manager.ShowDialogAsync(new RegistrationViewModel(), null, null);

        public static void LoginBox(LoggedUser loggedUser) => manager.ShowDialogAsync(new LoginViewModel(loggedUser), null, null);

        public static void ActiveTaskBox(ActiveTask activeTask) => manager.ShowDialogAsync(new ActiveTaskViewModel(activeTask), null, null);

        public static void ManagerPanelBox() => manager.ShowDialogAsync(new ManagerPanelViewModel(), null, null);

        private static IWindowManager manager = new WindowManager();
    }
}
