#nullable disable
namespace allopromo.Api.DTOs
{
    public class CreateUserDto : UserDto
    {
        public string ConfirmPassword { get; set; }
    }
}
