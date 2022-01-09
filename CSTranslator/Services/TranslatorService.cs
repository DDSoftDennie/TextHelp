
using Newtonsoft.Json;
using System.Text;
using CSAuth.Model;

namespace CSTranslator.Services
{
    public class TranslatorService : ITranslatorService
    {
        private string key = "", region = "", endpoint = "";


        public string Authenticate(Auth authentication)
        {
            string result;

            if (authentication != null & authentication.Key != "" && authentication.Region !="" && authentication.EndPoint !="")
            {
              key = authentication.Key;
              region = authentication.Region;
              endpoint = authentication.EndPoint;
              result = "Authenticated!";
            }
            else
            {
                result = "Please fill in the right Credentials!";
            }
            return result;
        }

        public async Task<string> Translate(string text)
        {
            string route = "/translate?api-version=3.0&from=nl&to=en";

            object[] body = new object[] { new { Text = text } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                // Build the request.
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", key);
                request.Headers.Add("Ocp-Apim-Subscription-Region", region);

                // Send the request and get response.
                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);

                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Dictionary<string, List<Dictionary<string, string>>>>>(responseBody);
                var translation = result[0]["translations"][0]["text"];

                return translation;
            }
        }
    }
}