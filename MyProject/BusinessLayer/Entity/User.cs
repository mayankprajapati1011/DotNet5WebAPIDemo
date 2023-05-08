using System;

namespace BusinessLayer.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string AddressLine1 { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
