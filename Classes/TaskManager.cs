using System;
using System.Collections.Generic;
using System.Text;

namespace CyberAwarenessChatbot.Classes
{
    public class TaskManager
    {
        private List<TaskItem> tasks = new List<TaskItem>();

        public void AddTask(string title, string description, DateTime? reminderDate = null)
        {
            tasks.Add(new TaskItem
            {
                Title = title,
                Description = description,
                ReminderDate = reminderDate,
                Completed = false
            });
        }

        public string ListTasks()
        {
            if (tasks.Count == 0)
                return "You currently have no tasks.";

            StringBuilder sb = new StringBuilder("Here are your tasks:\n");

            int count = 1;
            foreach (var task in tasks)
            {
                sb.AppendLine($"{count++}. {task.Title} - {task.Description}" +
                              (task.ReminderDate.HasValue ? $" (Reminder: {task.ReminderDate.Value.ToShortDateString()})" : "") +
                              (task.Completed ? " [Completed]" : ""));
            }

            return sb.ToString();
        }

        internal string AddTask(string v1, string v2, int v3)
        {
            throw new NotImplementedException();
        }

        internal string GetTaskList()
        {
            throw new NotImplementedException();
        }

        public class TaskItem
        {
            public string? Title { get; set; }
            public string? Description { get; set; }
            public DateTime? ReminderDate { get; set; }
            public bool Completed { get; set; }
        }

    }
}
