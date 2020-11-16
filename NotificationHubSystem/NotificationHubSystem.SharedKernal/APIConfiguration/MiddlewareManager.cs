using NotificationHubSystem.SharedKernal.AppConfiguration.Middleware;
using NotificationHubSystem.SharedKernal.Enum;
using NotificationHubSystem.SharedKernal.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Globalization;
using System.IO;
using Microsoft.Extensions.Logging;
using System.Linq;
using FluentValidation.AspNetCore;
using Serilog;
using System.Reflection;
using System;
using System.Collections.Generic;

namespace NotificationHubSystem.SharedKernal.AppConfiguration
{
    public static class MiddlewareManager
    {
        private static string AllowedOrigins = "AllowedOrigins";
        public static void AddAPIConfig(this IServiceCollection services, IConfiguration configuration, bool useCORS = default, bool useSwagger = default, bool useFluentValidation = default)
        {
            #region App localization
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(ResourceEnum.Language.en.ToString());
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo(ResourceEnum.Language.en.ToString()) };

                options.RequestCultureProviders.Insert(0, new Microsoft.AspNetCore.Localization.CustomRequestCultureProvider(context =>
                {
                    string userLangs = context.Request.Headers["Accept-Language"].ToString();
                    string firstLang = userLangs.Split(',').FirstOrDefault();
                    string defaultLang = string.IsNullOrEmpty(firstLang) ? ResourceEnum.Language.en.ToString() : firstLang;
                    return System.Threading.Tasks.Task.FromResult(new Microsoft.AspNetCore.Localization.ProviderCultureResult(defaultLang, defaultLang));
                }));
            });
            #endregion

            #region MVC Core
            if (useFluentValidation)
            {
                services.AddControllers().AddFluentValidation().AddControllersAsServices();
            }
            //else
            //{
            //    services.AddControllersWithViews().AddControllersAsServices();
            //}

            AppSettings appSettings = new AppSettings();
            configuration.Bind("AppSettings", appSettings);
            services.AddSingleton(appSettings);

            SeriLogSettings seriLogSettings = new SeriLogSettings();
            configuration.Bind("SeriLog", seriLogSettings);
            services.AddSingleton(seriLogSettings);
            #endregion

            #region Swagger
            if (useSwagger)
            {
                SwaggerSettings swaggerSettings = new SwaggerSettings();
                configuration.Bind("SwaggerSettings", swaggerSettings);
                services.AddSingleton(swaggerSettings);

                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc(swaggerSettings.Version, new OpenApiInfo
                    {
                        Title = swaggerSettings.Title,
                        Version = swaggerSettings.Version,
                        Description = swaggerSettings.Description
                    });
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = swaggerSettings.Description,
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new System.Collections.Generic.List<string>()
                    }
                    });
                    c.CustomSchemaIds(i =>
                            i.FullName.Replace("Unicom.Notifications.Core.DTOs.UseCase.Escalation.", string.Empty)
                                      .Replace("Unicom.Notifications.SharedKernal.Helper.HttpInOutHandler.", string.Empty)
                                      .Replace("Unicom.Notifications.SharedKernal.Enum.", string.Empty)
                                      .Replace("System.Collections.Generic.", string.Empty)
                                      .Replace("Unicom.Notifications.SharedKernal.Helper.Pagination.", string.Empty)
                                      .Replace("Unicom.Notifications.Core.DTOs.UseCase.Notification.", string.Empty)
                                      .Replace("Unicom.Notifications.Core.", string.Empty)
                                      .Replace("Unicom.Notifications.SharedKernal.", string.Empty)
                                      .Replace("Unicom.Notifications.Core.DTOs.UseCase.User.", string.Empty)
                                      .Replace("`1[[", "[")
                                      .Replace("`2[[", "[")
                                      .Replace(", Unicom.Notification.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]", "]")
                                      .Replace(", NotificationHubSystem.SharedKernal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]", string.Empty)
                                      .Replace(", System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]", string.Empty)
                                      .Replace("[System.String", "System.String")
                                      .Replace("HttpEnum+", "HttpEnum.")
                     );
                });

            }
            #endregion

            #region CORS
            if (useCORS)
            {
                IConfigurationSection originsSection = configuration.GetSection(AllowedOrigins);
                string[] origns = originsSection.AsEnumerable().Where(s => s.Value != null).Select(a => a.Value).ToArray();
                services.AddCors(options =>
                {
                    options.AddPolicy(AllowedOrigins, builder => builder.WithOrigins(origns).AllowAnyMethod().AllowAnyHeader());
                });
            }
            #endregion
        }
        public static void UseAPIConfig(this IApplicationBuilder app, ILoggerFactory loggerFactory, SwaggerSettings swaggerSettings = null, bool useCORS = default, bool useSwagger = default, bool useSignalR = default)
        {
            loggerFactory.AddSerilog();

            #region App Builder
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseAppMiddleware();
            #endregion

            #region Swagger
            if (useSwagger)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(swaggerSettings.URL, swaggerSettings.Name);
                });
            }
            #endregion

            #region CORS
            if (useCORS)
            {
                app.UseCors(AllowedOrigins);
            }
            #endregion
            Helper.AutoFacHelper.Container = app.ApplicationServices;
        }
    }
}
