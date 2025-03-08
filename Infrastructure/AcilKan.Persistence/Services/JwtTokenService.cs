using AcilKan.Application.Features.Mediator.Results.AppUserResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.Persistence.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Protocols.WsTrust;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace AcilKan.Persistence.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UserManager<AppUser> _userManager; // UserManager eklenmeli
        private readonly IConfiguration _configuration;

        public JwtTokenService(IOptions<JwtSettings> jwtSettings, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _jwtSettings = jwtSettings.Value;
            _userManager = userManager; // Constructor'a UserManager eklenmeli
            _configuration = configuration;
        }

        // Token oluşturma
        public async Task<TokenResult> GenerateTokens(AppUser user)
        {
            var claims = await GetClaims(user);
            var accessToken = GenerateAccessToken(claims);
            var refreshToken = GenerateRefreshToken(claims);
            // ✅ Kullanıcının Refresh Token'ını ve süresini güncelle
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7); // 7 gün geçerli
            return new TokenResult
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
        public async Task<bool> LogoutAsync(AppUser user, string accessToken)
        {
            if (user == null) return false;

            // Kullanıcının Refresh Token'ını sıfırla
            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = DateTime.UtcNow; // Hemen geçersiz kıl
            await _userManager.UpdateAsync(user);

            // Access Token'ı kara listeye ekle
            TokenBlacklist.AddToBlacklist(accessToken);

            return true;
        }



        public async Task<TokenResult> RefreshAccessToken(string refreshToken)
        {
            // Refresh Token'ı doğrula ve geçerliliğini kontrol et
            var principal = GetPrincipalFromExpiredToken(refreshToken);
            var email = principal.FindFirstValue(ClaimTypes.Email); // Email bilgisini claim'den alıyoruz

            // Kullanıcıyı email ile bul
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new SecurityTokenException("Geçersiz refresh token.");
            }

            // Yeni Access Token üret
            var newAccessToken = GenerateAccessToken(principal.Claims.ToList());

            // Eski Refresh Token'ı aynı tutabiliriz veya yeni bir tane de üretebiliriz.
            var newRefreshToken = GenerateRefreshToken(principal.Claims.ToList());

            return new TokenResult
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken // Yeni refresh token da eklenebilir
            };
        }



        // Kullanıcı bilgilerini claim olarak döndürme
        private async Task<List<Claim>> GetClaims(AppUser user)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.Name),
        new Claim(ClaimTypes.Surname, user.Surname),
        new Claim(ClaimTypes.MobilePhone, user.PhoneNumber ?? ""),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim("sub", user.Id.ToString())
    };

            // 📌 Kullanıcının rollerini çekip JWT'ye ekleyelim
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role)); // 📌 Kullanıcının rollerini claim olarak ekle
            }

            return claims;
        }

        // Access Token üretme
        private string GenerateAccessToken(List<Claim> claims)
        {
            var signingCredentials = GetSigningCredentials();
            var expirationTime = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: expirationTime,
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // Refresh Token üretme
        private string GenerateRefreshToken(List<Claim> claims)
        {
            var signingCredentials = GetSigningCredentials();
            var expirationTime = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationDays);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: expirationTime,
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // Signing credentials (imza işlemi için anahtar)
        private SigningCredentials GetSigningCredentials()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        }

        // Expired token'dan principal (kimlik) alma işlemi
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jsonToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            if (jsonToken == null)
            {
                throw new SecurityTokenException("Geçersiz token.");
            }

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false, // Refresh token zaten geçerliliği var, burayı kontrol etmiyoruz.
                ValidIssuer = _jwtSettings.Issuer,
                ValidAudience = _jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey)),
            };

            var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
            return principal;
        }

        public Task InvalidateTokens(string accessToken, string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
