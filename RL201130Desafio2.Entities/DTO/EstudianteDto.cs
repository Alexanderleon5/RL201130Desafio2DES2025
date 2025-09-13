using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RL201130Desafio2.Entities.DTO
{
    public class EstudianteDto
    {
        public int Codigo { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string NombreEstudiante { get; set; } = string.Empty;
        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "El formato del email no es valido")]
        public string EmailEstudiante { get; set; } = string.Empty;
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        public DateTime FechaNacimiento { get; set; }
    }
}