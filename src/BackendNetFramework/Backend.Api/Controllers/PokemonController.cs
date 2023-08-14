using System.Web.Http;
using Backend.Api.Bases;

namespace Backend.Api.Controllers
{
    [Route("pokemons")]
    public class PokemonController : MainController
    {

        [HttpGet]
        public IHttpActionResult Index()
        {
            return Ok();
        }
    }
}