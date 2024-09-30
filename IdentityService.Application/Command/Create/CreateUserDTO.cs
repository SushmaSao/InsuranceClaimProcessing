namespace IdentityService.Application.Command.Create
{
    public record CreateUserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
    }
}
