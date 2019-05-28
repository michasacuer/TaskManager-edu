﻿namespace TaskManager.WPF.ViewModels
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using Caliburn.Micro;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Models;

    public class ActiveTaskViewModel : Screen
    {
        private readonly string projectName;

        private readonly ActiveTask activeTask;

        private readonly MainWindowViewModel vm;

        public ActiveTaskViewModel(MainWindowViewModel vm)
        {
            this.vm = vm;

            this.activeTask = LoggedUser.Instance.GetUserTask();

            this.projectName = Repository.Instance.Projects.Single(p => p.Id == this.activeTask.Task.ProjectId).Name;
            this.ActiveTaskTextBlock = $"{this.activeTask.Task.Name}, Priorytet: {this.activeTask.Task.Priority}";
            this.DescriptionTextBlock = this.activeTask.Task.Description;
            this.TimerActiveTaskTextBlock = this.activeTask.Task.StartTime.ToString();
            this.NotifyOfPropertyChange(() => this.TimerActiveTaskTextBlock);
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
