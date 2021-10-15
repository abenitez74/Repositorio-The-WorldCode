using System;
using System.ComponentModel.DataAnnotations;

namespace UCR.App.Dominio
{
    public class Persona 
    {
        public int id{get;set;}
        [Required(ErrorMessage = "Campo nombre obligatorio")]
        [Display(Name = "Nombres")]
        public string nombre{get;set;}
        [Required(ErrorMessage = "Campo apellido obligatorio")]
        [Display(Name = "Apellidos")]
        public string appellidos{get;set;}
        
        [Range(1, 9999999999999, ErrorMessage = "Campo identificacion fuera del rango")]
        public int identificacion{get;set;}
        
        public int edad{get;set;}
        
        public EstadoCovid estadoCovid_1{get;set;}

        public Turno turno{get;set;}
    }
}