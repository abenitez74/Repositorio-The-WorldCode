using System.Collections.Generic;
using UCR.App.Dominio;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace UCR.App.Persistencia
{
    public class RepositorioEstados : IRepositorioEstados
    {
        private static AppContext _appContext;

        public RepositorioEstados(AppContext appContext)
        {
            _appContext = appContext;
        }

        //CRUD 
        //AgregarProfesor
        EstadoCovid IRepositorioEstados.AddEstado(EstadoCovid estadoCovid)
        {
            var estadoCovidAdicionado = _appContext.Estados.Add(estadoCovid);
            _appContext.SaveChanges();
            return estadoCovidAdicionado.Entity;
        }
        //BuscarDocente
        EstadoCovid IRepositorioEstados.GetEstado(int idEstado)
        {

            var estadoCovidEncontrado = _appContext.Estados.FirstOrDefault(p => p.id==idEstado);
            Console.WriteLine(estadoCovidEncontrado.Sintomas);
            return estadoCovidEncontrado;
        }
        //ActualizarEstadoCovid
        EstadoCovid IRepositorioEstados.UpdateEstado(EstadoCovid estadoCovid)
        {
            var estadoCovidEncontrado = _appContext.Estados.FirstOrDefault(p=>p.id==estadoCovid.id);
            if (estadoCovidEncontrado!=null)
            {
                estadoCovidEncontrado.Sintomas = estadoCovid.Sintomas;
                estadoCovidEncontrado.FechaDiagonostico = estadoCovid.FechaDiagonostico;
                estadoCovidEncontrado.tipoEstadoCovid= estadoCovid.tipoEstadoCovid;

                
                _appContext.SaveChanges();          
            }
            return estadoCovidEncontrado;
        }
        //BorrarEstado

        bool IRepositorioEstados.DeleteEstado(int estadoCovidId)
        {
            var estadoCovidEncontrado = _appContext.Estados.FirstOrDefault(p=>p.id==estadoCovidId);
            if (estadoCovidEncontrado==null)
                return false;
            _appContext.Estados.Remove(estadoCovidEncontrado);
            _appContext.SaveChanges();
            return true;
        }

        //BuscarEstados
        IEnumerable<EstadoCovid> IRepositorioEstados.GetAllEstadosCovid()
        {
            
            return _appContext.Estados;
            
        }

    }
}