namespace ShopingRequestSystem.Domain.ShopingRequests.Specifications.Requesters
{
    using System;
    using System.Linq.Expressions;
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

    public class RequesterByNameSpecification : Specification<Requester>
    {
        private readonly string name;

        public RequesterByNameSpecification(string name) 
            => this.name = name;

        protected override bool Include => this.name != null;

        public override Expression<Func<Requester, bool>> ToExpression()
            => requester => requester.Name.ToLower().Contains(this.name!.ToLower());
    }
}
