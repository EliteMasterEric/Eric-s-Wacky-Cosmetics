using System.Collections.Generic;
using BepInEx.Configuration;
using WackyCosmetics.Cosmetics;

namespace WackyCosmetics
{
    public class PluginConfig
    {
        public Dictionary<string, ConfigEntry<bool>> CosmeticConfigEntries;

        // Constructor
        public PluginConfig()
        {
            CosmeticConfigEntries = new Dictionary<string, ConfigEntry<bool>>();
        }

        // Bind config values to fields
        public void BindConfig(ConfigFile config)
        {
            WackyCosmeticGeneric.GenerateCosmeticConfigEntries(config);
        }

        internal void GenerateCosmeticConfigEntry(ConfigFile config, WackyCosmeticGeneric cosmetic)
        {
            ConfigEntry<bool> entry = config.Bind(
                "Cosmetics", // Category
                "EnableCosmetic_" + cosmetic.cosmeticId, // Key
                true, // Default value
                "Enable the " + cosmetic.cosmeticName + " cosmetic." // Description
            );

            CosmeticConfigEntries.Add(cosmetic.cosmeticId, entry);
        }

        public bool IsCosmeticEnabled(WackyCosmeticGeneric cosmetic)
        {
            return CosmeticConfigEntries[cosmetic.cosmeticId].Value;
        }
    }
}
