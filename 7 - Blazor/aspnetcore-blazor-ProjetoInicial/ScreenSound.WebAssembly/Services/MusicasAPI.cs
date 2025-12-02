using ScreenSound.Shared.Modelos.Requests;
using ScreenSound.Shared.Modelos.Response;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ScreenSound.WebAssembly.Services
{
    public class MusicasAPI
    {
        // Classe responsável por fazer a comunicação com a API para obter dados relacionados as músicas

        private readonly HttpClient _httpClient;

        public MusicasAPI(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }

        public async Task<ICollection<MusicaResponse>> GetMusicaAsync()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<MusicaResponse>>("musicas");
        }
    }
}
