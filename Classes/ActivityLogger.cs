using System.Collections.Generic;

namespace CyberAwarenessChatbot.Classes
{
    public class ActivityLogger
    {
        private List<string> log = new List<string>();

        public void Log(string action)
        {
            if (log.Count >= 10) log.RemoveAt(0); // Keep latest 10
            log.Add(action);
        }

        public string GetLog()
        {
            if (log.Count == 0) return "No recent actions.";

            string result = "Here’s a summary of recent actions:\n";
            for (int i = 0; i < log.Count; i++)
            {
                result += $"{i + 1}. {log[i]}\n";
            }
            return result;
        }
    }
}
