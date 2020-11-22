using BHA.ManagementAssistant.Nutritious.Common.Constant;
using BHA.ManagementAssistant.Nutritious.Core.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Model.Model.Baseless.AuthenticationOperation;
using BHA.ManagementAssistant.Nutritious.WebApi.Core.Controller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;

namespace BHA.ManagementAssistant.Nutritious.WebApi.Controllers.Token
{
    [Route("api/token")]
    [ApiController]
    public class AuthenticationController : IndependentController
    {
        private readonly IRepository<User> _repositoryUser;
        public AuthenticationController(IRepository<User> repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        [HttpPost("new")]
        public AuthenticationViewModel NewToken([FromBody] AuthenticationFilterModel authenticationFilterModel)
        {
            AuthenticationViewModel authenticationViewModel = new AuthenticationViewModel();

            User user = getUser(authenticationFilterModel);

            if (user != null)
            {
                authenticationViewModel = GenerateToken(user);
            }

            return authenticationViewModel;
        }

        private AuthenticationViewModel GenerateToken(User user)
        {
            Claim[] claims = new Claim[]{
                new Claim(MAClaims.ID, user.ID.ToString()),
                new Claim(MAClaims.OrganizationID, user.OrganizationID.ToString())
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

        private User getUser(AuthenticationFilterModel authenticationFilterModel)
        {
            User user = _repositoryUser.ForJoin().Where(item => item.Name == authenticationFilterModel.UserName && item.Password == authenticationFilterModel.UserPassword).FirstOrDefault();

            return user;
        }
    }
}