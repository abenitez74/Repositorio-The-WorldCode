using System;
using UCR.App.Dominio;
using UCR.App.Persistencia;
using System.Collections.Generic;

namespace UCR.App.Consola
{
    class Program
    {
        private static IRepositorioDocente _repoDocente = new RepositorioDocente(new Persistencia.AppContext());
        private static IRepositorioEstados _repoEstados = new RepositorioEstados(new Persistencia.AppContext());
        private static IRepositorioRestaurante _repoRestaurante = new RepositorioRestaurante(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /*
            Docente docenteConsultado = ConsultarDocenteEstado(2);
            Console.WriteLine(docenteConsultado.nombre);
            Console.WriteLine(docenteConsultado.appellidos);
            Console.WriteLine(docenteConsultado.estadoCovid_1);
            Console.WriteLine(docenteConsultado.estadoCovid_1.Sistomas);
            */
            
            //CrearDocente();
            //ConsultarDocente(3);
            //ConsultarDocentes();            
            //EditarDocente(4);
            //EliminarDocente(3);
            /*
                EstadoCovid  estadoNuevo= new EstadoCovid{
                Sintomas  = "Prueba Rapida",
                FechaDiagonostico = DateTime.Now.ToString(),
                tipoEstadoCovid= TipoEstadoCovid.Tos
            };

            AgregarEstadoDocente(estadoNuevo,2);
            */
            //EstadoCovid estadoCovidEncontrado  = _repoEstados.GetEstado(3);
            //AgregarEstadoDocente(estadoCovidEncontrado,1);

            AgregarRestaurante();
        }
        //CRUD
        //CrearDocente
        private static void CrearDocente()
        {

            EstadoCovid  Covid_eje_1 = new EstadoCovid{
                Sintomas  = "Prueba Rapida",
                FechaDiagonostico = DateTime.Now.ToString(),
                tipoEstadoCovid= TipoEstadoCovid.fiebre
                
            };

            var docente = new Docente{
                nombre = "Maria",
                appellidos = "Salcedo",
                identificacion = 1105389345,
                edad= 17,
                estadoCovid_1 = Covid_eje_1,
                turno = null,
                facultad = "Ingles",
                cubiculo = "7"
            };
            Docente docenteGuardado=_repoDocente.AddDocente(docente);
            if (docenteGuardado!=null)
                Console.WriteLine("Se registró un docente con éxito");
                else
                {
                    Console.WriteLine("Hubo un error de conexión con la base de datos");
                }
        }
        //ConsultarDocente

        private static Docente ConsultarDocente(int idDocente)
        {
            Docente docenteEncontrado = _repoDocente.GetDocente(idDocente);
            if (docenteEncontrado!=null)
                {   
                    Console.WriteLine(docenteEncontrado.nombre);
                    return docenteEncontrado;
                }
            else
            {
                Console.WriteLine("Docente no encontrado");
                return null;
            }
        }
        //EditarDocente
        private static void EditarDocente(int idDocente)
        {

            EstadoCovid  Covid_eje_2 = new EstadoCovid{
                Sintomas  = "Prueba PCR",
                FechaDiagonostico = DateTime.Now.ToString(),
                tipoEstadoCovid= TipoEstadoCovid.Perdida_olfato
                
            };

            var docente = new Docente{
                id =idDocente,
                nombre = "Carlos Humberto",
                appellidos = "Ospina Garcia",
                identificacion = 29134567,
                edad=27,
                estadoCovid_1= Covid_eje_2,
                turno=null,
                facultad = "Ciencias Naturales",
                cubiculo = "14"
            };
            var docenteActualizado = _repoDocente.UpdateDocente(docente);
            if (docenteActualizado!=null)
            {
                Console.WriteLine("Se actualizó el docente con identificación: " + docenteActualizado.identificacion);
            }else
            {
                Console.WriteLine("No se encontró el docente que se iba a actualizar");
            }

        }
        //EliminarDocente
        private static void EliminarDocente(int id)
        {
            
            if(_repoDocente.DeleteDocente(id))
                Console.WriteLine("Docente Eliminado");
            else
            {
                Console.WriteLine("No se pudo eliminar el docente con esta identificación,\nverifique que es la identificación correcta.");
            }
        }

        //ConsultarDocentes
        
        private static void ConsultarDocentes()
        {
            IEnumerable<Docente> Result_docentes = _repoDocente.GetAllDocentes();

            foreach(var iterador in Result_docentes)
            {
            Console.WriteLine(iterador.nombre + "  " + iterador.appellidos+ "  " + iterador.facultad);
                
            }

        }

        private static void AgregarEstadoDocente(EstadoCovid estadoCovid, int idDocente)
        {
            Docente docenteEncontrado = _repoDocente.GetDocente(idDocente);
            docenteEncontrado.estadoCovid_1 = estadoCovid;
            _repoDocente.UpdateDocente(docenteEncontrado);
        }

        private static Docente ConsultarDocenteEstado(int idDocente)
        {
            return _repoDocente.GetDocenteEstado(idDocente);
        }

        private static Restaurante AgregarRestaurante()
        {
            var restauranteCreado = new Restaurante
            {
                aforo = 30,
                numeroMesas = 5,
                comensales = null
            };
            return _repoRestaurante.AddRestaurante(restauranteCreado);

        } 

    }
}
