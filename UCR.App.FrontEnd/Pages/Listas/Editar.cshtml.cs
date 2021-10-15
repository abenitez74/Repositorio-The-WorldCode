using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UCR.App.Persistencia;
using UCR.App.Dominio;
namespace UCR.App.Frontend.Pages
{
    public class EditarModel : PageModel
    {

        private static IRepositorioDocente _repoDocente = new RepositorioDocente(new Persistencia.AppContext());
        [BindProperty]
        
        public Docente docente{get;set;}
        
        public IActionResult OnGet(int? docenteIdentificacion)
        {
            
            if(docenteIdentificacion.HasValue)
            {
                docente = _repoDocente.GetDocente(docenteIdentificacion.Value);
            }
            else
            {
                docente = new Docente(); 
            }
            
            
            if (docente==null)
            {
                return RedirectToPage("./Docentes");
            }else
            {
                return Page();
            }
        }
                
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }else
            {
                if(docente.id>0)
            {

                _repoDocente.UpdateDocente(docente);
            }else{
                Console.WriteLine(docente);
                _repoDocente.AddDocente(docente);
            }    
            }
            return RedirectToPage("./Docentes");
        }
    }
}
