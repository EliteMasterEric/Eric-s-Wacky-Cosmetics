using System.Reflection;
using BepInEx.Configuration;
using MoreCompany.Cosmetics;
using MoreCompany.Utils;
using UnityEngine;

namespace WackyCosmetics.Cosmetics
{
    public class WackyCosmeticGeneric : CosmeticGeneric
    {
        // public override string gameObjectPath => "assets/WackyCosmetics/Name/Name.prefab";
        // public override string cosmeticId => "wackycosmetics.name";
        // public override string textureIconPath => "assets/WackyCosmetics/Name/Name_Icon.png";
        public virtual string cosmeticName { get; } // Name
        public virtual string assetBundlePath { get; } // WackyCosmetics.cosmetic_name.bundle
        
        // public override CosmeticType cosmeticType => CosmeticType.HAT;

        // Once the asset bundle is loaded, store a reference to it here.
        public AssetBundle assetBundle { get; private set; }

        public void LoadFromAssetBundle() {
            if (!Plugin.Instance.PluginConfig.IsCosmeticEnabled(this)) {  
                Plugin.Instance.PluginLogger.LogInfo("Skipped Wacky cosmetic: " + cosmeticId);
                return;
            }

            // Load the asset bundle for this cosmetic.
            assetBundle = PluginAssets.LoadBundleFromThisAssembly(assetBundlePath);
            if (assetBundle == null) {
                Plugin.Instance.PluginLogger.LogError("Failed to load cosmetic asset bundle: " + assetBundlePath);
                return;
            }

            // Instantiate the cosmetic prefab from the asset bundle.
            GameObject cosmeticInstance = assetBundle.LoadPersistentAsset<GameObject>(gameObjectPath);
            if (cosmeticInstance == null) {
                Plugin.Instance.PluginLogger.LogError("Failed to load cosmetic prefab: " + gameObjectPath);
                return;
            }

            // Load the cosmetic icon from the asset bundle.
            Texture2D icon = assetBundle.LoadPersistentAsset<Texture2D>(textureIconPath);
            if (icon == null) {
                Plugin.Instance.PluginLogger.LogError("Failed to load cosmetic icon: " + textureIconPath);
                return;
            }

            CosmeticInstance cosmeticInstanceBehavior = cosmeticInstance.AddComponent<CosmeticInstance>();
            cosmeticInstanceBehavior.cosmeticId = cosmeticId;
            cosmeticInstanceBehavior.icon = icon;
            cosmeticInstanceBehavior.cosmeticType = cosmeticType;

            CosmeticRegistry.cosmeticInstances.Add(cosmeticId, cosmeticInstanceBehavior);
            Plugin.Instance.PluginLogger.LogInfo("Loaded Wacky cosmetic: " + cosmeticId);
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
                    // Load the cosmetic from the asset bundle, and add it to the registry.
                    cosmetic.LoadFromAssetBundle();
                }
            }
        }
    }
}