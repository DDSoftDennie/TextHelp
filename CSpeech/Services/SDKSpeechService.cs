using System.Threading.Tasks;
using CSAuth.Model;
using CSSpeech.Model;
using Microsoft.CognitiveServices.Speech;


namespace CSSpeech.Services
{
    public class SDKSpeechService : ISpeechService
    {

        private SpeechConfig? _config;
        private Speech _speech;

        public SDKSpeechService()
        {
            _speech = new Speech();
        }

        public SDKSpeechService(Auth authentication)
        {
            _speech = new Speech();
            _config = Authenticate(authentication);
        }
       
        public SpeechConfig? Authenticate(Auth authentication)
        {
            SpeechConfig config;
            if(authentication == null)
            {
                return null;
            }
            config = SpeechConfig.FromSubscription(authentication.Key, authentication.Region);    
            var synth = new SpeechSynthesizer(config);
            Configure();
            return config;
           
        }

        private string Configure()
        {
            string result;
            if (_speech.Language != "")
            {
                if (_config != null)
                {
                    _config.SpeechSynthesisLanguage = _speech?.Language;
                    result = "Speech configured!";
                }
                else
                {
                    result = "Something went wrong... Please make sure you are authenticated";
                }
            }
            else
            {
                result = "Please fill in the Speech Service Language!";
            }
            return result;
        }

        public void SetStartCharacters(int startCharacters)
        {
            if (_speech != null)
            {
                _speech.TotalChar = startCharacters;
            }
        }

        public void SetLanguage(string language)
        {
            _speech.Language = language;
        }

        public async Task<int> ReadAloud(string text)
        {
            int length = text.Length;
            using (SpeechSynthesizer synth = new SpeechSynthesizer(_config))
            {
                await synth.SpeakTextAsync(text);
            }
            _speech.TotalChar += length;
            return length;
        }

        public int GetTotalCharacters() => _speech?.TotalChar != null ? _speech.TotalChar : 0;

        public string GetAutorizationToken() => _config?.GetHashCode().ToString() != null ? _config.GetHashCode().ToString() : "";

        public Speech GetSpeech()=> _speech;

        public void Authenticate(Auth authentication, bool rest = true)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetAutorizationTokenAsync(string s1, string s2)
        {
            throw new System.NotImplementedException();
        }
    }


}