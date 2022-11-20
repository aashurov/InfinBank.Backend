using InfinBank.Application.Interfaces;
using System.Security.Claims;

namespace InfinBank.WebAPI.Services;

/// <summary>
/// CurrentUserService
/// </summary>
public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// CurrentUserService
    /// </summary>
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// UserId of Current logged user
    /// </summary>
    public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
}