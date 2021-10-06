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
    public class DetallesModel : PageModel
    {
        private static IRepositorioDocente _repoDocente = new RepositorioDocente(new Persistencia.AppContext());

        public Docente docente{get;set;}
        public IActionResult OnGet(int docenteId)
        {
            docente = _repoDocente.GetDocente(docenteId);
            if(docente == null)
            {
                return RedirectToPage("./Docentes");
            }
            return Page();
        }
    }
}
