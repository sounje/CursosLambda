namespace API_Cursos_Test.Model
{
    public class DataExcelModel
    {
        

        public required string Faculty { get; set; }
        public required string CodeCareer { get; set; }
        public required string Career { get; set; }
        public required string CodeDirection { get; set; }
        public required string Direction { get; set; }
        public required string Course { get; set; }
        public required string CodeCourse { get; set; }
        public required string Tipo { get; set; }
        public required int Credits { get; set; }
        public required string Incoming { get; set; }
        public required string Graduate { get; set; }
        public required string Requirement { get; set; }
    }

    public class DataToSend
    {
        public required string Period { get; set; }
        public required IEnumerable<DataExcelModel> Data { get; set; }
        
    }

    public class DataExcelImportModel
    {


        public  string? Faculty { get; set; }
        public  string? CodeCareer { get; set; }
        public  string? Career { get; set; }
        public  string? CodeDirection { get; set; }
        public  string? Direction { get; set; }
        public  string? Course { get; set; }
        public  string? CodeCourse { get; set; }
        public  string? Tipo { get; set; }
        public  int? Credits { get; set; }
        public  string? Incoming { get; set; }
        public  string? Graduate { get; set; }
        public  string? Requirement { get; set; }
    }
}
