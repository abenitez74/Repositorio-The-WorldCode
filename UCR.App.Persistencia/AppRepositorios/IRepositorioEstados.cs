using System.Collections.Generic;
using UCR.App.Dominio;

namespace UCR.App.Persistencia
{
    public interface IRepositorioEstados
    {
        //CRUD create - read- update - dlete
        //AddEstado
        EstadoCovid AddEstado(EstadoCovid estadoCovid);
        //GetEstado
        
        EstadoCovid GetEstado(int idEstado);
        
        //UpdateEstado

        EstadoCovid UpdateEstado(EstadoCovid estadoCovid);

        //DeleteEstado
        bool DeleteEstado(int estadoid);

        //getAllProfesor
        IEnumerable<EstadoCovid> GetAllEstadosCovid();

        
    }
}
