using Application.Interfaces.Application;
using Application.UseCase.DTO;
using Application.UseCase.DTOS;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAyudo_Acompanantes.Controllers;

namespace UnitTest.Controllers
{
    public class EspecialidadesTest
    {

        [Fact]
        public async Task GetEspecialidades_StatusCode200()
        {
            //Arrange
            var mockAcompananteService = new Mock<IEspecialidadService>();

            EspecialidadesController ControlerEspecialidades = new EspecialidadesController(mockAcompananteService.Object);

            var listEspecialidades = new List<EspecialidadResponse>
            {
                new EspecialidadResponse
                {
                    EspecialidadId = 1,
                    Descripcion = "Escolar"
                },
                new EspecialidadResponse
                {
                    EspecialidadId = 2,
                    Descripcion = "Domiciliario"
                },
            };

            mockAcompananteService.Setup(q => q.GetEspecialidades()).ReturnsAsync(listEspecialidades);

            //Act
            var result = await ControlerEspecialidades.GetEspecialidades() as OkObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task GetEspecialidades_StatusCode404()
        {
            //Arrange
            var mockAcompananteService = new Mock<IEspecialidadService>();

            EspecialidadesController ControlerEspecialidades = new EspecialidadesController(mockAcompananteService.Object);

            var listEspecialidades = new List<EspecialidadResponse>();

            mockAcompananteService.Setup(q => q.GetEspecialidades()).ReturnsAsync(listEspecialidades);

            //Act
            var result = await ControlerEspecialidades.GetEspecialidades() as NotFoundObjectResult;

            //Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task GetEspecialidad_StatusCode200()
        {
            //Arrange
            var mockAcompananteService = new Mock<IEspecialidadService>();

            EspecialidadesController ControlerEspecialidades = new EspecialidadesController(mockAcompananteService.Object);

            var especialidad = new EspecialidadResponse
            {
                EspecialidadId = 1,
                Descripcion = "Escolar"
            };

            mockAcompananteService.Setup(q => q.GetEspecialidadById(It.IsAny<int>())).ReturnsAsync(especialidad);

            //Act
            var result = await ControlerEspecialidades.GetEspecialidad(1) as OkObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task GetEspecialidad_StatusCode404()
        {
            //Arrange
            var mockAcompananteService = new Mock<IEspecialidadService>();

            EspecialidadesController ControlerEspecialidades = new EspecialidadesController(mockAcompananteService.Object);

            mockAcompananteService.Setup(q => q.GetEspecialidadById(It.IsAny<int>()));

            //Act
            var result = await ControlerEspecialidades.GetEspecialidad(1) as NotFoundObjectResult;

            //Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task PutEspecialidad_StatusCode200()
        {
            //Arrange
            var mockAcompananteService = new Mock<IEspecialidadService>();

            EspecialidadesController ControlerEspecialidades = new EspecialidadesController(mockAcompananteService.Object);

            var especialidadResponse = new EspecialidadResponse
            {
                EspecialidadId = 1,
                Descripcion = "Escolar"
            };

            var especialidadDTO = new EspecialidadDTO
            {
                Descripcion = "Domiciliario"
            };

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(true);

            mockAcompananteService.Setup(q => q.UpdateEspecialidad(It.IsAny<int>(), It.IsAny<EspecialidadDTO>())).ReturnsAsync(especialidadResponse);

            //Act
            var result = await ControlerEspecialidades.PutEspecialidad(1, especialidadDTO) as OkObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task PutEspecialidad_StatusCode404()
        {
            //Arrange
            var mockAcompananteService = new Mock<IEspecialidadService>();

            EspecialidadesController ControlerEspecialidades = new EspecialidadesController(mockAcompananteService.Object);

            var especialidadDTO = new EspecialidadDTO
            {
                Descripcion = "Domiciliario"
            };

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(false);
            //Act
            var result = await ControlerEspecialidades.PutEspecialidad(1, especialidadDTO) as NotFoundObjectResult;

            //Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task PutEspecialidad_StatusCode409()
        {
            //Arrange
            var mockAcompananteService = new Mock<IEspecialidadService>();

            EspecialidadesController ControlerEspecialidades = new EspecialidadesController(mockAcompananteService.Object);

            var especialidadResponse = new EspecialidadResponse
            {
                EspecialidadId = 1,
                Descripcion = "Escolar"
            };

            var especialidadDTO = new EspecialidadDTO
            {
                Descripcion = "Domiciliario"
            };

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(true);

            mockAcompananteService.Setup(q => q.UpdateEspecialidad(It.IsAny<int>(), It.IsAny<EspecialidadDTO>()));

            //Act
            var result = await ControlerEspecialidades.PutEspecialidad(1, especialidadDTO) as ConflictObjectResult;

            //Assert
            Assert.Equal(409, result.StatusCode);
        }

        [Fact]
        public async Task PostEspecialidad_StatusCode200()
        {
            //Arrange
            var mockAcompananteService = new Mock<IEspecialidadService>();

            EspecialidadesController ControlerEspecialidades = new EspecialidadesController(mockAcompananteService.Object);

            var especialidadResponse = new EspecialidadResponse
            {
                EspecialidadId = 1,
                Descripcion = "Escolar"
            };

            var especialidadDTO = new EspecialidadDTO
            {
                Descripcion = "Domiciliario"
            };

            mockAcompananteService.Setup(q => q.CreateEspecialidad(It.IsAny<EspecialidadDTO>())).ReturnsAsync(especialidadResponse);

            //Act
            var result = await ControlerEspecialidades.PostEspecialidad(especialidadDTO) as OkObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task PostEspecialidad_StatusCode404()
        {
            //Arrange
            var mockAcompananteService = new Mock<IEspecialidadService>();

            EspecialidadesController ControlerEspecialidades = new EspecialidadesController(mockAcompananteService.Object);

            var especialidadDTO = new EspecialidadDTO
            {
                Descripcion = "Domiciliario"
            };

            mockAcompananteService.Setup(q => q.CreateEspecialidad(It.IsAny<EspecialidadDTO>()));

            //Act
            var result = await ControlerEspecialidades.PostEspecialidad(especialidadDTO) as NotFoundObjectResult;

            //Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task DeleteEspecialidad_StatusCode200()
        {
            //Arrange
            var mockAcompananteService = new Mock<IEspecialidadService>();

            EspecialidadesController ControlerEspecialidades = new EspecialidadesController(mockAcompananteService.Object);

            var listEspecialidades = new EspecialidadResponse
            {
                EspecialidadId = 1,
                Descripcion = "Escolar"
            };

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(true);

            mockAcompananteService.Setup(q => q.DeleteEspecialidad(It.IsAny<int>())).ReturnsAsync(listEspecialidades);

            //Act
            var result = await ControlerEspecialidades.DeleteEspecialidad(1) as OkObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task DeleteEspecialidad_StatusCode404()
        {
            //Arrange
            var mockAcompananteService = new Mock<IEspecialidadService>();

            EspecialidadesController ControlerEspecialidades = new EspecialidadesController(mockAcompananteService.Object);

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(false);

            //Act
            var result = await ControlerEspecialidades.DeleteEspecialidad(1) as NotFoundObjectResult;

            //Assert
            Assert.Equal(404, result.StatusCode);
        }

    }
}
