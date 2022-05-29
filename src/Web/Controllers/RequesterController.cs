namespace ShopingRequestSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;
    using Swashbuckle.AspNetCore.Annotations;
    using ShopingRequestSystem.Queries.ShopingRequests.Requesters.Details;

    public class RequesterController : ApiController
    {
        /// <summary>
        /// Get shoping requester details by id
        /// </summary>
        /// <param name="query">Query contains the requester identifier</param>
        [HttpGet]
        [Authorize]
        [Route(Id)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(RequesterDetailsModel))]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<RequesterDetailsModel>> Details(
            [FromRoute] RequesterDetailsQuery<RequesterDetailsModel> query)
            => await this.Send(query);
    }
}
