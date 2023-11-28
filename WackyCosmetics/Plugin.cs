using BepInEx;

using HarmonyLib;
using BepInEx.Logging;
using UnityEngine;
using WackyCosmetics.Cosmetics;
using System.ComponentModel;

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
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance { get; private set; }

        public ManualLogSource PluginLogger;

        public PluginConfig PluginConfig;
        
        private void Awake()
        {
            Instance = this;

            this.PluginLogger = Logger;

            // Apply Harmony patches (if any exist)
            Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll();

            // Plugin startup logic
            PluginLogger.LogInfo($"Plugin {PluginInfo.PLUGIN_NAME} ({PluginInfo.PLUGIN_GUID}) is loaded!");

            // Perform initialization
            LoadConfig();
            LoadCosmetics();
        }

        private void LoadConfig()
        {
            this.PluginConfig = new PluginConfig();
            this.PluginConfig.BindConfig(this.Config);
        }

        private void LoadCosmetics()
        {
            // Sets up a callback for when LC_API.BundleAPI.BundleLoader finishes loading all assets
            LC_API.BundleAPI.BundleLoader.OnLoadedAssets += OnLCAPILoadedAssets;
        }

        private void OnLCAPILoadedAssets()
        {
            // Called when all assets have been loaded by LC_API.BundleAPI.BundleLoader
            WackyCosmeticGeneric.LoadCosmeticsFromThisAssembly();
        }
    }
}
