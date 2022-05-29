namespace ShopingRequestSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Swashbuckle.AspNetCore.Annotations;
    using ShopingRequestSystem.Queries.PublishedShopingRequests.Contractors.Details;

    public class ContractorController : ApiController
    {
        /// <summary>
        /// Get contractor details by id
        /// </summary>
        /// <param name="query">Query contains the contractor identifier</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route(Id)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ContractorDetailsModel))]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<ContractorDetailsModel>> Details(
        [FromRoute] ContractorDetailsQuery<ContractorDetailsModel> query)
            => await this.Send(query);
    }
}
