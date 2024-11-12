using System.Security.Claims;

namespace GestorDocumentalOIJ.Utility
{
    public  class UsuarioSesionHttp
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsuarioSesionHttp(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUsuarioSesion()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
            {
                return null;
            }

            var username = httpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            return username;
        }
    }
}
