using Application.Interfaces.Infraestructure.Command;
using Application.Model.Response;
using RestSharp;
using System.Text.Json;
using TEAyudo_Acompanantes;

namespace Infraestructure.Command
{
    public class PropuestaCommand : IPropuestaCommand
    {
        private readonly TEAyudoContext Context;
        public PropuestaCommand(TEAyudoContext Context)
        {
            this.Context = Context;
        }
        public async Task<PropuestaResponse> PutPropuesta(int Id, int Estado)
        {
            var Client = new RestClient("https://localhost:7231");
            var Request = new RestRequest("/api/Propuesta/" + Id + "/" + Estado);
            //Request.AddJsonBody(Estado.ToString()); //Ver porque deja String y no int. 
            RestResponse Result = await Client.ExecutePutAsync<PropuestaResponse>(Request);
            PropuestaResponse Response = JsonSerializer.Deserialize<PropuestaResponse>(Result.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return Response;
        }
    }
}
