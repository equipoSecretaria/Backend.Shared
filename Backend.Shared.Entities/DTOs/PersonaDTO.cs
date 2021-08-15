using System;

namespace Backend.Shared.Entities.DTOs
{
    public class PersonaDTO
    {
        public string NumeroIdentificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Edad { get; set; }
        public bool CondicionDesplazamiento { get; set; }
        public bool CondicionDiscapacidad { get; set; }
        public bool VictimaConflictoArmado { get; set; }
        public Guid IdTipoDocumento { get; set; }
        public Guid IdGenero { get; set; }
        public Guid IdOrientacionSexual { get; set; }
        public Guid IdEtnia { get; set; }
        public Guid IdEps { get; set; }
        public Guid IdCondicionUsuaria { get; set; }
        public string Correo { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Direccion { get; set; }
        public Guid IdPais { get; set; }
        public Guid? IdDepartamento { get; set; }
        public Guid? IdMunicipio { get; set; }
        public Guid? IdLocalidad { get; set; }
        public Guid? IdBarrio { get; set; }
        public Guid? IdUpz { get; set; }
        public Guid? IdZona { get; set; }
        public bool? PrimeraDosis { get; set; }
        public bool? SegundaDosis { get; set; }
        public DateTime? FechaPrimeraDosis { get; set; }
        public DateTime? FechaSegundaDosis { get; set; }
        public Guid IdLugarAplicacion { get; set; }
        public Guid? IdPrimeraVacuna { get; set; }
        public Guid? IdSegundaVacuna { get; set; }

    }
}
