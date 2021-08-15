using Backend.Shared.Entities.CustomValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Shared.Entities.DTOs.v2
{
    public class RequestPersonaNaturalDTO
    {
        [CustomIntValidator]
        public int TipoDocumento { get; set; }
        [CustomLongValidator]
        public long NumeroIdentificacion { get; set; }

        [CustomStringValidator]
        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        [CustomStringValidator]
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }

        [CustomEmailValidator]
        public string Email { get; set; }

        public string TelefonoFijo { get; set; }
        //validar solo numeros
        public string TelefonoCelular { get; set; }

        //datos geograficos
        [CustomIntValidator]
        public int Nacionalidad { get; set; }

        [CustomIntValidator]
        public int Departamento { get; set; }

        [CustomIntValidator]
        public int CiudadNacimiento { get; set; }

        public string CiudadNacimientoOtro { get; set; }

        [CustomIntValidator]
        public int DepartamentoResidencia { get; set; }

        [CustomIntValidator]
        public int CiudadResidencia { get; set; }

        [CustomStringValidator]
        public string DireccionResidencia { get; set; }

        //public short Estadogeo { get; set; }
        //public string DireccionCodificada { get; set; }
        //[CustomStringValidator]

        //[CustomIntValidator]
        //public int Zona { get; set; }

        //[CustomIntValidator]
        //public int Localidad { get; set; }

        //[CustomIntValidator]
        //public int Upz { get; set; }

        //[CustomStringValidator]
        //public string Barrio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        //public int Edad { get; set; }

        //Datos demograficos
        [CustomIntValidator]
        public int Sexo { get; set; }

        [CustomIntValidator]
        public int Genero { get; set; }

        [CustomIntValidator]
        public int OrientacionSexual { get; set; }
        [CustomIntValidator]
        public int Etnia { get; set; }

        [CustomIntValidator]
        public int EstadoCivil { get; set; }

        [CustomIntValidator]
        public int NivelEducativo { get; set; }

        ////representante legal
        //public int TipoDocumentoRepresentanteLegal { get; set; }
        //public int NumeroDocumentoRepresentanteLegal { get; set; }
        //public string NombreRepresentanteLegal { get; set; }

    }
}
