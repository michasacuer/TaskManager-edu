﻿namespace TaskManager.WPF.Models
{
    using Caliburn.Micro;
    using TaskManager.WPF.ViewModels;

    public static class Show
    {
        public static void ErrorBox(string alert) => manager.ShowDialog(new ErrorBoxViewModel(alert), null, null);

        public static void SuccesBox(string alert) => manager.ShowDialog(new SuccesBoxViewModel(alert), null, null);

        public static void RegistrationBox() => manager.ShowDialog(new RegistrationViewModel(), null, null);

        public static void LoginBox(LoggedUser loggedUser) => manager.ShowDialog(new LoginViewModel(loggedUser), null, null);

        public static void ActiveTaskBox(TaskManager.Models.Task task, string projectName)
            => manager.ShowDialog(new ActiveTaskViewModel(task, projectName), null, null);

        public static void ManagerPanelBox() => manager.ShowWindow(new ManagerPanelViewModel(), null, null);

        private static IWindowManager manager = new WindowManager();
    }
}
