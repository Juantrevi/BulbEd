using System.Security.Claims;

namespace BulbEd.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string GetUsername(this ClaimsPrincipal user)
    {
        return user.FindFirst(ClaimTypes.Name)?.Value;
    }


public static int GetUserId(this ClaimsPrincipal user)
{
    var claim = user.FindFirst(ClaimTypes.NameIdentifier);
    if (claim != null)
    {
        if (int.TryParse(claim.Value, out int userId))
        {
            Console.WriteLine("USERID" + userId);
            return userId;
        }
    }
    return 0; // return a default value if the claim is not found or the value is not a valid integer
}

}
