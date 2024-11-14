namespace Common.Application.Contracts.UserContract
{
    // the current user interface
    public interface ICurrentUser
    {
        /// <summary>
        /// Gets a value indicating whether the user is authenticated.
        /// </summary>
        bool IsAuthenticated { get; }

        /// <summary>
        /// Gets the user id.
        /// </summary>
        Guid? UserId { get; }

        /// <summary>
        /// Gets the user id.
        /// </summary>
        string? Email { get; }

    }
}
