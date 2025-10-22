using API_Cursos_Test.Interfaces;
using API_Cursos_Test.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_Cursos_Test.Repository
{
    public class FilterRepository(IConfiguration config) : IFilterCursos
    {
        private string? _connectionString = config.GetConnectionString("DefaultConnection");

        public async Task<IEnumerable<FacultyFilterModel>?> GetFacultyList()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("GetListFaculty", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        await connection.OpenAsync();
                        using var reader = await command.ExecuteReaderAsync();
                        List<FacultyFilterModel> listFaculty = new List<FacultyFilterModel>();
                        while (await reader.ReadAsync())
                        {
                            listFaculty.Add(new FacultyFilterModel
                            {
                                Id = reader.GetGuid("Id"),
                                Name = reader.GetString("Name")
                            });
                        }
                        return listFaculty;
                    }
                    catch (SqlException)
                    {
                        if (connection.State != ConnectionState.Closed)
                        {
                            await connection.CloseAsync();
                        }
                        //throw;
                        return null;
                    }

                }
            }
        }

        public async Task<IEnumerable<CareerFilterModel>?> GetCareerList(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("GetListCareerByFaculty", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    try
                    {
                        await connection.OpenAsync();
                        using var reader = await command.ExecuteReaderAsync();
                        List<CareerFilterModel> listCareer = new List<CareerFilterModel>();
                        while (await reader.ReadAsync())
                        {
                            listCareer.Add(new CareerFilterModel
                            {
                                Id = reader.GetGuid("Id"),
                                Name = reader.GetString("Name")
                            });
                        }
                        return listCareer;
                    }
                    catch (SqlException)
                    {
                        if (connection.State != ConnectionState.Closed)
                        {
                            await connection.CloseAsync();
                        }
                        //throw;
                        return null;
                    }

                }
            }
        }
    }
}
