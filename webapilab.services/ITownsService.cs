using System.Collections.Generic;
using System.Threading.Tasks;
using webapilab.entities;
using webapilab.entities.Queries.QueryResult;

namespace webapilab.services
{
    public interface ITownsService
    {
        Task<Town> Get(int townId);
        Task<IEnumerable<TownsQueryResult>> GetAll(string name);
    }
}