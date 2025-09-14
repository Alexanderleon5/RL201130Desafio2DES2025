using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RL201130Desafio2.Entities.DTO;

namespace RL201130Desafio2.BL.Interfaces
{
    public interface IInstructorService
    {
        Task<List<InstructorDto>> GetInstructoresAsync();
        Task<InstructorDto> GetInstructorByIdAsync(int id);
        Task<int> InsertInstructorAsync(InstructorDto instructor);
        Task<InstructorDto> UpdateInstructorAsync(InstructorDto instructor);
        Task<bool> DeleteInstructorAsync(int id);
    }
}