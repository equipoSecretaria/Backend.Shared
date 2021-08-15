using Backend.Shared.Entities.Responses;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    public interface IPersonaBusiness
    {
        /// <summary>
        /// AddPersonaNatural
        /// </summary>
        /// <param name="requestPersonaNaturalDTO"></param>
        /// <returns></returns>
        Task<ResponseBase<int>> AddPersonaNatural(Entities.DTOs.v2.RequestPersonaNaturalDTO requestPersonaNaturalDTO);

        /// <summary>
        /// AddPersonaJuridica
        /// </summary>
        /// <param name="requestPersonaJuridicaDTO"></param>
        /// <returns></returns>
        Task<ResponseBase<int>> AddPersonaJuridica(Entities.DTOs.v2.RequestPersonaJuridicaDTO requestPersonaJuridicaDTO);
    }
}
