using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PROJETOMVC.Context;
using PROJETOMVC.Models;

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

        public IActionResult Criar()
        {
            return View();
        }
    
        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            if(ModelState.IsValid)
            {
                _db.Contatos.Add(contato);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }


        public IActionResult Editar (int id)
        {
            var contato = _db.Contatos.Find(id);

            if (contato == null)
                return RedirectToAction(nameof(Index));

            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(Contato contato)
        {
            var contatoBanco = _db.Contatos.Find(contato.Id);

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _db.Contatos.Update(contatoBanco);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var contato = _db.Contatos.Find(id);

            if (contato == null)
                return RedirectToAction(nameof(Index));

            return View(contato);
        }

        public IActionResult Deletar(int id)
        {
            var contato = _db.Contatos.Find(id);

            if (contato == null)
                return RedirectToAction(nameof(Index));

            return View(contato);
        }

        [HttpPost]
        public IActionResult Deletar(Contato contato)
        {
            var contatoBanco = _db.Contatos.Find(contato.Id);

            _db.Contatos.Remove(contatoBanco);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }

}