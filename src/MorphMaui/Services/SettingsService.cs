namespace MorphMaui.Services
{
    internal class SettingsService
    {
        private enum MorphSettings
        {
            ENABLE_SHAKE
        }

        internal async static Task<SettingsService> Create(ISecureStorage storage)
        {
            var service = new SettingsService();
            var storedValue = await storage.GetAsync(MorphSettings.ENABLE_SHAKE.ToString());
            bool resolvedValue;

            if (!bool.TryParse(storedValue, out resolvedValue))
            {
                resolvedValue = true;
                service.EnableShake = resolvedValue;
                await storage.SetAsync(MorphSettings.ENABLE_SHAKE.ToString(), resolvedValue.ToString());
            }

            return service;
        }

        internal bool EnableShake { get; private set; }
    }
}
