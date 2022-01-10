using CSAuth.Services;
using CSSpeech.Services;
using System.Threading.Tasks;

namespace Cons.Controllers
{
    public class SpeechController
    {
        private SpeechAuthService _speechAuthService;
        private SDKSpeechService? _speechService;

       public  SpeechController()
        {
            _speechAuthService = new SpeechAuthService();
        }
        public string Authenticate((string, string)credentials)
        {
   
            _speechAuthService.MakeCredentials(credentials.Item1, credentials.Item2);
            _speechService = new SDKSpeechService(_speechAuthService.GetCredentials());
            return "Authenticated!"; 
        }

        public string SetLanguage(string lang)
        {
            _speechService?.SetLanguage(lang);   
            return "Language set!";
        }

        public string SetStartCharacters(int characters)
        {
            _speechService?.SetStartCharacters(characters);
            return "Initial characters set!";
        }

        public async Task<string> ReadAloud(string text)
        {
           int length =  await _speechService.ReadAloud(text);
           return $"Speech for '{text}' performed. {length} characters were computed.";
        }

        public string GetTotalCharacters()
        {
            return $"The total of charactes is: {_speechService.GetTotalCharacters()}.";
        }
    }
}
