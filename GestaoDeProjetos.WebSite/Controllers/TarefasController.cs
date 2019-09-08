using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoDeProjetos.Application.IAppServices;
using GestaoDeProjetos.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestaoDeProjetos.WebSite.Controllers
{
    public class TarefasController : Controller
    {
        private readonly IProjetoAppService _projetoAppService;
        private readonly IPessoaAppService _pessoaAppService;
        private readonly IEquipeAppService _equipeAppService;
        private readonly ITarefaAppService _tarefaAppService;

        public TarefasController(ITarefaAppService tarefaAppService, IProjetoAppService projetoAppService, IPessoaAppService pessoaAppService, IEquipeAppService equipeAppService)
        {
            _tarefaAppService = tarefaAppService;
            _projetoAppService = projetoAppService;
            _pessoaAppService = pessoaAppService;
            _equipeAppService = equipeAppService;
        }

        // GET: Tarefa
        public IActionResult Index()
        {
            return View(_tarefaAppService.ObterTodos());
        }

        // GET: Tarefa/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = _tarefaAppService.ObterPorId(id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // GET: Tarefa/Create
        public IActionResult Create()
        {
            ViewBag.Responsavel = _pessoaAppService.ObterTodos().Select(p => new SelectListItem()
            {
                Text = p.Nome,
                Value = p.Id.ToString()
            }).ToList();
            ViewBag.Projetos = _projetoAppService.ObterTodos().Select(p => new SelectListItem()
            {
                Text = p.Nome,
                Value = p.Id.ToString()
            }).ToList();

            return View();
        }

        // POST: Tarefa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome,DataInicio,DataPrevista,ResponsavelId,ProjetoId")] TarefaViewModel tarefa)
        {
            if (ModelState.IsValid)
            {
                _tarefaAppService.Adicionar(tarefa);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Responsavel = _pessoaAppService.ObterTodos().Select(p => new SelectListItem()
            {
                Text = p.Nome,
                Value = p.Id.ToString()
            }).ToList();
            ViewBag.Projetos = _projetoAppService.ObterTodos().Select(p => new SelectListItem()
            {
                Text = p.Nome,
                Value = p.Id.ToString()
            }).ToList();
            return View(tarefa);
        }

        // GET: Tarefa/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = _tarefaAppService.ObterPorId(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            ViewBag.Responsavel = _pessoaAppService.ObterTodos().Select(p => new SelectListItem()
            {
                Text = p.Nome,
                Value = p.Id.ToString()
            }).ToList();
            ViewBag.Projetos = _projetoAppService.ObterTodos().Select(p => new SelectListItem()
            {
                Text = p.Nome,
                Value = p.Id.ToString()
            }).ToList();

            return View(tarefa);
        }

        // POST: Tarefa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("Nome,DataInicio,DataPrevista,ResponsavelId,ProjetoId")] TarefaViewModel tarefa)
        {
            if (id != tarefa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _tarefaAppService.Editar(tarefa);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Responsavel = _pessoaAppService.ObterTodos().Select(p => new SelectListItem()
            {
                Text = p.Nome,
                Value = p.Id.ToString()
            }).ToList();
            ViewBag.Projetos = _projetoAppService.ObterTodos().Select(p => new SelectListItem()
            {
                Text = p.Nome,
                Value = p.Id.ToString()
            }).ToList();
            return View(tarefa);
        }

        // GET: Tarefa/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = _tarefaAppService.ObterPorId(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        // POST: Tarefa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            _tarefaAppService.Deletar(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

