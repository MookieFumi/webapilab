namespace webapilab.entities.Queries.QueryResult
{
    public class TownsQueryResult
    {
        public int TownId { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Province { get; set; }
    }
}