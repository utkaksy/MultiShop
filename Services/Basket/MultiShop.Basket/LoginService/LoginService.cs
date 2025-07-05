using System.Security.Claims;

namespace MultiShop.Basket.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpcontextAccessor;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _httpcontextAccessor = contextAccessor;
        }

        //public string GetUserId => _httpcontextAccessor.HttpContext.User.FindFirst("sub").Value;

        public string GetUserId
        {
            get
            {
                var httpContext = _httpcontextAccessor.HttpContext;
                var user = httpContext?.User;

                // sub varsa onu al, yoksa nameidentifier al
                var userId = user?.FindFirst("sub")?.Value
                          ?? user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userId))
                    throw new UnauthorizedAccessException("Kullanıcı kimliği alınamadı.");

                return userId;
            }
        }

    }
}
