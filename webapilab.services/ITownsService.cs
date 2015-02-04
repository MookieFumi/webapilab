using System.Threading.Tasks;
using webapilab.crosscutting;
using webapilab.entities;
using webapilab.entities.Queries.Configuration;
using webapilab.entities.Queries.Result;

namespace webapilab.services
{
    public interface ITownsService
    {
        Task<Town> Get(int townId);
        Task<QueryResult<TownsQueryResult>> GetAll(QueryConfiguration configuration, string name);
    }
}