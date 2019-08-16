using GestaoDeProjetos.Application.IAppServices;
using GestaoDeProjetos.Application.ViewModels;
using GestaoDeProjetos.Application.ViewModels.NotMapped;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace GestaoDeProjetos.WebSite.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly IProjetoAppService _projetoAppService;
        private readonly IPessoaAppService _pessoaAppService;
        private readonly IEquipeAppService _equipeAppService;

        public ProjetoController(IProjetoAppService projetoAppService, IPessoaAppService pessoaAppService, IEquipeAppService equipeAppService)
        {
            _projetoAppService = projetoAppService;
            _pessoaAppService = pessoaAppService;
            _equipeAppService = equipeAppService;
        }

        // GET: Projeto
        public IActionResult Index()
        {
            return View(_projetoAppService.ObterTodos());
        }

        // GET: Projeto/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = _projetoAppService.ObterPorId(id.Value);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // GET: Projeto/Create
        public IActionResult Create()
        {
            ViewBag.Coordenador = _pessoaAppService.ObterTodos().Select(p => new SelectListItem()
            {
                Text = p.Nome,
                Value = p.Id.ToString()
            }).ToList();
            ViewBag.Equipes = _equipeAppService.ObterTodos().Select(p => new SelectListItem()
            {
                Text = p.Nome,
                Value = p.Id.ToString()
            }).ToList();

            return View();
        }

        // POST: Projeto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("NomeProjeto,Descricao,Prioridade,DataPrevista,Relatorio,CoordenadorId,EquipeId")] ProjetoPessoaEquipeViewModel projetoPessoaEquipe)
        {
            if (ModelState.IsValid)
            {
                var projeto = new ProjetoViewModel()
                {
                    Nome = projetoPessoaEquipe.NomeProjeto,
                    Descricao = projetoPessoaEquipe.Descricao,
                    Prioridade = projetoPessoaEquipe.Prioridade,
                    DataPrevista = projetoPessoaEquipe.DataPrevista,
                    Relatorio = projetoPessoaEquipe.Relatorio
                };
                _projetoAppService.Adicionar(projeto, projetoPessoaEquipe.CoordenadorId, projetoPessoaEquipe.EquipeId);
                return RedirectToAction(nameof(Index));
            }
            return View(projetoPessoaEquipe);
        }

        // GET: Projeto/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = _projetoAppService.ObterPorId(id.Value);
            if (projeto == null)
            {
                return NotFound();
            }

            ViewBag.Coordenador = _pessoaAppService.ObterTodos().Select(p => new SelectListItem()
            {
                Text = p.Nome,
                Value = p.Id.ToString()
            }).ToList();
            ViewBag.Coordenador = _equipeAppService.ObterTodos().Select(p => new SelectListItem()
            {
                Text = p.Nome,
                Value = p.Id.ToString()
            }).ToList();

            return View(projeto);
        }

        // POST: Projeto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("NomeProjeto,Descricao,Prioridade,DataPrevista,Relatorio,Id,CoordenadorId,EquipeId")] ProjetoPessoaEquipeViewModel projetoPessoaEquipe)
        {
            if (id != projetoPessoaEquipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var projeto = new ProjetoViewModel()
                {
                    Nome = projetoPessoaEquipe.NomeProjeto,
                    Descricao = projetoPessoaEquipe.Descricao,
                    Prioridade = projetoPessoaEquipe.Prioridade,
                    DataPrevista = projetoPessoaEquipe.DataPrevista,
                    Relatorio = projetoPessoaEquipe.Relatorio
                };

                _projetoAppService.Editar(projeto, projetoPessoaEquipe.CoordenadorId, projetoPessoaEquipe.EquipeId);

                return RedirectToAction(nameof(Index));
            }
            return View(projetoPessoaEquipe);
        }

        // GET: Projeto/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = _projetoAppService.ObterPorId(id.Value);

            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // POST: Projeto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _projetoAppService.Deletar(id);

            return RedirectToAction(nameof(Index));
        }
    }
}