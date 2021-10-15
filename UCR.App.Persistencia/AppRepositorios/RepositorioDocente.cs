using System.Collections.Generic;
using UCR.App.Dominio;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace UCR.App.Persistencia
{
    public class RepositorioDocente : IRepositorioDocente
    {
        private static AppContext _appContext;

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
        Docente IRepositorioDocente.GetDocente(int id)
        {
            var docenteEncontrado = _appContext.Docentes.FirstOrDefault(p => p.id==id);
            return docenteEncontrado;
        }
        //ActualizarDocente
        Docente IRepositorioDocente.UpdateDocente(Docente docente)
        {
            var docenteEncontrado = _appContext.Docentes.FirstOrDefault(p=>p.id==docente.id);
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

        bool IRepositorioDocente.DeleteDocente(int docenteId)
        {
            var docenteEncontrado = _appContext.Docentes.FirstOrDefault(p=>p.id==docenteId);
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

        Docente IRepositorioDocente.GetDocenteEstado(int idDocente)
        {
            return _appContext.Docentes.Include(p=>p.estadoCovid_1).SingleOrDefault(p=>p.id==idDocente);
        }

    }
}