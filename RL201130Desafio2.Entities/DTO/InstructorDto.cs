using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RL201130Desafio2.Entities.DTO
{
    public class InstructorDto
    {
        public int Codigo { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string NombreInstructor { get; set; } = string.Empty;
        [Required(ErrorMessage = "La especialidad es requerida")]
        [StringLength(100, ErrorMessage = "La especialidad no puede tener más de 100 caracteres")]
        public string EspecialidadInstructor { get; set; } = string.Empty;
        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        public string EmailInstructor { get; set; } = string.Empty;
    }
}