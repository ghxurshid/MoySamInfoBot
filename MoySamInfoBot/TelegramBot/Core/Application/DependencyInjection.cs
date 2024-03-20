using Autofac.Core;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using MoySamInfoBot.TelegramBot.Core.Application.Interfaces;
using MoySamInfoBot.TelegramBot.Core.Application.Services;
using MoySamInfoBot.TelegramBot.Infrastructure.Context;

namespace MoySamInfoBot.TelegramBot.Core.Application
{
    public static class DependencyInjection
    {
        public static IContainer Container { get; private set; } = null!;

        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            // Регистрируем зависимости
            builder.RegisterType<IMenuFactory>().As<MenuFactory>();
            builder.RegisterType<IResourcesManager>().As<ResourcesManager>();
            builder.RegisterType<Context>().AsSelf();

            // Другие регистрации

            Container = builder.Build();
        }
    }
}
