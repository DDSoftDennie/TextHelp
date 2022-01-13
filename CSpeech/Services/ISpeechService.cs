using CSAuth.Model;
using System.Threading.Tasks;
using CSSpeech.Model;
using Microsoft.CognitiveServices.Speech;
using System.IO;

namespace CSSpeech.Services
{
   public interface ISpeechService
    {
        
        public void Authenticate(Auth authentication, bool rest=true);

        public SpeechConfig Authenticate(Auth Autentication);

        public Task<int> ReadAloud(string text);

        public Task<string> ReadAloud(string text, string accessToken);

        public Task WriteToFile(string text, string name);

        public int GetTotalCharacters();
        public string GetAutorizationToken();

        public Task SetAutorizationTokenAsync(string fetchUri, string subscriptionKey);

        public Speech GetSpeech();

        public void SetSpeech(Speech speech);

    //    private Task<Stream> GetTTS(string accessToken, string text);



        public void SetStartCharacters(int startCharacters);

        public void SetLanguage(string language);
    }
}
