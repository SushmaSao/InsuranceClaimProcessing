namespace IdentityService.Application.Contracts
{
    public interface ITokenGenerator
    {
        string GenerateToken(Guid userId, string email, IEnumerable<string> roles);
    }
}
