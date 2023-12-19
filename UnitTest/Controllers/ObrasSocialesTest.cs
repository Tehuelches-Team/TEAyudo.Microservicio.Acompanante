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
using TEAyudo.Controllers;
using TEAyudo_Acompanantes;
using TEAyudo_Acompanantes.Controllers;

namespace UnitTest.Controllers
{
    public class ObrasSocialesTest
    {
        
        [Fact]
        public async Task GetObrasSociales_StatusCode200()
        {
            //Arrange
            var mockAcompananteService = new Mock<IObraSocialService>();

            ObrasSocialesController ControlerAcompanante = new ObrasSocialesController(mockAcompananteService.Object);

            var listObraSociales = new List<ObraSocialResponse> 
            { 
                new ObraSocialResponse
                {
                    ObraSocialId = 1,
                    Nombre = "Manta",
                    Descripcion = "Raya"
                },

                new ObraSocialResponse
                {
                    ObraSocialId = 2,
                    Nombre = "Cielo",
                    Descripcion = "Rayo"
                },
            };

            mockAcompananteService.Setup(q => q.GetObraSociales()).ReturnsAsync(listObraSociales);

            //Act
            var result= await ControlerAcompanante.GetObrasSociales() as OkObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task GetObrasSociales_StatusCode404()
        {
            //Arrange
            var mockAcompananteService = new Mock<IObraSocialService>();

            ObrasSocialesController ControlerAcompanante = new ObrasSocialesController(mockAcompananteService.Object);

            mockAcompananteService.Setup(q => q.GetObraSociales());

            //Act
            var result = await ControlerAcompanante.GetObrasSociales() as NotFoundObjectResult;

            //Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task GetObraSocial_StatusCode200()
        {
            //Arrange
            var mockAcompananteService = new Mock<IObraSocialService>();

            ObrasSocialesController ControlerAcompanante = new ObrasSocialesController(mockAcompananteService.Object);

            var ObraSocial = new ObraSocialResponse
            {
                ObraSocialId = 1,
                Nombre = "Manta",
                Descripcion = "Raya"
            };

            mockAcompananteService.Setup(q => q.GetObraSocialById(It.IsAny<int>())).ReturnsAsync(ObraSocial);

            //Act
            var result = await ControlerAcompanante.GetObraSocial(1) as OkObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task GetObraSocial_StatusCode404()
        {
            //Arrange
            var mockAcompananteService = new Mock<IObraSocialService>();

            ObrasSocialesController ControlerAcompanante = new ObrasSocialesController(mockAcompananteService.Object);

            mockAcompananteService.Setup(q => q.GetObraSocialById(It.IsAny<int>()));

            //Act
            var result = await ControlerAcompanante.GetObraSocial(1) as NotFoundObjectResult;

            //Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task PutObraSocial_StatusCode200()
        {
            //Arrange
            var mockAcompananteService = new Mock<IObraSocialService>();

            ObrasSocialesController ControlerAcompanante = new ObrasSocialesController(mockAcompananteService.Object);

            var ObraSocialDTO = new ObraSocialDTO
            {
                Nombre = "Manta",
                Descripcion = "Raya"
            };

            var ObraSocialResponse = new ObraSocialResponse
            {
                ObraSocialId = 1,
                Nombre = "Manta",
                Descripcion = "Raya"
            };

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(true);

            mockAcompananteService.Setup(q => q.UpdateObraSocial(It.IsAny<int>(), It.IsAny<ObraSocialDTO>())).ReturnsAsync(ObraSocialResponse);

            //Act
            var result = await ControlerAcompanante.PutObraSocial(1, ObraSocialDTO) as OkObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task PutObraSocial_StatusCode404()
        {
            //Arrange
            var mockAcompananteService = new Mock<IObraSocialService>();

            ObrasSocialesController ControlerAcompanante = new ObrasSocialesController(mockAcompananteService.Object);

            var ObraSocialDTO = new ObraSocialDTO
            {
                Nombre = "Manta",
                Descripcion = "Raya"
            };

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(false);

            //Act
            var result = await ControlerAcompanante.PutObraSocial(1, ObraSocialDTO) as NotFoundObjectResult;

            //Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task PutObraSocial_StatusCode409()
        {
            //Arrange
            var mockAcompananteService = new Mock<IObraSocialService>();

            ObrasSocialesController ControlerAcompanante = new ObrasSocialesController(mockAcompananteService.Object);

            var ObraSocialDTO = new ObraSocialDTO
            {
                Nombre = "Manta",
                Descripcion = "Raya"
            };

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(true);

            mockAcompananteService.Setup(q => q.UpdateObraSocial(It.IsAny<int>(), It.IsAny<ObraSocialDTO>()));

            //Act
            var result = await ControlerAcompanante.PutObraSocial(1, ObraSocialDTO) as ConflictObjectResult;

            //Assert
            Assert.Equal(409, result.StatusCode);
        }

        [Fact]
        public async Task PostObraSocial_StatusCode200()
        {
            //Arrange
            var mockAcompananteService = new Mock<IObraSocialService>();

            ObrasSocialesController ControlerAcompanante = new ObrasSocialesController(mockAcompananteService.Object);

            var ObraSocialDTO = new ObraSocialDTO
            {
                Nombre = "Manta",
                Descripcion = "Raya"
            };

            var ObraSocialResponse = new ObraSocialResponse
            {
                ObraSocialId = 1,
                Nombre = "Manta",
                Descripcion = "Raya"
            };

            mockAcompananteService.Setup(q => q.CreateObraSocial(It.IsAny<ObraSocialDTO>())).ReturnsAsync(ObraSocialResponse);

            //Act
            var result = await ControlerAcompanante.PostObraSocial(ObraSocialDTO) as OkObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task PostObraSocial_StatusCode409()
        {
            //Arrange
            var mockAcompananteService = new Mock<IObraSocialService>();

            ObrasSocialesController ControlerAcompanante = new ObrasSocialesController(mockAcompananteService.Object);

            var ObraSocialDTO = new ObraSocialDTO
            {
                Nombre = "Manta",
                Descripcion = "Raya"
            };

            mockAcompananteService.Setup(q => q.CreateObraSocial(It.IsAny<ObraSocialDTO>()));

            //Act
            var result = await ControlerAcompanante.PostObraSocial(ObraSocialDTO) as ConflictObjectResult;

            //Assert
            Assert.Equal(409, result.StatusCode);
        }

        [Fact]
        public async Task DeleteObraSocial_StatusCode200()
        {
            //Arrange
            var mockAcompananteService = new Mock<IObraSocialService>();

            ObrasSocialesController ControlerAcompanante = new ObrasSocialesController(mockAcompananteService.Object);

            var ObraSocialDTO = new ObraSocialDTO
            {
                Nombre = "Manta",
                Descripcion = "Raya"
            };

            var ObraSocialResponse = new ObraSocialResponse
            {
                ObraSocialId = 1,
                Nombre = "Manta",
                Descripcion = "Raya"
            };

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(true);

            mockAcompananteService.Setup(q => q.DeleteObraSocial(It.IsAny<int>())).ReturnsAsync(ObraSocialResponse);

            //Act
            var result = await ControlerAcompanante.DeleteObraSocial(1) as OkObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task DeleteObraSocial_StatusCode404()
        {
            //Arrange
            var mockAcompananteService = new Mock<IObraSocialService>();

            ObrasSocialesController ControlerAcompanante = new ObrasSocialesController(mockAcompananteService.Object);

            var ObraSocialDTO = new ObraSocialDTO
            {
                Nombre = "Manta",
                Descripcion = "Raya"
            };

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(false);

            //Act
            var result = await ControlerAcompanante.DeleteObraSocial(1) as NotFoundObjectResult;

            //Assert
            Assert.Equal(404, result.StatusCode);
        }
    }
}
