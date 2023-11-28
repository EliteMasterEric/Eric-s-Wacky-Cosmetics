using System.Reflection;
using BepInEx.Configuration;
using MoreCompany.Cosmetics;
using UnityEngine;

namespace WackyCosmetics.Cosmetics
{
    public class WackyCosmeticGeneric : CosmeticGeneric
    {
        // public override string gameObjectPath => "assets/WackyCosmetics/Name/Name.prefab";
        // public override string cosmeticId => "wackycosmetics.name";
        // public override string textureIconPath => "assets/WackyCosmetics/Name/Name_Icon.png";
        public virtual string cosmeticName { get; }
        
        // public override CosmeticType cosmeticType => CosmeticType.HAT;

        public void LoadFromLCAPI() {
            // Load this cosmetic and register it with MoreCompany.
            // This uses LC_API.BundleAPI.BundleLoader to load the asset bundle, rather than MoreCompany's BundleUtilities.
            
            GameObject cosmeticInstance = LC_API.BundleAPI.BundleLoader.GetLoadedAsset<GameObject>(gameObjectPath);
            if (cosmeticInstance == null) {
                Plugin.Instance.PluginLogger.LogError("Failed to load cosmetic prefab: " + gameObjectPath);
                return;
            }

            Texture2D icon = LC_API.BundleAPI.BundleLoader.GetLoadedAsset<Texture2D>(textureIconPath);
            if (icon == null) {
                Plugin.Instance.PluginLogger.LogError("Failed to load cosmetic icon: " + textureIconPath);
                return;
            }

            CosmeticInstance cosmeticInstanceBehavior = cosmeticInstance.AddComponent<CosmeticInstance>();
            cosmeticInstanceBehavior.cosmeticId = cosmeticId;
            cosmeticInstanceBehavior.icon = icon;
            cosmeticInstanceBehavior.cosmeticType = cosmeticType;

            if (Plugin.Instance.PluginConfig.IsCosmeticEnabled(this)) {  
                CosmeticRegistry.cosmeticInstances.Add(cosmeticId, cosmeticInstanceBehavior);
                Plugin.Instance.PluginLogger.LogInfo("Loaded Wacky cosmetic: " + cosmeticId);
            } else {
                Plugin.Instance.PluginLogger.LogInfo("Skipped Wacky cosmetic: " + cosmeticId);
            }
        }

        public static void GenerateCosmeticConfigEntries(ConfigFile config) {
            // Gets a meta-reference to this DLL
            var assembly = Assembly.GetExecutingAssembly();

            if (assembly == null) {
                Plugin.Instance.PluginLogger.LogError("Failed to get assembly reference while generating config entries.");
                return;
            } else {
                Plugin.Instance.PluginLogger.LogInfo("Generating config entries for Wacky cosmetics.");
            }

            // Iterates over each class in this DLL
            foreach (var type in assembly.GetTypes()) {
                if (type == null) continue;
                // If it is a WackyCosmeticGeneric, instantiate and load it.
                if (type.IsSubclassOf(typeof(WackyCosmeticGeneric))) {
                    WackyCosmeticGeneric cosmetic = (WackyCosmeticGeneric) System.Activator.CreateInstance(type);
                    Plugin.Instance.PluginConfig.GenerateCosmeticConfigEntry(config, cosmetic);
                }
            }
        }

        public static void LoadCosmeticsFromThisAssembly() {
            // Gets a meta-reference to this DLL
            var assembly = Assembly.GetExecutingAssembly();

            if (assembly == null) {
                Plugin.Instance.PluginLogger.LogError("Failed to get assembly reference while loading cosmetics.");
                return;
            } else {
                Plugin.Instance.PluginLogger.LogInfo("Loading Wacky cosmetics.");
            }

            // Iterates over each class in this DLL
            foreach (var type in assembly.GetTypes()) {
                if (type == null) continue;
                // If it is a WackyCosmeticGeneric, instantiate and load it.
                if (type.IsSubclassOf(typeof(WackyCosmeticGeneric))) {
                    WackyCosmeticGeneric cosmetic = (WackyCosmeticGeneric) System.Activator.CreateInstance(type);
                    cosmetic.LoadFromLCAPI();
                }
            }
        }
    }
}