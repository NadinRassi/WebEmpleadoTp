using SistemaWebEmpleado.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaWebEmpleado.Models
{
    [Table("Empleado")]
    public class Empleado
    {

        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Apellido { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string DNI { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        [RegularExpression("[A]{1}[1-9]{5}$")]
        public string Legajo { get; set; }

        [AfterYear2000]
        public DateTime FechaNacimiento { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Titulo { get; set; }

    }
}
