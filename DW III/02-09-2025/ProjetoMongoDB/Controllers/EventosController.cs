using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using ProjetoMongoDB.Models;

namespace ProjetoMongoDB.Controllers
{
    public class EventosController : Controller
    {
        private readonly ContextMongoDb _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EventosController(ContextMongoDb context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Evento
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Evento.Find(_ => true).ToListAsync());
        }

        // GET: Evento/Details/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Evento.Find(m => m.Id == id).FirstOrDefaultAsync();

            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Evento/Create
        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Evento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Data,Tipo,HorarioInicio,HorarioFim")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                evento.Id = Guid.NewGuid();
                await _context.Evento.InsertOneAsync(evento);
                return RedirectToAction(nameof(Index));
            }
            return View(evento);
        }

        // GET: Evento/Edit/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Evento.Find(m => m.Id == id).FirstOrDefaultAsync();

            if (evento == null)
            {
                return NotFound();
            }
            return View(evento);
        }

        // POST: Evento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Descricao,Data,Tipo,HorarioInicio,HorarioFim")] Evento evento)
        {
            if (id != evento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Evento.ReplaceOneAsync(m => m.Id == evento.Id, evento);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(evento.Id))
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
            return View(evento);
        }

        // GET: Evento/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Evento.Find(m => m.Id == id).FirstOrDefaultAsync();

            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Evento/Delete/5
        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _context.Evento.DeleteOneAsync(u => u.Id == id);

            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(Guid id) // por ser privado, apenas a própria classe pode executar ele
        {
            return _context.Evento.Find(e => e.Id == id).Any();
        }
    }
}
