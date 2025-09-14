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
    public class CursoRepository : ICursoRepository
    {
        private readonly IDatabaseRepository _databaseRepository;

        public CursoRepository(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }
        public async Task<List<Curso>> GetCursosAsync()
        {
            string query = "SELECT * FROM Curso";
            return await _databaseRepository.GetDataByQueryAsync<Curso>(query);
        }
        public async Task<Curso> GetCursoByIdAsync(int id)
        {
            string query = "SELECT * FROM Curso WHERE IdCurso = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await _databaseRepository.GetDataByIdAsync<Curso>(query, parameters);
        }
        public async Task<int> InsertCursoAsync(Curso curso)
        {
            string query = "INSERT INTO Curso (Titulo, Descripcion, Nivel, IdInstructor) VALUES (@Titulo, @Descripcion, @Nivel, @IdInstructor); SELECT SCOPE_IDENTITY()";
            var parameters = new DynamicParameters();
            parameters.Add("@Titulo", curso.Titulo);
            parameters.Add("@Descripcion", curso.Descripcion);
            parameters.Add("@Nivel", curso.Nivel);
            parameters.Add("@IdInstructor", curso.IdInstructor);
            return await _databaseRepository.InsertAsync(query, parameters);
        }
        public async Task<Curso> UpdateCursoAsync(Curso curso)
        {
            string query = "UPDATE Curso SET Titulo = @Titulo, Descripcion = @Descripcion, Nivel = @Nivel, IdInstructor = @IdInstructor WHERE IdCurso = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", curso.IdCurso);
            parameters.Add("@Titulo", curso.Titulo);
            parameters.Add("@Descripcion", curso.Descripcion);
            parameters.Add("@Nivel", curso.Nivel);
            parameters.Add("@IdInstructor", curso.IdInstructor);
            await _databaseRepository.UpdateAsync<Curso>(query, parameters);
            return curso;
        }
        public async Task<bool> DeleteCursoAsync(int id)
        {
            string query = "DELETE FROM Curso WHERE IdCurso = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await _databaseRepository.DeleteAsync(query, parameters);
        }
        public async Task<bool> InstructorExistsAsync(int idInstructor)
        {
            string query = "SELECT COUNT(1) FROM Instructor WHERE IdInstructor = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", idInstructor);
            var count = await _databaseRepository.GetDataByIdAsync<int>(query, parameters);
            return count > 0;
        }
    }
}