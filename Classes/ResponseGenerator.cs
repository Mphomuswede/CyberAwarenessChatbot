using System;
using System.Collections.Generic;

namespace CyberAwarenessChatbot.Classes
{
    public class ResponseGenerator
    {
        private Dictionary<string, List<string>> topicResponses = new Dictionary<string, List<string>>
        {
            { "phishing", new List<string>
                {
                    "Be cautious of emails asking for personal information.",
                    "Phishing scams often pretend to be banks or popular websites.",
                    "Don’t click on links in suspicious emails or texts.",
                    "Check the sender’s email address — even small typos can reveal a scam.",
                    "Avoid opening attachments from unknown sources.",
                    "If in doubt, contact the company directly through their official website."
                }
            },
            { "2fa", new List<string>
                {
                    "Two-factor authentication adds an extra layer of security.",
                    "Use 2FA wherever possible, especially for emails and banking apps.",
                    "Even if someone has your password, 2FA can block them.",
                    "Apps like Google Authenticator or Authy are more secure than SMS-based 2FA.",
                    "Enable 2FA on all important accounts like Gmail, Facebook, and banking apps."
                }
            },
            { "password", new List<string>
                {
                    "Use a password manager to create and store strong passwords.",
                    "Avoid using the same password for multiple accounts.",
                    "Change your passwords regularly to reduce risk.",
                    "Include letters, numbers, and symbols in your password.",
                    "Never share your password with anyone — even someone who claims to be support."
                }
            },
            { "privacy", new List<string>
                {
                    "Limit the personal information you share online.",
                    "Review privacy settings on your social media accounts.",
                    "Be aware of which apps have access to your location and contacts.",
                    "Use incognito/private mode when browsing on shared devices.",
                    "Read permission requests before accepting app installs."
                }
            },
            { "malware", new List<string>
                {
                    "Install antivirus software and keep it updated.",
                    "Don’t download software from unknown sources.",
                    "Avoid clicking on pop-ups that offer free downloads.",
                    "Keep your system and apps updated to patch vulnerabilities.",
                    "Scan USB drives before opening them."
                }
            }
        };

        public string GetRandomResponse(string topic)
        {
            if (topicResponses.ContainsKey(topic))
            {
                var responses = topicResponses[topic];
                var random = new Random();
                int index = random.Next(responses.Count);
                return responses[index];
            }

            return "That's a great topic! Always follow best practices for cybersecurity.";
        }
    }
}
