using OrbitalOptics.Application.UseCases.Commands.Users;
using OrbitalOptics.Application;
using OrbitalOptics.Implementation;
using OrbitalOptics.Implementation.UseCases.Commands.Users;
using OrbitalOptics.Implementation.Validators;
using System.IdentityModel.Tokens.Jwt;
using OrbitalOptics.Implementation.Logging.UseCases;
using OrbitalOptics.Application.UseCases.Commands.Companies;
using OrbitalOptics.Implementation.UseCases.Commands.Companies;

namespace OrbitalOptics.API.Extensions
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<ICreateCompanyCommand, EfCreateCompanyCommand>();
            services.AddTransient<UseCaseHandler>();
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<IUseCaseLogger, SPUseCaseLogger>();
            services.AddTransient<RegisterUserDTOValidator>();
            services.AddTransient<CreateCompanyDTOValidator>();
        }

        public static Guid? GetTokenId(this HttpRequest request)
        {
            if (request == null || !request.Headers.ContainsKey("Authorization"))
            {
                return null;
            }

            string authHeader = request.Headers["Authorization"].ToString();

            if (authHeader.Split("Bearer ").Length != 2)
            {
                return null;
            }

            string token = authHeader.Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            var claims = tokenObj.Claims;

            var claim = claims.First(x => x.Type == "jti").Value;

            var tokenGuid = Guid.Parse(claim);

            return tokenGuid;
        }
    }
}
