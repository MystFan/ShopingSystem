namespace ShopingRequestSystem.Domain.ShopingRequests.Specifications.Requests
{
    using System;
    using System.Linq.Expressions;
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

    public class ShopingRequestByNameSpecification : Specification<ShopingRequest>
    {
        private readonly string name;

        public ShopingRequestByNameSpecification(string name) 
            => this.name = name;

        protected override bool Include => this.name != null;

        public override Expression<Func<ShopingRequest, bool>> ToExpression()
            => requester => requester.Name.ToLower().Contains(this.name!.ToLower());
    }
}
