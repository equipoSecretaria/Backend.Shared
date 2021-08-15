using System;

namespace Backend.Shared.Entities.Models.Tramites
{
    public partial class Persona
    {
        public int IdPersona { get; set; }
        public int TipoIdentificacion { get; set; }
        public long NumeIdentificacion { get; set; }
        public string PNombre { get; set; }
        public string SNombre { get; set; }
        public string PApellido { get; set; }
        public string SApellido { get; set; }
        public string Email { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoCelular { get; set; }
        public int? Nacionalidad { get; set; }
        public int? Departamento { get; set; }
        public int? CiudadNacimiento { get; set; }
        public string CiudadNacimientoOtro { get; set; }
        public int? DepaResi { get; set; }
        public int? CiudadResi { get; set; }
        public string DireResi { get; set; }
        public short? Estadogeo { get; set; }
        public float Cx { get; set; }
        public float Cy { get; set; }
        public string DirCodificada { get; set; }
        public int? Zona { get; set; }
        public int? Localidad { get; set; }
        public int? Upz { get; set; }
        public string Barrio { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? Edad { get; set; }
        public int? Sexo { get; set; }
        public int? Genero { get; set; }
        public int? Orientacion { get; set; }
        public int? Etnia { get; set; }
        public int? EstadoCivil { get; set; }
        public int? NivelEducativo { get; set; }
        public int? TipoIdenRl { get; set; }
        public int? NumeIdenRl { get; set; }
        public string NombreRs { get; set; }
    }
}
