namespace ShopingRequestSystem.Queries.ShopingRequests.Requests.Specifications
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq.Expressions;
    using ShopingRequestSystem.Queries.Common;
    using ShopingRequestSystem.Queries.ShopingRequests.Requests.Details;

    public class ShopingRequestByPaymentSumSpecification : Specification<ShopingRequestDetailsModel>
    {
        private const decimal MaxSum = 9999999999999999m;
        private readonly decimal minSum;
        private readonly decimal maxSum;

        public ShopingRequestByPaymentSumSpecification(
            decimal? minSum = default,
            decimal? maxSum = decimal.MaxValue)
        {
            this.minSum = minSum ?? default;
            this.maxSum = maxSum ?? MaxSum;
        }

        public override Expression<Func<ShopingRequestDetailsModel, bool>> ToExpression()
            => request => minSum < request.PaymentSum && request.PaymentSum < maxSum;

        public override string ToSql()
        {
            return $"@MinSum < sr.[PaymentSum] AND sr.[PaymentSum] < @MaxSum";
        }

        public override IEnumerable<SqlParameter> ToSqlParameters()
        {
            yield return new SqlParameter("MinSum", minSum);
            yield return new SqlParameter("MaxSum", maxSum);
        }
    }
}
