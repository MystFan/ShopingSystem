namespace ShopingRequestSystem.Application.ShopingRequests.Requests.Queries.Common
{
    using System;
    using System.Linq.Expressions;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

    public class ShopingRequestSortOrder : SortOrder<ShopingRequest>
    {
        public ShopingRequestSortOrder(string sortBy, string order)
            : base(sortBy, order)
        {
        }

        public override Expression<Func<ShopingRequest, object>> ToExpression()
            => this.SortBy switch
            {
                "name" => request => request.Name,
                "paymentSum" => request => request.PaymentSum,
                "requester" => request => request.Requester.Name,
                _ => request => request.Id
            };
    }
}
