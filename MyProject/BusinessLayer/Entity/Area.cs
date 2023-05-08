namespace BusinessLayer.Entity
{
    public class Area
    {
        public int Id { get; set; }
        public int ZoneId { get; set; }
        public Zone Zone { get; set; }
        public string Name { get; set; }
    }
}
