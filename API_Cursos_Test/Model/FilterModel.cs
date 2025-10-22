namespace API_Cursos_Test.Model
{
    public class FilterModel
    {
        public string? Name { get; set; }
        public required string Facultad { get; set; }
        public required string Programa { get; set; }
        public string? Nivel { get; set; }
        public string? Tipo { get; set; }
    }
}
