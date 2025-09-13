using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RL201130Desafio2.Entities.Models
{
    public class Inscripcion
    {
        [Key]
        public int IdInscripcion { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public int IdEstudiante { get; set; }
        public int IdCurso { get; set; }
    }
}   