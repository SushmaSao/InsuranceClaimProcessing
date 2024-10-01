namespace IdentityService.Application.Contracts
{
    public interface ITokenGenerator
    {
        string GenerateToken(Guid userId, IEnumerable<string> roles);
    }
}
