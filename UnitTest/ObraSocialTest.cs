using Application.Interfaces.Application;
using Application.Interfaces.Infraestructure.Command;
using Application.Interfaces.Infraestructure.Query;
using Application.UseCase.DTO;
using Application.UseCase.DTOS;
using Application.UseCase.Services;
using Moq;
using TEAyudo_Acompanantes;

namespace UnitTest
{
    public class ObraSocialTest
    {
        [Fact]
        public async Task GetATIdbyUsuarioId()
        {
            var mockObraSocialesCommand = new Mock<IObraSocialCommand>();
            var mockObraSocialesQuery = new Mock<IObraSocialQuery>();

            IObraSocialService service = new ObraSocialService(mockObraSocialesCommand.Object, mockObraSocialesQuery.Object);

            var listaObrasSociales = new List<ObraSocial>
            {
                new ObraSocial{
                    ObraSocialId=1,
                    Nombre="OSDE",
                    Descripcion="Con cada argentino siempre"
                },

                new ObraSocial{
                    ObraSocialId=2,
                    Nombre="ABC",
                    Descripcion="Alfabeto"
                },

                new ObraSocial{
                    ObraSocialId=3,
                    Nombre="Maracuya",
                    Descripcion="Mocoreta"
                },
            };

            mockObraSocialesQuery.Setup(q => q.GetObraSociales()).ReturnsAsync(listaObrasSociales);

            //act
            var result = await service.GetObraSociales();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetObraSocialById_correctamente()
        {
            var mockObraSocialesCommand = new Mock<IObraSocialCommand>();
            var mockObraSocialesQuery = new Mock<IObraSocialQuery>();

            IObraSocialService service = new ObraSocialService(mockObraSocialesCommand.Object, mockObraSocialesQuery.Object);

            var obraSocial = new ObraSocial
            {
                ObraSocialId = 1,
                Nombre = "OSDE",
                Descripcion = "Con cada argentino siempre"
            };

            mockObraSocialesQuery.Setup(q => q.GetObraSocialById(It.IsAny<int>())).ReturnsAsync(obraSocial);

            //Act
            var result = await service.GetObraSocialById(1);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetObraSocialById_ObraSocialNoEncontrada()
        {
            var mockObraSocialesCommand = new Mock<IObraSocialCommand>();
            var mockObraSocialesQuery = new Mock<IObraSocialQuery>();

            IObraSocialService service = new ObraSocialService(mockObraSocialesCommand.Object, mockObraSocialesQuery.Object);

            mockObraSocialesQuery.Setup(q => q.GetObraSocialById(It.IsAny<int>()));

            //Act
            var result = await service.GetObraSocialById(1);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task ifExist_True()
        {
            var mockObraSocialesCommand = new Mock<IObraSocialCommand>();
            var mockObraSocialesQuery = new Mock<IObraSocialQuery>();

            IObraSocialService service = new ObraSocialService(mockObraSocialesCommand.Object, mockObraSocialesQuery.Object);

            var obraSocial = new ObraSocial
            {
                ObraSocialId = 1,
                Nombre = "OSDE",
                Descripcion = "Con cada argentino siempre"
            };

            mockObraSocialesQuery.Setup(q => q.GetObraSocialById(It.IsAny<int>())).ReturnsAsync(obraSocial);

            //Act
            var result = await service.IfExist(1);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task ifExist_False()
        {
            var mockObraSocialesCommand = new Mock<IObraSocialCommand>();
            var mockObraSocialesQuery = new Mock<IObraSocialQuery>();

            IObraSocialService service = new ObraSocialService(mockObraSocialesCommand.Object, mockObraSocialesQuery.Object);

            mockObraSocialesQuery.Setup(q => q.GetObraSocialById(It.IsAny<int>()));

            //Act
            var result = await service.IfExist(2);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task UpdateObraSocial_Existosamente()
        {
            var mockObraSocialesCommand = new Mock<IObraSocialCommand>();
            var mockObraSocialesQuery = new Mock<IObraSocialQuery>();

            IObraSocialService service = new ObraSocialService(mockObraSocialesCommand.Object, mockObraSocialesQuery.Object);

            var obraSocialDTO = new ObraSocialDTO
            {
                Nombre = "OSDE",
                Descripcion = "Con cada argentino siempre"
            };

            var obraSocial = new ObraSocial
            {
                ObraSocialId = 1,
                Nombre = "OSDE",
                Descripcion = "Con cada argentino siempre"
            };

            mockObraSocialesQuery.Setup(q => q.ComprobarExistencia(It.IsAny<string>())).ReturnsAsync(obraSocial);

            mockObraSocialesCommand.Setup(q => q.UpdateObraSocial(It.IsAny<ObraSocial>()));

            //Act
            var result = await service.UpdateObraSocial(1,obraSocialDTO);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task UpdateObraSocial_Erroneamente()
        {
            var mockObraSocialesCommand = new Mock<IObraSocialCommand>();
            var mockObraSocialesQuery = new Mock<IObraSocialQuery>();

            IObraSocialService service = new ObraSocialService(mockObraSocialesCommand.Object, mockObraSocialesQuery.Object);

            var obraSocialDTO = new ObraSocialDTO
            {
                Nombre = "OSDE",
                Descripcion = "Con cada argentino siempre"
            };

            mockObraSocialesQuery.Setup(q => q.ComprobarExistencia(It.IsAny<string>()));

            //Act
            var result = await service.UpdateObraSocial(2, obraSocialDTO);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateObraSocial_Exitosamente()
        {
            var mockObraSocialesCommand = new Mock<IObraSocialCommand>();
            var mockObraSocialesQuery = new Mock<IObraSocialQuery>();

            IObraSocialService service = new ObraSocialService(mockObraSocialesCommand.Object, mockObraSocialesQuery.Object);

            var obraSocialDTO = new ObraSocialDTO
            {
                Nombre = "OSDE",
                Descripcion = "Con cada argentino siempre"
            };

            var obraSocial = new ObraSocial
            {
                ObraSocialId = 1,
                Nombre = "OSDE",
                Descripcion = "Con cada argentino siempre"
            };

            mockObraSocialesQuery.Setup(q => q.ComprobarExistencia(It.IsAny<string>()));

            mockObraSocialesCommand.Setup(q => q.CreateObraSocial(It.IsAny<ObraSocial>())).ReturnsAsync(obraSocial);

            //Act
            var result = await service.CreateObraSocial(obraSocialDTO);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CreateObraSocial_Erroneamente()
        {
            var mockObraSocialesCommand = new Mock<IObraSocialCommand>();
            var mockObraSocialesQuery = new Mock<IObraSocialQuery>();

            IObraSocialService service = new ObraSocialService(mockObraSocialesCommand.Object, mockObraSocialesQuery.Object);

            var obraSocialDTO = new ObraSocialDTO
            {
                Nombre = "OSDE",
                Descripcion = "Con cada argentino siempre"
            };

            var obraSocial = new ObraSocial
            {
                ObraSocialId = 1,
                Nombre = "OSDE",
                Descripcion = "Con cada argentino siempre"
            };

            mockObraSocialesQuery.Setup(q => q.ComprobarExistencia(It.IsAny<string>())).ReturnsAsync(obraSocial); //Si existe devuelve null

            //Act
            var result = await service.CreateObraSocial(obraSocialDTO);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task DeleteObraSocial()
        {
            var mockObraSocialesCommand = new Mock<IObraSocialCommand>();
            var mockObraSocialesQuery = new Mock<IObraSocialQuery>();

            IObraSocialService service = new ObraSocialService(mockObraSocialesCommand.Object, mockObraSocialesQuery.Object);

            var obraSocialDTO = new ObraSocialDTO
            {
                Nombre = "OSDE",
                Descripcion = "Con cada argentino siempre"
            };

            var obraSocial = new ObraSocial
            {
                ObraSocialId = 1,
                Nombre = "OSDE",
                Descripcion = "Con cada argentino siempre"
            };

            mockObraSocialesQuery.Setup(q => q.GetObraSocialById(It.IsAny<int>())).ReturnsAsync(obraSocial);

            mockObraSocialesCommand.Setup(q => q.DeleteObraSocial(It.IsAny<ObraSocial>()));

            //Act
            var result = await service.DeleteObraSocial(1);

            //Assert
            Assert.NotNull(result);
        }
    }
}
