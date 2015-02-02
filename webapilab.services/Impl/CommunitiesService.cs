using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using webapilab.entities;
using webapilab.Services;

namespace webapilab.services.Impl
{
    public class CommunitiesService : ServiceBase, ICommunitiesService
    {
        public CommunitiesService(DataContext context)
            : base(context)
        {

        }

        public async Task<Community> Get(int communityId)
        {
            return await Context.Communities.SingleOrDefaultAsync(p => p.CommunityId == communityId);
        }

        public async Task<IEnumerable<Community>> GetAll()
        {
            return await Context.Communities.ToListAsync();
        }
    }
}