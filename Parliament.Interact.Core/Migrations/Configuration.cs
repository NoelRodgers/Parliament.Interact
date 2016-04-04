using System;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using Parliament.Common.Interfaces;
using Parliament.Common.IoC;
using Parliament.Interact.Core.Domain.Context;
using Parliament.Interact.Core.Migrations.ABTestingSeeds;
using Parliament.Interact.Core.Migrations.ABTestingSeeds.Settings;
using StructureMap;
using StructureMap.Graph;

namespace Parliament.Interact.Core.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<InteractDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InteractDbContext context)
        {
            context.ActionContents.RemoveRange(context.ActionContents);
            context.IssueActionContents.RemoveRange(context.IssueActionContents);
            context.IssueTimeLines.RemoveRange(context.IssueTimeLines);
            context.FurtherReadings.RemoveRange(context.FurtherReadings);
            context.IssueActions.RemoveRange(context.IssueActions);
            context.ActionItems.RemoveRange(context.ActionItems);
            context.Issues.RemoveRange(context.Issues);
            context.FurtherReadings.RemoveRange(context.FurtherReadings);
            context.IssueTimeLines.RemoveRange(context.IssueTimeLines);

            var container = new Container(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.AssemblyContainingType<IConfigurationBuilder>();
                    scan.WithDefaultConventions();
                    scan.LookForRegistries();
                });
            });                                
         
            var seedFactory = container.GetInstance<IABTestingFactory>();
            var settings = container.GetInstance<IConfigurationBuilder>().GetConfiguration<ABTestingSettings>();
            var seedItem = seedFactory.GetSeed(settings.ABTestingSeed);
            if (seedItem != null) seedItem.Seed(context);
        }
    }
}
