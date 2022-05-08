namespace ShopingRequestSystem.Domain.ShopingRequests.Models
{
    using Bogus;
    using FakeItEasy;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ShopingRequestSystem.Domain.Common.Models;

    public class ShopingRequestFakes
    {
        public class ShopingRequestDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(List<ShopingRequest>);

            public object Create(Type type) => Data.GetShopingRequests();

            public Priority Priority => Priority.Default;
        }

        public static class Data
        {
            public static IEnumerable<ShopingRequest> GetShopingRequests(int count = 10)
            {
                int counter = 0;
                IEnumerable<ShopingRequest> withStatusOpen = Enumerable
                    .Range(1, count)
                    .Select(i => GetShopingRequest(RequestStatus.Open, counter + i));

                counter += count;
                IEnumerable<ShopingRequest> withStatusPublished = Enumerable
                    .Range(1, count)
                    .Select(i => GetShopingRequest(RequestStatus.Published, counter + i));

                counter += count;
                IEnumerable<ShopingRequest> withStatusInProgress = Enumerable
                    .Range(1, count)
                    .Select(i => GetShopingRequest(RequestStatus.InProgress, counter + i));

                counter += count;
                IEnumerable<ShopingRequest> withStatusCompleted = Enumerable
                    .Range(1, count)
                    .Select(i => GetShopingRequest(RequestStatus.Completed, counter + i));

                counter += count;
                IEnumerable<ShopingRequest> withStatusClosed = Enumerable
                    .Range(1, count)
                    .Select(i => GetShopingRequest(RequestStatus.Closed, counter + i));

                return withStatusOpen
                    .Concat(withStatusPublished)
                    .Concat(withStatusInProgress)
                    .Concat(withStatusCompleted)
                    .Concat(withStatusClosed)
                    .ToList();
            }

            public static ShopingRequest GetShopingRequest(RequestStatus status, int id = 1)
                => new Faker<ShopingRequest>()
                    .CustomInstantiator(f => new ShopingRequest(
                        Guid.NewGuid().ToString(),
                        new Requester(Guid.NewGuid().ToString(), $"name {id}", "+359898555111"),
                        status,
                        $"Request Name {id}",
                        $"Request Description {id}",
                        $"Request Delivery Address {id}",
                        100m + id))
                    .Generate()
                    .SetId(id);
        }
    }
}
