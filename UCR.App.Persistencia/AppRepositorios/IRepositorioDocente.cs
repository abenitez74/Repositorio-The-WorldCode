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
        
        Docente GetDocente(int id);
        
        //UpdateProfesor

        Docente UpdateDocente(Docente docente);

        //DeleteProfesor
        bool DeleteDocente(int id);

        //getAllProfesor
        IEnumerable<Docente> GetAllDocentes();

        //GetDocenteEstado
        Docente GetDocenteEstado(int idDocente);
    }
}
