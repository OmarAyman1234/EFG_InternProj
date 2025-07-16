using OrderSharedContent;

namespace Auth.Application.Interfaces
{
    public interface IAuthServices
    {
        string LoginUser(LoginRequest lr);
        bool RegisterUser(RegisterRequest rr);
        string Refresh();
    }
}
