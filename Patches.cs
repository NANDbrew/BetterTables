using HarmonyLib;
using UnityEngine;

namespace BetterTables
{
    internal class Patches
    {
        [HarmonyPatch(typeof(PrefabsDirectory), "PopulateShipItems")]
        public static class TableCollidersPatch
        {
            public static void Postfix()
            {
                if (AssetTools.bundle == null) return;

                int[] indices = { 64, 65, 66, 67, 68, 69, 72, 73, 74, 75, 76, 77, 78, 107, 377, 379 };

                for (int i = 0; i < indices.Length; i++)
                {
                    try
                    {
                        var oldThing = PrefabsDirectory.instance.directory[indices[i]].GetComponent<BoxCollider>();
                        var newThing = AssetTools.bundle.LoadAsset<GameObject>(oldThing.name + ".prefab").GetComponent<BoxCollider>();
                        var bs = newThing.GetComponentsInChildren<Transform>();
                        foreach (Transform cc in bs)
                        {
                            cc.SetParent(oldThing.transform, false);
                            cc.transform.localEulerAngles = Vector3.zero;
                        }
                        oldThing.size = newThing.size;
                        oldThing.center = newThing.center;
                        GameObject.Destroy(newThing.gameObject);
                    }
                    catch { Debug.LogError("BetterTables: couldn't load asset for item " + indices[i]); }
                }
            }
        }
    }
}
