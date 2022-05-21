namespace ShopingRequestSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using ShopingRequestSystem.Queries.ShopingRequests.Requesters.Details;

    public class RequesterController : ApiController
    {
        [HttpGet]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult<RequesterDetailsModel>> Details(
            [FromRoute] RequesterDetailsQuery<RequesterDetailsModel> query)
            => await this.Send(query);
    }
}
