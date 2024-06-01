﻿using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class EmprestimoController : Controller
    {
        readonly private ApplicationDbContext _db;

        public EmprestimoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<EmprestimoModel> emprestimos = _db.Emprestimo;
            return View(emprestimos);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(EmprestimoModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                _db.Emprestimo.Add(emprestimo);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimoModel emprestimo = _db.Emprestimo.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Editar(EmprestimoModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                _db.Emprestimo.Update(emprestimo);
                _db.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(emprestimo);
        }
    }
}
