using System.Linq;
using Parliament.Common.Interfaces;
using StructureMap;
using StructureMap.Graph;

namespace Parliament.Common.IoC
{
    public class Bootstrapper
    {
        public static IContainer Build()
        {
            var container = new Container(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.AssembliesFromApplicationBaseDirectory(
                        y =>
                            (y.FullName.StartsWith("Parliament") || y.FullName.StartsWith("Veneer")) &&
                            !y.FullName.EndsWith("Tests"));
                    scan.WithDefaultConventions();
                    scan.LookForRegistries();
                });
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.AssembliesFromApplicationBaseDirectory(
                        y =>
                            (y.FullName.StartsWith("Parliament") || y.FullName.StartsWith("Veneer")) &&
                            !y.FullName.EndsWith("Tests"));
                    scan.Include(y =>
                    {
                        return y.GetInterfaces().Any(z => z.IsAssignableFrom(typeof (IPluggable)));
                    });
                });
            });
            
            container.AssertConfigurationIsValid();
            return container;            
        }
    }
}