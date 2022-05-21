namespace ShopingRequestSystem.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Details;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Search;
    using ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.Create;
    using ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.Edit;
    using ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.Delete;
    using ShopingRequestSystem.Application.ShopingRequests.Commands.Requests.ChangeStatus;

    public class ShopingRequestController : ApiController
    {
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<SearchShopingRequestModel>> Search(
            [FromQuery] SearchShopingRequestQuery query)
            => await this.Send(query);

        [HttpGet]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult<ShopingRequestDetailsModel>> Details(
            [FromRoute] ShopingRequestDetailsQuery<ShopingRequestDetailsModel> query)
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

        [HttpPut]
        [Authorize]
        [Route(nameof(ChangeStatus) + PathSeparator + Id)]
        public async Task<ActionResult> ChangeStatus(int id, ChangeStatusCommand command)
            => await this.Send(command.SetId(id));
    }
}
