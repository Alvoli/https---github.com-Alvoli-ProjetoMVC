using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PROJETOMVC.Context;

namespace PROJETOMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AgendaContext _db;
        
        public ContatoController(AgendaContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            var contatos = _db.Contatos.ToList();
            return View(contatos);
        }

    }
}