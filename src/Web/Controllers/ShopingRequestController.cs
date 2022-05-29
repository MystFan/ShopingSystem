namespace ShopingRequestSystem.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Details;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Search;
    using ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.Create;
    using ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.Edit;
    using ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.Delete;
    using ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.ChangeStatus;

    public class ShopingRequestController : ApiController
    {
        /// <summary>
        /// Paged list of shoping requests
        /// </summary>
        /// <param name="query">Search criteria</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(SearchShopingRequestModel))]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<SearchShopingRequestModel>> Search(
            [FromQuery] SearchShopingRequestQuery query)
            => await this.Send(query);

        /// <summary>
        /// Get shoping request details by id
        /// </summary>
        /// <param name="query">Query contains the shoping request identifier</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route(Id)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ShopingRequestDetailsModel))]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<ShopingRequestDetailsModel>> Details(
            [FromRoute] ShopingRequestDetailsQuery<ShopingRequestDetailsModel> query)
            => await this.Send(query);

        /// <summary>
        /// Create new shoping request
        /// </summary>
        /// <param name="command">The information required to create shoping request</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(CreateShopingRequestOutputModel))]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<CreateShopingRequestOutputModel>> Create(
            CreateShopingRequestCommand command)
            => await this.Send(command);

        /// <summary>
        /// Edit shoping request
        /// </summary>
        /// <param name="id">Shoping request identifier</param>
        /// <param name="command">The information required to edit shoping request</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        [Route(Id)]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult> Edit(int id, EditShopingRequestCommand command)
            => await this.Send(command.SetId(id));

        /// <summary>
        /// Delete shoping request
        /// </summary>
        /// <param name="command">Contains shoping request identifier</param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize]
        [Route(Id)]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult> Delete(
            [FromRoute] DeleteShopingRequestCommand command)
            => await this.Send(command);

        /// <summary>
        /// Change the status of shoping request
        /// </summary>
        /// <param name="id">Shoping request identifier</param>
        /// <param name="command">Contains shoping request identifier and the new status</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        [Route(nameof(ChangeStatus) + PathSeparator + Id)]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult> ChangeStatus(int id, ChangeStatusCommand command)
            => await this.Send(command.SetId(id));
    }
}
