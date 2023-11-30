
using System.Reflection;
using UnityEngine;

namespace WackyCosmetics
{
    class PluginAssets
    {
        public static AssetBundle LoadBundleFromThisAssembly(string filename) {
            var assembly = Assembly.GetExecutingAssembly();
            if (assembly == null) {
                Plugin.Instance.PluginLogger.LogError("Failed to get assembly reference while loading bundle: " + filename);
                return null;
            }

            return MoreCompany.Utils.BundleUtilities.LoadBundleFromInternalAssembly(filename, assembly);
        }

        public static string[] ListEmbeddedResourcesInThisAssembly() {
            var assembly = Assembly.GetExecutingAssembly();
            if (assembly == null) {
                Plugin.Instance.PluginLogger.LogError("Failed to get assembly reference while listing embedded resources.");
                return null;
            }

            return assembly.GetManifestResourceNames();
        }
    }

}