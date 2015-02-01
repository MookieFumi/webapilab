using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using webapilab;

namespace webapilab.Services
{
    public interface IMembersService
    {
        void Add(Member member);
        Member Get(int memberId);
        IEnumerable<Member> GetAll();
        void Update(Member member);
        void Remove(int memberId);
    }

    public class MembersService : ServiceBase, IMembersService
    {
        public MembersService(DataContext context)
            : base(context)
        {

        }

        public void Add(Member member)
        {
            //TODO: checks
            Context.Members.Add(member);
            Context.SaveChanges();
        }

        public Member Get(int memberId)
        {
            return Context.Members.Single(p => p.MemberId == memberId);
        }

        public IEnumerable<Member> GetAll()
        {
            return Context.Members;
        }

        public void Update(Member member)
        {
            Context.Members.Attach(member);
            Context.Entry(member).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Remove(int memberId)
        {
            var member = Get(memberId);
            Context.Members.Remove(member);
            Context.SaveChanges();
        }
    }
}