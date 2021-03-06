using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Hubs;
using BusinessLogic.Runners;
using BusinessLogic.Services;
using CoreLayer.Interfaces;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Runners;
using CoreLayer.Interfaces.Services;
using DataAccessLayer;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SignalRTestProject.Workers;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Interfaces;

namespace SignalRTestProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IQueueTaskRepository, QueueTaskRepository>();
            services.AddScoped<IQueueTaskStatusRepository, QueueTaskStatusRepository>();
            services.AddHostedService<LoadingWorker>();

            services.AddSingleton<ITaskRepository, TaskRepository>();
            services.AddSingleton<ITaskService, TaskService>();
            services.AddSingleton<ITaskRunner, TaskRunner>();
            services.AddSingleton<ITaskRunner, TaskRunner>();
            services.AddSingleton<ILoadingService, LoadingService>();
            services.AddSingleton<INotifyService, NotifyService>();
            services.AddControllers();
            services.AddSignalR(); // Требуется для работы Веб сокетов
            services.AddCors(options => // CORS для подключения с другого адреса
            {
                options.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.WithOrigins(
                            "http://localhost"
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy"); // установим CORS

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // Указываем путь для подключения по веб сокету
                endpoints.MapHub<LoadingHub>("/loading");
                endpoints.MapHub<NotifyHub>("/notify");
            });
        }
    }
}
