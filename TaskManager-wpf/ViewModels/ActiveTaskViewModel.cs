namespace TaskManager.WPF.ViewModels
{
    using System.Threading.Tasks;
    using System.Windows;
    using Caliburn.Micro;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Models;

    public class ActiveTaskViewModel : Screen
    {
        private readonly ActiveTask activeTask;

        private readonly MainWindowViewModel vm;

        public ActiveTaskViewModel(MainWindowViewModel vm)
        {
            this.vm = vm;

            this.activeTask = LoggedUser.Instance.GetUserTask();

            this.ActiveTaskTextBlock = $"{this.activeTask.GetTaskName()}, Priorytet: {this.activeTask.GetTaskPriority()}";
            this.DescriptionTextBlock = this.activeTask.GetTaskDescription();
            this.TimerActiveTaskTextBlock = this.activeTask.GetTaskStartTime();
        }

        public string ActiveTaskTextBlock { get; set; }

        public string DescriptionTextBlock { get; set; }

        public string TimerActiveTaskTextBlock { get; set; }

        public async Task EndTaskButton()
        {
            this.vm.IsActiveTaskButtonVisible = Visibility.Hidden;
            this.vm.NotifyOfPropertyChange(() => this.vm.IsActiveTaskButtonVisible);

            await this.activeTask.EndActiveTask();
            await this.TryCloseAsync();

            Show.SuccesBox("Task zakończono pomyślnie!");
        }

        public void CancelTaskButton() => this.TryCloseAsync();
    }
}
