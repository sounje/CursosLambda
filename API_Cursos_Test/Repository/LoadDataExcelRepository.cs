using API_Cursos_Test.Helpers;
using API_Cursos_Test.Interfaces;
using API_Cursos_Test.Model;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace API_Cursos_Test.Repository
{
    public class LoadDataExcelRepository(IConfiguration config) : ILoadDataExcel
    {
        private string? _connectionString = config.GetConnectionString("DefaultConnection");

        public async Task<bool> SendDataExcel(UploadRequest model)
        {
            //var nameFile = model.ImportFile.FileName;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("InsertExcelData", connection))
                {
                   
                    try
                    {
                        // Especificar el tipo explícitamente, DataExcelImportModel
                        Console.WriteLine(model.ImportFile);
                        var x = model.ImportFile.ReadDataFromExcel<DataExcelImportModel>();
                        Console.WriteLine(x);
                        DataTable cursosTable = x.ToDataTable();
                        Console.WriteLine(cursosTable);
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter tvpParam = command.Parameters.AddWithValue("@data", cursosTable);
                        tvpParam.SqlDbType = SqlDbType.Structured;
                        command.Parameters.AddWithValue("@period", model.Periodo);
                        command.Parameters.AddWithValue("@user", model.Usuario);
                        command.Parameters.AddWithValue("@name", model.ImportFile.FileName);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex);
                        throw;
                    }

                   
                    try
                    {
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        return true;
                    }
                    catch (SqlException)
                    {
                        if (connection.State != ConnectionState.Closed)
                        {
                            await connection.CloseAsync();
                        }
                        //throw;
                        return false;
                    }
                   
                }
            }
        }

        public async Task<bool> SendDataJson(DataToSend model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("InsertExcelData", connection))
                {
                    DataTable cursosTable = model.Data.ToDataTable();

                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter tvpParam = command.Parameters.AddWithValue("@data", cursosTable);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    command.Parameters.AddWithValue("@period", model.Period);
                    //SqlParameter outputParam = new()
                    //{
                    //    ParameterName = "@OutputParamName",
                    //    SqlDbType = SqlDbType.Int, 
                    //    Direction = ParameterDirection.Output,
                    //};
                    //command.Parameters.AddWithValue("@OutputParamName", outputParam);
                    try
                    {
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                        
                        
                        return true;
                    }
                    catch (SqlException)
                    {
                        if (connection.State != ConnectionState.Closed)
                        {
                            await connection.CloseAsync();
                        }
                        //throw;
                        return false;
                    }

                }
            }


        }
    }

    
   

}
