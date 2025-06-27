using System.Windows;
using CyberAwarenessChatbot.Classes;

namespace CyberAwarenessChatbot
{
    public partial class MainWindow : Window
    {
        VoicePlayer voice = new VoicePlayer("C:\\Users\\RC_Student_lab\\source\\repos\\CyberAwarenessChatbot\\Assets\\voive greeting.wav");
        AsciiLogo logo = new AsciiLogo("C:\\Users\\RC_Student_lab\\source\\repos\\CyberAwarenessChatbot\\Assets\\logo.txt");
        ResponseGenerator responder = new ResponseGenerator();
        KeywordHandler keywordHandler = new KeywordHandler();
        MemoryManager memory = new MemoryManager();
        SentimentAnalyzer sentiment = new SentimentAnalyzer();
        TaskManager taskManager = new TaskManager();
        QuizManager quizManager = new QuizManager();
        NLPProcessor nlp = new NLPProcessor();
        ActivityLogger logger = new ActivityLogger();

        private bool isNameAsked = false;
        private string userName = "";

        public MainWindow()
        {
            InitializeComponent();
            voice.PlayGreeting();
            ChatDisplay.Text = logo.GetLogo() + "\n\nHello! 👋 Welcome to the Cybersecurity Awareness Chatbot.\nWhat is your name?";
            isNameAsked = true;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInput.Text.Trim();
            logger.Log("User input: " + input);

            if (isNameAsked && string.IsNullOrWhiteSpace(userName))
            {
                // Check if input looks like a valid name (not just a number)
                if (int.TryParse(input, out _))
                {
                    ChatDisplay.Text += $"\n\nBot: That doesn’t look like a name. Please tell me your name.";
                    return;
                }

                userName = input;
                memory.Remember("userName", userName);
                ChatDisplay.Text += $"\n\n{userName}: {input}\nBot: Nice to meet you, {userName}! How can I help you today?";
                isNameAsked = false;
                UserInput.Clear();
                return;
            

        }
            else
            {
                string response = NLPProcessor.ProcessInput(
                    input.ToLower(),
                    keywordHandler,
                    responder,
                    sentiment,
                    memory,
                    taskManager,
                    quizManager,
                    logger
                );

                ChatDisplay.Text += $"\n\n{userName}: {input}\nBot: {response}";
            }

            UserInput.Clear();
        }

        private void ClearChat_Click(object sender, RoutedEventArgs e)
        {
            ChatDisplay.Text = $"Hi again, {userName}! The chat has been cleared. How can I assist you now?";
            logger.Log("Chat cleared.");
        }

        private void StartQuiz_Click(object sender, RoutedEventArgs e)
        {
            string response = quizManager.StartQuiz();
            ChatDisplay.Text += $"\n\nBot: {response}";
            logger.Log("Quiz started.");
        }

        private void ViewTasks_Click(object sender, RoutedEventArgs e)
        {
            string response = taskManager.ListTasks();
            ChatDisplay.Text += $"\n\nBot: {response}";
            logger.Log("Tasks viewed.");
        }
        private void ViewActivityLog_Click(object sender, RoutedEventArgs e)
        {
            string log = logger.GetLog();
            ChatDisplay.Text += $"\n\nBot: Here's your activity log:\n{log}";
        }


        // The method you requested to add:
        private void StartQuizButton_Click(object sender, RoutedEventArgs e)
        {
            string quizQuestion = quizManager.AskQuestion();
            ChatDisplay.Text += $"\n\nBot: {quizQuestion}";
            logger.Log("Quiz started.");
        }
    }
}
