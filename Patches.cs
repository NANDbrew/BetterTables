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

                int[] indices = { 62, 63, 64, 65, 66, 67, 68, 69, 72, 73, 74, 75, 76, 77, 78, 105, 106, 107, 375, 377, 378, 379 };

                for (int i = 0; i < indices.Length; i++)
                {
                    try
                    {
                        var oldThing = PrefabsDirectory.instance.directory[indices[i]].GetComponent<BoxCollider>();
                        var newThing = AssetTools.bundle.LoadAsset<GameObject>(oldThing.name + ".prefab").GetComponent<BoxCollider>();
                        var bs = newThing.GetComponentsInChildren<Transform>();
                        foreach (Transform cc in bs)
                        {
                            //cc.gameObject.tag = "ItemSubcollider";
                            cc.SetParent(oldThing.transform, false);
                            cc.transform.localEulerAngles = Vector3.zero;
                        }
                        oldThing.size = newThing.size;
                        oldThing.center = newThing.center;
                        if (oldThing.GetComponent<MeshCollider>() is MeshCollider oldCol && newThing.GetComponent<MeshCollider>() is MeshCollider newCol)
                        {
                            oldCol.sharedMesh = newCol.sharedMesh;
                        }
                        GameObject.Destroy(newThing.gameObject);

                        // special handling for emerald smoker
                        if (indices[i] == 378)
                        {
                            Transform[] children = oldThing.GetComponentsInChildren<Transform>();
                            for (int t = 0; t < children.Length; t++)
                            {
                                if (children[t].name.StartsWith("col") && Mathf.Approximately(children[t].localPosition.y, 0))
                                {
                                    Debug.Log("destroying child: " + children[t].name);
                                    GameObject.Destroy(children[t].gameObject);
                                }
                            }
                        }
                        Debug.Log("BT: adjusted item: " + oldThing.name);
                    }
                    catch { Debug.LogError("BetterTables: failed to patch item " + indices[i]); }
                }
            }
        }
    }
}
