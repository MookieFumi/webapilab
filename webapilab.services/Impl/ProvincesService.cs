using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using webapilab.entities;

namespace webapilab.services.Impl
{
    public class ProvincesService : ServiceBase, IProvincesService
    {
        public ProvincesService(DataContext context)
            : base(context)
        {

        }

        public async Task<Province> Get(int provinceId)
        {
            return await Context.Provinces.SingleOrDefaultAsync(p => p.ProvinceId == provinceId);
        }

        public async Task<IEnumerable<Province>> GetAll()
        {
            return await Context.Provinces.ToListAsync();
        }
    }
}