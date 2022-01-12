using CSAuth.Model;
using System.Threading.Tasks;
using CSSpeech.Model;
using Microsoft.CognitiveServices.Speech;

namespace CSSpeech.Services
{
   public interface ISpeechService
    {

        public void Authenticate(Auth authentication, bool rest=true);

        public SpeechConfig Authenticate(Auth Autentication);


        public Task<int> ReadAloud(string text);

        public int GetTotalCharacters();
        public string GetAutorizationToken();

        public Task<string> GetAutorizationTokenAsync(string fetchUri, string subscriptionKey);


        public Speech GetSpeech();

        public void SetStartCharacters(int startCharacters);

        public void SetLanguage(string language);
    }
}
