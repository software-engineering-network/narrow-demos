using System.Reflection;
using Autofac;
using ConsoleApps.Infrastructure.InMemory;
using ConsoleApps.Infrastructure.Read;
using ConsoleApps.Services;

namespace ConsoleApps.ConsoleApp;

public class Module : Autofac.Module
{
    public static readonly Assembly[] Assemblies =
    {
        typeof(Program).Assembly, // ui
        typeof(MakeSale).Assembly, // services
        typeof(FetchCars).Assembly, // infrastructure read
        typeof(Storage).Assembly // infrastructure write
    };

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(Assemblies).AsImplementedInterfaces();
        builder.RegisterType<App>().AsSelf();
    }
}
