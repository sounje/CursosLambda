using API_Cursos_Test.Model;

namespace API_Cursos_Test.Interfaces
{
    public interface ILoadDataExcel
    {
        Task<bool> SendDataJson(DataToSend model);
        Task<bool> SendDataExcel(UploadRequest model);
    }
}
