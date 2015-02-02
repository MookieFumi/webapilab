using System.Collections.Generic;
using System.Threading.Tasks;
using webapilab.entities;

namespace webapilab.services
{
    public interface ICommunitiesService
    {
        Task<Community> Get(int communityId);
        Task<IEnumerable<Community>> GetAll();
    }
}