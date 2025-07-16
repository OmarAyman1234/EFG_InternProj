using Auth.Application.Interfaces;
using OrderSharedContent;

namespace Auth.Application.UseCases
{
    public class AuthServices : IAuthServices
    {
        private readonly LoginUserUseCase _loginUserUseCase;
        private readonly RegisterUserUseCase _registerUserUseCase;
        private readonly RefreshRouteUseCase _refreshRouteUseCase;
        public AuthServices(LoginUserUseCase loginUserUseCase, RegisterUserUseCase registerUserUseCase, RefreshRouteUseCase refreshRouteUseCase)
        {
            _loginUserUseCase = loginUserUseCase;
            _registerUserUseCase = registerUserUseCase;
            _refreshRouteUseCase = refreshRouteUseCase;
        }

        public string LoginUser(LoginRequest lr)
        {
            return _loginUserUseCase.Execute(lr);
        }
        public bool RegisterUser(RegisterRequest rr)
        {
            return _registerUserUseCase.Execute(rr);
        }
        public string Refresh()
        {
            return _refreshRouteUseCase.Execute();
        }
    }
}
