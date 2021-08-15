using Backend.Shared.Entities.CustomValidation;

namespace Backend.Shared.Entities.DTOs.v2
{
    public class RequestPersonaJuridicaDTO
    {
        [CustomStringValidator]
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        [CustomStringValidator]
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }

        [CustomIntValidator]
        public int TipoDocumento { get; set; }
        [CustomIntValidator]
        public int NumeroIdentificacion { get; set; }
        public string TelefonoFijo { get; set; }
        [CustomStringValidator]
        public string TelefonoCelular { get; set; }
        [CustomEmailValidator]
        public string Email { get; set; }
        [CustomIntValidator]
        public int TipoDocumentoRepresentanteLegal { get; set; }
        [CustomIntValidator]
        public int NumeroDocumentoRepresentanteLegal { get; set; }
        [CustomStringValidator]
        public string NombreRazonSocial { get; set; }

    }
}
