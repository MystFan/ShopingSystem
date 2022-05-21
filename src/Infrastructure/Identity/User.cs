namespace ShopingRequestSystem.Infrastructure.Identity
{
    using Microsoft.AspNetCore.Identity;
    using ShopingRequestSystem.Application.Identity.Commands;
    using ShopingRequestSystem.Domain.Common;

    public class User : IdentityUser, IUser, IAggregateRoot
    {
        internal User(string email)
            : base(email)
            => this.Email = email;
    }
}
