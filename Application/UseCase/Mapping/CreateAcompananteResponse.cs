﻿using Application.Interfaces.Application;
using Application.UseCase.DTO;
using Application.UseCase.Responses;
using TEAyudo.DTO;
using TEAyudo_Acompanantes;

namespace Application.UseCase.CrearUsuarioAcompante
{
    public class CreateAcompananteResponse : ICreateAcompananteResponse
    {
        async Task<AcompananteResponse> ICreateAcompananteResponse.CreateAcompananteResponse(Acompanante Acompanante, UsuarioResponse Usuario)
        {
            List<ObraSocialResponse> ListaObrasSociales = new List<ObraSocialResponse>();
            List<EspecialidadResponse> ListaEspecialidades = new List<EspecialidadResponse>();
            foreach (var Single in Acompanante.Especialidades)
            {
                ListaEspecialidades.Add(new EspecialidadResponse
                {
                    EspecialidadId = Single.EspecialidadId,
                    Descripcion = Single.Especialidad.Descripcion,
                });
            }

            foreach (var Single in Acompanante.ObrasSociales)
            {
                ListaObrasSociales.Add(new ObraSocialResponse
                {
                    ObraSocialId = Single.ObraSocial.ObraSocialId,
                    Nombre = Single.ObraSocial.Nombre,
                    Descripcion = Single.ObraSocial.Descripcion,
                });
            }

            string aux = Convert.ToString(Acompanante.Disponibilidad, 2);
            while (aux.Length < 12)
            {
                aux = "0" + aux;
            }

            return (new AcompananteResponse
            {
                UsuarioId = Usuario.UsuarioId,
                Nombre = Usuario.Nombre,
                Apellido = Usuario.Apellido,
                Domicilio = Usuario.Domicilio,
                FechaNacimiento = Usuario.FechaNacimiento,
                FotoPerfil = Usuario.FotoPerfil,
                CorreoElectronico = Usuario.CorreoElectronico,
                Contrasena = Usuario.Contrasena,
                EstadoUsuarioId = Usuario.EstadoUsuarioId,
                AcompananteId = Acompanante.AcompananteId,
                ZonaLaboral = Acompanante.ZonaLaboral,
                Contacto = Acompanante.Contacto,
                Documentacion = Acompanante.Documentacion,
                Experiencia = Acompanante.Experiencia,
                Disponibilidad = aux,
                ObrasSociales = ListaObrasSociales,
                Especialidad = ListaEspecialidades,
            });

        }

        async Task<List<AcompananteResponse>> ICreateAcompananteResponse.CreateAcompanantesResponse(List<Acompanante> ListaAcompanantes, List<UsuarioResponse> ListaUsuarios)
        {
            List<AcompananteResponse> ResultadosAcompanantes = new List<AcompananteResponse>();
            foreach (var Usuario in ListaUsuarios)
            {
                foreach (var Acompanante in ListaAcompanantes)
                {
                    if (Usuario.UsuarioId == Acompanante.UsuarioId)
                    {
                        List<ObraSocialResponse> ListaObrasSociales = new List<ObraSocialResponse>();
                        List<EspecialidadResponse> ListaEspecialidades = new List<EspecialidadResponse>();
                        foreach (var Single in Acompanante.Especialidades)
                        {
                            ListaEspecialidades.Add(new EspecialidadResponse
                            {
                                EspecialidadId = Single.EspecialidadId,
                                Descripcion = Single.Especialidad.Descripcion,
                            });
                        }

                        foreach (var Single in Acompanante.ObrasSociales)
                        {
                            ListaObrasSociales.Add(new ObraSocialResponse
                            {
                                ObraSocialId = Single.ObraSocial.ObraSocialId,
                                Nombre = Single.ObraSocial.Nombre,
                                Descripcion = Single.ObraSocial.Descripcion,
                            });
                        }
                        string aux = Convert.ToString(Acompanante.Disponibilidad, 2);
                        while (aux.Length < 12)
                        {
                            aux = "0" + aux;
                        }

                        ResultadosAcompanantes.Add(new AcompananteResponse
                        {
                            UsuarioId = Usuario.UsuarioId,
                            Nombre = Usuario.Nombre,
                            Apellido = Usuario.Apellido,
                            Domicilio = Usuario.Domicilio,
                            FechaNacimiento = Usuario.FechaNacimiento,
                            FotoPerfil = Usuario.FotoPerfil,
                            CorreoElectronico = Usuario.CorreoElectronico,
                            Contrasena = Usuario.Contrasena,
                            EstadoUsuarioId = Usuario.EstadoUsuarioId,
                            AcompananteId = Acompanante.AcompananteId,
                            ZonaLaboral = Acompanante.ZonaLaboral,
                            Contacto = Acompanante.Contacto,
                            Documentacion = Acompanante.Documentacion,
                            Experiencia = Acompanante.Experiencia,
                            Disponibilidad = aux,
                            ObrasSociales = ListaObrasSociales,
                            Especialidad = ListaEspecialidades,
                        });
                    }
                }
            }
            return ResultadosAcompanantes;
        }
    }
}
