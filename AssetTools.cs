using System.IO;
using UnityEngine;

namespace BetterTables
{
    internal class AssetTools
    {
        public static AssetBundle bundle;
        const string assetFile = "furniture_cols";

        public static void LoadAssetBundles()    //Load the bundle
        {
            string dataPath = Directory.GetParent(Plugin.instance.Info.Location).FullName;
            try
            {
                bundle = AssetBundle.LoadFromFile(Path.Combine(dataPath, assetFile));
            }
            catch 
            {
                Debug.LogError("BetterTables: Bundle not loaded! Did you place it in the correct folder?");
            }

            if (bundle != null) { Debug.Log("BetterTables: loaded bundle " + bundle.ToString()); }

            

        }
    }
}
