using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FoodCourtManagement.Models;
namespace AngularJwt_Api.Business
{
    public class Jwt_Authentication
    {
        private static string Secret = "ERMN05OPLoDvbTTa/QkqLNMI7cPLguaRyHzyg7n5qNBVjQmtBhz4SzYh4NBVCXi3KJHlSXKP+oi2+bXr6CUYTR==";
        public static string GenerateToken(Customer logedUser)
        {
            string role;
            int userID;
            if (logedUser.cust_MailID == "admin@admin.com")
            {
                role = "admin";
                userID = logedUser.customer_ID;
            }
            else
                role = "user";
                userID = logedUser.customer_ID;

            DateTime issuedAt = DateTime.UtcNow;
            DateTime expires = DateTime.UtcNow.AddMinutes(20);
            var tokenHandler = new JwtSecurityTokenHandler();
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, logedUser.first_Name),
                new Claim(ClaimTypes.Email,logedUser.cust_MailID),
               //new Claim("User ID", logedUser.customer_ID),
                new Claim(ClaimTypes.Role, role)
            });
            _ = DateTime.UtcNow;
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(Secret));
            var signingCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature);
            var token = tokenHandler.CreateJwtSecurityToken(issuer: "https://localhost:44384", audience: "http://localhost:4200",
                        subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}