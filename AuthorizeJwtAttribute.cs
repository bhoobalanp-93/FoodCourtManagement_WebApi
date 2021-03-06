﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
namespace AngularJwt_Api.Business
{
    public class AuthorizeJwtAttribute : AuthorizeAttribute
    {
        private static string Secret = "ERMN05OPLoDvbTTa/QkqLNMI7cPLguaRyHzyg7n5qNBVjQmtBhz4SzYh4NBVCXi3KJHlSXKP+oi2+bXr6CUYTR==";
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string token;
            if (!TryRetrieveToken(actionContext.Request, out token))
            {
                actionContext.Response =
                                     new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            try
            {
                var now = DateTime.UtcNow;
                var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(Secret));
                SecurityToken securityToken;
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                TokenValidationParameters validationParameters = new TokenValidationParameters()
                {
                    ValidAudience = "https://localhost:44384",
                    ValidIssuer = "http://localhost:4200",
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = this.LifetimeValidator,
                    IssuerSigningKey = securityKey
                };
                //extract and assign the user of the jwt
                Thread.CurrentPrincipal = handler.ValidateToken(token, validationParameters, out securityToken);
                HttpContext.Current.User = handler.ValidateToken(token, validationParameters, out securityToken);
                base.OnAuthorization(actionContext);
            }
            catch (SecurityTokenValidationException)
            {
                actionContext.Response =
                                     new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            catch (Exception)
            {
                actionContext.Response =
                                      new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            IEnumerable<string> authzHeaders;
            if (!request.Headers.TryGetValues("Authorization", out authzHeaders) || authzHeaders.Count() > 1)
            {
                return false;
            }
            var bearerToken = authzHeaders.ElementAt(0);
            token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
            return true;
        }
        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
                //expires = DateTime.UtcNow.AddMinutes(15);
            {
                if (DateTime.UtcNow < expires)
                {
                    return true;
                }
            }
            return false;
        }
    }
}