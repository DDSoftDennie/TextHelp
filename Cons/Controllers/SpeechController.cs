using CSAuth.Services;
using CSSpeech.Services;
using System.Threading.Tasks;

namespace Cons.Controllers
{
    public class SpeechController
    {
        private SpeechAuthService _speechAuthService;
       private ISpeechService? _speechService;
 
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

        public string AuthenticateREST((string, string, string)credentials)
        {
            _speechAuthService.MakeCredentials(credentials.Item1, credentials.Item2, credentials.Item3);
            _speechService = new RESTSpeechService(_speechAuthService.GetCredentials());
          
            return "REST Authenticated!";
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


        public async Task SetAcessToken(string uri, string key)
        {
           
             await _speechService?.SetAutorizationTokenAsync(uri, key);
            
        }

        public async Task<string> ReadAloud(string text)
        {
            string characters = "";
            if(_speechService!= null)
            {
                var result = await _speechService.ReadAloud(text);
                characters = result.ToString();
            }
            return $"Speech for '{text}' performed. {characters} characters were computed.";

        }

        public async Task WriteToFile(string text, string file)
        {
            if(_speechService!= null)
            {
                await _speechService.WriteToFile(text, file);
            }
          
        }

        public string GetTotalCharacters()
        {
            return $"The total of charactes is: {_speechService.GetTotalCharacters()}.";
        }
    }
}
