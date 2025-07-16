using OrderSharedContent;

namespace Auth.Data.Repositories
{
    public interface IAuthServices
    {
        string LoginUser(LoginRequest lr);
        bool RegisterUser(RegisterRequest rr);
        string Refresh();
    }
}
