using System;
using System.Collections.Generic;
using System.Text;

namespace CyberAwarenessChatbot.Classes
{
    public class QuizManager
    {
        private int currentQuestionIndex = 0;
        private int score = 0;
        private bool quizInProgress = false;

        private List<(string Question, List<string> Options, int CorrectAnswer)> questions = new List<(string, List<string>, int)>
        {
            ("What should you do if you receive a suspicious email?", new List<string> { "Open it", "Reply", "Delete it", "Report it" }, 3),
            ("What is 2FA?", new List<string> { "A type of malware", "A backup plan", "Two-Factor Authentication", "A network attack" }, 2),
            ("Which password is strongest?", new List<string> { "123456", "Qwerty", "John2020", "G6@!x8Pz" }, 3),
            ("What does a phishing scam try to do?", new List<string> { "Teach security", "Get your info", "Clean your PC", "Fix your Wi-Fi" }, 1),
            ("What should you do before clicking a link in an email?", new List<string> { "Hover to check URL", "Click fast", "Forward it", "Reply to sender" }, 0),
            ("True or False: You should use the same password everywhere.", new List<string> { "True", "False" }, 1),
            ("Which of these is a good cybersecurity habit?", new List<string> { "Sharing passwords", "Ignoring updates", "Using strong passwords", "Clicking unknown links" }, 2),
            ("What is malware?", new List<string> { "A food app", "A virus or bad software", "An update tool", "A game" }, 1),
            ("How often should you update your passwords?", new List<string> { "Every 5 years", "Only if hacked", "Regularly", "Never" }, 2),
            ("What does HTTPS mean in a website?", new List<string> { "Hyper Tool", "Secure connection", "Not safe", "It's a scam" }, 1)
        };

        public string StartQuiz()
        {
            currentQuestionIndex = 0;
            score = 0;
            quizInProgress = true;
            return AskQuestion();
        }

        public string AskQuestion()
        {
            if (currentQuestionIndex >= questions.Count)
                return ShowFinalScore();

            var (question, options, _) = questions[currentQuestionIndex];

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Question {currentQuestionIndex + 1}: {question}");

            for (int i = 0; i < options.Count; i++)
            {
                sb.AppendLine($"{i + 1}. {options[i]}");
            }

            return sb.ToString();
        }

        public string SubmitAnswer(int userChoice)
        {
            if (!quizInProgress)
                return "No quiz in progress. Type 'start quiz' to begin.";

            var (_, options, correctIndex) = questions[currentQuestionIndex];

            string result;
            if (userChoice - 1 == correctIndex)
            {
                score++;
                result = "✅ Correct!";
            }
            else
            {
                result = $"❌ Wrong. The correct answer was: {options[correctIndex]}";
            }

            currentQuestionIndex++;

            if (currentQuestionIndex >= questions.Count)
            {
                quizInProgress = false;
                return result + "\n\n" + ShowFinalScore();
            }

            return result + "\n\n" + AskQuestion();
        }

        private string ShowFinalScore()
        {
            string feedback;

            if (score >= 8)
                feedback = "🎉 Excellent job! You're a cybersecurity pro!";
            else if (score >= 5)
                feedback = "💡 Not bad! Keep learning to stay safe online.";
            else
                feedback = "📘 Keep practicing. The more you know, the safer you are!";

            return $"🏁 Quiz complete!\nScore: {score}/{questions.Count}\n{feedback}";
        }
    }
}
