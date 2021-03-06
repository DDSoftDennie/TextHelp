// See https://aka.ms/new-console-template for more information
using Cons.Controllers;
using System.Threading.Tasks;

DisplayController display = new DisplayController();
SpeechController speech = new SpeechController();
TranslateController translate = new TranslateController();

display.DisplayHeader();
display.DrawLine(5);

int todo = display.AskWhatToDo();
if(todo == 1)
{
    await SpeechMethod();
} else if (todo == 2)
{
    await TranslateMethod();
} else if(todo == 3)
{
    await TranslateAndSpeakMethod();
}
display.DisplayFooter();


 async Task SpeechMethod()
{
  


    //SDK
   (string, string) credentials = ((string, string))display.AskSpeechCredentials();
   display.DisplayText(speech.Authenticate(credentials));
   

    //REST
    //(string, string, string) credentials = ((string, string, string))display.AskSpeechRESTCredentials();
    //display.DisplayText(speech.AuthenticateREST(credentials));
  

    display.DrawLine(5);
    string lang = "en-EN";
    display.DisplayText(speech.SetLanguage(lang));
    display.DrawLine(5);

    bool mayContinue;
    do
    {
        string input = display.AskInput("Type a text you want to read aloud...");
      

        //REST Save to file
        //await speech.SetAcessToken(credentials.Item3, credentials.Item1);
        //string fileName = display.AskInput("Enter file name:");
        //await speech.WriteToFile(input, fileName);

        //SDK Speech and Read Aloud
         display.DisplayText(await speech.ReadAloud(input));
         display.DisplayText(speech.GetTotalCharacters());

        display.DrawLine(5);
        mayContinue = display.AskToContinue("speak");
    } while (mayContinue);
}

async Task TranslateMethod()
{
    (string, string, string) credentials = ((string, string, string))display.AskTranslateCredentials();
    display.DisplayText(translate.Authenticate(credentials));
    display.DrawLine(10);

    bool mayContinue;
    do
    {
        string input = display.AskInput("Type a NL text to translate to EN: ");
        display.DisplayText(await translate.Translate(input));
        display.DrawLine(10);
        mayContinue = display.AskToContinue("translate");
    }while(mayContinue);
}



async Task TranslateAndSpeakMethod()
{
    (string, string, string) translateCredentials = ((string, string, string))display.AskTranslateCredentials();
    display.DisplayText(translate.Authenticate(translateCredentials));
    display.DrawLine(10);

    (string, string) speechCredentials = ((string, string))display.AskSpeechCredentials();
    display.DisplayText(speech.Authenticate(speechCredentials));
    display.DrawLine(10);
    string lang = "en-EN";
    speech.SetLanguage(lang);

    bool mayContinue;
    do
    {
        string input = display.AskInput("Type a NL text to translate to EN: ");
        string translated = await translate.Translate(input);
        display.DisplayText(translated);
       // display.DisplayText(await speech.ReadAloud(translated));
        display.DrawLine(10);
        mayContinue = display.AskToContinue("both");
    } while (mayContinue);
}

