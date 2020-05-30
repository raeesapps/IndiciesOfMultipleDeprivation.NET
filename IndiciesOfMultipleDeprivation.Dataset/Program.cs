using Autofac;

namespace IndiciesOfMultipleDeprivation
{
    class Program
    {
        public static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using var scope = container.BeginLifetimeScope();
            var bootstrap = scope.Resolve<IBootstrap>();
            bootstrap.Start();
        }
    }
}