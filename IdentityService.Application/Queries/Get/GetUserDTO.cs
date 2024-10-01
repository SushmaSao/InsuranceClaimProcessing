namespace IdentityService.Application.Queries.Get
{
    public class GetUserDTO
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }

        public Guid? RoleId { get; set; }
    }
}
