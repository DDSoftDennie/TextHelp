using CSAuth.Model;
using CSAuth.Services;
using CSSpeech.Model;
using CSSpeech.Services;
using System.Threading.Tasks;


namespace Cons.Controllers
{
    public class SpeechController
    {
        private SpeechAuthService _speechAuthService = new SpeechAuthService();
        private SDKSpeechService _speechService = new SDKSpeechService();
        private Auth _auth = new Auth();
        private Speech _speech = new Speech();
        public string Authenticate((string, string)credentials)
        {
            _speechAuthService.MakeCredentials(credentials.Item1, credentials.Item2);
            _auth = _speechAuthService.GetCredentials();
            _speechService.Authenticate(_auth);

            return "Authenticated!"; 
        }

        public string SetLanguage(string lang)
        {
            _speech = new Speech
            {
                Language = lang
            };
            _speechService.Configure(_speech);

         
            return "Language set!";
        }

        public string SetStartCharacters(int characters)
        {
            _speechService.SetStartCharacters(_speech, characters);
            return "Initial characters set!";
        }

        public async Task< string> ReadAloud(string text)
        {
           int length =  await _speechService.ReadAloud(text);
           return $"Speech for '{text}' performed. {length} characters were computed.";
        }

        public string GetTotalCharacters()
        {
            return $"The total of charactes is: {_speech.TotalChar}.";
        }
    }
}
