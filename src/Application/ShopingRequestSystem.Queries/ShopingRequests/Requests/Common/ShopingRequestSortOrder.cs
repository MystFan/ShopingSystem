namespace ShopingRequestSystem.Queries.ShopingRequests.Requests.Common
{
    using System;
    using System.Linq.Expressions;
    using ShopingRequestSystem.Queries.Common;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Details;

    public class ShopingRequestSortOrder : SortOrder<ShopingRequestDetailsModel>
    {
        public ShopingRequestSortOrder(string sortBy, string order)
            : base(sortBy, order)
        {
        }

        public override Expression<Func<ShopingRequestDetailsModel, object>> ToExpression()
            => SortBy switch
            {
                "name" => request => request.Name,
                "paymentSum" => request => request.PaymentSum,
                "requester" => request => request.Requester.Name,
                _ => request => request.Id
            };


        public override string ToSql()
            => SortBy switch
            {
                "name" => "[Name]",
                "paymentSum" => "[PaymentSum]",
                "requester" => "[RequesterName]",
                _ => "[Id]"
            };
    }
}
