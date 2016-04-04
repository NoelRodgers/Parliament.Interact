using System.Collections.Generic;
using System.Linq;

namespace Parliament.Interact.Core.Migrations.ABTestingSeeds
{
    public class ABTestingFactory : IABTestingFactory
    {
        private readonly IList<IABTestingItem> _items;

        public ABTestingFactory(IList<IABTestingItem> items)
        {
            _items = items;
        }

        public IABTestingItem GetSeed(string abConfigSetting)
        {
            return _items.SingleOrDefault(x => x.ConfigurationName == abConfigSetting);
        }
    }
}