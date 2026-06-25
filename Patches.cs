using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BetterTables
{
    internal class Patches
    {
/*        [HarmonyPatch(typeof(ItemRigidbody), "CreateSubcollider")]
        public static class SubColPatch
        {
            private static void Postfix(ShipItem ___item, List<Collider> ___subcolliders)
            {
                if (___subcolliders.Last().GetComponent<AutoLevel>() is AutoLevel lev)
                {
                    ___item.GetComponentInChildren<AutoLevel>()?.RegisterCol(lev.transform);
                }
                
            }
        }*/
        [HarmonyPatch(typeof(ShipItemHammer), "RaycastHitsFloor")]
        public static class HammerPatch
        {
            [HarmonyPrefix]
            public static bool RaycastHitsFloor(ShipItem item, ref bool __result)
            {
                LayerMask layerMask = -1;
                if (Physics.Raycast(item.GetItemRigidbody().GetComponent<Collider>().bounds.center, Vector3.down, out var hitInfo, 4f, layerMask))
                {
                    if (hitInfo.collider.gameObject.layer == 8)
                    {
                        Debug.Log("TRUE Floor raycast hit: " + hitInfo.collider.name);
                        __result = true;
                        return false;
                    }

                    Debug.Log("FALSE Floor raycast hit: " + hitInfo.collider.name);
                    __result = false;
                    return false;
                }

                Debug.Log("FALSE Floor raycast NO HIT");
                __result = false;
                return false;
            }
        }
        [HarmonyPatch(typeof(PrefabsDirectory), "PopulateShipItems")]
        public static class TableCollidersPatch
        {
            public static void Prefix()
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

                //try
                //{
                if (PrefabsDirectory.instance.directory.Length < 442) Array.Resize(ref PrefabsDirectory.instance.directory, 442);
                Debug.Log("BT trying to add item");
                Plugin.table1 = AssetTools.bundle.LoadAsset<GameObject>("table M S.prefab");
                Plugin.table1.transform.GetChild(0).gameObject.AddComponent<AutoLevel>();
                PrefabsDirectory.instance.directory[440] = Plugin.table1;
                Plugin.table2 = AssetTools.bundle.LoadAsset<GameObject>("table M S 1.prefab");
                Plugin.table2.transform.GetChild(0).gameObject.AddComponent<AutoLevel>();
                PrefabsDirectory.instance.directory[441] = Plugin.table2;
                Debug.Log("BT added item");
                //}
                //catch { Debug.LogError("BT failed to add item"); }
            }
        }
    }
}
