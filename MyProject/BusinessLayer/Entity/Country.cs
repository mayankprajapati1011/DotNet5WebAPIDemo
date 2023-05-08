using System;

namespace BusinessLayer.Entity
{
    public  class Country
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
