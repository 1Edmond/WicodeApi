
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WicodeApi.Controllers;

[ApiController]
public class TokenController : Controller
{
    private readonly WicodeApiContext _context;

    public TokenController(WicodeApiContext context) => _context = context;

    [Route("/auth/{login}/{password}")]
    [HttpGet]
    [AllowAnonymous]
    public ActionResult<string> GetToken(string login, string password)
    {
       
        if(_context.Settings.Any(s => s.Name == login && s.Value == password))
        {
                var credentials = new SigningCredentials(Constants.SIGN_KEY, SecurityAlgorithms.HmacSha256);
                var section = new JwtSecurityToken(
                    issuer : "friedo",
                    audience : "wicode",
                    claims : new List<Claim>()
                    {
                        new Claim(ClaimTypes.Role,"Admin")
                    },
                    expires : DateTime.UtcNow.AddMinutes(20),
                    signingCredentials : credentials
                    );
                var handler = new JwtSecurityTokenHandler();

                var stringToken = handler.WriteToken(section);
                return Ok(stringToken);
           
        }
        else
            if(login == Constants.AppLogin && password == Constants.AppPassword)
            {
                var credentials = new SigningCredentials(Constants.SIGN_KEY, SecurityAlgorithms.HmacSha256);
                var section = new JwtSecurityToken(
                    issuer: "friedo",
                    audience: "wicode",
                    expires: DateTime.UtcNow.AddMinutes(20),
                    signingCredentials: credentials
                    );
                var handler = new JwtSecurityTokenHandler();

                var stringToken = handler.WriteToken(section);
                return Ok(stringToken);
            }
        
        return BadRequest("T'es qui?");
    }



}
