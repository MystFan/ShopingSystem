namespace ShopingRequestSystem.Web.Examples
{
    using System;
    using Swashbuckle.AspNetCore.Filters;
    using ShopingRequestSystem.Queries.PublishedShopingRequests.Contractors.Details;

    internal class ContractorDetailsExample : IExamplesProvider<ContractorDetailsModel>
    {
        public ContractorDetailsModel GetExamples()
        {
            return new ContractorDetailsModel()
            {
                Id = 1,
                Name = "FirstName LastName",
                UserId = Guid.NewGuid().ToString(),
                PhoneNumber = "+3590888555666"
            };
        }
    }
}
