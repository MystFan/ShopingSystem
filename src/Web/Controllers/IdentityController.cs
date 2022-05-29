namespace ShopingRequestSystem.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using ShopingRequestSystem.Application.Identity.Commands.ChangePassword;
    using ShopingRequestSystem.Application.Identity.Commands.CreateUser;
    using ShopingRequestSystem.Application.Identity.Commands.LoginUser;

    public class IdentityController : ApiController
    {
        /// <summary>
        /// Register new user as requester and contractor
        /// </summary>
        /// <param name="command">Required user information</param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(Register))]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult> Register(
            CreateUserCommand command)
            => await this.Send(command);

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="command">Required user information</param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(Login))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(LoginOutputModel))]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<LoginOutputModel>> Login(
            LoginUserCommand command)
            => await this.Send(command);

        /// <summary>
        /// Change the password of the user
        /// </summary>
        /// <param name="command">Contains current password and new password</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        [Route(nameof(ChangePassword))]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult> ChangePassword(
            ChangePasswordCommand command)
            => await this.Send(command);
    }
}
