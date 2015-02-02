using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using webapilab.entities;
using webapilab.entities.Queries.QueryResult;
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

        public async Task<IEnumerable<TownsQueryResult>> GetAll(string name)
        {
            return await Context.Towns
                .Where(p => p.Name.Contains(name))
                .Select(p => new TownsQueryResult
                {
                    TownId = p.TownId,
                    Name = p.Name,
                    ProvinceId = p.ProvinceId,
                    Province = p.Province.Name,
                    Latitude = p.Latitude,
                    Longitude = p.Longitude
                })
                .OrderBy(o=>o.Name)
                .ToListAsync();
        }
    }
}