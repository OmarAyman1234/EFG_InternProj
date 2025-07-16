using Auth.Application.Interfaces;
using Auth.Application.UseCases;
using Auth.Infrastructure;
using Auth.Domain;
using OrderSharedContent;
using OrderSharedContent.Context;
using System.Security.Claims;

namespace Auth.Data.Repositories
{
    public class AuthServices : IAuthServices
    {
        private readonly AuthContext _context;
        private readonly ITokenService _tokenService;
        private readonly LoginUserUseCase _loginUserUseCase;
        private readonly RegisterUserUseCase _registerUserUseCase;
        private readonly RefreshRouteUseCase _refreshRouteUseCase;
        public AuthServices(AuthContext context, ITokenService tokenService, LoginUserUseCase loginUserUseCase, RegisterUserUseCase registerUserUseCase, RefreshRouteUseCase refreshRouteUseCase)
        {
            _context = context;
            _tokenService = tokenService;
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
