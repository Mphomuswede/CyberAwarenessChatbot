using System.Collections.Generic;

namespace CyberAwarenessChatbot.Classes
{
    public class KeywordHandler
    {
        // Define some keywords and related topics
        private Dictionary<string, string> keywordTopics = new Dictionary<string, string>
        {
            { "password", "Use strong, unique passwords and avoid reusing them across sites." },
            { "scam", "Always be cautious with unexpected emails or messages. Don’t click on unknown links." },
            { "privacy", "Check your app and account privacy settings regularly. Limit what you share online." }
        };

        public string CheckForKeyword(string input)
        {
            foreach (var keyword in keywordTopics.Keys)
            {
                if (input.Contains(keyword))
                {
                    return keywordTopics[keyword];
                }
            }
            return null; // No keyword matched
        }
    }
}
