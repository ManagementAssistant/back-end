using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BHA.ManagementAssistant.Nutritious.Common.Constant;
using BHA.ManagementAssistant.Nutritious.Model.Model.Baseless.AuthenticationOperation;
using BHA.ManagementAssistant.Nutritious.WebApi.Core.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace BHA.ManagementAssistant.Nutritious.WebApi.Controllers.Token
{
    [Route("api/token")]
    [ApiController]
    public class AuthenticationController : IndependentController
    {
        [HttpPost("new")]
        public AuthenticationViewModel GetToken([FromBody] AuthenticationFilterModel authenticationFilterModel)
        {
            AuthenticationViewModel authenticationViewModel = new AuthenticationViewModel();
            if (isValidUserAndPassword(authenticationFilterModel))
            {
                authenticationViewModel = GenerateToken(authenticationFilterModel);
            }

            return authenticationViewModel;
        }

        private AuthenticationViewModel GenerateToken(AuthenticationFilterModel authenticationFilterModel)
        {
            Claim[] claims = new Claim[]{
                new Claim(MAClaims.ID,"23"),
                new Claim(MAClaims.OrganizationID,"46")
            };

            DateTime expire = DateTime.Now.AddHours(18);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: JwtConstants.HeaderTypeAlt,
                audience: JwtConstants.HeaderTypeAlt,
                claims: claims,
                expires: expire,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConstants.JweCompactSerializationRegex)), SecurityAlgorithms.HmacSha256)
            );

            return new AuthenticationViewModel
            {
                Expire = expire,
                isLogin = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        private bool isValidUserAndPassword(AuthenticationFilterModel authenticationFilterModel)
        {
            return true;
        }
    }
}