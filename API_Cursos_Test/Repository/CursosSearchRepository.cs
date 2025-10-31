using API_Cursos_Test.Interfaces;
using API_Cursos_Test.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_Cursos_Test.Repository
{
    public class CursosSearchRepository(IConfiguration config) : ICursosSearch
    {
        private string? _connectionString = config.GetConnectionString("DefaultConnection");

        public async Task<IEnumerable<CursosSearchModel>?> GetCursosBySearch(FilterModel model)
        {
            using (var connection = new SqlConnection(_connectionString)){
                using (var command = new SqlCommand("GetSearchCourse", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", model.Name);
                    command.Parameters.AddWithValue("@facultad", model.Facultad);
                    command.Parameters.AddWithValue("@programa", model.Programa);
                    command.Parameters.AddWithValue("@nivel", model.Nivel);
                    command.Parameters.AddWithValue("@tipo", model.Tipo);

                    try
                    {
                        await connection.OpenAsync();
                        using var reader = await command.ExecuteReaderAsync();
                        List<CursosSearchModel> listCursos = new List<CursosSearchModel>();
                        while (await reader.ReadAsync())
                        {
                            listCursos.Add(new CursosSearchModel
                            {
                                Id = reader.GetGuid("Id"),
                                Code = reader.GetString("Code"),
                                Course = reader.GetString("Course"),
                                Career = reader.GetString("Career"),
                                Credits = reader.GetInt32("Credits"),
                                Faculty = reader.GetString("Faculty"),
                                Type = reader.GetString("Type"),
                                Incoming = reader.GetString("Incoming"),
                                Graduate = reader.GetString("Graduate") ?? "",
                                //Graduate = reader["Graduate"]?.ToString() ?? "",
                                Requirement = reader.GetString("Requirement")
                            });
                        }
                        return listCursos;
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
