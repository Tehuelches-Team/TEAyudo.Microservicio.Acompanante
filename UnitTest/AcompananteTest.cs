using Application.Exceptions;
using Application.Interfaces.Application;
using Application.Interfaces.Infraestructure.Command;
using Application.Interfaces.Infraestructure.Query;
using Application.Model.Response;
using Application.UseCase.CrearUsuarioAcompante;
using Application.UseCase.DTOS;
using Application.UseCase.Mapping;
using Application.UseCase.Responses;
using Application.UseCase.Services;
using Moq;
using TEAyudo_Acompanantes;

namespace UnitTest
{
    public class AcompananteTest
    {
        [Fact]
        public async Task GetAcompantes_Fallido()
        {
            //Arrange 
            var mockAcompananteCommand = new Mock<IAcompananteCommand>();
            var mockAcompananteQuery = new Mock<IAcompananteQuery>();
            ICreateAcompananteResponse mapping = new CreateAcompananteResponse();
            var mockUsuarioCommand = new Mock<IUsuarioCommand>();
            var mockUsuarioQuery = new Mock<IUsuarioQuery>();
            var mockPropuestaCommand = new Mock<IPropuestaCommand>();

            IAcompanteService service = new AcompananteService(mockAcompananteCommand.Object, mockAcompananteQuery.Object, mapping, mockUsuarioCommand.Object, mockUsuarioQuery.Object, mockPropuestaCommand.Object);

            //Act
            var result = await service.GetAcompantes();

            //Asserts

            Assert.Null(result);
        }

        [Fact]
        public async Task GetAcompantes_Correctamente()
        {
            //Arrange 
            var mockAcompananteCommand = new Mock<IAcompananteCommand>();
            var mockAcompananteQuery = new Mock<IAcompananteQuery>();
            ICreateAcompananteResponse mapping = new CreateAcompananteResponse();
            var mockUsuarioCommand = new Mock<IUsuarioCommand>();
            var mockUsuarioQuery = new Mock<IUsuarioQuery>();
            var mockPropuestaCommand = new Mock<IPropuestaCommand>();

            IAcompanteService service = new AcompananteService(mockAcompananteCommand.Object, mockAcompananteQuery.Object, mapping, mockUsuarioCommand.Object, mockUsuarioQuery.Object, mockPropuestaCommand.Object);

            var primerAT = new Acompanante
            {
                AcompananteId = 1,
                UsuarioId = 1,
                ZonaLaboral = "Berazategui",
                ObraSocialId = 2,
                Contacto = "123456789",
                Documentacion = "Documento de prueba",
                EspecialidadId = 1,
                Experiencia = "5 años",
                Disponibilidad = Convert.ToInt16("001111110110110", 2),
            };

            var segundoAT = new Acompanante
            {
                AcompananteId = 2,
                UsuarioId = 2,
                ZonaLaboral = "Quilmes",
                ObraSocialId = 1,
                Contacto = "9876543210",
                Documentacion = "Documento de prueba",
                EspecialidadId = 2,
                Experiencia = "3 años",
                Disponibilidad = Convert.ToInt16("111100100011", 2),
            };

            var primerUsuario = new UsuarioResponse
            {
                UsuarioId = 1,
                Nombre = "Antoine",
                Apellido = "Griezmann",
                CorreoElectronico = "Antoine@gmail.com",
                Contrasena = "Grizzi7",
                FotoPerfil = "https://i0.wp.com/www.lacolinadenervion.com/wp-content/uploads/2023/09/atletico-madrid-v-real-madrid-cf-laliga-ea-sports-scaled.jpg?fit=800%2C533&ssl=1",
                Domicilio = "Madrid",
                FechaNacimiento = "21/03/1991",
                EstadoUsuarioId = 1
            };

            var segundoUsuario = new UsuarioResponse
            {
                UsuarioId = 2,
                Nombre = "Lionel",
                Apellido = "Messi",
                CorreoElectronico = "Messias@gmail.com",
                Contrasena = "Andapaalla",
                FotoPerfil = "https://i0.wp.com/www.lacolinadenervion.com/wp-content/uploads/2023/09/atletico-madrid-v-real-madrid-cf-laliga-ea-sports-scaled.jpg?fit=800%2C533&ssl=1",
                Domicilio = "Miami",
                FechaNacimiento = "24/06/1987",
                EstadoUsuarioId = 1
            };

            var primerObraSocial = new ObraSocial
            {
                ObraSocialId = 1,
                Nombre = "Soap",
                Descripcion = "La mejor",
            };

            var SegundaObraSocial = new ObraSocial
            {
                ObraSocialId = 2,
                Nombre = "Tomato",
                Descripcion = "Potato",
            };

            var primerRelacionATObraSocial = new AcompananteObraSocial
            {
                AcompananteId = 1,
                Acompanante = primerAT,
                ObrasocialId = 2,
                ObraSocial = SegundaObraSocial,
            };

            SegundaObraSocial.Acompanantes = new List<AcompananteObraSocial> { primerRelacionATObraSocial };

            primerAT.ObrasSociales = new List<AcompananteObraSocial> { primerRelacionATObraSocial };

            var segundaRelacionATObraSocial = new AcompananteObraSocial
            {
                AcompananteId = 2,
                Acompanante = segundoAT,
                ObrasocialId = 1,
                ObraSocial = primerObraSocial,
            };

            primerObraSocial.Acompanantes = new List<AcompananteObraSocial> { segundaRelacionATObraSocial };

            segundoAT.ObrasSociales = new List<AcompananteObraSocial> { segundaRelacionATObraSocial };

            var listaAcompanantes = new List<Acompanante>();

            listaAcompanantes.Add(primerAT);
            listaAcompanantes.Add(segundoAT);

            mockAcompananteQuery.Setup(q => q.GetAcompanantes()).ReturnsAsync(listaAcompanantes);

            var listaUsuarios = new List<UsuarioResponse>();

            listaUsuarios.Add(primerUsuario);
            listaUsuarios.Add(segundoUsuario);

            mockUsuarioQuery.Setup(q => q.GetAllUsuarios()).ReturnsAsync(listaUsuarios);

            var primerEspecialidad = new Especialidad
            {
                EspecialidadId = 1,
                Descripcion = "Muy buen cuidado",
            };

            var segundaEspecialidad = new Especialidad
            {
                EspecialidadId = 2,
                Descripcion = "excelente cuidado",
            };

            var primerATEspecialidad = new AcompananteEspecialidad
            {
                AcompananteId = 1,
                Acompanante = primerAT,
                EspecialidadId = 1,
                Especialidad = primerEspecialidad,
            };

            primerEspecialidad.Acompanantes = new List<AcompananteEspecialidad> { primerATEspecialidad };

            primerAT.Especialidades = new List<AcompananteEspecialidad> { primerATEspecialidad };

            var segundoATEspecialidad = new AcompananteEspecialidad
            {
                AcompananteId = 2,
                Acompanante = segundoAT,
                EspecialidadId = 2,
                Especialidad = segundaEspecialidad,
            };

            segundaEspecialidad.Acompanantes = new List<AcompananteEspecialidad> { segundoATEspecialidad };

            segundoAT.Especialidades = new List<AcompananteEspecialidad> { segundoATEspecialidad };


            //Act
            var result = await service.GetAcompantes();

            //Asserts
            Assert.NotNull(result);

        }

        [Fact]
        public async Task Filtros_Exitosos()
        {
            //Arrange 
            var mockAcompananteCommand = new Mock<IAcompananteCommand>();
            var mockAcompananteQuery = new Mock<IAcompananteQuery>();
            ICreateAcompananteResponse mapping = new CreateAcompananteResponse();
            var mockUsuarioCommand = new Mock<IUsuarioCommand>();
            var mockUsuarioQuery = new Mock<IUsuarioQuery>();
            var mockPropuestaCommand = new Mock<IPropuestaCommand>();

            IAcompanteService service = new AcompananteService(mockAcompananteCommand.Object, mockAcompananteQuery.Object, mapping, mockUsuarioCommand.Object, mockUsuarioQuery.Object, mockPropuestaCommand.Object);


            var primerAT = new Acompanante
            {
                AcompananteId = 1,
                UsuarioId = 1,
                ZonaLaboral = "Quilmes",
                ObraSocialId = 2,
                Contacto = "123456789",
                Documentacion = "Documento de prueba",
                EspecialidadId = 1,
                Experiencia = "5 años",
                Disponibilidad = Convert.ToInt16("000111110110110", 2),
            };

            var segundoAT = new Acompanante
            {
                AcompananteId = 2,
                UsuarioId = 2,
                ZonaLaboral = "Quilmes",
                ObraSocialId = 1,
                Contacto = "9876543210",
                Documentacion = "Documento de prueba",
                EspecialidadId = 2,
                Experiencia = "3 años",
                Disponibilidad = Convert.ToInt16("000111100100011", 2), 
            };

            var primerUsuario = new UsuarioResponse
            {
                UsuarioId = 1,
                Nombre = "Antoine",
                Apellido = "Griezmann",
                CorreoElectronico = "Antoine@gmail.com",
                Contrasena = "Grizzi7",
                FotoPerfil = "https://i0.wp.com/www.lacolinadenervion.com/wp-content/uploads/2023/09/atletico-madrid-v-real-madrid-cf-laliga-ea-sports-scaled.jpg?fit=800%2C533&ssl=1",
                Domicilio = "Madrid",
                FechaNacimiento = "21/03/1991",
                EstadoUsuarioId = 1
            };

            var segundoUsuario = new UsuarioResponse
            {
                UsuarioId = 2,
                Nombre = "Lionel",
                Apellido = "Messi",
                CorreoElectronico = "Messias@gmail.com",
                Contrasena = "Andapaalla",
                FotoPerfil = "https://i0.wp.com/www.lacolinadenervion.com/wp-content/uploads/2023/09/atletico-madrid-v-real-madrid-cf-laliga-ea-sports-scaled.jpg?fit=800%2C533&ssl=1",
                Domicilio = "Miami",
                FechaNacimiento = "24/06/1987",
                EstadoUsuarioId = 1
            };

            var primerObraSocial = new ObraSocial
            {
                ObraSocialId = 1,
                Nombre = "Soap",
                Descripcion = "La mejor",
            };

            var SegundaObraSocial = new ObraSocial
            {
                ObraSocialId = 2,
                Nombre = "Tomato",
                Descripcion = "Potato",
            };

            var primerRelacionATObraSocial = new AcompananteObraSocial
            {
                AcompananteId = 1,
                Acompanante = primerAT,
                ObrasocialId = 2,
                ObraSocial = SegundaObraSocial,
            };

            SegundaObraSocial.Acompanantes = new List<AcompananteObraSocial> { primerRelacionATObraSocial };

            primerAT.ObrasSociales = new List<AcompananteObraSocial> { primerRelacionATObraSocial };

            var segundaRelacionATObraSocial = new AcompananteObraSocial
            {
                AcompananteId = 2,
                Acompanante = segundoAT,
                ObrasocialId = 1,
                ObraSocial = primerObraSocial,
            };

            primerObraSocial.Acompanantes = new List<AcompananteObraSocial> { segundaRelacionATObraSocial };

            segundoAT.ObrasSociales = new List<AcompananteObraSocial> { segundaRelacionATObraSocial };

            var listaAcompanantes = new List<Acompanante>();

            listaAcompanantes.Add(primerAT);
            listaAcompanantes.Add(segundoAT);

            var listaUsuarios = new List<UsuarioResponse>();

            listaUsuarios.Add(primerUsuario);
            listaUsuarios.Add(segundoUsuario);

            var primerEspecialidad = new Especialidad
            {
                EspecialidadId = 1,
                Descripcion = "Muy buen cuidado",
            };

            var segundaEspecialidad = new Especialidad
            {
                EspecialidadId = 2,
                Descripcion = "excelente cuidado",
            };

            var primerATEspecialidad = new AcompananteEspecialidad
            {
                AcompananteId = 1,
                Acompanante = primerAT,
                EspecialidadId = 2,
                Especialidad = primerEspecialidad,
            };

            primerEspecialidad.Acompanantes = new List<AcompananteEspecialidad> { primerATEspecialidad };

            primerAT.Especialidades = new List<AcompananteEspecialidad> { primerATEspecialidad };

            var segundoATEspecialidad = new AcompananteEspecialidad
            {
                AcompananteId = 2,
                Acompanante = segundoAT,
                EspecialidadId = 2,
                Especialidad = segundaEspecialidad,
            };

            segundaEspecialidad.Acompanantes = new List<AcompananteEspecialidad> { segundoATEspecialidad };

            segundoAT.Especialidades = new List<AcompananteEspecialidad> { segundoATEspecialidad };

            mockAcompananteQuery.Setup(q => q.GetAcompananteFiltros(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Int16>(), It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(listaAcompanantes);

            mockUsuarioQuery.Setup(q => q.GetAllUsuarios()).ReturnsAsync(listaUsuarios);

            //Act
            var result = await service.Filtrar(0, 2, Convert.ToInt16("000111100100010", 2), 0, "Quilmes");
            
            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAcompanteById_Correcto()
        {
            //Arrange 
            var mockAcompananteCommand = new Mock<IAcompananteCommand>();
            var mockAcompananteQuery = new Mock<IAcompananteQuery>();
            //var mockCreateResponse = new Mock<ICreateAcompananteResponse>();
            ICreateAcompananteResponse mapping = new CreateAcompananteResponse();
            var mockUsuarioCommand = new Mock<IUsuarioCommand>();
            var mockUsuarioQuery = new Mock<IUsuarioQuery>();
            var mockPropuestaCommand = new Mock<IPropuestaCommand>();

            IAcompanteService service = new AcompananteService(mockAcompananteCommand.Object, mockAcompananteQuery.Object, mapping, mockUsuarioCommand.Object, mockUsuarioQuery.Object, mockPropuestaCommand.Object);

            var Usuario = new UsuarioResponse {
                    UsuarioId=1,
                    Nombre="Antoine",
                    Apellido="Griezmann",
                    CorreoElectronico="Antoine@gmail.com",
                    Contrasena="Grizzi7",
                    FotoPerfil="https://i0.wp.com/www.lacolinadenervion.com/wp-content/uploads/2023/09/atletico-madrid-v-real-madrid-cf-laliga-ea-sports-scaled.jpg?fit=800%2C533&ssl=1",
                    Domicilio="Madrid",
                    FechaNacimiento="21/03/1991",
                    EstadoUsuarioId=1
            };

            mockUsuarioQuery.Setup(q => q.GetUsuarioById(1)).ReturnsAsync(Usuario);

            var Acompanante = new Acompanante
            {
                AcompananteId = 1,
                UsuarioId = 1,
                ZonaLaboral = "Berazategui",
                ObraSocialId = 2,
                Contacto = "123456789",
                Documentacion = "Documento de prueba",
                EspecialidadId = 1,
                Experiencia = "5 años",
                Disponibilidad = Convert.ToInt16("000011110110110", 2), // Int16
                ObrasSociales = new List<AcompananteObraSocial>(),
                Especialidades = new List<AcompananteEspecialidad>(),
            };

            mockAcompananteQuery.Setup(q => q.GetAcompananteById(1)).ReturnsAsync(Acompanante);

            //Act
            var result = await service.GetAcompanteById(1);

            //Asserts

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAcompanteById_Fallido()
        {
            //Arrange 
            var mockAcompananteCommand = new Mock<IAcompananteCommand>();
            var mockAcompananteQuery = new Mock<IAcompananteQuery>();
            //var mockCreateResponse = new Mock<ICreateAcompananteResponse>();
            ICreateAcompananteResponse mapping = new CreateAcompananteResponse();
            var mockUsuarioCommand = new Mock<IUsuarioCommand>();
            var mockUsuarioQuery = new Mock<IUsuarioQuery>();
            var mockPropuestaCommand = new Mock<IPropuestaCommand>();

            IAcompanteService service = new AcompananteService(mockAcompananteCommand.Object, mockAcompananteQuery.Object, mapping, mockUsuarioCommand.Object, mockUsuarioQuery.Object, mockPropuestaCommand.Object);

            var Usuario = new UsuarioResponse
            {
                UsuarioId = 1,
                Nombre = "Antoine",
                Apellido = "Griezmann",
                CorreoElectronico = "Antoine@gmail.com",
                Contrasena = "Grizzi7",
                FotoPerfil = "https://i0.wp.com/www.lacolinadenervion.com/wp-content/uploads/2023/09/atletico-madrid-v-real-madrid-cf-laliga-ea-sports-scaled.jpg?fit=800%2C533&ssl=1",
                Domicilio = "Madrid",
                FechaNacimiento = "21/03/1991",
                EstadoUsuarioId = 1
            };

            mockUsuarioQuery.Setup(q => q.GetUsuarioById(1)).ReturnsAsync(Usuario);

            var Acompanante = new Acompanante
            {
                AcompananteId = 1,
                UsuarioId = 1,
                ZonaLaboral = "Berazategui",
                ObraSocialId = 2,
                Contacto = "123456789",
                Documentacion = "Documento de prueba",
                EspecialidadId = 1,
                Experiencia = "5 años",
                Disponibilidad = Convert.ToInt16("000011110110110", 2), // Int16
                ObrasSociales = new List<AcompananteObraSocial>(),
                Especialidades = new List<AcompananteEspecialidad>(),
            };

            mockAcompananteQuery.Setup(q => q.GetAcompananteById(1)).ReturnsAsync(Acompanante);

            //Act
            var result = await service.GetAcompanteById(3);

            //Asserts

            Assert.Null(result);
        }

        [Fact]
        public async Task IfExist_Correcto()
        {
            //Arrange
            var mockAcompananteCommand = new Mock<IAcompananteCommand>();
            var mockAcompananteQuery = new Mock<IAcompananteQuery>();
            ICreateAcompananteResponse mapping = new CreateAcompananteResponse();
            var mockUsuarioCommand = new Mock<IUsuarioCommand>();
            var mockUsuarioQuery = new Mock<IUsuarioQuery>();
            var mockPropuestaCommand = new Mock<IPropuestaCommand>();

            IAcompanteService service = new AcompananteService(mockAcompananteCommand.Object, mockAcompananteQuery.Object, mapping, mockUsuarioCommand.Object, mockUsuarioQuery.Object, mockPropuestaCommand.Object);

            var Acompanante = new Acompanante
            {
                AcompananteId = 1,
                UsuarioId = 1,
                ZonaLaboral = "Berazategui",
                ObraSocialId = 2,
                Contacto = "123456789",
                Documentacion = "Documento de prueba",
                EspecialidadId = 1,
                Experiencia = "5 años",
                Disponibilidad = Convert.ToInt16("000011110110110", 2), // Int16
                ObrasSociales = new List<AcompananteObraSocial>(),
                Especialidades = new List<AcompananteEspecialidad>(),
            };

            mockAcompananteQuery.Setup(q => q.GetAcompananteById(1)).ReturnsAsync(Acompanante);

            //Act
            var result = await service.IfExist(1);

            //Asserts

            Assert.True(result);

        }

        [Fact]
        public async Task IfExist_Fallido()
        {
            //Arrange
            var mockAcompananteCommand = new Mock<IAcompananteCommand>();
            var mockAcompananteQuery = new Mock<IAcompananteQuery>();
            ICreateAcompananteResponse mapping = new CreateAcompananteResponse();
            var mockUsuarioCommand = new Mock<IUsuarioCommand>();
            var mockUsuarioQuery = new Mock<IUsuarioQuery>();
            var mockPropuestaCommand = new Mock<IPropuestaCommand>();

            IAcompanteService service = new AcompananteService(mockAcompananteCommand.Object, mockAcompananteQuery.Object, mapping, mockUsuarioCommand.Object, mockUsuarioQuery.Object, mockPropuestaCommand.Object);

            var Acompanante = new Acompanante
            {
                AcompananteId = 1,
                UsuarioId = 1,
                ZonaLaboral = "Berazategui",
                ObraSocialId = 2,
                Contacto = "123456789",
                Documentacion = "Documento de prueba",
                EspecialidadId = 1,
                Experiencia = "5 años",
                Disponibilidad = Convert.ToInt16("000011110110110", 2), // Int16
                ObrasSociales = new List<AcompananteObraSocial>(),
                Especialidades = new List<AcompananteEspecialidad>(),
            };

            mockAcompananteQuery.Setup(q => q.GetAcompananteById(1)).ReturnsAsync(Acompanante);

            //Act
            var result = await service.IfExist(3);

            //Asserts

            Assert.False(result);
        }

        [Fact]
        public async Task UpdateAcompante()
        {
            //Arrange
            var mockAcompananteCommand = new Mock<IAcompananteCommand>();
            var mockAcompananteQuery = new Mock<IAcompananteQuery>();
            ICreateAcompananteResponse mapping = new CreateAcompananteResponse();
            var mockUsuarioCommand = new Mock<IUsuarioCommand>();
            var mockUsuarioQuery = new Mock<IUsuarioQuery>();
            var mockPropuestaCommand = new Mock<IPropuestaCommand>();

            IAcompanteService service = new AcompananteService(mockAcompananteCommand.Object, mockAcompananteQuery.Object, mapping, mockUsuarioCommand.Object, mockUsuarioQuery.Object, mockPropuestaCommand.Object);

            var Acompanante = new Acompanante
            {
                AcompananteId = 1,
                UsuarioId = 1,
                ZonaLaboral = "Berazategui",
                ObraSocialId = 2,
                Contacto = "123456789",
                Documentacion = "Documento de prueba",
                EspecialidadId = 1,
                Experiencia = "5 años",
                Disponibilidad = Convert.ToInt16("000011110110110", 2),
                ObrasSociales = new List<AcompananteObraSocial>(),
                Especialidades = new List<AcompananteEspecialidad>(),
            };

            var usuario = new UsuarioAcompananteDTO
            {
                Nombre = "Antoine",
                Apellido = "Griezmann",
                CorreoElectronico = "Antoine@gmail.com",
                Contrasena = "Grizzi7",
                FotoPerfil = "https://i0.wp.com/www.lacolinadenervion.com/wp-content/uploads/2023/09/atletico-madrid-v-real-madrid-cf-laliga-ea-sports-scaled.jpg?fit=800%2C533&ssl=1",
                Domicilio = "Madrid",
                FechaNacimiento = "21/03/1991",
                EstadoUsuarioId = 1,
                ZonaLaboral = "Berazategui",
                Contacto = "123456789",
                Documentacion = "Documento de prueba",
                Experiencia = "5 años",
                Disponibilidad = "000011110110110",
            };

            mockAcompananteCommand.Setup(q => q.UpdateAcompanante(1,usuario));

            var at = mockAcompananteQuery.Setup(q => q.GetAcompananteById(1)).ReturnsAsync(Acompanante);

            var usuarioresponse = new UsuarioResponse
            {
                UsuarioId = 1,
                Nombre = "Antoine",
                Apellido = "Griezmann",
                CorreoElectronico = "Antoine@gmail.com",
                Contrasena = "Grizzi7",
                FotoPerfil = "https://i0.wp.com/www.lacolinadenervion.com/wp-content/uploads/2023/09/atletico-madrid-v-real-madrid-cf-laliga-ea-sports-scaled.jpg?fit=800%2C533&ssl=1",
                Domicilio = "Madrid",
                FechaNacimiento = "21/03/1991",
                EstadoUsuarioId = 1
            };

            var usuarioDTO = new UsuarioDTO
            {
                Nombre = "Antoine",
                Apellido = "Griezmann",
                CorreoElectronico = "Antoine@gmail.com",
                Contrasena = "Grizzi7",
                FotoPerfil = "https://i0.wp.com/www.lacolinadenervion.com/wp-content/uploads/2023/09/atletico-madrid-v-real-madrid-cf-laliga-ea-sports-scaled.jpg?fit=800%2C533&ssl=1",
                Domicilio = "Metropolitano",
                FechaNacimiento = "21/03/1991",
            };
            MapUsuarioDTO Mapping = new MapUsuarioDTO();

            var usuarioResult = mockUsuarioCommand.Setup(q => q.PutUsuario(1,It.IsAny<UsuarioDTO>())).ReturnsAsync(usuarioresponse);

            //Act
            var result = await service.UpdateAcompante(1, usuario);

            //Asserts
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CreateAcompanante()
        {
            //Arrange
            var mockAcompananteCommand = new Mock<IAcompananteCommand>();
            var mockAcompananteQuery = new Mock<IAcompananteQuery>();
            ICreateAcompananteResponse mapping = new CreateAcompananteResponse();
            var mockUsuarioCommand = new Mock<IUsuarioCommand>();
            var mockUsuarioQuery = new Mock<IUsuarioQuery>();
            var mockPropuestaCommand = new Mock<IPropuestaCommand>();

            IAcompanteService service = new AcompananteService(mockAcompananteCommand.Object, mockAcompananteQuery.Object, mapping, mockUsuarioCommand.Object, mockUsuarioQuery.Object, mockPropuestaCommand.Object);

            var Usuariodto = new AcompananteDTO
            {
                UsuarioId = 1,
                ZonaLaboral = "Berazategui",
                Contacto = "123456789",
                Documentacion = "Documento de prueba",
                Experiencia = "5 años",
                Disponibilidad = "000011110110110",
            };

            mockAcompananteCommand.Setup(q => q.CreateAcompanante(It.IsAny<Acompanante>())).ReturnsAsync(1);
            
            //Act
            var result = await service.CreateAcompante(Usuariodto);

            //Asserts
            Assert.Equal(1,result);
        }

        [Fact]
        public async Task DeleteAcompanante()
        {
            //Arrange
            var mockAcompananteCommand = new Mock<IAcompananteCommand>();
            var mockAcompananteQuery = new Mock<IAcompananteQuery>();
            ICreateAcompananteResponse mapping = new CreateAcompananteResponse();
            var mockUsuarioCommand = new Mock<IUsuarioCommand>();
            var mockUsuarioQuery = new Mock<IUsuarioQuery>();
            var mockPropuestaCommand = new Mock<IPropuestaCommand>();

            IAcompanteService service = new AcompananteService(mockAcompananteCommand.Object, mockAcompananteQuery.Object, mapping, mockUsuarioCommand.Object, mockUsuarioQuery.Object, mockPropuestaCommand.Object);

            var Acompanante = new Acompanante
            {
                AcompananteId = 1,
                UsuarioId = 1,
                ZonaLaboral = "Berazategui",
                ObraSocialId = 2,
                Contacto = "123456789",
                Documentacion = "Documento de prueba",
                EspecialidadId = 1,
                Experiencia = "5 años",
                Disponibilidad = Convert.ToInt16("000011110110110", 2), 
                ObrasSociales = new List<AcompananteObraSocial>(),
                Especialidades = new List<AcompananteEspecialidad>(),
            };

            mockAcompananteQuery.Setup(q => q.GetAcompananteById(1)).ReturnsAsync(Acompanante);

            mockAcompananteCommand.Setup(q => q.DeleteAcompanante(It.IsAny<Acompanante>()));

            var Usuario = new UsuarioResponse
            {
                UsuarioId = 1,
                Nombre = "Antoine",
                Apellido = "Griezmann",
                CorreoElectronico = "Antoine@gmail.com",
                Contrasena = "Grizzi7",
                FotoPerfil = "https://i0.wp.com/www.lacolinadenervion.com/wp-content/uploads/2023/09/atletico-madrid-v-real-madrid-cf-laliga-ea-sports-scaled.jpg?fit=800%2C533&ssl=1",
                Domicilio = "Madrid",
                FechaNacimiento = "21/03/1991",
                EstadoUsuarioId = 1
            };

            mockUsuarioCommand.Setup(q => q.DeleteUsuario(It.IsAny<int>())).ReturnsAsync(Usuario);

            //Act
            await service.DeleteAcompante(1);

            //Asserts
            //El test se considera exitoso ya que no hay errores
        }

        [Fact]
        public async Task CreateAcompanteObraSocial_Correctamente()
        {
            //Arrange
            var mockAcompananteCommand = new Mock<IAcompananteCommand>();
            var mockAcompananteQuery = new Mock<IAcompananteQuery>();
            ICreateAcompananteResponse mapping = new CreateAcompananteResponse();
            var mockUsuarioCommand = new Mock<IUsuarioCommand>();
            var mockUsuarioQuery = new Mock<IUsuarioQuery>();
            var mockPropuestaCommand = new Mock<IPropuestaCommand>();

            IAcompanteService service = new AcompananteService(mockAcompananteCommand.Object, mockAcompananteQuery.Object, mapping, mockUsuarioCommand.Object, mockUsuarioQuery.Object, mockPropuestaCommand.Object);

            var atObraSocialDTO = new AcompananteObraSocialDTO
            {
                AcompananteId = 1,
                ObraSocialId = 2,
            };

            mockAcompananteCommand.Setup(q => q.CreateAcompanante(It.IsAny<Acompanante>())).ReturnsAsync(1);

            var acompanante = new Acompanante
            {
                AcompananteId = 1,
                UsuarioId = 1,
                ZonaLaboral = "Berazategui",
                ObraSocialId = 2,
                Contacto = "123456789",
                Documentacion = "Documento de prueba",
                EspecialidadId = 1,
                Experiencia = "5 años",
                Disponibilidad = Convert.ToInt16("000011110110110", 2),
                ObrasSociales = new List<AcompananteObraSocial>(),
                Especialidades = new List<AcompananteEspecialidad>(),
            };

            var obraSocial = new ObraSocial
            {
                ObraSocialId = 1,
                Nombre = "Soap",
                Descripcion = "La mejor",
            };

            var atobrasocial = new AcompananteObraSocial
            {
                AcompananteId = 1,
                Acompanante = acompanante,
                ObrasocialId = 1,
                ObraSocial = obraSocial,
            };

            obraSocial.Acompanantes = new List<AcompananteObraSocial> { atobrasocial };

            acompanante.ObrasSociales = new List<AcompananteObraSocial> { atobrasocial };

            var atobrasocialSegunda = new AcompananteObraSocial
            {
                AcompananteId = 1,
                Acompanante = acompanante,
                ObrasocialId = 2,
                ObraSocial = obraSocial,
            };

            mockAcompananteQuery.Setup(q => q.GetAcompananteById(It.IsAny<int>())).ReturnsAsync(acompanante);

            mockAcompananteCommand.Setup(q => q.CreateAcompanteObraSocial(It.IsAny<AcompananteObraSocial>())).ReturnsAsync(atobrasocialSegunda);


            //Act
            var result = await service.CreateAcompanteObraSocial(atObraSocialDTO);

            //Asserts
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CreateAcompanteObraSocial_ExcepcionRelacionExistente()
        {
            //Arrange
            var mockAcompananteCommand = new Mock<IAcompananteCommand>();
            var mockAcompananteQuery = new Mock<IAcompananteQuery>();
            ICreateAcompananteResponse mapping = new CreateAcompananteResponse();
            var mockUsuarioCommand = new Mock<IUsuarioCommand>();
            var mockUsuarioQuery = new Mock<IUsuarioQuery>();
            var mockPropuestaCommand = new Mock<IPropuestaCommand>();

            IAcompanteService service = new AcompananteService(mockAcompananteCommand.Object, mockAcompananteQuery.Object, mapping, mockUsuarioCommand.Object, mockUsuarioQuery.Object, mockPropuestaCommand.Object);

            var atObraSocialDTO = new AcompananteObraSocialDTO
            {
                AcompananteId = 1,
                ObraSocialId = 1,
            };

            mockAcompananteCommand.Setup(q => q.CreateAcompanante(It.IsAny<Acompanante>())).ReturnsAsync(1);

            var acompanante = new Acompanante
            {
                AcompananteId = 1,
                UsuarioId = 1,
                ZonaLaboral = "Berazategui",
                ObraSocialId = 2,
                Contacto = "123456789",
                Documentacion = "Documento de prueba",
                EspecialidadId = 1,
                Experiencia = "5 años",
                Disponibilidad = Convert.ToInt16("000011110110110", 2),
                ObrasSociales = new List<AcompananteObraSocial>(),
                Especialidades = new List<AcompananteEspecialidad>(),
            };

            var obraSocial = new ObraSocial
            {
                ObraSocialId = 1,
                Nombre = "Soap",
                Descripcion = "La mejor",
            };

            var atobrasocial = new AcompananteObraSocial
            {
                AcompananteId = 1,
                Acompanante = acompanante,
                ObrasocialId = 1,
                ObraSocial = obraSocial,
            };

            obraSocial.Acompanantes = new List<AcompananteObraSocial> { atobrasocial };

            acompanante.ObrasSociales = new List<AcompananteObraSocial> { atobrasocial };


            mockAcompananteQuery.Setup(q => q.GetAcompananteById(It.IsAny<int>())).ReturnsAsync(acompanante);

            mockAcompananteCommand.Setup(q => q.CreateAcompanteObraSocial(It.IsAny<AcompananteObraSocial>())).ReturnsAsync(atobrasocial);

            //Act & Asserts
            await Assert.ThrowsAsync<RelacionExistenteException>(async () => await service.CreateAcompanteObraSocial(atObraSocialDTO));
        }

        [Fact]
        public async Task CreateAcompanteObraSocial_ObraSocialInexistente()
        {
            //Arrange
            var mockAcompananteCommand = new Mock<IAcompananteCommand>();
            var mockAcompananteQuery = new Mock<IAcompananteQuery>();
            ICreateAcompananteResponse mapping = new CreateAcompananteResponse();
            var mockUsuarioCommand = new Mock<IUsuarioCommand>();
            var mockUsuarioQuery = new Mock<IUsuarioQuery>();
            var mockPropuestaCommand = new Mock<IPropuestaCommand>();

            IAcompanteService service = new AcompananteService(mockAcompananteCommand.Object, mockAcompananteQuery.Object, mapping, mockUsuarioCommand.Object, mockUsuarioQuery.Object, mockPropuestaCommand.Object);

            var atObraSocialDTO = new AcompananteObraSocialDTO
            {
                AcompananteId = 1,
                ObraSocialId = 1,
            };

            mockAcompananteCommand.Setup(q => q.CreateAcompanante(It.IsAny<Acompanante>())).ReturnsAsync(1);

            var acompanante = new Acompanante
            {
                AcompananteId = 1,
                UsuarioId = 1,
                ZonaLaboral = "Berazategui",
                ObraSocialId = 2,
                Contacto = "123456789",
                Documentacion = "Documento de prueba",
                EspecialidadId = 1,
                Experiencia = "5 años",
                Disponibilidad = Convert.ToInt16("000011110110110", 2),
                ObrasSociales = new List<AcompananteObraSocial>(),
                Especialidades = new List<AcompananteEspecialidad>(),
            };

            var obraSocial = new ObraSocial
            {
                ObraSocialId = 2,
                Nombre = "Soap",
                Descripcion = "La mejor",
            };

            var atobrasocial = new AcompananteObraSocial
            {
                AcompananteId = 1,
                Acompanante = acompanante,
                ObrasocialId = 2,
                ObraSocial = obraSocial,
            };

            mockAcompananteQuery.Setup(q => q.GetAcompananteById(It.IsAny<int>())).ReturnsAsync(acompanante);

            mockAcompananteCommand.Setup(q => q.CreateAcompanteObraSocial(It.IsAny<AcompananteObraSocial>()));

            //Act
            var result = await service.CreateAcompanteObraSocial(atObraSocialDTO);

            //Asserts
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateAcompanteEspecialidad_Correctamente()
        {
            //Arrange
            var mockAcompananteCommand = new Mock<IAcompananteCommand>();
            var mockAcompananteQuery = new Mock<IAcompananteQuery>();
            ICreateAcompananteResponse mapping = new CreateAcompananteResponse();
            var mockUsuarioCommand = new Mock<IUsuarioCommand>();
            var mockUsuarioQuery = new Mock<IUsuarioQuery>();
            var mockPropuestaCommand = new Mock<IPropuestaCommand>();

            IAcompanteService service = new AcompananteService(mockAcompananteCommand.Object, mockAcompananteQuery.Object, mapping, mockUsuarioCommand.Object, mockUsuarioQuery.Object, mockPropuestaCommand.Object);

            var atEspecialidadDTO = new AcompananteEspecialidadDTO
            {
                AcompananteId = 1,
                EspecialidadId = 2,
            };

            var acompanante = new Acompanante
            {
                AcompananteId = 1,
                UsuarioId = 1,
                ZonaLaboral = "Berazategui",
                ObraSocialId = 2,
                Contacto = "123456789",
                Documentacion = "Documento de prueba",
                EspecialidadId = 1,
                Experiencia = "5 años",
                Disponibilidad = Convert.ToInt16("000011110110110", 2),
                ObrasSociales = new List<AcompananteObraSocial>(),
                Especialidades = new List<AcompananteEspecialidad>(),
            };

            mockAcompananteQuery.Setup(q => q.GetAcompananteById(It.IsAny<int>())).ReturnsAsync(acompanante);

            mockAcompananteCommand.Setup(q => q.CreateAcompanante(It.IsAny<Acompanante>())).ReturnsAsync(1);

            var especialidad = new Especialidad
            {
                EspecialidadId = 1,
                Descripcion = "Muy buen cuidado",
            };

            var atEspecialidad = new AcompananteEspecialidad
            {
                AcompananteId = 1,
                Acompanante = acompanante,
                EspecialidadId = 1,
                Especialidad = especialidad,
            };

            especialidad.Acompanantes = new List<AcompananteEspecialidad> { atEspecialidad };

            acompanante.Especialidades = new List<AcompananteEspecialidad> { atEspecialidad };

            var atEspecialidadSegunda = new AcompananteEspecialidad
            {
                AcompananteId = 1,
                Acompanante = acompanante,
                EspecialidadId = 2,
                Especialidad = especialidad,
            };

            mockAcompananteCommand.Setup(q => q.CreateAcompanteEspecialidad(It.IsAny<AcompananteEspecialidad>())).ReturnsAsync(atEspecialidadSegunda);


            //Act
            var result = await service.CreateAcompanteEspecialidad(atEspecialidadDTO);

            //Asserts
            Assert.NotNull(result); //Franco, fijate bien esto porque tengo sueño y soy peligroso, espero que puedas mejorarlo, con cariño franco con sueño <3.
        }

        [Fact]
        public async Task CreateAcompanteEspecialidad_ExcepcionRelacionExistente()
        {
            //Arrange
            var mockAcompananteCommand = new Mock<IAcompananteCommand>();
            var mockAcompananteQuery = new Mock<IAcompananteQuery>();
            ICreateAcompananteResponse mapping = new CreateAcompananteResponse();
            var mockUsuarioCommand = new Mock<IUsuarioCommand>();
            var mockUsuarioQuery = new Mock<IUsuarioQuery>();
            var mockPropuestaCommand = new Mock<IPropuestaCommand>();

            IAcompanteService service = new AcompananteService(mockAcompananteCommand.Object, mockAcompananteQuery.Object, mapping, mockUsuarioCommand.Object, mockUsuarioQuery.Object, mockPropuestaCommand.Object);

            var atEspecialidadDTO = new AcompananteEspecialidadDTO
            {
                AcompananteId = 1,
                EspecialidadId = 1,
            };

            var acompanante = new Acompanante
            {
                AcompananteId = 1,
                UsuarioId = 1,
                ZonaLaboral = "Berazategui",
                ObraSocialId = 2,
                Contacto = "123456789",
                Documentacion = "Documento de prueba",
                EspecialidadId = 1,
                Experiencia = "5 años",
                Disponibilidad = Convert.ToInt16("000011110110110", 2),
                ObrasSociales = new List<AcompananteObraSocial>(),
                Especialidades = new List<AcompananteEspecialidad>(),
            };

            mockAcompananteQuery.Setup(q => q.GetAcompananteById(It.IsAny<int>())).ReturnsAsync(acompanante);

            mockAcompananteCommand.Setup(q => q.CreateAcompanante(It.IsAny<Acompanante>())).ReturnsAsync(1);

            var especialidad = new Especialidad
            {
                EspecialidadId = 1,
                Descripcion = "Muy buen cuidado",
            };

            var atEspecialidad = new AcompananteEspecialidad
            {
                AcompananteId = 1,
                Acompanante = acompanante,
                EspecialidadId = 1,
                Especialidad = especialidad,
            };

            especialidad.Acompanantes = new List<AcompananteEspecialidad> { atEspecialidad };

            acompanante.Especialidades = new List<AcompananteEspecialidad> { atEspecialidad };


            mockAcompananteCommand.Setup(q => q.CreateAcompanteEspecialidad(It.IsAny<AcompananteEspecialidad>())).ReturnsAsync(atEspecialidad);


            //Act & Assert
            await Assert.ThrowsAsync<RelacionExistenteException>(async () => await service.CreateAcompanteEspecialidad(atEspecialidadDTO));
        }

        [Fact]
        public async Task CreateAcompanteEspecialidad_EspecialidadInexistente()
        {
            //Arrange
            var mockAcompananteCommand = new Mock<IAcompananteCommand>();
            var mockAcompananteQuery = new Mock<IAcompananteQuery>();
            ICreateAcompananteResponse mapping = new CreateAcompananteResponse();
            var mockUsuarioCommand = new Mock<IUsuarioCommand>();
            var mockUsuarioQuery = new Mock<IUsuarioQuery>();
            var mockPropuestaCommand = new Mock<IPropuestaCommand>();

            IAcompanteService service = new AcompananteService(mockAcompananteCommand.Object, mockAcompananteQuery.Object, mapping, mockUsuarioCommand.Object, mockUsuarioQuery.Object, mockPropuestaCommand.Object);

            var atEspecialidadDTO = new AcompananteEspecialidadDTO
            {
                AcompananteId = 1,
                EspecialidadId = 2,
            };

            var acompanante = new Acompanante
            {
                AcompananteId = 1,
                UsuarioId = 1,
                ZonaLaboral = "Berazategui",
                ObraSocialId = 2,
                Contacto = "123456789",
                Documentacion = "Documento de prueba",
                EspecialidadId = 1,
                Experiencia = "5 años",
                Disponibilidad = Convert.ToInt16("000011110110110", 2),
                ObrasSociales = new List<AcompananteObraSocial>(),
                Especialidades = new List<AcompananteEspecialidad>(),
            };

            mockAcompananteQuery.Setup(q => q.GetAcompananteById(It.IsAny<int>())).ReturnsAsync(acompanante);

            mockAcompananteCommand.Setup(q => q.CreateAcompanante(It.IsAny<Acompanante>())).ReturnsAsync(1);

            var especialidad = new Especialidad
            {
                EspecialidadId = 1,
                Descripcion = "Escolar",
            };

            var atEspecialid = new AcompananteEspecialidad
            {
                AcompananteId = 1,
                Acompanante = acompanante,
                EspecialidadId = 1,
                Especialidad = especialidad,
            };

            mockAcompananteCommand.Setup(q => q.CreateAcompanteEspecialidad(It.IsAny<AcompananteEspecialidad>()));

            //Act
            var result = await service.CreateAcompanteEspecialidad(atEspecialidadDTO);

            //Asserts
            Assert.Null(result);
        }

        [Fact]
        public async Task PutPropuesta()
        {
            //Arrange
            var mockAcompananteCommand = new Mock<IAcompananteCommand>();
            var mockAcompananteQuery = new Mock<IAcompananteQuery>();
            ICreateAcompananteResponse mapping = new CreateAcompananteResponse();
            var mockUsuarioCommand = new Mock<IUsuarioCommand>();
            var mockUsuarioQuery = new Mock<IUsuarioQuery>();
            var mockPropuestaCommand = new Mock<IPropuestaCommand>();

            IAcompanteService service = new AcompananteService(mockAcompananteCommand.Object, mockAcompananteQuery.Object, mapping, mockUsuarioCommand.Object, mockUsuarioQuery.Object, mockPropuestaCommand.Object);

            var propuesta = new PropuestaResponse
            {
                PropuestaId = 1,
                TutorId = 1,
                AcompananteId = 1,
                InfoAdicional= "Escolar",
                Monto = 200000,
                EstadoPropuesta = 1,
                Descripcion = "A la grande le puse cuca"
            };

            mockPropuestaCommand.Setup(q => q.PutPropuesta(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(propuesta);

            //Act
            var result = await service.PutPropuesta(1,1);

            //Asserts
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetATIdbyUsuarioId()
        {
            //Arrange
            var mockAcompananteCommand = new Mock<IAcompananteCommand>();
            var mockAcompananteQuery = new Mock<IAcompananteQuery>();
            ICreateAcompananteResponse mapping = new CreateAcompananteResponse();
            var mockUsuarioCommand = new Mock<IUsuarioCommand>();
            var mockUsuarioQuery = new Mock<IUsuarioQuery>();
            var mockPropuestaCommand = new Mock<IPropuestaCommand>();

            IAcompanteService service = new AcompananteService(mockAcompananteCommand.Object, mockAcompananteQuery.Object, mapping, mockUsuarioCommand.Object, mockUsuarioQuery.Object, mockPropuestaCommand.Object);

            mockAcompananteQuery.Setup(q => q.GetAcompananteIdByUsuarioId(It.IsAny<int>())).ReturnsAsync(1);

            //Act
            var result = await service.GetATIdbyUsuarioId(1);

            //Asserts
            Assert.NotNull(result);
        }

    }
}