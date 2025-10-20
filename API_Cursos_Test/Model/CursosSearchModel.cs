namespace API_Cursos_Test.Model
{
    public class CursosSearchModel
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? Course { get; set; }
        public string? Career { get; set; }
        public int Credits { get; set; }
        public string? Faculty { get; set; }
        public string? Type { get; set; }
        public string? Incoming { get; set; }
        public string? Graduate { get; set; }
        public string? Requirement { get; set; }
    }
}
