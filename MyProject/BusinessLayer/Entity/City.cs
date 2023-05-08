using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entity
{
 public   class City : IDisposable
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
