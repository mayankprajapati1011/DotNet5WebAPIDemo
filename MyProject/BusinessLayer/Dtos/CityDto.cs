
using System.Collections.Generic;

namespace BusinessLayer.Dtos
{
    public class CityForCreateDto
    {
        public int Id { get; set; }
        public short StateId { get; set; }
        public string Name { get; set; }
    }

    public class CityForListDto
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public string Name { get; set; }
    }

    public class StateCity
    {
        public string StateName { get; set; }
        public string CityName { get; set; }
    }

    public class StateDto
    {
        public string State { get; set; }
        public List<CityDto> City { get; set; }
    }

    public class CityDto
    {
        public string Name { get; set; }
    }

}
