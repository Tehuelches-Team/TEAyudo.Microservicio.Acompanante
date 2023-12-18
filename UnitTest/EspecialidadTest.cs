using Application.Interfaces.Application;
using Application.Interfaces.Infraestructure.Command;
using Application.Interfaces.Infraestructure.Query;
using Application.UseCase.DTOS;
using Application.UseCase.Services;
using Moq;
using TEAyudo_Acompanantes;

namespace UnitTest
{
    public class EspecialidadTest
    {
        [Fact]
        public async Task GetEspecialidades()
        {
            var mockEspecialidadesCommand = new Mock<IEspecialidadCommand>();
            var mockEspecialidadesQuery = new Mock<IEspecialidadQuery>();

            IEspecialidadService service = new EspecialidadService(mockEspecialidadesCommand.Object, mockEspecialidadesQuery.Object);

            var listaEspecialidades = new List<Especialidad>
            {
                new Especialidad{
                    EspecialidadId=1,
                    Descripcion="Escolar"
                },

                new Especialidad{
                    EspecialidadId=2,
                    Descripcion="Domiciliario"
                }
            };

            mockEspecialidadesQuery.Setup(q => q.GetEspecialidades()).ReturnsAsync(listaEspecialidades);

            //act
            var result = await service.GetEspecialidades();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetEspecialidadById_Exitosamente()
        {
            var mockEspecialidadesCommand = new Mock<IEspecialidadCommand>();
            var mockEspecialidadesQuery = new Mock<IEspecialidadQuery>();

            IEspecialidadService service = new EspecialidadService(mockEspecialidadesCommand.Object, mockEspecialidadesQuery.Object);


            var especialidad = new Especialidad
            {
                EspecialidadId = 1,
                Descripcion = "Escolar"
            };

            mockEspecialidadesQuery.Setup(q => q.GetEspecialidadById(It.IsAny<int>())).ReturnsAsync(especialidad);

            //act
            var result = await service.GetEspecialidadById(1);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetEspecialidadById_Erroneamente()
        {
            var mockEspecialidadesCommand = new Mock<IEspecialidadCommand>();
            var mockEspecialidadesQuery = new Mock<IEspecialidadQuery>();

            IEspecialidadService service = new EspecialidadService(mockEspecialidadesCommand.Object, mockEspecialidadesQuery.Object);

            mockEspecialidadesQuery.Setup(q => q.GetEspecialidadById(It.IsAny<int>()));

            //act
            var result = await service.GetEspecialidadById(2);

            //Assert
            Assert.Null(result);
        }


        [Fact]
        public async Task IfExist_Exitosamente()
        {
            var mockEspecialidadesCommand = new Mock<IEspecialidadCommand>();
            var mockEspecialidadesQuery = new Mock<IEspecialidadQuery>();

            IEspecialidadService service = new EspecialidadService(mockEspecialidadesCommand.Object, mockEspecialidadesQuery.Object);


            var especialidad = new Especialidad
            {
                EspecialidadId = 1,
                Descripcion = "Escolar"
            };

            mockEspecialidadesQuery.Setup(q => q.GetEspecialidadById(It.IsAny<int>())).ReturnsAsync(especialidad);

            //act
            var result = await service.IfExist(1);

            //Assert
            Assert.True(result);
        }


        [Fact]
        public async Task IfExist_Erroneamente()
        {
            var mockEspecialidadesCommand = new Mock<IEspecialidadCommand>();
            var mockEspecialidadesQuery = new Mock<IEspecialidadQuery>();

            IEspecialidadService service = new EspecialidadService(mockEspecialidadesCommand.Object, mockEspecialidadesQuery.Object);

            mockEspecialidadesQuery.Setup(q => q.GetEspecialidadById(It.IsAny<int>()));

            //act
            var result = await service.IfExist(1);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task UpdateEspecialidad_Exitosamente()
        {
            var mockEspecialidadesCommand = new Mock<IEspecialidadCommand>();
            var mockEspecialidadesQuery = new Mock<IEspecialidadQuery>();

            IEspecialidadService service = new EspecialidadService(mockEspecialidadesCommand.Object, mockEspecialidadesQuery.Object);

            var especialidadDTO = new EspecialidadDTO
            {
                Descripcion = "De prueba"
            };

            var especialidad = new Especialidad
            {
                EspecialidadId = 1,
                Descripcion = "Escolar"
            };

            mockEspecialidadesQuery.Setup(q => q.ComprobarExistencia(It.IsAny<string>())).ReturnsAsync(especialidad);

            mockEspecialidadesCommand.Setup(q => q.UpdateEspecialidad(It.IsAny<Especialidad>()));

            //act
            var result = await service.UpdateEspecialidad(1,especialidadDTO);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task UpdateEspecialidad_Erroneamente()
        {
            var mockEspecialidadesCommand = new Mock<IEspecialidadCommand>();
            var mockEspecialidadesQuery = new Mock<IEspecialidadQuery>();

            IEspecialidadService service = new EspecialidadService(mockEspecialidadesCommand.Object, mockEspecialidadesQuery.Object);

            var especialidadDTO = new EspecialidadDTO
            {
                Descripcion = "De prueba"
            };

            mockEspecialidadesQuery.Setup(q => q.ComprobarExistencia(It.IsAny<string>()));

            //act
            var result = await service.UpdateEspecialidad(1, especialidadDTO);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateEspecialidad_Exitosamente()
        {
            var mockEspecialidadesCommand = new Mock<IEspecialidadCommand>();
            var mockEspecialidadesQuery = new Mock<IEspecialidadQuery>();

            IEspecialidadService service = new EspecialidadService(mockEspecialidadesCommand.Object, mockEspecialidadesQuery.Object);

            var especialidadDTO = new EspecialidadDTO
            {
                Descripcion = "De prueba"
            };

            var especialidad = new Especialidad
            {
                EspecialidadId = 1,
                Descripcion = "Escolar"
            };

            mockEspecialidadesQuery.Setup(q => q.ComprobarExistencia(It.IsAny<string>()));

            mockEspecialidadesCommand.Setup(q => q.CreateEspecialidad(It.IsAny<Especialidad>())).ReturnsAsync(especialidad);

            //act
            var result = await service.CreateEspecialidad(especialidadDTO);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CreateEspecialidad_Erroneamente()
        {
            var mockEspecialidadesCommand = new Mock<IEspecialidadCommand>();
            var mockEspecialidadesQuery = new Mock<IEspecialidadQuery>();

            IEspecialidadService service = new EspecialidadService(mockEspecialidadesCommand.Object, mockEspecialidadesQuery.Object);

            var especialidadDTO = new EspecialidadDTO
            {
                Descripcion = "De prueba"
            };

            var especialidad = new Especialidad
            {
                EspecialidadId = 1,
                Descripcion = "Escolar"
            };

            mockEspecialidadesQuery.Setup(q => q.ComprobarExistencia(It.IsAny<string>())).ReturnsAsync(especialidad);

            //act
            var result = await service.CreateEspecialidad(especialidadDTO);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task DeleteEspecialidad_Exitosamente()
        {
            var mockEspecialidadesCommand = new Mock<IEspecialidadCommand>();
            var mockEspecialidadesQuery = new Mock<IEspecialidadQuery>();

            IEspecialidadService service = new EspecialidadService(mockEspecialidadesCommand.Object, mockEspecialidadesQuery.Object);

            var especialidadDTO = new EspecialidadDTO
            {
                Descripcion = "De prueba"
            };

            var especialidad = new Especialidad
            {
                EspecialidadId = 1,
                Descripcion = "Escolar"
            };

            mockEspecialidadesQuery.Setup(q => q.GetEspecialidadById(It.IsAny<int>())).ReturnsAsync(especialidad);

            mockEspecialidadesCommand.Setup(q => q.DeleteEspecialidad(It.IsAny<Especialidad>()));

            //act
            var result = await service.DeleteEspecialidad(1);

            //Assert
            Assert.NotNull(result);
        }
    }
}
