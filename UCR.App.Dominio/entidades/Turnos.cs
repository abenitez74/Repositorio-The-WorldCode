using System;

namespace UCR.App.Dominio
{
    public class Turno 
    {
        public int id{get;set;}
        public Persona Persona {get;set;}
        public DateTime Horario {get;set;}
        public string Menu{get;set;}

        public int PersonaId{get;set;}
        //public Persona Persona{get;set;}
    }
}