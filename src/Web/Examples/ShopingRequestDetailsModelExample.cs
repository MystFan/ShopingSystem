namespace ShopingRequestSystem.Web.Examples
{
    using System;
    using Swashbuckle.AspNetCore.Filters;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Details;
    using ShopingRequestSystem.Queries.ShopingRequests.Requesters.Details;

    internal class ShopingRequestDetailsModelExample : IExamplesProvider<ShopingRequestDetailsModel>
    {
        public ShopingRequestDetailsModel GetExamples()
        {
            return new ShopingRequestDetailsModel()
            {
                Id = 1,
                Name = "The name",
                Description = "The Description",
                DeliveryAddress = "The Delivery Address",
                RequestId = Guid.NewGuid().ToString(),
                RequesterId = 1,
                Status = 1,
                PaymentSum = 20.0m,
                Requester = new RequesterDetailsModel()
                {
                    Id = 1,
                    UserId = Guid.NewGuid().ToString(),
                    Name = "FirstName LastName",
                    PhoneNumber = "+3590888555666"
                }
            };
        }
    }
}
