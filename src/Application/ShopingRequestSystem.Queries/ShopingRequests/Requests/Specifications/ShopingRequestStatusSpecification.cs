namespace ShopingRequestSystem.Queries.ShopingRequests.Requests.Specifications
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Data.SqlClient;
    using System.Linq.Expressions;
    using ShopingRequestSystem.Queries.Common;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Details;

    public class ShopingRequestStatusSpecification : Specification<ShopingRequestDetailsModel>
    {
        private readonly int status;

        public ShopingRequestStatusSpecification(int status)
            => this.status = status;

        public override Expression<Func<ShopingRequestDetailsModel, bool>> ToExpression()
        {
            return request => request.Status == status;
        }

        public override string ToSql()
        {
            return $"sr.[Status] = @Status";
        }

        public override IEnumerable<SqlParameter> ToSqlParameters()
        {
            yield return new SqlParameter("Status", status);
        }
    }
}
