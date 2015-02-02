using webapilab.entities;

namespace webapilab.Services
{
    public abstract class ServiceBase
    {
        public readonly string ConnectionString = "";
        public readonly DataContext Context;

        protected ServiceBase(DataContext context)
        {
            ConnectionString = context.Database.Connection.ConnectionString;
            Context = context;
        }
    }
}