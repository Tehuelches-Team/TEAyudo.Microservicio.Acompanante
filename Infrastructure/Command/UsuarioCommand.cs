using Application.Exceptions;
using Application.Interfaces.Infraestructure.Command;
using Application.UseCase.DTOS;
using Application.UseCase.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infraestructure.Command
{
    public class UsuarioCommand : IUsuarioCommand
    {
        async Task<UsuarioResponse?> IUsuarioCommand.DeleteUsuario(int Id)
        {
            var Client = new RestClient("https://localhost:7174");
            var Request = new RestRequest("/api/Usuario/" + Id, Method.Delete);
            var Result = await Client.ExecuteAsync(Request);
            UsuarioResponse Response = JsonSerializer.Deserialize<UsuarioResponse>(Result.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return Response;
        }

        async Task<UsuarioResponse?> IUsuarioCommand.PutUsuario(int Id, UsuarioAcompananteDTO UsuarioAcompananteDTO)
        {
            var Client = new RestClient("https://localhost:7174");
            var Request = new RestRequest("/api/Usuario/" + Id);
            Request.AddJsonBody(new UsuarioDTO
            {
                Nombre=UsuarioAcompananteDTO.Nombre,
                Apellido=UsuarioAcompananteDTO.Apellido,
                CorreoElectronico = UsuarioAcompananteDTO.CorreoElectronico,
                Contrasena = UsuarioAcompananteDTO.Contrasena,
                FotoPerfil = UsuarioAcompananteDTO.FotoPerfil,
                Domicilio =UsuarioAcompananteDTO.Domicilio,
                FechaNacimiento= UsuarioAcompananteDTO.FechaNacimiento,
            });
            RestResponse Result = await Client.ExecutePutAsync(Request);
            if (Result.StatusCode == HttpStatusCode.Conflict)
            {
                throw new ConflictoException("El correo electronico ya se encuentra asociado a otra cuenta");
            }
            if (Result.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new FormatException("Ha ingresado un formato de fecha erronea");
            }
            UsuarioResponse Response = JsonSerializer.Deserialize<UsuarioResponse>(Result.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return Response;
        }
    }
}
