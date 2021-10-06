using System;

namespace UCR.App.Dominio
{
    public class Persona 
    {
        public int id{get;set;}

        public string nombre{get;set;}
        
        public string appellidos{get;set;}
        
        public int identificacion{get;set;}
        
        public int edad{get;set;}
        
        public bool estadoCovid{get;set;}

        public Turno turno{get;set;}
    }
}