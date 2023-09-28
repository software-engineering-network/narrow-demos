using Autofac;

namespace ConsoleApps.Infrastructure.InMemory;

public class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Storage>().AsSelf();
    }
}
