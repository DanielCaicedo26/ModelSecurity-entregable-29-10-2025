using Entity.DTOs.Auth;
using Entity.DTOs.Default;
using Google.Apis.Auth;
namespace Business.Interfaces.IBusinessImplements.Auth
{
    public interface IToken
    {
        //Task<string> GenerateToken(LoginUserDto dto);
        /// <summary>
        /// Valida credenciales y emite Access + Refresh + CSRF junto con información del usuario.
        /// </summary>
        Task<(string AccessToken, string RefreshToken, string CsrfToken, string FirstName, string LastName)> GenerateTokensAsync(LoginUserDto dto);

        /// <summary>
        /// Rota el refresh token y devuelve nuevo Access + Refresh.
        /// </summary>
        Task<(string NewAccessToken, string NewRefreshToken)> RefreshAsync(string refreshTokenPlain, string remoteIp = null);

        /// <summary>
        /// Revoca explícitamente un refresh token.
        /// </summary>
        Task RevokeRefreshTokenAsync(string refreshToken);
    }
}
