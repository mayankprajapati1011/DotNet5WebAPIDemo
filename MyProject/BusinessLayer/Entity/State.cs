using System;
using System.Collections.Generic;

namespace BusinessLayer.Entity
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual  List<City> Cities { get; set; }

    }
}
