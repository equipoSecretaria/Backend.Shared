using Backend.Shared.Entities.DTOs.v2;
using Backend.Shared.Entities.Interface.Repository;
using Backend.Shared.Entities.Responses;
using Backend.Shared.Utilities.Telemetry;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Backend.Shared.BusinessRules
{
    public class PersonaBusiness : Entities.Interface.Business.IPersonaBusiness
    {
        #region Attributes

        /// <summary>
        /// The repository inhumaciones
        /// </summary>
        private readonly IBaseRepositoryCommonsMySQL<Entities.Models.Tramites.Persona> _repositoryPersona;

        /// <summary>
        /// The telemetry exception
        /// </summary>
        private readonly ITelemetryException TelemetryException;
        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonaBusiness"/> class.
        /// </summary>
        /// <param name="telemetryException">The telemetry exception.</param>
        /// <param name="repositoryPersona">The repository persona.</param>
        public PersonaBusiness(ITelemetryException telemetryException,
                               IBaseRepositoryCommonsMySQL<Entities.Models.Tramites.Persona> repositoryPersona)
        {
            TelemetryException = telemetryException;
            _repositoryPersona = repositoryPersona;
        }
        #endregion

        #region Methods

        /// <summary>
        /// AddPersonaJuridica
        /// </summary>
        /// <param name="requestPersonaJuridicaDTO"></param>
        /// <returns></returns>
        public async Task<ResponseBase<int>> AddPersonaJuridica(RequestPersonaJuridicaDTO requestPersonaJuridicaDTO)
        {
            try
            {
                var result = await _repositoryPersona.GetAsync(predicate: p => p.NumeIdentificacion.Equals(requestPersonaJuridicaDTO.NumeroIdentificacion));

                if (result != null)
                {
                    return new ResponseBase<int>(HttpStatusCode.BadRequest, message: "El documento ya se encuentra registrado");
                }
                var objPersona = new Entities.Models.Tramites.Persona();

                if (requestPersonaJuridicaDTO.TipoDocumento == 5)
                {
                    objPersona = new Entities.Models.Tramites.Persona
                    {
                        PNombre = requestPersonaJuridicaDTO.PrimerNombre,
                        SNombre = requestPersonaJuridicaDTO.SegundoNombre,
                        PApellido = requestPersonaJuridicaDTO.PrimerApellido,
                        SApellido = requestPersonaJuridicaDTO.SegundoApellido,
                        TipoIdentificacion = requestPersonaJuridicaDTO.TipoDocumento,
                        NumeIdentificacion = requestPersonaJuridicaDTO.NumeroIdentificacion,
                        TelefonoFijo = requestPersonaJuridicaDTO.TelefonoFijo,
                        TelefonoCelular = requestPersonaJuridicaDTO.TelefonoCelular,
                        Email = requestPersonaJuridicaDTO.Email,
                        DirCodificada = "",
                        TipoIdenRl = requestPersonaJuridicaDTO.TipoDocumentoRepresentanteLegal,
                        NumeIdenRl = requestPersonaJuridicaDTO.NumeroDocumentoRepresentanteLegal,
                        NombreRs = requestPersonaJuridicaDTO.NombreRazonSocial
                    };
                }
                else
                {
                    return new ResponseBase<int>(HttpStatusCode.BadRequest, message: "El Tipo de Documento no es Valido");
                }

                await _repositoryPersona.AddAsync(objPersona);

                return new ResponseBase<int>(HttpStatusCode.OK, message: "Solicitud OK", data: objPersona.IdPersona);

            }
            catch (Exception ex)
            {
                TelemetryException.RegisterException(ex);
                return new ResponseBase<int>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// AddPersonaNatural
        /// </summary>
        /// <param name="personaDTO"></param>
        /// <returns></returns>
        public async Task<ResponseBase<int>> AddPersonaNatural(Shared.Entities.DTOs.v2.RequestPersonaNaturalDTO personaDTO)
        {
            try
            {
                var result = await _repositoryPersona.GetAsync(predicate: p => p.NumeIdentificacion.Equals(personaDTO.NumeroIdentificacion));

                if (result != null)
                {
                    return new ResponseBase<int>(HttpStatusCode.BadRequest, message: "El documento ya se encuentra registrado");
                }
                var objPersona = new Entities.Models.Tramites.Persona();

                if (personaDTO.TipoDocumento != 5)
                {
                    objPersona = new Entities.Models.Tramites.Persona
                    {
                        PNombre = personaDTO.PrimerNombre,
                        SNombre = personaDTO.SegundoNombre,
                        PApellido = personaDTO.PrimerApellido,
                        SApellido = personaDTO.SegundoApellido,
                        TipoIdentificacion = personaDTO.TipoDocumento,
                        NumeIdentificacion = personaDTO.NumeroIdentificacion,
                        TelefonoFijo = personaDTO.TelefonoFijo,
                        TelefonoCelular = personaDTO.TelefonoCelular,
                        Email = personaDTO.Email,
                        Nacionalidad = personaDTO.Nacionalidad,
                        Departamento = personaDTO.Departamento,
                        CiudadNacimiento = personaDTO.CiudadNacimiento,
                        CiudadNacimientoOtro = personaDTO.CiudadNacimientoOtro,
                        DepaResi = personaDTO.DepartamentoResidencia,
                        CiudadResi = personaDTO.CiudadResidencia,
                        DireResi = personaDTO.DireccionResidencia,
                        DirCodificada = "",
                        FechaNacimiento = personaDTO.FechaNacimiento,
                        Sexo = personaDTO.Sexo,
                        Genero = personaDTO.Genero,
                        Orientacion = personaDTO.OrientacionSexual,
                        Etnia = personaDTO.Etnia,
                        EstadoCivil = personaDTO.EstadoCivil,
                        NivelEducativo = personaDTO.NivelEducativo
                    };
                }
                else
                {
                    return new ResponseBase<int>(HttpStatusCode.BadRequest, message: "El Tipo de Documento no es Valido");
                }
                await _repositoryPersona.AddAsync(objPersona);

                return new ResponseBase<int>(HttpStatusCode.OK, message: "Solicitud OK", data: objPersona.IdPersona);
            }
            catch (Exception ex)
            {
                TelemetryException.RegisterException(ex);
                return new ResponseBase<int>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion
    }
}
