using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberAwarenessChatbot.Classes
{
    public class SentimentAnalyzer
    {
        public string DetectMood(string input)
        {
            if (input.Contains("worried") || input.Contains("scared")) return "worried";
            if (input.Contains("curious") || input.Contains("interested")) return "curious";
            if (input.Contains("frustrated") || input.Contains("angry")) return "frustrated";
            return "neutral";
        }
    }
}