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
    public class InscripcionRepository : IInscripcionRepository
    {
        private readonly IDatabaseRepository _databaseRepository;

        public InscripcionRepository(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }
        public async Task<List<Inscripcion>> GetInscripcionesAsync()
        {
            string query = "SELECT * FROM Inscripcion";
            return await _databaseRepository.GetDataByQueryAsync<Inscripcion>(query);
        }

        public async Task<Inscripcion> GetInscripcionByIdAsync(int id)
        {
            string query = "SELECT * FROM Inscripcion WHERE IdInscripcion = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await _databaseRepository.GetDataByIdAsync<Inscripcion>(query, parameters);
        }

        public async Task<int> InsertInscripcionAsync(Inscripcion inscripcion)
        {
            string query = "INSERT INTO Inscripcion (FechaInscripcion, IdEstudiante, IdCurso) VALUES (@FechaInscripcion, @IdEstudiante, @IdCurso); SELECT SCOPE_IDENTITY()";
            var parameters = new DynamicParameters();
            parameters.Add("@FechaInscripcion", inscripcion.FechaInscripcion);
            parameters.Add("@IdEstudiante", inscripcion.IdEstudiante);
            parameters.Add("@IdCurso", inscripcion.IdCurso);
            return await _databaseRepository.InsertAsync(query, parameters);
        }

        public async Task<Inscripcion> UpdateInscripcionAsync(Inscripcion inscripcion)
        {
            string query = "UPDATE Inscripcion SET FechaInscripcion = @FechaInscripcion, IdEstudiante = @IdEstudiante, IdCurso = @IdCurso WHERE IdInscripcion = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", inscripcion.IdInscripcion);
            parameters.Add("@FechaInscripcion", inscripcion.FechaInscripcion);
            parameters.Add("@IdEstudiante", inscripcion.IdEstudiante);
            parameters.Add("@IdCurso", inscripcion.IdCurso);
            await _databaseRepository.UpdateAsync<Inscripcion>(query, parameters);
            return inscripcion;
        }

        public async Task<bool> DeleteInscripcionAsync(int id)
        {
            string query = "DELETE FROM Inscripcion WHERE IdInscripcion = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await _databaseRepository.DeleteAsync(query, parameters);
        }

        public async Task<bool> InscripcionExistsAsync(int idEstudiante, int idCurso)
        {
            string query = "SELECT COUNT(1) FROM Inscripcion WHERE IdEstudiante = @IdEstudiante AND IdCurso = @IdCurso";
            var parameters = new DynamicParameters();
            parameters.Add("@IdEstudiante", idEstudiante);
            parameters.Add("@IdCurso", idCurso);
            var count = await _databaseRepository.GetDataByIdAsync<int>(query, parameters);
            return count > 0;
        }
    }
}