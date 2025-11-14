using MediaBrowser.Controller.Library;

namespace Jellyfin.Plugin.JellyBridge.JellyfinModels;

/// <summary>
/// Wrapper around Jellyfin's IUserManager interface.
/// </summary>
public class JellyfinIUserManager : WrapperBase<IUserManager>
{
    public JellyfinIUserManager(IUserManager userManager) : base(userManager)
    {
        InitializeVersionSpecific();
    }

    /// <summary>
    /// Gets all users.
    /// </summary>
    public IEnumerable<JellyfinUser> GetAllUsers()
    {
        return Inner.Users.Select(user => new JellyfinUser((dynamic)user));
    }

    /// <summary>
    /// Gets a user by ID.
    /// </summary>
    /// <param name="userId">The user ID</param>
    /// <returns>The user if found, null otherwise</returns>
    public JellyfinUser? GetUserById(Guid userId)
    {
        var user = Inner.GetUserById(userId);
        if (user == null)
        {
            return null;
        }
        return new JellyfinUser((dynamic)user);
    }
}

