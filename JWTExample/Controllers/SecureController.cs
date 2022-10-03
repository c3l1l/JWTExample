using JWTExample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecureController : ControllerBase
    {
        FilmDBContext _db;
        IJwt _jwt;
        public SecureController(FilmDBContext db, IJwt jwt)
        {
            _db = db;
            _jwt = jwt;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Filmler()
        {
            return Ok(_db.Filmlers.ToList());
        }
        [HttpPost]
        public IActionResult Control(UserVM user)
        {
            string token = _jwt.Authenticate(user.Username, user.Password);
            if (token == null)
            {
                return Unauthorized("Unauthorized usage..");
            }
            return Ok(token);
        }

    }
}
