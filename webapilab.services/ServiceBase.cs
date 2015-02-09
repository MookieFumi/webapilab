using webapilab.entities;

namespace webapilab.services
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