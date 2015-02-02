using System.Collections.Generic;
using System.Threading.Tasks;
using webapilab.entities;

namespace webapilab.services
{
    public interface IMembersService
    {
        Task Add(Member member);
        Task<Member> Get(int memberId);
        Task<IEnumerable<Member>> GetAll();
        Task Update(Member member);
        Task Remove(int memberId);
    }
}