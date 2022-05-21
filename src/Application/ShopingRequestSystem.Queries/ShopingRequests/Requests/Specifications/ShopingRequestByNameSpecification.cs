namespace ShopingRequestSystem.Queries.ShopingRequests.Requests.Specifications
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Data.SqlClient;
    using System.Linq.Expressions;
    using ShopingRequestSystem.Queries.Common;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Details;

    public class ShopingRequestByNameSpecification : Specification<ShopingRequestDetailsModel>
    {
        private readonly string name;

        public ShopingRequestByNameSpecification(string name)
            => this.name = name;

        protected override bool Include => name != null;

        public override Expression<Func<ShopingRequestDetailsModel, bool>> ToExpression()
            => requester => requester.Name.ToLower().Contains(name!.ToLower());

        public override string ToSql()
        {
            return $"LOWER(sr.[Name]) like '%' + LOWER(@Name) + '%'";
        }

        public override IEnumerable<SqlParameter> ToSqlParameters()
        {
            yield return new SqlParameter("Name", name);
        }
    }
}
