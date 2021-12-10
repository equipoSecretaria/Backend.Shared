using Backend.Shared.Entities.Responses;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    public interface ICertificadoDefuncionBusiness
    {
        /// <summary>
        /// ValidateCertificadoDefuncion
        /// </summary>
        /// <param name="numeroIdentificacion"></param>
        /// <returns></returns>
        Task<ResponseBase<dynamic>> ValidateCertificadoDefuncion(string numeroIdentificacion);
    }
}
