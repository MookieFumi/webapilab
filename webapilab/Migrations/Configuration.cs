namespace webapilab.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<webapilab.Infrastructure.AuthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "webapilab.Infrastructure.AuthContext";
        }

        protected override void Seed(webapilab.Infrastructure.AuthContext context)
        {
            //  This method will be called after migrating to the latest version.
        }
    }
}
