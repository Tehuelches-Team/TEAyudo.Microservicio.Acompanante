using Application.Interfaces.Infraestructure.Command;
using Application.UseCase.DTOS;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using TEAyudo_Acompanantes;

namespace Infraestructure.Command
{
    public class AcompananteCommand : IAcompananteCommand
    {
        private readonly TEAyudoContext _Context;
        public AcompananteCommand(TEAyudoContext Context)
        {
            _Context = Context;
        }

        async Task IAcompananteCommand.UpdateAcompanante(int Id, UsuarioAcompananteDTO UsuarioAcompananteDTO)
        {
            Acompanante Acompanante = await _Context.Acompanantes.FirstOrDefaultAsync(s => s.AcompananteId == Id);

            Acompanante.ZonaLaboral = UsuarioAcompananteDTO.ZonaLaboral;
            Acompanante.Contacto = UsuarioAcompananteDTO.Contacto;
            Acompanante.Documentacion = UsuarioAcompananteDTO.Documentacion;
            Acompanante.Experiencia = UsuarioAcompananteDTO.Experiencia;
            _Context.SaveChanges(); 
        }

        async Task<int> IAcompananteCommand.CreateAcompanante(Acompanante AcompananteRecibido)
        {
            _Context.Add(AcompananteRecibido);
            await _Context.SaveChangesAsync();
            return AcompananteRecibido.AcompananteId;
        }

        async Task IAcompananteCommand.DeleteAcompanante(Acompanante AcompananteRecibido)
        {
            _Context.Remove(AcompananteRecibido);
            await _Context.SaveChangesAsync();
        }

        async Task<AcompananteObraSocial?> IAcompananteCommand.CreateAcompanteObraSocial(AcompananteObraSocial Relacion)
        {
            if (await _Context.ObrasSociales.FirstOrDefaultAsync(s => s.ObraSocialId == Relacion.ObrasocialId) != null)
            {
                _Context.Add(Relacion);
                await _Context.SaveChangesAsync();
                return await _Context.AcompanantesObraSocial.Include(s => s.ObraSocial).Include(s => s.Acompanante).FirstOrDefaultAsync(s => s.AcompananteId == Relacion.AcompananteId);
            }
            return null;
        }

        async Task<AcompananteEspecialidad?> IAcompananteCommand.CreateAcompanteEspecialidad(AcompananteEspecialidad Relacion)
        {
            if (await _Context.Especialidades.FirstOrDefaultAsync(s => s.EspecialidadId == Relacion.EspecialidadId) != null)
            {
                _Context.Add(Relacion);
                await _Context.SaveChangesAsync();
                return await _Context.AcompanantesEspecialidades.Include(s => s.Especialidad).Include(s => s.Acompanante).FirstOrDefaultAsync(s => s.AcompananteId == Relacion.AcompananteId);
            }
            return null;
        }

        async Task<Acompanante?> IAcompananteCommand.CreateAcompanteDisponibilidad(AcompananteDisponibilidadDTO Relacion)
        {
            DisponibilidadSemanal Disponibilidad = await _Context.DisponibilidadesSemanales.FirstAsync(s => s.DisponibilidadSemanalId == Relacion.DisponibilidadSemanalId);
            if (Disponibilidad != null)
            {
                _Context.Add(Relacion);
                await _Context.SaveChangesAsync();
                return await _Context.Acompanantes.Include(s => s.DisponibilidadesSemanales).FirstOrDefaultAsync(s => s.AcompananteId == Relacion.AcompananteId);
            }
            return null;
        }
    }
}
