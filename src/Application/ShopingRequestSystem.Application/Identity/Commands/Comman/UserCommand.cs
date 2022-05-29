namespace ShopingRequestSystem.Application.Identity.Commands.Comman
{
    public abstract class UserCommand
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
