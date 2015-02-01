using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapilab;

namespace webapilab.Services
{
    public abstract class ServiceBase
    {
        public readonly string ConnectionString = "";
        public readonly DataContext Context;

        protected ServiceBase(DataContext context)
        {
            this.ConnectionString = context.Database.Connection.ConnectionString;
            this.Context = context;
        }
    }
}