using System;
using TaskManager.Enums;
using TaskManager.Models;

namespace TaskManager.Services
{
    static public class NewTask
    {
        public static Priority SetPriority(bool isLow, bool isMedium, bool isHigh) =>
            isLow == true ? Priority.Low : 
            isMedium == true ? Priority.Medium : 
            isHigh == true ? Priority.High : throw new ArgumentNullException();

        public static bool ProjectSelected(string projectName) => projectName == null ? false : true;

        public static (bool, string) IsValid(Task task)
        {
            bool isValid;
            string alert;

            if (task.TaskName == null)
            {
                isValid = false;
                alert = "Nazwa zadania nie może być pusta!";
            }
            else
            {
                isValid = true;
                alert = "Zadanie dodano pomyślnie";
            }

            return (isValid, alert);
        }
    }
}
