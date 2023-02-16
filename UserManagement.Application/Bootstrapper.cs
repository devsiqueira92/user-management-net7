using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UserManagement.Application.Services.LoggedUser;
using UserManagement.Application.Services.Token;
using UserManagement.Application.UseCases.CheckEmail;
using UserManagement.Application.UseCases.Login;
using UserManagement.Application.UseCases.PasswordChange;
using UserManagement.Application.UseCases.UserRegister;

namespace UserManagement.Application
{
    public static class Bootstrapper
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            AddTokenConfiguration(services, configuration);
            AddUseCases(services);
            AddServices(services);
        }

        private static void AddUseCases(IServiceCollection services) 
        {
            services.AddScoped<IUserRegisterUseCase, UserRegisterUseCase>()
                .AddScoped<ICheckEmailUseCase, CheckEmailUseCase>()
                .AddScoped<ILoginUseCase, LoginUseCase>()
                .AddScoped<IPasswordChangeUseCase, PasswordChangeUseCase>();
        }

        private static void AddTokenConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "localhost",
                    ValidAudience = "localhost",
                    IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(configuration.GetSection("Secrets:SecurityKey").Value))
                };

            });

            var sectionTempoDeVida = configuration.GetRequiredSection("Configuracoes:Jwt:TempoVidaTokenMinutos");
            var sectionKey = configuration.GetRequiredSection("Secrets:SecurityKey");
            services.AddScoped<ITokenController>(option => new TokenController(int.Parse(sectionTempoDeVida.Value), sectionKey.Value));
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<ILoggedUser, LoggedUser>();
        }

    }
}
