using System.Collections.Generic;

namespace BusinessLayer.Entity
{
    public class ChildMenu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string PageUrl { get; set; }
        public int OrderCode { get; set; }
        public int ParentMenuId { get; set; }
        public  ParentMenu  ParentMenu { get; set; }
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public virtual List<RightsDistribution> RightsDistribution { get; set; }
    }
}
