namespace BusinessLayer.Entity
{
    public class RightsDistribution
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int ChildMenuId { get; set; }
        public ChildMenu ChildMenu { get; set; }
        public bool AllowView { get; set; }
        public bool AllowAdd { get; set; }
        public bool AllowUpdate { get; set; }
        public bool AllowDelete { get; set; }
        public bool AllowPrint { get; set; }
    }
}
