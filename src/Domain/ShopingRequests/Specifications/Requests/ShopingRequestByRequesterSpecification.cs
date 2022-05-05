namespace ShopingRequestSystem.Domain.ShopingRequests.Specifications.Requests
{
    using System;
    using System.Linq.Expressions;
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

    public class ShopingRequestByRequesterSpecification : Specification<ShopingRequest>
    {
        private readonly string requester;

        public ShopingRequestByRequesterSpecification(string requester)
            => this.requester = requester;

        protected override bool Include => this.requester != null;

        public override Expression<Func<ShopingRequest, bool>> ToExpression()
            => request => request.Requester.Name.ToLower()
                .Contains(this.requester!.ToLower());
    }
}
