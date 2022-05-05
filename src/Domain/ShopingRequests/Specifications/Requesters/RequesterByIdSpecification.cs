namespace ShopingRequestSystem.Domain.ShopingRequests.Specifications.Requesters
{
    using System;
    using System.Linq.Expressions;
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

    public class RequesterByIdSpecification : Specification<Requester>
    {
        private readonly int? id;

        public RequesterByIdSpecification(int? id)
            => this.id = id;

        protected override bool Include => this.id != null;

        public override Expression<Func<Requester, bool>> ToExpression()
            => requester => requester.Id == this.id;
    }
}
