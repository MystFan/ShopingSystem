namespace ShopingRequestSystem.Queries.ShopingRequests.Requesters.Specifications
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq.Expressions;
    using ShopingRequestSystem.Queries.Common;
    using ShopingRequestSystem.Queries.ShopingRequests.Requesters.Details;

    public class RequesterByIdSpecification : Specification<RequesterDetailsModel>
    {
        private readonly int? id;

        public RequesterByIdSpecification(int? id)
            => this.id = id;

        protected override bool Include => id != null;

        public override Expression<Func<RequesterDetailsModel, bool>> ToExpression()
            => requester => requester.Id == id;

        public override string ToSql()
        {
            return "[Id] = @Id";
        }

        public override IEnumerable<SqlParameter> ToSqlParameters()
        {
            yield return new SqlParameter("Id", id);
        }
    }
}
