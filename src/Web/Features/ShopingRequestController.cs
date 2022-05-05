namespace ShopingRequestSystem.Web.Features
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Application.ShopingRequests.Requests.Commands.Create;
    using ShopingRequestSystem.Application.ShopingRequests.Requests.Commands.Delete;
    using ShopingRequestSystem.Application.ShopingRequests.Requests.Commands.Edit;
    using ShopingRequestSystem.Application.ShopingRequests.Requests.Queries.Details;
    using ShopingRequestSystem.Application.ShopingRequests.Requests.Queries.Search;

    public class ShopingRequestController : ApiController
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<SearchShopingRequestOutputModel>> Search(
            [FromQuery] SearchShopingRequestQuery query)
            => await this.Send(query);

        [HttpGet]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult<ShopingRequestDetailsOutputModel>> Details(
            [FromRoute] ShopingRequestDetailsQuery<ShopingRequestDetailsOutputModel> query)
            => await this.Send(query);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateShopingRequestOutputModel>> Create(
            CreateShopingRequestCommand command)
            => await this.Send(command);

        [HttpPut]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Edit(int id, EditShopingRequestCommand command)
            => await this.Send(command.SetId(id));

        [HttpDelete]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Delete(
            [FromRoute] DeleteShopingRequestCommand command)
            => await this.Send(command);
    }
}
