using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ProjetoMongoDB.Models;

namespace ProjetoMongoDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ContextMongoDb _context;
        private UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ContextMongoDb context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Evento.Find(_ => true).ToListAsync());
        }

        public async Task<IActionResult> MeusEventos(string email)
        {
            string EmailUser = User.Identity.Name; 

            if (id == null)
            {
                return NotFound();
            }

            var meuEventos = await _context.Evento.Find(e => e.Participantes.Any(p => p.Id == email));
            
            if (eventos == null)
            {
                return NotFound();
            }

            return View(eventos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
