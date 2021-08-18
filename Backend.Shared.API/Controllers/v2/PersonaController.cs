using Backend.Shared.Entities.CustomValidation;
using Backend.Shared.Entities.Interface.Business;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers.v2
{
    /// <summary>
    /// public class HomeController : Controller
    /// </summary>
    [ApiController, Route("api/v2/[controller]")]
    public class PersonaController : ControllerBase
    {
        #region Attributes
        /// <summary>
        /// personaBusiness
        /// </summary>
        private readonly IPersonaBusiness _personaBusiness;
        #endregion

        #region Constructor
        /// <summary>
        /// PersonaController
        /// </summary>
        /// <param name="personaBusiness"></param>
        public PersonaController(IPersonaBusiness personaBusiness)
        {
            _personaBusiness = personaBusiness;
        }
        #endregion

        #region Methods
        /// <summary>
        /// AddPersonaNatural
        /// </summary>
        /// <param name="personaDTO"></param>
        /// <returns></returns>
        [HttpPost("AddPersonaNatural")]
        [ValidateModel]
        public async Task<ActionResult> AddPersonaNatural(Entities.DTOs.v2.RequestPersonaNaturalDTO personaDTO)
        {
            var result = await _personaBusiness.AddPersonaNatural(personaDTO);
            return StatusCode(result.Code, result);
        }

        /// <summary>
        /// AddPersonaJuridica
        /// </summary>
        /// <param name="requestPersonaJuridicaDTO"></param>
        /// <returns></returns>
        [HttpPost("AddPersonaJuridica")]
        [ValidateModel]
        public async Task<ActionResult> AddPersonaJuridica(Entities.DTOs.v2.RequestPersonaJuridicaDTO requestPersonaJuridicaDTO)
        {
            var result = await _personaBusiness.AddPersonaJuridica(requestPersonaJuridicaDTO);
            return StatusCode(result.Code, result);
        }


        /// <summary>
        /// GetInfoUserById
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpGet("GetInfoUserById/{idUser}")]
        public async Task<ActionResult> GetInfoUserById(int idUser)
        {
            var result = await _personaBusiness.GetInfoUserById(idUser);
            return StatusCode(result.Code, result);
        }
        #endregion
    }
}
