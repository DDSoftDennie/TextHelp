using CSAuth;
using CSAuth.Model;
using CSSpeech;
using CSSpeech.Model;

namespace Cons.Controllers
{
    public class SpeechController
    {
        private SpeechAuthService _speechAuthService = new SpeechAuthService();
        private SpeechService _speechService = new SpeechService();
        private Auth _auth = new Auth();
        private Speech _speech = new Speech();
        public string Authenticate((string, string)credentials)
        {
            _speechAuthService.MakeCredentials(credentials.Item1, credentials.Item2);
            _auth = _speechAuthService.GetCredentials();
            _speechService.Authenticate(_auth);
            string token = _speechService.GetAuthorizationToken().ToString();

            return token; 
        }

        public string SetLanguage(string lang)
        {
            _speech = new Speech
            {
                Language = lang
            };
            _speechService.Configure(_speech);

            string result = "Language set!";
            return result;
        }

        public async Task< string> ReadAloud(string text)
        {
            await _speechService.ReadAloud(text);
            return "Speech for '{text}' performed";
        }
    }
}
