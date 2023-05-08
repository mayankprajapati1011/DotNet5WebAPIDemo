using System;

namespace BusinessLayer.Entity
{
   public class BinCollectionTransaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int BinId { get; set; }
        public Bin Bin { get; set; }
        public int SocietyId { get; set; }
        public Society Society { get; set; }
    }
}
