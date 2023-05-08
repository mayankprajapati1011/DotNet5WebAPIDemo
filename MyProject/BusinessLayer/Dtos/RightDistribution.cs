using System.Collections.Generic;

namespace BusinessLayer.Dtos
{
    public class RightsDistributionForCreateDto
    {
        public int RoleId { get; set; }
        public List<RightDistributionPermissionDto> Permission { get; set; }
    }
    public class RightDistributionPermissionDto
    {
        public int  ChildMenuId { get; set; }
        public bool AllowView { get; set; }
        public bool AllowAdd { get; set; }
        public bool AllowUpdate { get; set; }
        public bool AllowDelete { get; set; }
        public bool AllowPrint { get; set; }
    }
}
