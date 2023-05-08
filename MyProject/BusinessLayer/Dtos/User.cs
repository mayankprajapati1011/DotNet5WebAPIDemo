namespace BusinessLayer.Dtos
{
   public class UserForCreateDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string   Password { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public int RoleId { get; set; }
        public string AddressLine1 { get; set; }
    }

    public class UserForListDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string RoleName { get; set; }

    }

    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string RoleName { get; set; }
        public string AddressLine1 { get; set; }
    }

    public class LoginResponseDto
    {
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
    public class ChangePasswordDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
