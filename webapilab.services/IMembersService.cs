using System.Collections.Generic;
using webapilab.entities;

namespace webapilab.services
{
    public interface IMembersService
    {
        void Add(Member member);
        Member Get(int memberId);
        IEnumerable<Member> GetAll();
        void Update(Member member);
        void Remove(int memberId);
    }
}