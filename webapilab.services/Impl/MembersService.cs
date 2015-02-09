using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using webapilab.entities;

namespace webapilab.services.Impl
{
    public class MembersService : ServiceBase, IMembersService
    {
        public MembersService(DataContext context)
            : base(context)
        {

        }

        public async Task Add(Member member)
        {
            //TODO: checks
            Context.Members.Add(member);
            await Context.SaveChangesAsync();
        }

        public async Task<Member> Get(int memberId)
        {
            return await Context.Members.SingleOrDefaultAsync(p => p.MemberId == memberId);
        }

        public async Task<IEnumerable<Member>> GetAll()
        {
            var query = Context.Members;
            return await query.ToListAsync();
        }

        public async Task Update(Member member)
        {
            Context.Members.Attach(member);
            Context.Entry(member).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task Remove(int memberId)
        {
            var member = await Get(memberId);
            Context.Members.Remove(member);
            await Context.SaveChangesAsync();
        }
    }
}