using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoDeProjetos.Application.IAppServices;
using GestaoDeProjetos.Application.ViewModels;
using GestaoDeProjetos.Application.ViewModels.NotMapped;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestaoDeProjetos.WebSite.Controllers
{
    [Authorize]
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

            var detalheEquipe = new DetalhesEquipeViewModel
            {
                Id = equipe.Id,
                Nome = equipe.Nome,
                Descricao = equipe.Descricao,
                DataCadastro = equipe.DataCadastro,
                DataModificacao = equipe.DataModificacao,
                Projetos = equipe.Projetos,
                PessoasEquipe = equipe.PessoasEquipes
            };

            return View(detalheEquipe);
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

            ViewBag.Pessoas = _pessoaAppService.ObterTodos().Select(p => new SelectListItem()
            {
                Text = p.Nome,
                Value = p.Id.ToString()
            }).OrderBy(x => x.Text).ToList();
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

            ViewBag.Pessoas = _pessoaAppService.ObterTodos().Select(p => new SelectListItem()
            {
                Text = p.Nome,
                Value = p.Id.ToString()
            }).OrderBy(x => x.Text).ToList();
            var equipePessoasProjeto = new EquipePessoasProjetoViewModel()
            {
                Id = equipe.Id,
                Nome = equipe.Nome,
                CoordenadorId = equipe.CoordenadorId,
                Descricao = equipe.Descricao,
                IntegrantesId = equipe.PessoasEquipes.Select(x => x.Pessoa.Id).ToArray(),
                DataCadastro = equipe.DataCadastro
            };

            ViewBag.Pessoas = _pessoaAppService.ObterTodos().Select(p => new SelectListItem()
            {
                Text = p.Nome,
                Value = p.Id.ToString()
            }).OrderBy(x => x.Text).ToList();
            return View(equipePessoasProjeto);
        }
        // POST: Equipe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("Nome,CoordenadorId,Descricao,IntegrantesId,Id")] EquipePessoasProjetoViewModel equipePessoasProjeto)
        {
            if (id != equipePessoasProjeto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var equipe = new EquipeViewModel()
                {
                    Id = id,
                    Nome = equipePessoasProjeto.Nome,
                    Descricao = equipePessoasProjeto.Descricao
                };

                _equipeAppService.Editar(equipe, equipePessoasProjeto.CoordenadorId, equipePessoasProjeto.IntegrantesId);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Pessoas = _pessoaAppService.ObterTodos().Select(p => new SelectListItem()
            {
                Text = p.Nome,
                Value = p.Id.ToString()
            }).OrderBy(x => x.Text).ToList();
            return View(equipePessoasProjeto);
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


    
