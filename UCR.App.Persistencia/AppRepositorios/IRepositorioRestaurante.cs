using System.Collections.Generic;
using UCR.App.Dominio;

namespace UCR.App.Persistencia
{
    public interface IRepositorioRestaurante
    {
        //CRUD create - read- update - dlete
        //AddProfesor
        Restaurante AddRestaurante(Restaurante restaurante);
        //GetProfesor
        
        Restaurante GetRestaurante(int restauranteid);
        
        //UpdateProfesor

        Restaurante UpdateRestaurante(Restaurante restaurante);

        //DeleteProfesor
        bool DeleteRestaurante(int restauranteid);

        //getAllProfesor
        IEnumerable<Restaurante> GetAllRestaurantes();

        //GetRestauranteEstado

    }
}
