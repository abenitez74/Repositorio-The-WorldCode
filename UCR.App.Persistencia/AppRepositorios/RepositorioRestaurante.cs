using System.Collections.Generic;
using UCR.App.Dominio;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace UCR.App.Persistencia
{
    public class RepositorioRestaurante : IRepositorioRestaurante
    {
        private static AppContext _appContext;

        public RepositorioRestaurante(AppContext appContext)
        {
            _appContext = appContext;
        }

        //CRUD 
        //AgregarProfesor
        Restaurante IRepositorioRestaurante.AddRestaurante(Restaurante restaurante)
        {
            var RestauranteAdicionado = _appContext.Restaurante.Add(restaurante);
            _appContext.SaveChanges();
            return RestauranteAdicionado.Entity;
        }
        //BuscarRestaurante
        Restaurante IRepositorioRestaurante.GetRestaurante(int restauranteid)
        {
            var RestauranteEncontrado = _appContext.Restaurante.FirstOrDefault(p => p.id==restauranteid);
            return RestauranteEncontrado;
        }
        //ActualizarRestaurante
        Restaurante IRepositorioRestaurante.UpdateRestaurante(Restaurante restaurante)
        {
            var RestauranteEncontrado = _appContext.Restaurante.FirstOrDefault(p=>p.id==restaurante.id);
            if (RestauranteEncontrado!=null)
            {
                RestauranteEncontrado.aforo = restaurante.aforo; 
                RestauranteEncontrado.numeroMesas = restaurante.numeroMesas;
                RestauranteEncontrado.comensales =restaurante.comensales;
                _appContext.SaveChanges();          
            }
            return RestauranteEncontrado;
        }
        //BorrarRestaurante

        bool IRepositorioRestaurante.DeleteRestaurante(int restauranteid)
        {
            var RestauranteEncontrado = _appContext.Restaurante.FirstOrDefault(p=>p.id==restauranteid);
            if (RestauranteEncontrado==null)
                return false;
            _appContext.Restaurante.Remove(RestauranteEncontrado);
            _appContext.SaveChanges();
            return true;
        }

        //BuscarRestaurantes
        IEnumerable<Restaurante> IRepositorioRestaurante.GetAllRestaurantes()
        {
            
            return _appContext.Restaurante;
            
        }
    }
}