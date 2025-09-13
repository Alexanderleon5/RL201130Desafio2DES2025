using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RL201130Desafio2.Entities.DTO
{
    public class CursoDto
    {
        public int Codigo { get; set; }
        [Required(ErrorMessage = "El titulo es requerido")]
        [StringLength(150, ErrorMessage = "El titulo no puede tener más de 150 caracteres")]
        public string TituloCurso { get; set; } = string.Empty;
        [Required(ErrorMessage = "La descripcion es requerida")]
        [StringLength(300, ErrorMessage = "La descripcion no puede tener mas de 300 caracteres")]
        public string DescripcionCurso { get; set; } = string.Empty;
        [Required(ErrorMessage = "El nivel es requerido")]
        [RegularExpression("^(Basico|intermedio|avanzado)$", ErrorMessage = "El nivel debe ser basico, intermedio o avanzado")]
        public string NivelCurso { get; set; } = string.Empty;
        [Required(ErrorMessage = "El instructor es requerido")]
        public int IdInstructor { get; set; }
    }
}