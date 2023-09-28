using Autofac;
using Module = ConsoleApps.ConsoleApp.Module;

var builder = new ContainerBuilder();
builder.RegisterAssemblyModules(Module.Assemblies);
var container = builder.Build();

using var scope = container.BeginLifetimeScope();

var app = scope.Resolve<App>();
app.Run();
