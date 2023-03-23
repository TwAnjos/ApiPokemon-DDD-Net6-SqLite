using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace WebAPIs.ProgramConfigs
{
    public class SwaggerConfig
    {
        internal static Action<SwaggerUIOptions> GetEndpoint()
        {
            return options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI V1");
            };
        }

        internal static Action<SwaggerGenOptions> SwaggerOptions() => options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme." +
                "\r\n\r\n Enter 'Bearer' [Space] and then you token in the text input below." +
                "\r\n\r\n Example: Bearer 12345abcdef"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        };


    }
}
