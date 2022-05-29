namespace ShopingRequestSystem.Queries.ShopingRequests.Requests.Specifications
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq.Expressions;
    using ShopingRequestSystem.Queries.Common;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Details;

    public class ShopingRequestByRequesterSpecification : Specification<ShopingRequestDetailsModel>
    {
        private readonly string requester;

        public ShopingRequestByRequesterSpecification(string requester)
            => this.requester = requester;

        protected override bool Include => requester != null;

        public override Expression<Func<ShopingRequestDetailsModel, bool>> ToExpression()
            => request => request.Requester.Name.ToLower()
                .Contains(requester!.ToLower());

        public override string ToSql()
        {
            return $"LOWER(r.[Name]) like '%' + LOWER(@RequesterName) + '%'";
        }

        public override IEnumerable<SqlParameter> ToSqlParameters()
        {
            yield return new SqlParameter("RequesterName", requester);
        }
    }
}
