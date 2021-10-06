using System.Collections.Generic;
using UCR.App.Dominio;
using System.Linq;

namespace UCR.App.Persistencia
{
    public class RepositorioDocente : IRepositorioDocente
    {
        private readonly AppContext _appContext;

        public RepositorioDocente(AppContext appContext)
        {
            _appContext = appContext;
        }

        //CRUD 
        //AgregarProfesor
        Docente IRepositorioDocente.AddDocente(Docente docente)
        {
            var docenteAdicionado = _appContext.Docentes.Add(docente);
            _appContext.SaveChanges();
            return docenteAdicionado.Entity;
        }
        //BuscarDocente
        Docente IRepositorioDocente.GetDocente(int identificacion)
        {
            var docenteEncontrado = _appContext.Docentes.FirstOrDefault(p => p.identificacion==identificacion);
            return docenteEncontrado;
        }
        //ActualizarDocente
        Docente IRepositorioDocente.UpdateDocente(Docente docente)
        {
            var docenteEncontrado = _appContext.Docentes.FirstOrDefault(p=>p.identificacion==docente.identificacion);
            if (docenteEncontrado!=null)
            {
                docenteEncontrado.nombre = docente.nombre;
                docenteEncontrado.appellidos = docente.appellidos;
                docenteEncontrado.edad= docente.edad;
                docenteEncontrado.identificacion = docente.identificacion;
                docenteEncontrado.facultad = docente.facultad;
                docenteEncontrado.cubiculo = docente.cubiculo;
                _appContext.SaveChanges();          
            }
            return docenteEncontrado;
        }
        //BorrarDocente

        bool IRepositorioDocente.DeleteDocente(int identificacion)
        {
            var docenteEncontrado = _appContext.Docentes.FirstOrDefault(p=>p.identificacion==identificacion);
            if (docenteEncontrado==null)
                return false;
            _appContext.Docentes.Remove(docenteEncontrado);
            _appContext.SaveChanges();
            return true;
        }

        //BuscarDocentes
        IEnumerable<Docente> IRepositorioDocente.GetAllDocentes()
        {
            
            return _appContext.Docentes;
            
        }

    }
}