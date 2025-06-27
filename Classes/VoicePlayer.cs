using System.Media;

namespace CyberAwarenessChatbot.Classes
{
    public class VoicePlayer
    {
        private string audioPath;

        public VoicePlayer(string path)
        {
            audioPath = path;
        }

        public void PlayGreeting()
        {
            SoundPlayer player = new SoundPlayer("C:\\Users\\RC_Student_lab\\source\\repos\\CyberAwarenessChatbot\\Assets\\voive greeting.wav");
            player.Play();
        }
    }
}
