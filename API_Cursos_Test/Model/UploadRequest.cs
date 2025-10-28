namespace API_Cursos_Test.Model
{
    public class UploadRequest
    {
        public required IFormFile ImportFile { get; set; }
        public required string Usuario { get; set; }
        public required string Periodo { get; set; }
    }
}
