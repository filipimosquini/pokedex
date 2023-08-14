using System.Web.Http;
using Backend.Api.Bases;

namespace Backend.Api.Controllers
{
    [Route("mestres")]
    public class MestrePokemonController : MainController
    {
        [HttpGet]
        public IHttpActionResult Index()
        {
            return Ok();
        }
    }
}