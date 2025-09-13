using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RL201130Desafio2.Entities.Models
{
    public class Instructor
    {
        [Key]
        public int IdInstructor { get; set; }
        public required string Nombre { get; set; }
        public required string Especialidad { get; set; }
        public required string Email { get; set; }
    }
}