namespace IdentityService.Application.Contracts
{
    public interface ITokenGenerator
    {
        string GenerateToken(string userId, IEnumerable<string> roles);
        bool ValidateToken(string token, out string userId);
    }
}
