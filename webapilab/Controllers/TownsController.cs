using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using Newtonsoft.Json;
using webapilab.crosscutting;
using webapilab.entities.Queries.Configuration;
using webapilab.entities.Queries.Result;
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

        // GET api/towns/GetTowns
        public async Task<IHttpActionResult> GetTowns(string name, int pageIndex = 1, int pageSize = crosscutting.Settings.MaxPageSize)
        {
            var queryConfiguration = new QueryConfiguration()
            {
                Paging = new PagingConfiguration(pageIndex, pageSize)
            };
            QueryResult<TownsQueryResult> paginatedList = await _townsService.GetAll(queryConfiguration, name);
            if (paginatedList == null)
            {
                return NotFound();
            }
            return Ok(paginatedList);
        }
    }
}