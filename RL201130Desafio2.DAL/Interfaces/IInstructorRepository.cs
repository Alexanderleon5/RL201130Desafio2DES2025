using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RL201130Desafio2.Entities.Models;

namespace RL201130Desafio2.DAL.Interfaces
{
    public interface IInstructorRepository
    {
        Task<List<Instructor>> GetInstructoresAsync();
        Task<Instructor> GetInstructorByIdAsync(int id);
        Task<int> InsertInstructorAsync(Instructor instructor);
        Task<Instructor> UpdateInstructorAsync(Instructor instructor);
        Task<bool> DeleteInstructorAsync(int id);
    }
}