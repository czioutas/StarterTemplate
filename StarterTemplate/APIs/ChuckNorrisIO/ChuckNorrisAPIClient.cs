using Newtonsoft.Json;
using StarterTemplate.Application;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarterTemplate.APIs.ChuckNorrisIO
{
    /// <summary>
    /// This is the Basic Approach of using the IHttpclientFactory
    /// </summary>
    public class ChuckNorrisAPIClient : IChuckNorrisAPIClient
    {
        private const string APIEndPoint = "https://api.chucknorris.io/jokes/random";
        private readonly IHttpClientFactory _clientFactory;

        public ChuckNorrisAPIClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<JokeResponseModel> GetJokeAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, APIEndPoint);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new APIClientHttpFailure();
            }

            using (StreamReader sr = new StreamReader(await response.Content.ReadAsStreamAsync()))
            using (JsonTextReader jsonReader = new JsonTextReader(sr))
            {
                JsonSerializer ser = new JsonSerializer();
                return ser.Deserialize<JokeResponseModel>(jsonReader);
            }
        }
    }
}