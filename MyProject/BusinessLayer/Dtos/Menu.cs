using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dtos
{
    public class MenuForRightsDistributionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentMenuId { get; set; }
        public string ParentMenuName { get; set; }
        public bool AllowView { get; set; }
        public bool AllowAdd { get; set; }
        public bool AllowUpdate { get; set; }
        public bool AllowDelete { get; set; }
        public bool AllowPrint { get; set; }
    }

    public class MenuForListDto
    {
        public List<ParentMenuDto> ParentMenu { get; set; }
        public List<MenuDto> ChildMenu { get; set; }
    }

    public class MenuDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string PageUrl { get; set; }
        public int OrderCode { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public int ParentMenuId { get; set; }
    }

    public class ParentMenuDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int OrderCode { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
