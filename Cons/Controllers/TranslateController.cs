using CSTranslator.Model;
using CSTranslator.Services;
using CSAuth.Model;
using CSAuth.Services;
using System.Threading.Tasks;

namespace Cons.Controllers
{
    public  class TranslateController
    {
        private TranslateAuthService _translateAuthService = new TranslateAuthService();
        private TranslatorService _translatorService = new TranslatorService();
        private Auth _auth = new Auth();
        private Translator _translator = new Translator();

        public string Authenticate((string, string, string)credentials)
        {
            _translateAuthService.MakeCredentials(credentials.Item1, credentials.Item2, credentials.Item3);
            _auth = _translateAuthService.GetCredentials();
            _translatorService.Authenticate(_auth);

            return "Authenticated!";
        }

        public async Task<string> Translate(string text)
        {
            string translation = "";

            translation =  await _translatorService.Translate(text);
            return translation;
           
        }

    }
}
