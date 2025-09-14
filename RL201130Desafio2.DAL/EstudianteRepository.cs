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
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly IDatabaseRepository _databaseRepository;
        public EstudianteRepository(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }
        public async Task<List<Estudiante>> GetEstudiantesAsync()
        {
            string query = "SELECT * FROM Estudiante";
            return await _databaseRepository.GetDataByQueryAsync<Estudiante>(query);
        }
        public async Task<Estudiante> GetEstudianteByIdAsync(int id)
        {
            string query = "SELECT * FROM Estudiante WHERE IdEstudiante = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await _databaseRepository.GetDataByIdAsync<Estudiante>(query, parameters);
        }

        public async Task<int> InsertEstudianteAsync(Estudiante estudiante)
        {
            string query = "INSERT INTO Estudiante (Nombre, Email, FechaNacimiento) VALUES (@Nombre, @Email, @FechaNacimiento); SELECT SCOPE_IDENTITY()";
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", estudiante.Nombre);
            parameters.Add("@Email", estudiante.Email);
            parameters.Add("@FechaNacimiento", estudiante.FechaNacimiento);
            return await _databaseRepository.InsertAsync(query, parameters);
        }
        public async Task<Estudiante> UpdateEstudianteAsync(Estudiante estudiante)
        {
            string query = "UPDATE Estudiante SET Nombre = @Nombre, Email = @Email, FechaNacimiento = @FechaNacimiento WHERE IdEstudiante = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", estudiante.IdEstudiante);
            parameters.Add("@Nombre", estudiante.Nombre);
            parameters.Add("@Email", estudiante.Email);
            parameters.Add("@FechaNacimiento", estudiante.FechaNacimiento);
            await _databaseRepository.UpdateAsync<Estudiante>(query, parameters);
            return estudiante;
        }
        public async Task<bool> DeleteEstudianteAsync(int id)
        {
            string query = "DELETE FROM Estudiante WHERE IdEstudiante = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await _databaseRepository.DeleteAsync(query, parameters);
        }
    }
}