using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UCR.App.Persistencia;
using UCR.App.Dominio;
using Microsoft.AspNetCore.Authorization;

namespace UCR.App.FrontEnd.Pages
{
    [Authorize]
    public class DocentesModel : PageModel
    {
        private static IRepositorioDocente _repoDocente = new RepositorioDocente(new Persistencia.AppContext());
        

        public IEnumerable<Docente> Docentes{get;set;}
        
        public void OnGet()
        {
            Docentes = _repoDocente.GetAllDocentes();
            
        }
    }
}
