using System;
using System.ComponentModel.DataAnnotations;

namespace UCR.App.Dominio
{
    public class EstadoCovid
    {
        public int id{get;set;}
        public String Sintomas{get;set;}
        public String  FechaDiagonostico{get;set;}
        public TipoEstadoCovid tipoEstadoCovid{get;set;}
         
    }
}