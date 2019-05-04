﻿namespace TaskManager.WPF.Services
{
    using System;
    using TaskManager.WPF.Enums;
    using TaskManager.WPF.Models;

    public static class NewTask
    {
        public static Priority SetPriority(bool isLow, bool isMedium, bool isHigh) =>
            isLow ? Priority.Low :
            isMedium ? Priority.Medium :
            isHigh ? Priority.High : throw new ArgumentNullException();

        public static bool ProjectSelected(string projectName) => projectName != null;

        public static (bool, string) IsValid(Task task) =>
            task.Name == null ? (false, "Nazwa zadania nie może być pusta!") : (true, "Zadanie dodano pomyślnie");
    }
}
