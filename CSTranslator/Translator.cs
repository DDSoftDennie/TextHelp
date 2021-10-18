using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CSTranslator
{
    public static class Translator
    {
        //   public string Key { get; set; }
        //    public string Endpoint { get; set; }

        public static async Task<string> Translate(string Key, string EndPoint, string Text, string Location)
        {
            string route = "/translate?api-version=3.0&from=nl&to=en";

            object[] body = new object[] { new { Text = Text } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                // Build the request.
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(EndPoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", Key);
                request.Headers.Add("Ocp-Apim-Subscription-Region", Location);

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