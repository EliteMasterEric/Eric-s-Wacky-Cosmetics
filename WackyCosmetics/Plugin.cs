using BepInEx;

using HarmonyLib;
using BepInEx.Logging;
using WackyCosmetics.Cosmetics;

namespace WackyCosmetics
{
    public static class PluginInfo
    {
        public const string PLUGIN_ID = "WackyCosmetics";
        public const string PLUGIN_NAME = "EliteMasterEric's Wacky Cosmetics";
        public const string PLUGIN_VERSION = "1.0.0";
        public const string PLUGIN_GUID = "com.elitemastereric.wackycosmetics";
    }

    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency(MoreCompany.PluginInformation.PLUGIN_GUID, BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance { get; private set; }

        public ManualLogSource PluginLogger;

        public PluginConfig PluginConfig;
        
        private void Awake()
        {
            Instance = this;

            PluginLogger = Logger;

            // Apply Harmony patches (if any exist)
            Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll();

            // Plugin startup logic
            PluginLogger.LogInfo($"Plugin {PluginInfo.PLUGIN_NAME} ({PluginInfo.PLUGIN_GUID}) is loaded!");

            // PluginLogger.LogWarning(string.Join("\n", PluginAssets.ListEmbeddedResourcesInThisAssembly()));

            // Perform initialization
            LoadConfig();
            LoadCosmetics();
        }

        private void LoadConfig()
        {
            PluginConfig = new PluginConfig();
            PluginConfig.BindConfig(Config);
        }

        private void LoadCosmetics()
        {
            WackyCosmeticGeneric.LoadCosmeticsFromThisAssembly();
        }
    }
}
