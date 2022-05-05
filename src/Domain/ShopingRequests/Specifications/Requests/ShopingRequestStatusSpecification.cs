namespace ShopingRequestSystem.Domain.ShopingRequests.Specifications.Requests
{
    using System;
    using System.Linq.Expressions;
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

    public class ShopingRequestStatusSpecification : Specification<ShopingRequest>
    {
        private readonly RequestStatus status;

        public ShopingRequestStatusSpecification(RequestStatus status)
            => this.status = status;

        public override Expression<Func<ShopingRequest, bool>> ToExpression()
        {
            return request => request.Status.Value == status.Value;
        }
    }
}
