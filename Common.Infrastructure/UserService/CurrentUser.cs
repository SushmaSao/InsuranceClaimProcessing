using Common.Application.Contracts.UserContract;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Common.Infrastructure.UserService
{
    public class CurrentUser : ICurrentUser
    {
        /// <summary>
        /// The http context accessor.
        /// </summary>
        private readonly IHttpContextAccessor httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor) =>
                 this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

        public bool IsAuthenticated => this.httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;

        public Guid? UserId => this.GetClaim(ClaimTypes.NameIdentifier, Guid.Parse) ?? Guid.Empty;

        public string? Email => this.GetClaim(ClaimTypes.Email);

        /// <summary>
        /// Retrieves a claim value, or <see langword="null"/> when the claim does not exist.
        /// </summary>
        /// <param name="type">The claim type.</param>
        /// <returns>The claim value.</returns>
        private string? GetClaim(string type) =>
            this.httpContextAccessor.HttpContext?.User.FindFirstValue(type);

        /// <summary>
        /// Retrieves a claim value, or <see langword="null"/> when the claim does not exist. The value
        /// is converted from a <see cref="string"/> via the <paramref name="converter"/> delegate.
        /// </summary>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <param name="type">The claim type.</param>
        /// <param name="converter">The value converter.</param>
        /// <returns>The claim value.</returns>
        private TValue? GetClaim<TValue>(string type, Func<string, TValue> converter)
            where TValue : struct
        {
            var value = this.GetClaim(type);
            return value is not null ? converter(value) : null;
        }


    }
}
