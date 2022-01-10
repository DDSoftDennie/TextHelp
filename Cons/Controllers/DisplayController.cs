using CSAuth.Services;
using CSSpeech.Services;
using System;
using System.Text;


namespace Cons.Controllers
{
   public class DisplayController
    {
       // private SpeechAuthService _Auth = new SpeechAuthService();
       //  private SDKSpeechService _speech = new SDKSpeechService();

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
            Console.WriteLine("Welcome to my Speech & Translate Demo");
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

        public(string, string) AskSpeechCredentials()
        {
            string key, region ;
            key = AskInput("Please enter your SPEECH Key: ");
            region = AskInput("Please enter your SPEECH Region: ");

            return (key, region);
            
        }

        public(string, string, string) AskTranslateCredentials()
        {
            string key, region, endpoint;

            key = AskInput("Please enter your TRANSLATE Key: ");
            region = AskInput("Please enter your TRANSLATE Region: ");
            endpoint = AskInput("Please enter your TRANSLATE endpoint: ");
            return(key, region, endpoint);

        }

        public int AskWhatToDo()
        {
            string todo;
            todo = AskInput("What do you want? (1) = Speak || (2) = Translate || (3) = Both. Please enter a number");
            int num ;
            int.TryParse(todo,out  num);
            return num;
        }

        public string AskLanguage()
        {
            string lang;
            lang = AskInput("Please enter your SPEECH Language: ");
            return lang;
        }
        public  bool AskToContinue(string task)
        {
            Console.WriteLine($"Press 'y' to {task} again.");
            return Console.ReadKey().Key == ConsoleKey.Y;
        }


    }
}
