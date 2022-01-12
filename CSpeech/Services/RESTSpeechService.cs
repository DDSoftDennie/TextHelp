using CSAuth.Model;
using CSSpeech.Model;
using Microsoft.CognitiveServices.Speech;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using CSAuth;
using System.Net.Http;
using System.Text;

namespace CSSpeech.Services
{
    public class RESTSpeechService : ISpeechService
    {
        private string _key ="", _region="", _endpoint="", _lang="";
        private string _requestBody="";
        public static readonly string FetchTokenUri = "https://northeurope.api.cognitive.microsoft.com/sts/v1.0/issueToken";



        private Speech _speech;

        public RESTSpeechService()
        {
            _speech = new Speech();
        }

        public RESTSpeechService(Auth authentication)
        {
            _speech = new Speech();
            Authenticate(authentication,true);
        }
        public SpeechConfig Authenticate(Auth authentication)
        {
            throw new NotImplementedException();
           
        }

        public void Authenticate(Auth authentication, bool rest = true)
        {
            if (authentication == null
                || authentication.Key == null
                || authentication.Region == null
                || authentication.EndPoint == null)
            {
                return;
            }

            _key = authentication.Key;
            _region = authentication.Region;
            _endpoint = authentication.EndPoint;

        }

        public string GetAutorizationToken()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAutorizationTokenAsync(string fetchUri, string subscriptionKey)
        {
            throw new NotImplementedException();
            //fetchuri = https://northeurope.tts.speech.microsoft.com/cognitiveservices/v1
            //using (var client = new HttpClient())
            //{
            //    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
            //    UriBuilder uriBuilder = new UriBuilder(fetchUri);

            //    var result = await client.PostAsync(uriBuilder.Uri.AbsoluteUri, null);
            //   // Console.WriteLine("Token Uri: {0}", uriBuilder.Uri.AbsoluteUri);
            //    return await result.Content.ReadAsStringAsync();
            //}
        }
        public async Task<int> ReadAloud(string text)
        {
            string body = "<speak version='1.0' xml:lang='en-US'><voice xml:lang='" + _speech.Language +"' xml:gender='Male' name = 'en-US-ChristopherNeural'>" + text + " </voice></speak>";
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(_endpoint);
                request.Content = new StringContent(body, Encoding.UTF8, "application/ssml+xml");
                request.Headers.Add("Ocp-Apim-Subscription-Key", _key);
                request.Headers.Add("Host", _region+ ".tts.speech.microsoft.com");
                request.Headers.Add("X-Microsoft-OutputFormat", "webm-16khz-16bit-mono-opus");
               // request.Headers.Add("Content-Type", "application/ssml+xml");
               // request.Headers.Add("Content-Length", text.Length.ToString());
                request.Headers.Add("User-Agent", "TextHelp");

                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);

                var responseBody = await response.Content.ReadAsStringAsync();

                int length = text.Length;
                _speech.TotalChar += length;
                return length;
            }
        }

   
        public void SetLanguage(string language)
        {
            _lang = language;
        }

        public void SetStartCharacters(int startCharacters)
        {
            if (_speech != null)
            {
                _speech.TotalChar = startCharacters;
            }
        }

        public Speech GetSpeech() => _speech;

        public int GetTotalCharacters() => _speech?.TotalChar != null ? _speech.TotalChar : 0;

     
    }
}
