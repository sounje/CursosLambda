using API_Cursos_Test.Model;

namespace API_Cursos_Test.Interfaces
{
    public interface IFilterCursos
    {
        Task<IEnumerable<FacultyFilterModel>?> GetFacultyList();
        Task<IEnumerable<CareerFilterModel>?> GetCareerList(Guid id);
        
    }
}
