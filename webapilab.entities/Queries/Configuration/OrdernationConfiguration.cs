using System;
using webapilab.crosscutting;

namespace webapilab.entities.Queries.Configuration
{
    public class OrdernationConfiguration
    {
        public OrdernationConfiguration()
        {
            SortExpression = String.Empty;
        }

        public SortDirection SortDirection { get; set; }
        public string SortExpression { get; set; }
    }
}