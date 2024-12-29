using System.Security.Claims;

namespace MediCareApi.AppService;

public class UserAcessor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserAcessor()
    {
        _httpContextAccessor = new HttpContextAccessor();
    }

    public Guid ObterIdUsuario()
    {
        var usuarioId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        return usuarioId == null ? Guid.Empty : Guid.Parse(usuarioId);
    }

}