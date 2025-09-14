using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using RL201130Desafio2.DAL.Interfaces;
using RL201130Desafio2.Entities.Models;

namespace RL201130Desafio2.DAL
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly IDatabaseRepository _databaseRepository;
        public InstructorRepository(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }
        public async Task<List<Instructor>>GetInstructoresAsync()
        {
            string query = "SELECT * FROM Instructor";
            return await _databaseRepository.GetDataByQueryAsync<Instructor>(query);
        }
        public async Task<Instructor>GetInstructorByIdAsync(int id)
        {
            string query = "SELECT * FROM Instructor WHERE IdInstructor = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await _databaseRepository.GetDataByIdAsync<Instructor>(query, parameters);
        }
        public async Task<int>InsertInstructorAsync(Instructor instructor)
        {
            string query = "INSERT INTO Instructor (Nombre, Especialidad, Email) VALUES (@Nombre, @Especialidad, @Email); SELECT SCOPE_IDENTITY()";
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", instructor.Nombre);
            parameters.Add("@Especialidad", instructor.Especialidad);
            parameters.Add("@Email", instructor.Email);
            return await _databaseRepository.InsertAsync(query, parameters);
        }
        public async Task<Instructor>UpdateInstructorAsync(Instructor instructor)
        {
            string query = "UPDATE Instructor SET Nombre = @Nombre, Especialidad = @Especialidad, Email = @Email WHERE IdInstructor = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", instructor.IdInstructor);
            parameters.Add("@Nombre", instructor.Nombre);
            parameters.Add("@Especialidad", instructor.Especialidad);
            parameters.Add("@Email", instructor.Email);
            await _databaseRepository.UpdateAsync<Instructor>(query, parameters);
            return instructor;
        }
        public async Task<bool>DeleteInstructorAsync(int id)
        {
            string query = "DELETE FROM Instructor WHERE IdInstructor = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await _databaseRepository.DeleteAsync(query, parameters);
        }
    }
}