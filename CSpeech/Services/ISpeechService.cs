using CSAuth.Model;
using CSSpeech.Model;
using System.Threading.Tasks;

namespace CSSpeech.Services
{
   public interface ISpeechService
    {
        public string Authenticate(Auth authentication);

        public string Configure(Speech speech);

        public Task ReadAloud(string text);
    }
}
