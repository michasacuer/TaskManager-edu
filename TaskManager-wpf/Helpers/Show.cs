namespace TaskManager.WPF.Helpers
{
    using System;
    using System.Diagnostics;
    using Caliburn.Micro;
    using TaskManager.Models;
    using TaskManager.WPF.ViewModels;

    public static class Show
    {
        public static void ErrorBox(string alert) => manager.ShowDialogAsync(new ErrorBoxViewModel(alert), null, null);

        public static void SuccesBox(string alert) => manager.ShowDialogAsync(new SuccesBoxViewModel(alert), null, null);

        public static void Pdf(string filepath)
        {
            var process = new Process();
            var pdf = new Uri(filepath, UriKind.RelativeOrAbsolute);

            process.StartInfo.FileName = pdf.LocalPath;
            process.Start();
        }

        public static void RegistrationBox() => manager.ShowDialogAsync(new RegistrationViewModel(), null, null);

        public static void LoginBox(MainWindowViewModel vm) => manager.ShowDialogAsync(new LoginViewModel(vm), null, null);

        public static void ActiveTaskBox(MainWindowViewModel vm) => manager.ShowDialogAsync(new ActiveTaskViewModel(vm), null, null);

        public static void ManagerPanelBox() => manager.ShowDialogAsync(new ManagerPanelViewModel(), null, null);

        public static void DeleteTaskBox(Task task) => manager.ShowDialogAsync(new DeleteTaskBoxViewModel(task), null, null);

        public static void DeleteProjectBox(Project project) => manager.ShowDialogAsync(new DeleteProjectBoxViewModel(project), null, null);

        public static void InfoTaskBox(Task task) => manager.ShowDialogAsync(new InfoTaskBoxViewModel(task), null, null);

        public static void InfoProjectBox(Project project) => manager.ShowDialogAsync(new InfoProjectBoxViewModel(project), null, null);

        private static IWindowManager manager = new WindowManager();
    }
}
