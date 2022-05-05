namespace ShopingRequestSystem.Domain.ShopingRequests.Specifications.Requests
{
    using System;
    using System.Linq.Expressions;
    using ShopingRequestSystem.Domain.Common;
    using ShopingRequestSystem.Domain.ShopingRequests.Models;

    public class ShopingRequestByPaymentSumSpecification : Specification<ShopingRequest>
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

        public override Expression<Func<ShopingRequest, bool>> ToExpression()
            => request => this.minSum < request.PaymentSum && request.PaymentSum < this.maxSum;
    }
}
