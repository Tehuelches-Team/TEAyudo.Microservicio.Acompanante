using Application.Exceptions;
using Application.Interfaces.Application;
using Application.Interfaces.Infraestructure.Command;
using Application.Model.Response;
using Application.UseCase.DTO;
using Application.UseCase.DTOS;
using Application.UseCase.Responses;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TEAyudo.Controllers;
using TEAyudo.DTO;

namespace UnitTest.Controllers
{
    public class AcompananteTest
    {
        [Fact]
        public async Task GetAcompananteByFiltros_StatusCode200()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            List<AcompananteResponse> listaAcompanante = new List<AcompananteResponse>
            {
                new AcompananteResponse
                {
                    AcompananteId=1,
                    UsuarioId=1,
                    Nombre="Pedro",
                    Apellido="Martinez",
                    CorreoElectronico="Pedrito@gmail.com",
                    Contrasena="Pedro123",
                    FotoPerfil="aaaaa.jpg",
                    Domicilio="Calle falsa 123",
                    FechaNacimiento= "12/09/1992",
                    EstadoUsuarioId=1,
                    ZonaLaboral="Quilmes",
                    Contacto= "1234567890",
                    Documentacion="aaaa.jpg",
                    Experiencia="3 años",
                    Disponibilidad= "111100110111",
                    Especialidad=new List<EspecialidadResponse>
                    {
                        new EspecialidadResponse
                        {
                            EspecialidadId=1,
                            Descripcion="Escolar"
                        },
                        new EspecialidadResponse
                        {
                            EspecialidadId=2,
                            Descripcion="Domiciliario"
                        },
                    },
                    ObrasSociales= new List<ObraSocialResponse>
                    {
                        new ObraSocialResponse
                        {
                            ObraSocialId=1,
                            Nombre="OSDE",
                            Descripcion="Somos la numero 1",
                        },
                        new ObraSocialResponse
                        {
                            ObraSocialId=2,
                            Nombre="PIUM",
                            Descripcion="Somos la numero 2",
                        },
                    }
                },
            };

            mockAcompananteService.Setup(q => q.Filtrar(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Int16>(), It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(listaAcompanante);

            //Act
            var result = await ControlerAcompanante.GetAcompananteByFiltros(0, 2, "000111100100010", 0, "Quilmes") as OkObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task GetAcompananteByFiltros_StatusCode404()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            List<AcompananteResponse> listaAcompanante = new List<AcompananteResponse>();

            mockAcompananteService.Setup(q => q.Filtrar(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Int16>(), It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(listaAcompanante);

            //Act
            var result = await ControlerAcompanante.GetAcompananteByFiltros(0, 2, "000111100100010", 0, "Quilmes") as NotFoundObjectResult;

            //Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task GetAcompanantes_StatusCode200()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            List<AcompananteResponse> listaAcompanante = new List<AcompananteResponse>
            {
                new AcompananteResponse
                {
                    AcompananteId=1,
                    UsuarioId=1,
                    Nombre="Pedro",
                    Apellido="Martinez",
                    CorreoElectronico="Pedrito@gmail.com",
                    Contrasena="Pedro123",
                    FotoPerfil="aaaaa.jpg",
                    Domicilio="Calle falsa 123",
                    FechaNacimiento= "12/09/1992",
                    EstadoUsuarioId=1,
                    ZonaLaboral="Quilmes",
                    Contacto= "1234567890",
                    Documentacion="aaaa.jpg",
                    Experiencia="3 años",
                    Disponibilidad= "111100110111",
                    Especialidad=new List<EspecialidadResponse>
                    {
                        new EspecialidadResponse
                        {
                            EspecialidadId=1,
                            Descripcion="Escolar"
                        },
                        new EspecialidadResponse
                        {
                            EspecialidadId=2,
                            Descripcion="Domiciliario"
                        },
                    },
                    ObrasSociales= new List<ObraSocialResponse>
                    {
                        new ObraSocialResponse
                        {
                            ObraSocialId=1,
                            Nombre="OSDE",
                            Descripcion="Somos la numero 1",
                        },
                        new ObraSocialResponse
                        {
                            ObraSocialId=2,
                            Nombre="PIUM",
                            Descripcion="Somos la numero 2",
                        },
                    }
                },
            };

            mockAcompananteService.Setup(q => q.GetAcompantes()).ReturnsAsync(listaAcompanante);

            //Act
            var result = await ControlerAcompanante.GetAcompanantes() as OkObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task GetAcompanantes_StatusCode404()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            List<AcompananteResponse?> listaAcompanante = new List<AcompananteResponse>();

            mockAcompananteService.Setup(q => q.GetAcompantes()).ReturnsAsync(listaAcompanante);

            //Act
            var result = await ControlerAcompanante.GetAcompanantes() as NotFoundObjectResult;

            //Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task GetAcompananteId_StatusCode200()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            int id = 1;

            mockAcompananteService.Setup(q => q.GetATIdbyUsuarioId(It.IsAny<int>())).ReturnsAsync(id);

            //Act
            var result = await ControlerAcompanante.GetAcompananteId(id) as OkObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task GetAcompananteId_StatusCode404()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            mockAcompananteService.Setup(q => q.GetATIdbyUsuarioId(It.IsAny<int>()));

            //Act
            var result = await ControlerAcompanante.GetAcompananteId(1) as NotFoundObjectResult;

            //Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task GetAcompanantesById_StatusCode200()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            AcompananteResponse acompanante= new AcompananteResponse
            {
                AcompananteId = 1,
                UsuarioId = 1,
                Nombre = "Pedro",
                Apellido = "Martinez",
                CorreoElectronico = "Pedrito@gmail.com",
                Contrasena = "Pedro123",
                FotoPerfil = "aaaaa.jpg",
                Domicilio = "Calle falsa 123",
                FechaNacimiento = "12/09/1992",
                EstadoUsuarioId = 1,
                ZonaLaboral = "Quilmes",
                Contacto = "1234567890",
                Documentacion = "aaaa.jpg",
                Experiencia = "3 años",
                Disponibilidad = "111100110111",
                Especialidad = new List<EspecialidadResponse>
                    {
                        new EspecialidadResponse
                        {
                            EspecialidadId=1,
                            Descripcion="Escolar"
                        },
                        new EspecialidadResponse
                        {
                            EspecialidadId=2,
                            Descripcion="Domiciliario"
                        },
                    },
                ObrasSociales = new List<ObraSocialResponse>
                    {
                        new ObraSocialResponse
                        {
                            ObraSocialId=1,
                            Nombre="OSDE",
                            Descripcion="Somos la numero 1",
                        },
                        new ObraSocialResponse
                        {
                            ObraSocialId=2,
                            Nombre="PIUM",
                            Descripcion="Somos la numero 2",
                        },
                    }
            };

            mockAcompananteService.Setup(q => q.GetAcompanteById(It.IsAny<int>())).ReturnsAsync(acompanante);

            //Act
            var result = await ControlerAcompanante.GetAcompanantesById(1) as OkObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task GetAcompanantesById_StatusCode404()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            mockAcompananteService.Setup(q => q.GetAcompanteById(It.IsAny<int>()));

            //Act
            var result = await ControlerAcompanante.GetAcompanantesById(1) as NotFoundObjectResult;

            //Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task PutAcompanante_StatusCode200()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            var atDTO = new UsuarioAcompananteDTO
            {
                Nombre = "Pedro",
                Apellido = "Martinez",
                CorreoElectronico = "Pedrito@gmail.com",
                Contrasena = "Pedro123",
                FotoPerfil = "aaaaa.jpg",
                Domicilio = "Calle falsa 123",
                FechaNacimiento = "12/09/1992",
                EstadoUsuarioId = 1,
                ZonaLaboral = "Quilmes",
                Contacto = "1234567890",
                Documentacion = "aaaa.jpg",
                Experiencia = "3 años",
                Disponibilidad = "111100110111",
            };

            var atResponse = new AcompananteResponse
            {
                AcompananteId = 1,
                UsuarioId = 1,
                Nombre = "Pedro",
                Apellido = "Martinez",
                CorreoElectronico = "Pedrito@gmail.com",
                Contrasena = "Pedro123",
                FotoPerfil = "aaaaa.jpg",
                Domicilio = "Calle falsa 123",
                FechaNacimiento = "12/09/1992",
                EstadoUsuarioId = 1,
                ZonaLaboral = "Quilmes",
                Contacto = "1234567890",
                Documentacion = "aaaa.jpg",
                Experiencia = "3 años",
                Disponibilidad = "111100110111",
                Especialidad = new List<EspecialidadResponse>
                    {
                        new EspecialidadResponse
                        {
                            EspecialidadId=1,
                            Descripcion="Escolar"
                        },
                        new EspecialidadResponse
                        {
                            EspecialidadId=2,
                            Descripcion="Domiciliario"
                        },
                    },
                ObrasSociales = new List<ObraSocialResponse>
                    {
                        new ObraSocialResponse
                        {
                            ObraSocialId=1,
                            Nombre="OSDE",
                            Descripcion="Somos la numero 1",
                        },
                        new ObraSocialResponse
                        {
                            ObraSocialId=2,
                            Nombre="PIUM",
                            Descripcion="Somos la numero 2",
                        },
                    }
            };

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(true);

            mockAcompananteService.Setup(q => q.UpdateAcompante(It.IsAny<int>(), It.IsAny<UsuarioAcompananteDTO>())).ReturnsAsync(atResponse);

            //Act
            var result = await ControlerAcompanante.PutAcompanante(1, atDTO) as OkObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task PutAcompanante_StatusCode404()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            var atDTO = new UsuarioAcompananteDTO
            {
                Nombre = "Pedro",
                Apellido = "Martinez",
                CorreoElectronico = "Pedrito@gmail.com",
                Contrasena = "Pedro123",
                FotoPerfil = "aaaaa.jpg",
                Domicilio = "Calle falsa 123",
                FechaNacimiento = "12/09/1992",
                EstadoUsuarioId = 1,
                ZonaLaboral = "Quilmes",
                Contacto = "1234567890",
                Documentacion = "aaaa.jpg",
                Experiencia = "3 años",
                Disponibilidad = "111100110111",
            };

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(false);

            //Act
            var result = await ControlerAcompanante.PutAcompanante(1, atDTO) as NotFoundObjectResult;

            //Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task PutAcompanante_StatusCode409()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            var atDTO = new UsuarioAcompananteDTO
            {
                Nombre = "Pedro",
                Apellido = "Martinez",
                CorreoElectronico = "Pedrito@gmail.com",
                Contrasena = "Pedro123",
                FotoPerfil = "aaaaa.jpg",
                Domicilio = "Calle falsa 123",
                FechaNacimiento = "12/09/1992",
                EstadoUsuarioId = 1,
                ZonaLaboral = "Quilmes",
                Contacto = "1234567890",
                Documentacion = "aaaa.jpg",
                Experiencia = "3 años",
                Disponibilidad = "111100110111",
            };

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(true);

            mockAcompananteService.Setup(q => q.UpdateAcompante(It.IsAny<int>(), It.IsAny<UsuarioAcompananteDTO>())).Throws(new ConflictoException("Mensaje de conflicto"));

            //Act
            var result = await ControlerAcompanante.PutAcompanante(1, atDTO) as ConflictObjectResult;

            //Assert
            Assert.Equal(409, result.StatusCode);
        }

        [Fact]
        public async Task PutAcompanante_StatusCode400()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            var atDTO = new UsuarioAcompananteDTO
            {
                Nombre = "Pedro",
                Apellido = "Martinez",
                CorreoElectronico = "Pedrito@gmail.com",
                Contrasena = "Pedro123",
                FotoPerfil = "aaaaa.jpg",
                Domicilio = "Calle falsa 123",
                FechaNacimiento = "12/09/1992",
                EstadoUsuarioId = 1,
                ZonaLaboral = "Quilmes",
                Contacto = "1234567890",
                Documentacion = "aaaa.jpg",
                Experiencia = "3 años",
                Disponibilidad = "111100110111",
            };

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(true);

            mockAcompananteService.Setup(q => q.UpdateAcompante(It.IsAny<int>(), It.IsAny<UsuarioAcompananteDTO>())).Throws(new FormatException("Mensaje de conflicto"));

            //Act
            var result = await ControlerAcompanante.PutAcompanante(1, atDTO) as BadRequestObjectResult;

            //Assert
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task PutPropuesta_StatusCode200()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            var propuesta = new PropuestaResponse
            {
                PropuestaId = 1,
                TutorId = 1,
                AcompananteId = 1,
                InfoAdicional = "Escolar",
                Monto = 100000,
                EstadoPropuesta = 1,
                Descripcion = "Mensaje de prueba"
            };

            mockAcompananteService.Setup(q => q.PutPropuesta(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(propuesta);

            //Act
            var result = await ControlerAcompanante.PutPropuesta(1, 1) as OkObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task PostAcompanante_StatusCode200()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            var atDTO = new AcompananteDTO
            {
                UsuarioId = 1,
                ZonaLaboral = "Quilmes",
                Contacto = "1234567890",
                Disponibilidad = "100000111101",
                Documentacion = "Algo.jpg",
                Experiencia = "3 Años"
            };

            mockAcompananteService.Setup(q => q.CreateAcompante(atDTO)).ReturnsAsync(1);

            //Act
            var result = await ControlerAcompanante.PostAcompanante(atDTO) as JsonResult;

            //Assert
            Assert.Equal(201, result.StatusCode);
        }

        [Fact]
        public async Task PostAcompanante_StatusCode409()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            var atDTO = new AcompananteDTO 
            {
                UsuarioId=1,
                ZonaLaboral="Quilmes",
                Contacto="1234567890",
                Disponibilidad="100000111101",
                Documentacion="Algo.jpg",
                Experiencia="3 Años"
            };

            mockAcompananteService.Setup(q => q.CreateAcompante(atDTO));

            //Act
            var result = await ControlerAcompanante.PostAcompanante(atDTO) as ConflictObjectResult;

            //Assert
            Assert.Equal(409, result.StatusCode);
        }

        [Fact]
        public async Task PostAcompananteObraSocial_StatusCode200()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            var atObraSocialDTO = new AcompananteObraSocialDTO
            {
                AcompananteId=1,
                ObraSocialId=1,
            };

            var atResponse = new AcompananteObraSocialResponse
            {
                AcompananteId = 1,
                ZonaLaboral = "Quilmes",
                Contacto = "1234567890",
                Documentacion = "Algo.jpg",
                Experiencia = "3 Años",
                ObraSociales = new List<ObraSocialResponse>
                {
                    new ObraSocialResponse
                    {
                        ObraSocialId=1,
                        Nombre="Pepito",
                        Descripcion="Con pasas"
                    },
                    new ObraSocialResponse
                    {
                        ObraSocialId=2,
                        Nombre="pulpo",
                        Descripcion="Armani"
                    },
                }
            };

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(true);

            mockAcompananteService.Setup(q => q.CreateAcompanteObraSocial(It.IsAny<AcompananteObraSocialDTO>())).ReturnsAsync(atResponse);

            //Act
            var result = await ControlerAcompanante.PostAcompananteObraSocial(atObraSocialDTO) as OkObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task PostAcompananteObraSocial_AcompanantanteInexistenteStatusCode404()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            var atObraSocialDTO = new AcompananteObraSocialDTO
            {
                AcompananteId = 1,
                ObraSocialId = 1,
            };

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(false);

            //Act
            var result = await ControlerAcompanante.PostAcompananteObraSocial(atObraSocialDTO) as NotFoundObjectResult;

            //Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task PostAcompananteObraSocial_ObraSocialInexistenteStatusCode404()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            var atObraSocialDTO = new AcompananteObraSocialDTO
            {
                AcompananteId = 1,
                ObraSocialId = 1,
            };

            var atResponse = new AcompananteObraSocialResponse
            {
                AcompananteId = 1,
                ZonaLaboral = "Quilmes",
                Contacto = "1234567890",
                Documentacion = "Algo.jpg",
                Experiencia = "3 Años",
                ObraSociales = new List<ObraSocialResponse>
                {
                    new ObraSocialResponse
                    {
                        ObraSocialId=1,
                        Nombre="Pepito",
                        Descripcion="Con pasas"
                    },
                    new ObraSocialResponse
                    {
                        ObraSocialId=2,
                        Nombre="pulpo",
                        Descripcion="Armani"
                    },
                }
            };

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(true);

            mockAcompananteService.Setup(q => q.CreateAcompanteObraSocial(It.IsAny<AcompananteObraSocialDTO>()));

            //Act
            var result = await ControlerAcompanante.PostAcompananteObraSocial(atObraSocialDTO) as NotFoundObjectResult;

            //Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task PostAcompananteObraSocial_StatusCode409()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            var atObraSocialDTO = new AcompananteObraSocialDTO
            {
                AcompananteId = 1,
                ObraSocialId = 1,
            };

            var atResponse = new AcompananteObraSocialResponse
            {
                AcompananteId = 1,
                ZonaLaboral = "Quilmes",
                Contacto = "1234567890",
                Documentacion = "Algo.jpg",
                Experiencia = "3 Años",
                ObraSociales = new List<ObraSocialResponse>
                {
                    new ObraSocialResponse
                    {
                        ObraSocialId=1,
                        Nombre="Pepito",
                        Descripcion="Con pasas"
                    },
                    new ObraSocialResponse
                    {
                        ObraSocialId=2,
                        Nombre="pulpo",
                        Descripcion="Armani"
                    },
                }
            };

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(true);

            mockAcompananteService.Setup(q => q.CreateAcompanteObraSocial(It.IsAny<AcompananteObraSocialDTO>())).Throws(new RelacionExistenteException("Mensaje de conflicto"));

            //Act
            var result = await ControlerAcompanante.PostAcompananteObraSocial(atObraSocialDTO) as ConflictObjectResult;

            //Assert
            Assert.Equal(409, result.StatusCode);
        }

        [Fact]
        public async Task PostAcompananteEspecialidad_StatusCode200()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            var atEspecialidadDTO = new AcompananteEspecialidadDTO
            {
                AcompananteId = 1,
                EspecialidadId = 1,
            };

            var atEspecialidadResponse = new AcompananteEspecialidadResponse
            {
                AcompananteId = 1,
                ZonaLaboral = "Quilmes",
                Contacto = "1234567890",
                Documentacion = "Algo.jpg",
                Experiencia = "3 Años",
                Especialidades = new List<EspecialidadResponse>
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
                }
            };

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(true);

            mockAcompananteService.Setup(q => q.CreateAcompanteEspecialidad(It.IsAny<AcompananteEspecialidadDTO>())).ReturnsAsync(atEspecialidadResponse);

            //Act
            var result = await ControlerAcompanante.PostAcompananteEspecialidad(atEspecialidadDTO) as OkObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task PostAcompananteEspecialidad_AcompanantanteInexistenteStatusCode404()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            var atEspecialidadDTO = new AcompananteEspecialidadDTO
            {
                AcompananteId = 1,
                EspecialidadId = 1,
            };

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(false);

            //Act
            var result = await ControlerAcompanante.PostAcompananteEspecialidad(atEspecialidadDTO) as NotFoundObjectResult;

            //Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task PostAcompananteEspecialidad_EspecialidadInexistenteStatusCode404()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            var atEspecialidadDTO = new AcompananteEspecialidadDTO
            {
                AcompananteId = 1,
                EspecialidadId = 1,
            };

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(true);

            mockAcompananteService.Setup(q => q.CreateAcompanteEspecialidad(It.IsAny<AcompananteEspecialidadDTO>()));

            //Act
            var result = await ControlerAcompanante.PostAcompananteEspecialidad(atEspecialidadDTO) as NotFoundObjectResult;

            //Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task PostAcompananteEspecialidad_StatusCode409()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            var atEspecialidadDTO = new AcompananteEspecialidadDTO
            {
                AcompananteId = 1,
                EspecialidadId = 1,
            };

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(true);

            mockAcompananteService.Setup(q => q.CreateAcompanteEspecialidad(It.IsAny<AcompananteEspecialidadDTO>())).Throws(new RelacionExistenteException("Mensaje de conflicto")); ;

            //Act
            var result = await ControlerAcompanante.PostAcompananteEspecialidad(atEspecialidadDTO) as ConflictObjectResult;

            //Assert
            Assert.Equal(409, result.StatusCode);
        }

        [Fact]
        public async Task DeleteAcompanante_StatusCode200()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            var acompananteResponse = new AcompananteResponse
            {
                AcompananteId = 1,
                UsuarioId = 1,
                Nombre = "Pedro",
                Apellido = "Martinez",
                CorreoElectronico = "Pedrito@gmail.com",
                Contrasena = "Pedro123",
                FotoPerfil = "aaaaa.jpg",
                Domicilio = "Calle falsa 123",
                FechaNacimiento = "12/09/1992",
                EstadoUsuarioId = 1,
                ZonaLaboral = "Quilmes",
                Contacto = "1234567890",
                Documentacion = "aaaa.jpg",
                Experiencia = "3 años",
                Disponibilidad = "111100110111",
                Especialidad = new List<EspecialidadResponse>
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
                },
                ObrasSociales = new List<ObraSocialResponse>
                {
                    new ObraSocialResponse
                    {
                        ObraSocialId = 1,
                        Nombre = "OSDE",
                        Descripcion = "Somos la numero 1",
                    },
                    new ObraSocialResponse
                    {
                        ObraSocialId = 2,
                        Nombre = "PIUM",
                        Descripcion = "Somos la numero 2",
                    },
                }
            };

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(true);

            mockAcompananteService.Setup(q => q.DeleteAcompante(It.IsAny<int>())).ReturnsAsync(acompananteResponse); ;

            //Act
            var result = await ControlerAcompanante.DeleteAcompanante(1) as OkObjectResult;

            //Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task DeleteAcompanante_StatusCode404()
        {
            //Arrange
            var mockAcompananteService = new Mock<IAcompanteService>();

            AcompanantesController ControlerAcompanante = new AcompanantesController(mockAcompananteService.Object);

            mockAcompananteService.Setup(q => q.IfExist(It.IsAny<int>())).ReturnsAsync(false);

            //Act
            var result = await ControlerAcompanante.DeleteAcompanante(1) as NotFoundObjectResult;

            //Assert
            Assert.Equal(404, result.StatusCode);
        }

    }
}
