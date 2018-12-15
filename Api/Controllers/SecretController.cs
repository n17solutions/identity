using Microsoft.AspNetCore.Mvc;

namespace N17Solutions.Identity.Api.Controllers
{
    [Route("[controller]")]
    public class SecretController : Controller
    {
        public IActionResult Get()
        {
            return Ok(N17Solutions.Infrastructure.Domain.Model.Secret.Generate());
            
        }
    }
}