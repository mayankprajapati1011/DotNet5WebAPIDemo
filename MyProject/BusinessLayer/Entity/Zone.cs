namespace BusinessLayer.Entity
{
    public class Zone
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string Name { get; set; }
    }
}
