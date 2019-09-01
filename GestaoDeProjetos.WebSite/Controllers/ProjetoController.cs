using GestaoDeProjetos.Application.IAppServices;
using GestaoDeProjetos.Application.ViewModels;
using GestaoDeProjetos.Application.ViewModels.NotMapped;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace GestaoDeProjetos.WebSite.Controllers
{
    [Authorize]
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
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = _projetoAppService.ObterPorId(id);
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
        public IActionResult Create([Bind("NomeProjeto,Descricao,Prioridade,DataInicio,DataPrevista,Relatorio,CoordenadorId,EquipeId")] ProjetoPessoaEquipeViewModel projetoPessoaEquipe)
        {
            if (ModelState.IsValid)
            {
                var projeto = new ProjetoViewModel()
                {
                    Nome = projetoPessoaEquipe.NomeProjeto,
                    Descricao = projetoPessoaEquipe.Descricao,
                    Prioridade = projetoPessoaEquipe.Prioridade,
                    DataInicio = projetoPessoaEquipe.DataInicio,
                    DataPrevista = projetoPessoaEquipe.DataPrevista,
                    Relatorio = projetoPessoaEquipe.Relatorio,
                    Status = "Início"
                };
                _projetoAppService.Adicionar(projeto, projetoPessoaEquipe.CoordenadorId, projetoPessoaEquipe.EquipeId);
                return RedirectToAction(nameof(Index));
            }

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
            return View(projetoPessoaEquipe);
        }

        // GET: Projeto/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = _projetoAppService.ObterPorId(id);
            if (projeto == null)
            {
                return NotFound();
            }

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

            var projetoPessoaEquipe = new ProjetoPessoaEquipeViewModel()
            {
                Id = projeto.Id,
                NomeProjeto = projeto.Nome,
                Descricao = projeto.Descricao,
                Status = projeto.Status,
                Prioridade = projeto.Prioridade,
                DataInicio = projeto.DataInicio,
                DataPrevista = projeto.DataPrevista,
                Relatorio = projeto.Relatorio,
                Progresso = projeto.Progresso,
                CoordenadorId = projeto.CoordenadorId,
                EquipeId = projeto.EquipeId
            };

            return View(projetoPessoaEquipe);
        }

        // POST: Projeto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("NomeProjeto,Descricao,Prioridade,DataInicio,DataPrevista,Relatorio,Id,CoordenadorId,EquipeId")] ProjetoPessoaEquipeViewModel projetoPessoaEquipe)
        {
            if (id != projetoPessoaEquipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var projeto = new ProjetoViewModel()
                {
                    Id = id,
                    Nome = projetoPessoaEquipe.NomeProjeto,
                    Descricao = projetoPessoaEquipe.Descricao,
                    Prioridade = projetoPessoaEquipe.Prioridade,
                    DataInicio = projetoPessoaEquipe.DataInicio,
                    DataPrevista = projetoPessoaEquipe.DataPrevista,
                    Relatorio = projetoPessoaEquipe.Relatorio
                };

                _projetoAppService.Editar(projeto, projetoPessoaEquipe.CoordenadorId, projetoPessoaEquipe.EquipeId);

                return RedirectToAction(nameof(Index));
            }

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
            return View(projetoPessoaEquipe);
        }

        // GET: Projeto/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = _projetoAppService.ObterPorId(id);

            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // POST: Projeto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            _projetoAppService.Deletar(id);

            return RedirectToAction(nameof(Index));
        }
    }
}