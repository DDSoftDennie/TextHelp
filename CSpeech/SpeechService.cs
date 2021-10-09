
using CSAuth.Model;
using CSSpeech.Model;
using Microsoft.CognitiveServices.Speech;


namespace CSSpeech;
public class SpeechService : ISpeechService
{
    private Auth auth = new Auth();
    private Speech speech = new Speech();
    private SpeechConfig? config = null;

    public string Authenticate(Auth authentication)
    {
        string result;

        if(authentication.Key != "")
        {
           if(authentication.Region != "")
            {
                config = SpeechConfig.FromSubscription(authentication.Key, authentication.Region);
                result = "Authenticated!";
            }
            else
            {
                result = "Please fill in the Speech Service Region!";
            }
        }
        else
        {
            result =  "Please fill in the Speech Service Key!";
        }
        return result;
     
    }

    public string Configure(Speech speech)
    {
        string result;
        if(speech.Language  != "")
        {
            if(config != null)
            {
                config.SpeechSynthesisLanguage = speech.Language;
                result = "Speech configured!";
            }
            else{
                result = "Something went wrong... Please make sure you are authenticated";
            }
        }
        else
        {
            result = "Please fill in the Speech Service Language!";
        }
        return result;
    }

    public async Task ReadAloud(string text)
    {
       using (SpeechSynthesizer synth = new SpeechSynthesizer(config))
        {
            await synth.SpeakTextAsync(text);
        }
    }
}
