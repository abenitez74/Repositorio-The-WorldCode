using System;

namespace UCR.App.Dominio
{
    public class Restaurante 
    {
        public int id{get;set;}
        public int aforo{get;set;}
        public int numeroMesas{get;set;}
        public System.Collections.Generic.List<Persona> comensales{get;set;}
    }
}