namespace ShopingRequestSystem.Queries.ShopingRequests.Requesters.Specifications
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq.Expressions;
    using ShopingRequestSystem.Queries.Common;
    using ShopingRequestSystem.Queries.ShopingRequests.Requesters.Details;

    public class RequesterByNameSpecification : Specification<RequesterDetailsModel>
    {
        private readonly string name;

        public RequesterByNameSpecification(string name)
            => this.name = name;

        protected override bool Include => name != null;

        public override Expression<Func<RequesterDetailsModel, bool>> ToExpression()
            => requester => requester.Name.ToLower().Contains(name!.ToLower());

        public override string ToSql()
        {
            return $"LOWER([Name]) like '%' + LOWER(@Name) + '%'";
        }

        public override IEnumerable<SqlParameter> ToSqlParameters()
        {
            yield return new SqlParameter("Name", name);
        }
    }
}
