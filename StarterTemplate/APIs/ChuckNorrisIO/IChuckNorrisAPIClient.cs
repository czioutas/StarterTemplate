using System.Threading.Tasks;

namespace StarterTemplate.APIs.ChuckNorrisIO
{
    public interface IChuckNorrisAPIClient
    {
        Task<JokeResponseModel> GetJokeAsync();
    }
}
