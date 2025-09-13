using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RL201130Desafio2.Entities.Models
{
    public class Estudiante
    {
        [Key]
        public int IdEstudiante { get; set; }
        public required string Nombre { get; set; }
        public required string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}