using CyberAwarenessChatbot.Classes;

internal static class NLPProcessorHelpers
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
        // Detect mood
        string mood = sentiment.DetectMood(input);

        // NLP commands
        if (input.Contains("quiz"))
        {
            return quizManager.AskQuestion();
        }
        if (input.StartsWith("answer") && int.TryParse(input.Replace("answer", "").Trim(), out int answer))
        {
            return quizManager.SubmitAnswer(answer);
        }
        if (input.Contains("add task"))
        {
            memory.SetInterest("task");
            return taskManager.AddTask("Cyber Task", "Follow best practices.", 5);
        }
        if (input.Contains("show task"))
        {
            return taskManager.GetTaskList();
        }
        if (input.Contains("show activity") || input.Contains("what have you done"))
        {
            return logger.GetLog();
        }

        // Keyword recognition
        string tip = keywordHandler.CheckForKeyword(input);
        if (tip != null)
        {
            memory.SetInterest(input);
            return tip;
        }

        // Random tip
        if (input.Contains("phishing") || input.Contains("2fa"))
        {
            return responder.GetRandomResponse(input.Contains("2fa") ? "2fa" : "phishing");
        }

        // Sentiment support
        if (mood == "worried") return "It's okay to feel worried. Let me help you feel more secure.";
        if (mood == "curious") return "I love that you're curious! Cybersecurity is full of exciting info.";
        if (mood == "frustrated") return "Take a breath — we’ll work through your concerns together.";

        return "I'm not sure I understand. Can you try rephrasing?";
    }
}