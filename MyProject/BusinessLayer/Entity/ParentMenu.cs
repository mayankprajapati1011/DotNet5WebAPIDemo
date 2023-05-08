namespace BusinessLayer.Entity
{
    public class ParentMenu
    {
        public int Id { get; set; }
        public string Name  { get; set; }
        public string DisplayName { get; set; }
        public int OrderCode { get; set; }
        public string ImageUrl { get; set; }
        public bool  IsActive { get; set; }
    }
}
