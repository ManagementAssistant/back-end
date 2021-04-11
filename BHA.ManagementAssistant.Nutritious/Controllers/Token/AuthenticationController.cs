using BHA.ManagementAssistant.Nutritious.Common.Constant;
using BHA.ManagementAssistant.Nutritious.Common.Extension;
using BHA.ManagementAssistant.Nutritious.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Model.Enums;
using BHA.ManagementAssistant.Nutritious.Model.Model.Baseless.AuthenticationOperation;
using BHA.ManagementAssistant.Nutritious.Service.Interface;
using BHA.ManagementAssistant.Nutritious.WebApi.Core.Controller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BHA.ManagementAssistant.Nutritious.Common.Exceptions;

namespace BHA.ManagementAssistant.Nutritious.WebApi.Controllers.Token
{
    [Route("api/token")]
    [ApiController]
    public class AuthenticationController : IndependentController
    {
        private IServiceProvider _serviceProvider;

        public AuthenticationController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost("new")]
        public AuthenticationViewModel NewToken([FromBody] AuthenticationModel authenticationModel)
        {
            AuthenticationViewModel authenticationViewModel = new AuthenticationViewModel();

            User user = getUser(authenticationModel);

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

        private User getUser(AuthenticationModel authenticationModel)
        {

            IUserService serviceUser = _serviceProvider.GetService<IUserService>();
            IQueryable<User> queryUser = serviceUser.Repository.ForJoin();

            LoginType loginType = (LoginType)authenticationModel.LoginType;

            switch (loginType)
            {
                case LoginType.UserNameAndPassword:
                    return getUserWithLoginTypeUserNameAndPassword(authenticationModel, queryUser);
                default:
                    throw new TechnicalException("undefined.logintype");
            }
        }

        private User getUserWithLoginTypeUserNameAndPassword(AuthenticationModel authenticationModel, IQueryable<User> queryUser)
        {
            return queryUser.Where(item => item.Name == authenticationModel.UserName && item.Password == authenticationModel.UserPassword).FirstOrDefault();
        }
    }
}