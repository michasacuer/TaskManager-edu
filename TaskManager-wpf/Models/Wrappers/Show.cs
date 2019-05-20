namespace TaskManager.WPF.Models
{
    using Caliburn.Micro;
    using TaskManager.WPF.ViewModels;

    public static class Show
    {
        public static void ErrorBox(string alert) => manager.ShowDialog(new ErrorBoxViewModel(alert), null, null);

        public static void SuccesBox(string alert) => manager.ShowDialog(new SuccesBoxViewModel(alert), null, null);

        public static void RegistrationBox()
            => manager.ShowDialog(new RegistrationViewModel(), null, null);

        public static void LoginBox(LoggedUser loggedUser)
            => manager.ShowDialog(new LoginViewModel(loggedUser), null, null);

        public static void ActiveTaskBox(string taskName, string projectName, FakeData context)
            => manager.ShowDialog(new ActiveTaskViewModel(context.GetTask(taskName, projectName), context, projectName), null, null);

        private static IWindowManager manager = new WindowManager();
    }
}
