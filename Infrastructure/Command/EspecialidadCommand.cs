using Application.Interfaces.Infraestructure.Command;
using Microsoft.EntityFrameworkCore;
using TEAyudo_Acompanantes;

namespace Infraestructure.Command
{
    public class EspecialidadCommand : IEspecialidadCommand
    {
        private readonly TEAyudoContext _Context;
        public EspecialidadCommand(TEAyudoContext Context)
        {
            _Context = Context;
        }

        async Task IEspecialidadCommand.UpdateEspecialidad(Especialidad EspecialidadRecibida)
        {
            Especialidad UniqueEspecialidad = await _Context.Especialidades.FirstOrDefaultAsync(s => s.EspecialidadId == EspecialidadRecibida.EspecialidadId);

            UniqueEspecialidad.Descripcion = EspecialidadRecibida.Descripcion;
            _Context.SaveChanges();
        }

        async Task<Especialidad> IEspecialidadCommand.CreateEspecialidad(Especialidad Descripcion)
        {
            _Context.Add(Descripcion);
            await _Context.SaveChangesAsync();
            return Descripcion;
        }

        async Task IEspecialidadCommand.DeleteEspecialidad(Especialidad Especialidad)
        {
            _Context.Remove(Especialidad);
            await _Context.SaveChangesAsync();
        }

    }
}
