using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Willprecht_Final.Data;
using Willprecht_Final.Models;

namespace Willprecht_Final
{
    public class JwtAuthenticationManager
    {
        private readonly string key;

        private readonly IDictionary<string, string> users = new Dictionary<string, string>()
        { {"CJones", "Jones" }, {"GStanley", "Stanley"}, {"JKnowles", "Knowles"}, {"GThurston", "Thurston"}, {"APerry", "Perry"}, {"JCoyle", "Coyle"}, {"VCola", "Cola"}, {"CBryant", "Bryant"}, {"DHargrove", "Hargrove"}, {"JJohnson", "Johnson"} };


        public JwtAuthenticationManager(string key)
        {
            this.key = key;
        }

        public string Authentication(string username, string password, string role)
        {
            if (!users.Any(u => u.Key == username && u.Value == password))
            { return null; }

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                }),

                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
