namespace ShopingRequestSystem.Web.Examples
{
    using Swashbuckle.AspNetCore.Filters;
    using ShopingRequestSystem.Application.Identity.Commands.LoginUser;

    internal class LoginOutputModelExample : IExamplesProvider<LoginOutputModel>
    {
        public LoginOutputModel GetExamples()
        {
            return new LoginOutputModel("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI1ZDMwMjgyZi1jZmE3LTRiMWEtOTFmZS04ZGNmNzA0MDI2MjMiLCJ1bmlxdWVfbmFtZSI6InRvZG9yLRpbWl0cm92QHNjYWxlZm9jdXMuY29tIiwibmJmIjoxNjUzNTYyNDY4LCJleHAiOjE2NTQxNjcyNjgsImlhdCI6MTY1MzU2MjQ2OH0._-KVfSehFEAkee2_yCgpw6Y6Gti2UF9t_RU5C5nTKY0");
        }
    }
}
