using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mailer.Core.Mappers;
using Mailer.Core.ServerConnections;
using Mailer.Core.Services;
using Mailer.Core.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Mailer.Api
{
    public class Startup
    {
        string _testSecret = null;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            if(env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(x => x.SerializerSettings.Formatting = Formatting.Indented);
            services.Configure<EmailConfig>(Configuration.GetSection("EmailConfig"));
            services.Configure<EmailSecrets>(Configuration.GetSection("EmailSecrets"));
            services.AddTransient<IInboxService, InboxService>();
            services.AddTransient<ISmtpService, SmtpService>();
            services.AddTransient<IImapConnection, ImapConnection>();
            services.AddTransient<ISmtpConnection, SmtpConnection>();
            services.AddSingleton(AutoMapperConfig.Initialize());
            _testSecret = Configuration["Password"];
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
