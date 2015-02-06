using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using webapilab.crosscutting;
using webapilab.entities;
using webapilab.entities.Queries.Configuration;
using webapilab.entities.Queries.Result;
using webapilab.Services;

namespace webapilab.services.Impl
{
    public class TownsService : ServiceBase, ITownsService
    {
        public TownsService(DataContext context)
            : base(context)
        {
        }

        public async Task<Town> Get(int townId)
        {
            return await Context.Towns.SingleOrDefaultAsync(p => p.TownId == townId);
        }


        public async Task<QueryResult<TownsQueryResult>> GetAll(QueryConfiguration configuration, string name)
        {
            var query = from t in Context.Towns
                        where t.Name.Contains(name)
                        select t;

            var query2 = from e in query
                         select new TownsQueryResult
                         {
                             TownId = e.TownId,
                             Name = e.Name,
                             ProvinceId = e.ProvinceId,
                             Province = e.Province.Name
                         };

            var sortDirection = configuration.Ordenation.SortDirection;
            switch (configuration.Ordenation.SortExpression.ToLower())
            {
                default:
                    query2 =
                        sortDirection == SortDirection.Ascending
                            ? query2.OrderBy(p => p.Name)
                            : query2.OrderByDescending(p => p.Name);
                    break;
            }
            int count;
            IEnumerable<TownsQueryResult> data;
            if (configuration.Paging.Enable)
            {
                count = await query2.CountAsync();
                data = await query2.Skip((configuration.Paging.PageIndex < 1 ? 0 : configuration.Paging.PageIndex - 1) * configuration.Paging.PageSize)
                                .Take(configuration.Paging.PageSize)
                                .ToListAsync();
            }
            else
            {
                data = await query2.ToListAsync();
                count = data.Count();
            }

            return new QueryResult<TownsQueryResult>
            {
                PageIndex = configuration.Paging.PageIndex,
                PageSize = configuration.Paging.PageSize,
                Count = count,
                Data = data
            };

        }
    }
}