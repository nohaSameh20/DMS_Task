using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Application.Users;
using DMS.Application.Interfaces;
using DMS.Application.Services;
using DMS.Application.Items;
using DMS.Application.Items.Commands;

namespace Application
{
    public static class DI
    {
        public static void RegisterApplication(this IServiceCollection services, IFileManagerConfiguration config)
        {

            // Register Configuration 
            services.AddSingleton<IFileManagerConfiguration, FileManagerConfiguration>(provider => new FileManagerConfiguration()
            {
                Container = config.Container,
                HostingPath = config.HostingPath,
                ServerUrl = config.ServerUrl
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IHashService, HashService>();
            services.AddScoped<IFileManagerService, FileManagerService>();


            //===================User=========================
            services.AddScoped<IAddUserCommand, AddUserCommand>();

            //===================Item=====================//
            services.AddScoped<IGetItemsQuery, GetItemsQuery>();
            services.AddScoped<IAddItemFactory, AddItemFactory>();
            services.AddScoped<IAddItemCommand, AddItemCommand>();





        }
    }
}