using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _8BallShot.Data;
using _8BallShot.Models;

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

        // GET: Torneios
        public async Task<IActionResult> Index()
        {
            return View(_jogador);
              //return _context.Torneio != null ? 
              //            View(await _context.Torneio.ToListAsync()) :
              //            Problem("Entity set 'ApplicationDbContext.Torneio'  is null.");
        }

        [HttpPost]
        public IActionResult Bracket(int player1, int player2)
        {
            var player1Selected = _jogador.Find(p => p.IdJogador == player1);
            var player2Selected = _jogador.Find(p => p.IdJogador == player2);

            if (player1Selected != null && player2Selected != null)
            {
                var model = new Tuple<Jogador, Jogador>(player1Selected, player2Selected);
                return View("BracketView", model);
            }
            else
            {
                return NotFound(); // Trata o caso em que um ou ambos os jogadores não são encontrados
            }
        }


        // GET: Torneios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Torneio == null)
            {
                return NotFound();
            }

            var torneio = await _context.Torneio
                .FirstOrDefaultAsync(m => m.IdTorneio == id);
            if (torneio == null)
            {
                return NotFound();
            }

            return View(torneio);
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

        // GET: Torneios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Torneio == null)
            {
                return NotFound();
            }

            var torneio = await _context.Torneio.FindAsync(id);
            if (torneio == null)
            {
                return NotFound();
            }
            return View(torneio);
        }

        // POST: Torneios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTorneio,NomeTorneio,nFases,nJogadores,DataInicio")] Torneio torneio)
        {
            if (id != torneio.IdTorneio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(torneio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TorneioExists(torneio.IdTorneio))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(torneio);
        }

        // GET: Torneios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Torneio == null)
            {
                return NotFound();
            }

            var torneio = await _context.Torneio
                .FirstOrDefaultAsync(m => m.IdTorneio == id);
            if (torneio == null)
            {
                return NotFound();
            }

            return View(torneio);
        }

        // POST: Torneios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Torneio == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Torneio'  is null.");
            }
            var torneio = await _context.Torneio.FindAsync(id);
            if (torneio != null)
            {
                _context.Torneio.Remove(torneio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TorneioExists(int id)
        {
          return (_context.Torneio?.Any(e => e.IdTorneio == id)).GetValueOrDefault();
        }
    }
}
