namespace Parliament.Interact.Core.Migrations.ABTestingSeeds
{
    public interface IABTestingFactory
    {
        IABTestingItem GetSeed(string abConfigSetting);
    }
}