namespace ShopingRequestSystem.Web.Examples
{
    using System;
    using Swashbuckle.AspNetCore.Filters;
    using ShopingRequestSystem.Queries.ShopingRequests.Requesters.Details;

    internal class RequesterDetailsExample : IExamplesProvider<RequesterDetailsModel>
    {
        public RequesterDetailsModel GetExamples()
        {
            return new RequesterDetailsModel()
            {
                Id = 1,
                Name = "FirstName LastName",
                UserId = Guid.NewGuid().ToString(),
                PhoneNumber = "+3590888555666"
            };
        }
    }
}
