using System.Collections.Generic;
using UCR.App.Dominio;

namespace UCR.App.Persistencia
{
    public interface IRepositorioDocente
    {
        //CRUD create - read- update - dlete
        //AddProfesor
        Docente AddDocente(Docente docente);
        //GetProfesor
        
        Docente GetDocente(int identificacion);
        
        //UpdateProfesor

        Docente UpdateDocente(Docente docente);

        //DeleteProfesor
        bool DeleteDocente(int identificacion);

        //getAllProfesor
        IEnumerable<Docente> GetAllDocentes();
    }
}
