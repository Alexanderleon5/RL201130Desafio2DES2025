using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RL201130Desafio2.Entities.DTO
{
    public class InscripcionDto
    {
        public int Codigo { get; set; }
        [Required(ErrorMessage = "La fecha de inscripcion es requerida")]
        public DateTime FechaInscripcion { get; set; }
        [Required(ErrorMessage = "El estudiante es requerido")]
        public int IdEstudiante { get; set; }
        [Required(ErrorMessage = "El curso es requerido")]
        public int IdCurso { get; set; }
    }
}