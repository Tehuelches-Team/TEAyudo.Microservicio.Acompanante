using Application.Interfaces.Infraestructure.Query;
using Application.UseCase.Responses;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace Infraestructure.Querys
{
    public class UsuarioQuery : IUsuarioQuery
    {
        async Task<List<UsuarioResponse>>? IUsuarioQuery.GetAllUsuarios()
        {
            var Client = new RestClient("https://localhost:7174");
            var Resquest = new RestRequest("/api/Usuario");
            RestResponse Response = await Client.ExecuteGetAsync(Resquest);
            //return await Client.GetJsonAsync<List<UsuarioResponse>>("/api/Usuario");
            if (Response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            return JsonSerializer.Deserialize<List<UsuarioResponse>>(Response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        async Task<UsuarioResponse?> IUsuarioQuery.GetUsuarioById(int Id)
        {
            var Client = new RestClient("https://localhost:7174");
            return await Client.GetJsonAsync<UsuarioResponse>("/api/Usuario/" + Id);
        }
    }
}
