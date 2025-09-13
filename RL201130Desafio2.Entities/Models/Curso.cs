using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RL201130Desafio2.Entities.Models
{
    public class Curso
    {
        [Key]
        public int IdCurso { get; set; }
        public required string Titulo { get; set; }
        public required string Descripcion { get; set; }
        public required string Nivel { get; set; }
        public int IdInstructor { get; set; }
    }
}