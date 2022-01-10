using CSAuth.Model;
using System.Threading.Tasks;
using CSSpeech.Model;
using Microsoft.CognitiveServices.Speech;

namespace CSSpeech.Services
{
   public interface ISpeechService
    {

        public SpeechConfig Authenticate(Auth authentication);

        public Task<int> ReadAloud(string text);

        public int GetTotalCharacters();
        public string GetAutorizationToken();

        public Speech GetSpeech();

        public void SetStartCharacters(int startCharacters);

        public void SetLanguage(string language);
    }
}
