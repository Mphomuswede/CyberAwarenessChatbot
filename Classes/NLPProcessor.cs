using System;
using System.Text.RegularExpressions;

namespace CyberAwarenessChatbot.Classes
{
    public class NLPProcessor
    {
        public static string ProcessInput(string input,
            KeywordHandler keywordHandler,
            ResponseGenerator responder,
            SentimentAnalyzer sentiment,
            MemoryManager memory,
            TaskManager taskManager,
            QuizManager quizManager,
            ActivityLogger logger)
        {
            input = input.ToLower(); // Normalize input
            string mood = sentiment.DetectMood(input);

            //  REMINDER: e.g. "Remind me to review settings in 3 days"
            Match reminderMatch = Regex.Match(input, @"remind(?: me)?(?: to)? (.+?) in (\d+) days?");
            if (reminderMatch.Success)
            {
                string taskTitle = reminderMatch.Groups[1].Value;
                int days = int.Parse(reminderMatch.Groups[2].Value);
                DateTime reminderDate = DateTime.Now.AddDays(days);

                taskManager.AddTask(taskTitle, $"Reminder to: {taskTitle}", reminderDate);
                logger.Log($"Reminder set: {taskTitle} in {days} days");
                return $"Got it! I’ll remind you to \"{taskTitle}\" in {days} days.";
            }

            //  FOLLOW-UP: "yes" after task
            if (input == "yes" || input.Contains("yes"))
            {
                string lastTask = memory.GetLastTask();
                if (!string.IsNullOrEmpty(lastTask))
                {
                    taskManager.AddTask(lastTask, $"Reminder to: {lastTask}", DateTime.Now.AddDays(3));
                    logger.Log("Reminder added for last task: " + lastTask);
                    memory.ClearLastTask();
                    return $"Okay, I’ve set a reminder for \"{lastTask}\" in 3 days.";
                }
            }

            //  NLP Add Task: "add a task to enable 2FA"
            Match taskMatch = Regex.Match(input, @"add (?:a )?task(?: to)? (.+)");
            if (taskMatch.Success)
            {
                string task = taskMatch.Groups[1].Value;
                taskManager.AddTask(task, $"Cybersecurity task: {task}");
                memory.SetLastTask(task);
                logger.Log("Task added: " + task);
                return $"Task added: \"{task}\". Would you like a reminder?";
            }

            //  QUIZ section
            if (input.Contains("quiz"))
            {
                return quizManager.AskQuestion();
            }
            if (input.StartsWith("answer") && int.TryParse(input.Replace("answer", "").Trim(), out int answer))
            {
                return quizManager.SubmitAnswer(answer);
            }

            //  Show Tasks
            if (input.Contains("show task"))
            {
                return taskManager.ListTasks();
            }

            //  Show Activity Log
            if (input.Contains("show activity") || input.Contains("what have you done"))
            {
                return logger.GetLog();
            }

            //  Keyword tips
            string tip = keywordHandler.CheckForKeyword(input);
            if (tip != null)
            {
                memory.SetInterest(input);
                return tip;
            }

            //  Phishing or 2FA random tips
            if (input.Contains("phishing") || input.Contains("2fa"))
            {
                return responder.GetRandomResponse(input.Contains("2fa") ? "2fa" : "phishing");
            }

            //  Sentiment-aware responses
            if (mood == "worried") return "It's okay to feel worried. Let me help you feel more secure.";
            if (mood == "curious") return "I love that you're curious! Cybersecurity is full of exciting info.";
            if (mood == "frustrated") return "Take a breath — we’ll work through your concerns together.";

            // ❌ Default fallback
            return "I'm not sure I understand. Can you try rephrasing?";
        }
    }
}
