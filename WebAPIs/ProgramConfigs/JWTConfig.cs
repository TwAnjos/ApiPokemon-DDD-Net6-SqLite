using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebAPIs.Token;

namespace WebAPIs.ProgramConfigs
{
    public class JWTConfig
    {
        internal static Action<AuthenticationOptions> GetJWTConfig()
        {
            return options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            };
        }
        internal static Action<JwtBearerOptions> AddJwtBearerConfig(WebApplicationBuilder builder)
        {
            return options =>
            {
                var jk = JwtSecurityKey.Create("Secret_Key-12345678");

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    RequireAudience = false,

                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateActor = false,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = "Teste.Issuer.Bearer",
                    ValidAudience = "Teste.Audience.Bearer",
                    IssuerSigningKey = jk
                };

                options.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = authentication =>
                    {
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = authentication =>
                    {
                        return Task.CompletedTask;
                    }
                };
            };
        }

        

       

    }
}
