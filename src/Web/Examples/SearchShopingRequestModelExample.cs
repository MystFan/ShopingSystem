namespace ShopingRequestSystem.Web.Examples
{
    using System;
    using Swashbuckle.AspNetCore.Filters;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Search;

    internal class SearchShopingRequestModelExample : IExamplesProvider<SearchShopingRequestModel>
    {
        public SearchShopingRequestModel GetExamples()
        {
            return new SearchShopingRequestModel(new ShopingRequestModel[]
            {
                new ShopingRequestModel()
                {
                    Id = 1,
                    Name = "The name",
                    Description = "The Description",
                    DeliveryAddress = "The Delivery Address",
                    RequestId = Guid.NewGuid().ToString(),
                    RequesterId = 1,
                    Status = 1,
                    PaymentSum = 20.0m,
                    UserId = Guid.NewGuid().ToString(),
                    RequesterName = "FirstName LastName",
                    RequesterPhoneNumber = "+3590888555666"
                }
            }, 1, 1);
        }
    }
}
