using System;
using System.Collections.Generic;

namespace CyberAwarenessChatbot.Classes
{
    public class MemoryManager
    {
        private Dictionary<string, string> memoryData = new Dictionary<string, string>();

        // Store a value under a specific key
        public void Remember(string key, string value)
        {
            memoryData[key] = value;
        }

        // Retrieve a value by key
        public string Recall(string key)
        {
            return memoryData.ContainsKey(key) ? memoryData[key] : "";
        }

        // Interest
        public void SetInterest(string topic)
        {
            Remember("interest", topic);
        }

        public string GetInterest()
        {
            return Recall("interest");
        }

        // Name
        public void SetName(string name)
        {
            Remember("userName", name);
        }

        public string GetName()
        {
            return Recall("userName");
        }

        // Last task for follow-up
        public void SetLastTask(string task)
        {
            Remember("lastTask", task);
        }

        public string GetLastTask()
        {
            return Recall("lastTask");
        }

        public void ClearLastTask()
        {
            if (memoryData.ContainsKey("lastTask"))
                memoryData.Remove("lastTask");
        }
    }
}
