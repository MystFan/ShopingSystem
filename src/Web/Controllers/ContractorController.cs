namespace ShopingRequestSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using ShopingRequestSystem.Queries.PublishedShopingRequests.Contractors.Details;

    public class ContractorController : ApiController
    {
        [HttpGet]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult<ContractorDetailsModel>> Details(
        [FromRoute] ContractorDetailsQuery<ContractorDetailsModel> query)
            => await this.Send(query);
    }
}
