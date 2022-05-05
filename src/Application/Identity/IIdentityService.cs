namespace ShopingRequestSystem.Application.Identity
{
    using System.Threading.Tasks;
    using ShopingRequestSystem.Application.Common;
    using ShopingRequestSystem.Application.Identity.Commands;
    using ShopingRequestSystem.Application.Identity.Commands.ChangePassword;
    using ShopingRequestSystem.Application.Identity.Commands.LoginUser;

    public interface IIdentityService
    {
        Task<Result<IUser>> Register(UserInputModel userInput);

        Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
    }
}
