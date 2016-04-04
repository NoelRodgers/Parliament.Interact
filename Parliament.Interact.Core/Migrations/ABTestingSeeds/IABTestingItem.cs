using Parliament.Interact.Core.Domain.Context;

namespace Parliament.Interact.Core.Migrations.ABTestingSeeds
{
    public interface IABTestingItem
    {
        string ConfigurationName { get;  }

        void Seed(InteractDbContext context);
    }
}