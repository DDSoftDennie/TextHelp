// See https://aka.ms/new-console-template for more information



using Cons.Controllers;
using System.Threading.Tasks;
using Cons.Cred;

DisplayController display = new DisplayController();
SpeechController speech = new SpeechController();
TranslateController translate = new TranslateController();

display.DisplayHeader();
display.DrawLine(10);

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

    AuthenticateSpeech();
    string lang = "en-EN";
    display.DisplayText(speech.SetLanguage(lang));
    display.DrawLine(5);
   
    bool mayContinue;
    
    do
    {
        string input = display.AskInput("Type a text you want to read aloud...");
        display.DisplayText(await speech.ReadAloud(input));
        display.DisplayText(speech.GetTotalCharacters());
        display.DrawLine(5);
        mayContinue = display.AskToContinue("speak");
    } while (mayContinue);
}

async Task TranslateMethod()
{
    AuthenticateTranslate();
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
    AuthenticateTranslate();
    AuthenticateSpeech();
    string lang = "en-EN";
    speech.SetLanguage(lang);

    bool mayContinue;
    do
    {
        string input = display.AskInput("Type a NL text to translate to EN: ");
        string translated = await translate.Translate(input);
        display.DisplayText(translated);
        display.DisplayText(await speech.ReadAloud(translated));
        display.DrawLine(10);
        mayContinue = display.AskToContinue("both");
    } while (mayContinue);
}

void AuthenticateSpeech()
{
    (string, string) credentials;
    credentials.Item1 = Cred.SpeechKey();
    credentials.Item2 = Cred.SpeechRegion();
    display.DisplayText(speech.Authenticate(credentials));
    display.DrawLine(10);
}

void AuthenticateTranslate()
{
    (string, string, string) translateCredentials;
    translateCredentials.Item1 = Cred.TranslatorKey();
    translateCredentials.Item2 = Cred.TranslatorRegion();
    translateCredentials.Item3 = Cred.TranslatorEndPoint();
    display.DisplayText(translate.Authenticate(translateCredentials));
    display.DrawLine(10);
}

