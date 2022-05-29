namespace ShopingRequestSystem.Application.Identity.Commands
{
    public class UserInputModel
    {
        public UserInputModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
