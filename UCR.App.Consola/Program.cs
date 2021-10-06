using System;
using UCR.App.Dominio;
using UCR.App.Persistencia;
using System.Collections.Generic;

namespace UCR.App.Consola
{
    class Program
    {
        private static IRepositorioDocente _repoDocente = new RepositorioDocente(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //CrearDocente();
            //ConsultarDocente(94456890);
            //ConsultarDocentes();            
            EditarDocente();
        }
        //CRUD
        //CrearDocente
        private static void CrearDocente()
        {

            Restaurante restaurante_eje_1 = new Restaurante{
                aforo = 30,
                numeroMesas = 12,
                
            };



            var docente = new Docente{
                nombre = "Alberto",
                appellidos = "Benitez",
                identificacion = 94229312,
                edad= 47,
                estadoCovid=false,
                turno = null,
                facultad = "Ingenieria de Sistemas",
                cubiculo = "4"
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

        private static void ConsultarDocente(int identificacion)
        {
            Docente docenteEncontrado = _repoDocente.GetDocente(identificacion);
            if (docenteEncontrado!=null)
                Console.WriteLine(docenteEncontrado.nombre);
            else
            {
                Console.WriteLine("Docente no encontrado");
            }
        }
        //EditarDocente
        private static void EditarDocente()
        {
            var docente = new Docente{
                nombre = "Alberto Nacianceno",
                appellidos = "Benitez Bahena",
                identificacion = 94229312,
                edad=47,
                estadoCovid=false,
                turno=null,
                facultad = "Derecho",
                cubiculo = "4"
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
        private static void EliminarDocente(int identificacion)
        {
            if(_repoDocente.DeleteDocente(identificacion))
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

    }
}
