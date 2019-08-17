using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoDeProjetos.Application.IAppServices;
using GestaoDeProjetos.Application.ViewModels;
using GestaoDeProjetos.Application.ViewModels.NotMapped;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestaoDeProjetos.WebSite.Controllers
{
    public class EquipeController : Controller
    {
        private readonly IEquipeAppService _equipeAppService;
        private readonly IPessoaAppService _pessoaAppService;

        public EquipeController(IEquipeAppService equipeAppService, IPessoaAppService pessoaAppService)
        {
            _equipeAppService = equipeAppService;
            _pessoaAppService = pessoaAppService;
        }

        // GET: Equipe
        public IActionResult Index()
        {
            return View(_equipeAppService.ObterTodos());
        }

        // GET: Equipe/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipe = _equipeAppService.ObterPorId(id);
            if (equipe == null)
            {
                return NotFound();
            }

            return View(equipe);
        }

        // GET: Equipe/Create
        public IActionResult Create()
        {
            ViewBag.Pessoas = _pessoaAppService.ObterTodos().Select(p => new SelectListItem()
            {
                Text = p.Nome,
                Value = p.Id.ToString()
            }).OrderBy(x => x.Text).ToList();

            return View();
        }
        // POST: Equipe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome,CoordenadorId,Descricao,IntegrantesId")] EquipePessoasProjetoViewModel equipePessoasProjeto)
        {
            if (ModelState.IsValid)
            {
                var equipe = new EquipeViewModel()
                {
                    Nome = equipePessoasProjeto.Nome,
                    Descricao = equipePessoasProjeto.Descricao
                };
                _equipeAppService.Adicionar(equipe, equipePessoasProjeto.CoordenadorId, equipePessoasProjeto.IntegrantesId);
                return RedirectToAction(nameof(Index));
            }
            return View(equipePessoasProjeto);
        }

        // GET: Equipe/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipe = _equipeAppService.ObterPorId(id);
            if (equipe == null)
            {
                return NotFound();
            }
            return View(equipe);
        }
        // POST: Equipe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("Nome,Funcao,Setor,Contato,Empresa,Id")] EquipeViewModel equipe)
        {
            if (id != equipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _equipeAppService.Editar(equipe);

                return RedirectToAction(nameof(Index));
            }
            return View(equipe);
        }
        // GET: Equipe/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipe = _equipeAppService.ObterPorId(id);

            if (equipe == null)
            {
                return NotFound();
            }

            return View(equipe);
        }
        // POST: Equipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            _equipeAppService.Deletar(id);

            return RedirectToAction(nameof(Index));
        }
    }
}


    
