using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using webapilab.entities.Queries.QueryResult;
using webapilab.services;

namespace webapilab.Controllers
{
    [Authorize]
    public class TownsController : ApiController
    {
        private readonly ITownsService _townsService;
        public TownsController(ITownsService townsService)
        {
            _townsService = townsService;
        }

        public async Task<IEnumerable<TownsQueryResult>> Get(string name)
        {
            return await _townsService.GetAll(name);
        }
    }
}