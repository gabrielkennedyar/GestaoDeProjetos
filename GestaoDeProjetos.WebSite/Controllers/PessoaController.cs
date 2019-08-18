using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestaoDeProjetos.Application.ViewModels;
using GestaoDeProjetos.Application.IAppServices;
using GestaoDeProjetos.Application.ViewModels.NotMapped;

namespace GestaoDeProjetos.WebSite.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaAppService _pessoaAppService;

        public PessoaController(IPessoaAppService pessoaAppService)
        {
            _pessoaAppService = pessoaAppService;
        }

        // GET: Pessoa
        public IActionResult Index()
        {
            return View(_pessoaAppService.ObterTodos());
        }

        // GET: Pessoa/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = _pessoaAppService.ObterPorId(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            var detalhepessoas = new DetalhesPessoaViewModel
            {
                Id = pessoa.Id,
                Funcao = pessoa.Funcao,
                Nome = pessoa.Nome,
                DataCadastro = pessoa.DataCadastro,
                Projetos = pessoa.ProjetosCoordenados,
                PessoasEquipe = pessoa.PessoasEquipes
            };

            return View(detalhepessoas);
        }

        // GET: Pessoa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome,Funcao,Setor,Contato,Empresa,Id")] PessoaViewModel pessoa)
        {
            if (ModelState.IsValid)
            {
                _pessoaAppService.Adicionar(pessoa);
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        // GET: Pessoa/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = _pessoaAppService.ObterPorId(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("Nome,Funcao,Setor,Contato,Empresa,Id")] PessoaViewModel pessoa)
        {
            if (id != pessoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _pessoaAppService.Editar(pessoa);

                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        // GET: Pessoa/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = _pessoaAppService.ObterPorId(id);
                
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // POST: Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            _pessoaAppService.Deletar(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
