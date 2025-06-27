using System.IO;

namespace CyberAwarenessChatbot.Classes
{
    public class AsciiLogo
    {
        private string logoPath;

        public AsciiLogo(string path)
        {
            logoPath = path;
        }

        public string GetLogo()
        {
            return File.ReadAllText("C:\\Users\\RC_Student_lab\\source\\repos\\CyberAwarenessChatbot\\Assets\\logo.txt");
        }
    }
}

