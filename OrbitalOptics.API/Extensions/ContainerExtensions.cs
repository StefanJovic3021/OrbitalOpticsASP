using OrbitalOptics.Application.UseCases.Commands.Users;
using OrbitalOptics.Application;
using OrbitalOptics.Implementation;
using OrbitalOptics.Implementation.UseCases.Commands.Users;
using System.IdentityModel.Tokens.Jwt;
using OrbitalOptics.Implementation.Logging.UseCases;
using OrbitalOptics.Application.UseCases.Commands.Companies;
using OrbitalOptics.Implementation.UseCases.Commands.Companies;
using OrbitalOptics.Application.UseCases.Queries.Companies;
using OrbitalOptics.Implementation.UseCases.Queries.Companies;
using OrbitalOptics.Application.UseCases.Commands.Categories;
using OrbitalOptics.Implementation.UseCases.Commands.Categories;
using OrbitalOptics.Implementation.Validators.Categories;
using OrbitalOptics.Implementation.Validators.Companies;
using OrbitalOptics.Application.UseCases.Queries.Categories;
using OrbitalOptics.Implementation.UseCases.Queries.Categories;
using OrbitalOptics.Implementation.Validators.Users;
using OrbitalOptics.Application.UseCases.Commands.Images;
using OrbitalOptics.Implementation.UseCases.Commands.Images;
using OrbitalOptics.Implementation.UseCases.Queries.Images;
using OrbitalOptics.Application.UseCases.Queries.Images;
using OrbitalOptics.Implementation.Validators.Images;
using OrbitalOptics.Application.UseCases.Queries.Users;
using OrbitalOptics.Implementation.UseCases.Queries.Users;

namespace OrbitalOptics.API.Extensions
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            // Company usecases
            services.AddTransient<ICreateCompanyCommand, EfCreateCompanyCommand>();
            services.AddTransient<IDeleteCompanyCommand, EfDeleteCompanyCommand>();
            services.AddTransient<IUpdateCompanyCommand, EfUpdateCompanyCommand>();
            services.AddTransient<IGetCompaniesQuery, EfGetCompaniesQuery>();
            services.AddTransient<CreateCompanyDTOValidator>();
            services.AddTransient<DeleteCompanyDTOValidator>();
            services.AddTransient<UpdateCompanyDTOValidator>();
            // Category usecases
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();
            services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();
            services.AddTransient<IGetCategoriesQuery, EfGetCategoriesQuery>();
            services.AddTransient<CreateCategoryDTOValidator>();
            services.AddTransient<DeleteCategoryDTOValidator>();
            services.AddTransient<UpdateCategoryDTOValidator>();
            // Image usecases
            services.AddTransient<ICreateImageCommand, EfCreateImageCommand>();
            services.AddTransient<IDeleteImageCommand, EfDeleteImageCommand>();
            services.AddTransient<IUpdateImageCommand, EfUpdateImageCommand>();
            services.AddTransient<IGetImagesQuery, EfGetImagesQuery>();
            services.AddTransient<CreateImageDTOValidator>();
            services.AddTransient<DeleteImageDTOValidator>();
            services.AddTransient<UpdateImageDTOValidator>();
            // User usecases
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<IUpdateUseAccessCommand, EfUpdateUserAccessCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<RegisterUserDTOValidator>();
            services.AddTransient<UpdateUserAccessDTOValidator>();
            services.AddTransient<DeleteUserDTOValidator>();
            services.AddTransient<UpdateUserDTOValidator>();
            // --------- //
            services.AddTransient<UseCaseHandler>();
            services.AddTransient<IUseCaseLogger, SPUseCaseLogger>();
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
