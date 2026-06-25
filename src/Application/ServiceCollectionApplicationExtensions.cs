using Application.Command;
using Application.Command.Handler;
using Application.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public static class ServiceCollectionApplicationExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services
                .AddCommandBehavior<RenameSwitcherCommand, RenameSwitcherCommandHandler>()
                .AddCommandBehavior<RenameSwitcherInputCommand, RenameSwitcherInputCommandHandler>();

            return services;
        }


        static IServiceCollection AddCommandBehavior<TCommand, TCommandHandler>(this IServiceCollection services)
            where TCommand : ICommand
            where TCommandHandler : class, ICommandHandler<TCommand>
        {
            services.AddTransient<ICommandHandler<TCommand>, TCommandHandler>();

            return services;    
        }
    }
}
