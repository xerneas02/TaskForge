using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using utilisateur.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace utilisateur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entities.Utilisateur>>> GetUtilisateurs()
        {
            return Ok(await _context.Utilisateurs.ToListAsync());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entities.Utilisateur>> GetUtilisateur(int id)
        {
             return Ok(await _context.Utilisateurs.FirstOrDefaultAsync(user => user.Id == id));
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<Entities.Utilisateur>> PostUtilisateur(Entities.Utilisateur utilisateur)
        {
            // On ajoute notre utilisateur dans la base
            _context.Utilisateurs.Add(utilisateur);
            // On sauvegarde la modification
            await _context.SaveChangesAsync();
            // On retourne l'utilisateur nouvellement crée en appelant la fonction CreatedAtAction
            return CreatedAtAction(nameof(GetUtilisateur), new { id = utilisateur.Id },utilisateur);
        }
    }
}
