namespace ShopingRequestSystem.Queries.Common
{
    public class ConnectionStrings
    {
        public ConnectionStrings() => this.DefaultConnection = default!;

        public string DefaultConnection { get; private set; }
    }
}
