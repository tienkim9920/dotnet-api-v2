using System;
using Web_Api_Computer_Shop.Model;

namespace Web_Api_Computer_Shop.Repository
{
    public interface IAuthenticationReponsitory
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        AuthenticateResponse SignUp(SignUpRequest model);
        AuthenticateResponse ForgotPassword(ForgotPasswordRequest model);
        AuthenticateResponse ChangePassword(ChangePasswordRequest model, Guid Id);
    }
}
