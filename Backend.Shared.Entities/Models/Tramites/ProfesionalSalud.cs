using Microsoft.VisualBasic;

namespace Backend.Shared.Entities.Models.Tramites
{
    public partial class ProfesionalSalud
    {
        public string TIPO_I { get; set; }
        public int NROIDENT { get; set; }
        public string SITIO_EXP_IDENT { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string DIRECCION_CONSULTORIO { get; set; }
        public string DIRECCION1_CONSULTORIO { get; set; }
        public string TELEFONO_CONSULTORIO { get; set; }
        public string TELEFONO1_CONSULTORIO { get; set; }
        public string SEXO { get; set;}
        public DateFormat FECHA_NACIMIENTO { get; set; }
        public string CIUDAD_RESIDENCIA { get; set; }
        public int  BAR_CODIGO { get; set; }
        public string TELEFONO_MOVIL { get; set; }
        public string NOMBRE1 { get; set; }
        public string NOMBRE2 { get; set; }
        public string APELLIDO { get; set; }
        public string APELLIDO2 { get; set; }
        public string CORREO_ELECTRONICO { get; set; }
        
        
        
    }
}