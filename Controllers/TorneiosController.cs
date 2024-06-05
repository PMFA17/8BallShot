using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _8BallShot.Data;
using _8BallShot.Models;
using Microsoft.AspNetCore.Authorization;

namespace _8BallShot.Controllers
{
    public class TorneiosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly List<Jogador> _jogador;

        public TorneiosController(ApplicationDbContext context)
        {
            _context = context;

            _jogador = new List<Jogador>
            {
                new Jogador { IdJogador = 1, NomeJogador = "Jogador 1", NIF = 123456789 },
                new Jogador { IdJogador = 2, NomeJogador = "Jogador 2", NIF = 987654321 },
                new Jogador { IdJogador = 3, NomeJogador = "Jogador 3", NIF = 123456329 },
                new Jogador { IdJogador = 4, NomeJogador = "Jogador 4", NIF = 987633421 },
            };
        }

        [Authorize]
        public IActionResult Tabela()
        {
            return View();
        }

        [Authorize]
        public IActionResult Eliminatoria()
        {
            return View();
        }

        public IActionResult CampeonatoEliminatoria()
        {
            return View();
        }

        [Authorize]
        public IActionResult Formato()
        {
            return View();
        }

        // GET: Torneios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Torneios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTorneio,NomeTorneio,nFases,nJogadores,DataInicio")] Torneio torneio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(torneio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(torneio);
        }

    }
}
