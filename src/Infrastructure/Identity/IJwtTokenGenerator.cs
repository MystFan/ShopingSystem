namespace ShopingRequestSystem.Infrastructure.Identity
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
