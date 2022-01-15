using CSAuth.Model;
using CSSpeech.Model;
using Microsoft.CognitiveServices.Speech;
using System;

using System.Threading.Tasks;

using System.Net.Http;

using System.IO;

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

   

        public async Task SetAutorizationTokenAsync(string fetchUri, string subscriptionKey)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
            var response = await client.PostAsync("https://northeurope.api.cognitive.microsoft.com/sts/v1.0/issueToken", null);
             _speech.AccessToken = await response.Content.ReadAsStringAsync();
          
        }


       
        public async Task WriteToFile(string text, string name)
        {
            string path = @"C:\DDSoft\AI Demos\TextHelp\TextHelp\Output\" + name + ".mp3";
           
            var readStream = await GetTTS(_speech.AccessToken, text);

            FileStream writeStream = File.Create(path);
            int Length = 256;
            Byte[] buffer = new Byte[Length];

            int bytestoRead = readStream.Read(buffer, 0, Length);
            while (bytestoRead > 0)
            {
                writeStream.Write(buffer, 0, bytestoRead);
                bytestoRead = readStream.Read(buffer, 0, Length);
            }

            readStream.Close();
            writeStream.Close();

        }

       
        private async Task<Stream> GetTTS(string accessToken, string text)
        {

            string body = "<speak version='1.0' xml:lang='en-US'><voice xml:lang='" + _speech.Language + "' xml:gender='Male' name = 'en-US-ChristopherNeural'>" + text + " </voice></speak>";

            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(body);
           
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/ssml+xml");
            client.DefaultRequestHeaders.Add("X-Microsoft-OutputFormat", "riff-16khz-16bit-mono-pcm");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Add("User-Agent", "TextHelp");
            HttpResponseMessage response = await client.PostAsync(_endpoint, content);

            return  await response.Content.ReadAsStreamAsync();

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

        public void SetSpeech(Speech speech)
        {
            this._speech = speech;
        }

        public int GetTotalCharacters() => _speech?.TotalChar != null ? _speech.TotalChar : 0;



        #region NotUsed


        public SpeechConfig Authenticate(Auth authentication)
        {
            throw new NotImplementedException();

        }

        public string GetAutorizationToken()
        {
            throw new NotImplementedException();
        }

        public Task<int> ReadAloud(string text)
        {
            throw new NotImplementedException();
        }

        public async Task<string> ReadAloud(string text, string accessToken)
        {

            throw new NotImplementedException();

            //if (result == null || result.ToString() == null)
            //{
            //    return "";
            //} else

            //return result.ToString();

        }
        #endregion

    }
}
