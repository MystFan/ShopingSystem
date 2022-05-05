namespace ShopingRequestSystem.Domain.RequestExecutions.Models
{
    using System;
    using System.Collections.Generic;

    internal class TransportTypeData
    {
        public Type EntityType => typeof(TransportType);

        public IEnumerable<object> GetData()
            => new List<TransportType>
            {
                new TransportType("Mothor Vehicle", "This vehicles include motorcycles, cars, trucks, buses."),
            };
    }
}
