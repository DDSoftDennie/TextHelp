using CSAuth;
using CSSpeech;
using System;
using System.Text;


namespace Cons.Controllers
{
   public class DisplayController
    {
        private SpeechAuthService _Auth = new SpeechAuthService();
        private SpeechService _speech = new SpeechService();

        public void DrawLine(int length)
        {
            StringBuilder line = new StringBuilder();
            for (int i = 0; i <= length; i++)
            {
                line.Append("-");
            }
            Console.WriteLine(line.ToString());

        }

        public void DisplayHeader()
        {
            Console.WriteLine("Welcome to my Speech Demo");
            DrawLine(25);
        }

        public void DisplayFooter()
        {
            Console.WriteLine("Press any key to continue...");
        }

        public void DisplayText(string text)
        {
            Console.WriteLine(text);
        }

        public string AskInput(string question)
        {
            Console.WriteLine(question);
            Console.Write("> ");
            var input =  Console.ReadLine();
            string answer = input != null ? input : "";
            return answer;
        }

        public(string, string) AskCredentials()
        {
            string key;
            string region;
            Console.WriteLine("Please enter your Key: ");
            var input = Console.ReadLine();
            key = input != null ? input: "";

            Console.WriteLine("Please enter the Region: ");
            input = Console.ReadLine();
            region = input != null ? input : "";

            return (key, region);
            
        }

        public string AskLanguage()
        {
            string lang;
            Console.WriteLine("Please enter the Language: ");
            var input = Console.ReadLine();
            lang = input != null ? input : "";
            return (lang);
        }
        public  bool AskToContinue()
        {
            Console.WriteLine("Press 'y' to speak again.");
            return Console.ReadKey().Key == ConsoleKey.Y;

        }


    }
}
