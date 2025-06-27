 Cybersecurity Awareness Chatbot (PROG6221 Final POE)

Project Overview

This WPF-based C# application is an interactive chatbot that educates users on **cybersecurity awareness** through conversations, tasks, reminders, and quizzes. It simulates human-like dialogue using keyword recognition, sentiment analysis, and memory features.

---

 Key Features

Part 1: Voice and Logo Integration
- **Voice Greeting**: Plays a WAV file greeting when the app launches.
- **ASCII Art Logo**: Displays an ASCII logo from a `.txt` file.

 Part 2: Chatbot Intelligence
- **Keyword Recognition**: Detects cybersecurity keywords like `password`, `scam`, and `privacy` and gives educational tips.
- **Dynamic Responses**: Randomly selects from multiple answers for topics like phishing and 2FA.
- **Conversation Memory**: Remembers the user’s name and topics of interest.
- **Sentiment Detection**: Detects moods like *worried*, *curious*, and *frustrated* and responds empathetically.
- **Error Handling**: Gracefully handles unexpected inputs and guides the user to rephrase.

---

 Part 3: GUI Features (WPF/XAML)

 Main Chat Window
- Dark-themed WPF interface
- Scrollable chat box
- Input box + buttons for:
  - `Send`
  - `Clear Chat`
  - `Start Quiz`
  - `View Tasks`
  - `Show Activity Log`

 Task Assistant
- Add custom cybersecurity tasks (e.g., “Review privacy settings”).
- Set reminders using natural language like:  
  `Remind me to update my password in 5 days`
- View all active tasks.
- Tasks are logged with timestamps.

 Cybersecurity Quiz
- Start a 10-question quiz with `Start Quiz` button or type `"quiz"`.
- Mixed multiple choice and true/false.
- Tracks score and gives final feedback like:
  - “ Great job! You're a cybersecurity pro!”
  - “Keep learning to stay safe online.”

 Simulated NLP (Natural Language Processing)
- Recognizes flexible phrasing like:
  - `"Remind me to enable 2FA in 3 days"`
  - `"Add task to check account settings"`
- Interprets meaning through string processing and regular expressions.

 Activity Log
- Records and displays:
  - Tasks added
  - Reminders set
  - Quiz started or completed
  - User inputs
- Only shows last 5–10 events for clarity.

Project Structure

