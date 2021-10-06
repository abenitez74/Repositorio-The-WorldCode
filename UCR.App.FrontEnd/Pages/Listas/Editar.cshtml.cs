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
        
        public IActionResult OnGet(int docenteIdentificacion)
        {
            Console.WriteLine(docenteIdentificacion);
            docente=_repoDocente.GetDocente(docenteIdentificacion);

            if (docente==null)
            {
                return RedirectToPage("./Docentes");
            }else
            {
                return Page();
            }
        }
        public IActionResult onPost()
        {
            _repoDocente.UpdateDocente(docente);
            return RedirectToPage("./Docentes");
        }
    }
}
