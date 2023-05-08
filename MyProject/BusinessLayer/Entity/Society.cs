namespace BusinessLayer.Entity
{
    public   class Society
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public string Name { get; set; }
    }
}
