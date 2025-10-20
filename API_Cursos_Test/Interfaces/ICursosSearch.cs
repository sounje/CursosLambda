using API_Cursos_Test.Model;

namespace API_Cursos_Test.Interfaces
{
    public interface ICursosSearch
    {
        Task<IEnumerable<CursosSearchModel>> GetCursosBySearch(FilterModel model);
    }
}
