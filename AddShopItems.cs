using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BetterTables
{
    internal class AddShopItems
    {
        internal static void SceneLoaded(Scene scene, LoadSceneMode _)
        {
/*            if (scene.name == "island 1 A Gold Rock")
                GoldRockCity();*/
            if (scene.name == "island 15 M (Fort)")
                FortAestrin();
/*            if (scene.name == "island 9 E Dragon Cliffs")
                DragonCliffs();
            if (scene.name == "island 26 Lagoon SwampTemple")
                FireFishTown();
            if (scene.name == "island 20 A (Oasis)")
                Oasis();
            if (scene.name == "island 18 M (Oasis)")
                HappyBay();*/
        }

/*        internal static void GoldRockCity()
        {
            var scenery = GameObject.Find("island 1 A (gold rock) scenery");
            if (scenery == null)
            {
                LogError("Gold Rock City scenery not found.");
                return;
            }

            var itemToMove = scenery.GetComponentsInChildren<Transform>()?.FirstOrDefault(t => t.name == "shop item (217)");
            if (itemToMove != null)
                itemToMove.localPosition = new Vector3(1539.777f, 7.558f, -385.538f);
            MakeShopItem("shop item 301", scenery.transform, new Vector3(1538.75f, 5.71f, -385.08f), new Vector3(0f, 55f, 0f), Items.SealingNails);
            MakeShopItem("shop item 302", scenery.transform, new Vector3(1538.75f, 6.17f, -385.08f), new Vector3(0f, 55f, 0f), Items.SealingNails);
            MakeShopItem("shop item 303", scenery.transform, new Vector3(1534.969f, 6.875f, -377.88f), new Vector3(0f, 325.504f, 0f), Items.EmptyCrate);
            MakeShopItem("shop item 304", scenery.transform, new Vector3(1534.969f, 5.49f, -377.88f), new Vector3(0f, 325.504f, 0f), Items.EmptyCrate);
            MakeShopItem("shop item 305", scenery.transform, new Vector3(1537.369f, 5.5f, -381.38f), new Vector3(0f, 325.504f, 0f), Items.EmptyCrate);
            MakeShopItem("shop item 306", scenery.transform, new Vector3(1539.86f, 7.215f, -385.86f), new Vector3(90f, 0f, 0f), Items.SpoonLure);
            MakeShopItem("shop item 307", scenery.transform, new Vector3(1539.05f, 5.87f, -386.2f), new Vector3(270f, 55f, 0f), Items.CrateSpoonLures);
            MakeShopItem("shop item 308", scenery.transform, new Vector3(1539.6f, 5.87f, -387f), new Vector3(270f, 55f, 0f), Items.CrateSpoonLures);
        }*/

        internal static void FortAestrin()
        {
            var scenery = GameObject.Find("island 15 M (Fort) scenery");
            if (scenery == null)
            {
                Debug.LogError("Fort Aestrin scenery not found.");
                return;
            }

            MakeShopItem("shop item (311)", scenery.transform, new Vector3(-9.38916f, 2.411f, 60.136f), new Vector3(10.589f, 18.672f, 90.00001f), Plugin.table1);
            MakeShopItem("shop item (312)", scenery.transform, new Vector3(-9.867f, 2.41f, 59.559f), new Vector3(11.729f, 18.968f, 90.00001f), Plugin.table2);
        }

        /*internal static void DragonCliffs()
        {
            var scenery = GameObject.Find("island 9 E (dragon cliffs) scenery");
            if (scenery == null)
            {
                LogError("Dragon Cliffs scenery not found.");
                return;
            }

            MakeShopItem("shop item spawner (301)", scenery.transform, new Vector3(-81.883f, 3.945f, -549.095f), new Vector3(0f, 224f, 0f), Items.SealingNails);
            MakeShopItem("shop item spawner (302)", scenery.transform, new Vector3(-81.883f, 3.715f, -549.095f), new Vector3(0f, 224f, 0f), Items.SealingNails);
            var itemToMove = scenery.GetComponentsInChildren<Transform>()?.FirstOrDefault(t => t.name == "shop item spawner (158)");
            if (itemToMove != null)
                itemToMove.localPosition = new Vector3(-85f, 4.116f, -548.19f);
            MakeShopItem("shop item spawner (303)", scenery.transform, new Vector3(-86.6f, 4.116f, -547.0f), new Vector3(90f, 44.117f, 270f), Items.EmptyCrate);
            MakeShopItem("shop item spawner (304)", scenery.transform, new Vector3(-81.403f, 4.216f, -551.395f), new Vector3(0f, 134.117f, 270f), Items.EmptyCrate);
            MakeShopItem("shop item spawner (305)", scenery.transform, new Vector3(-82.403f, 4.216f, -550.395f), new Vector3(0f, 134.117f, 270f), Items.EmptyCrate);
            MakeShopItem("shop item spawner (306)", scenery.transform, new Vector3(-84.48f, 4.266f, -548.85f), new Vector3(90f, 214.8614f, 0f), Items.SwimbaitLure);
            MakeShopItem("shop item spawner (307)", scenery.transform, new Vector3(-83.82f, 3.752f, -548.424f), new Vector3(0f, 221.5683f, 0f), Items.CrateSwimbaitLures);
            MakeShopItem("shop item spawner (308)", scenery.transform, new Vector3(-83.82f, 3.977f, -548.424f), new Vector3(0f, 221.5683f, 0f), Items.CrateSwimbaitLures);
        }

        internal static void FireFishTown()
        {
            var scenery = GameObject.Find("island lagoon Temple scenery");
            if (scenery == null)
            {
                LogError("Fire Fish Town scenery not found.");
                return;
            }

            MakeShopItem("shop item (301)", scenery.transform, new Vector3(-4.1f, 0.365f, -2.97f), new Vector3(0f, 276f, 0f), Items.SealingNails);
            MakeShopItem("shop item (302)", scenery.transform, new Vector3(-4.05f, 0.365f, -2.485f), new Vector3(0f, 276f, 0f), Items.SealingNails);
            MakeShopItem("shop item (303)", scenery.transform, new Vector3(-4.4767f, 0.24f, 0.15f), new Vector3(0f, 5.3656f, 0f), Items.EmptyCrate);
            MakeShopItem("shop item (304)", scenery.transform, new Vector3(-7f, 0.2f, 0.75f), new Vector3(0f, 95.3656f, 0f), Items.EmptyCrate);
            MakeShopItem("shop item (305)", scenery.transform, new Vector3(-7f, 0.88f, 0.75f), new Vector3(0f, 95.3656f, 0f), Items.EmptyCrate);
        }

        internal static void Oasis()
        {
            var scenery = GameObject.Find("island 20 A (oasis) scenery");
            if (scenery == null)
            {
                LogError("Oasis scenery not found.");
                return;
            }

            MakeShopItem("shop item (301)", scenery.transform, new Vector3(78.174f, 15.798f, -142.55f), new Vector3(270f, 180f, 0f), Items.SealingNails);
            MakeShopItem("shop item (302)", scenery.transform, new Vector3(78.073f, 15.45f, -144f), new Vector3(0f, 89.1775f, 0f), Items.EmptyCrate);
            MakeShopItem("shop item (303)", scenery.transform, new Vector3(78.073f, 15.45f, -146.7f), new Vector3(0f, 89.1775f, 0f), Items.EmptyCrate);
            MakeShopItem("shop item (304)", scenery.transform, new Vector3(78.073f, 15.45f, -149.4f), new Vector3(0f, 89.1775f, 0f), Items.EmptyCrate);
        }

        internal static void HappyBay()
        {
            var scenery = GameObject.Find("island 18 M (Oasis) scenery");
            if (scenery == null)
            {
                LogError("Happy Bay scenery not found.");
                return;
            }

            MakeShopItem("shop item (301)", scenery.transform, new Vector3(-137.68f, 5.58f, 22.87f), new Vector3(270f, 210f, 0f), Items.SealingNails);
            MakeShopItem("shop item (302)", scenery.transform, new Vector3(-138.268f, 4.71f, 21.9f), new Vector3(0f, 30f, 0f), Items.EmptyCrate);
            MakeShopItem("shop item (303)", scenery.transform, new Vector3(-137.74f, 4.71f, 22.84f), new Vector3(0f, 30f, 0f), Items.EmptyCrate);
            MakeShopItem("shop item (304)", scenery.transform, new Vector3(-138.04f, 5.41f, 22.34f), new Vector3(0f, 30f, 0f), Items.EmptyCrate);
        }*/

        private static void MakeShopItem(string name, Transform parent, Vector3 position, Vector3 rotation, GameObject go)
        {
            var shopitem = new GameObject(name);
            shopitem.transform.parent = parent;
            shopitem.transform.localPosition = position;
            shopitem.transform.localRotation = Quaternion.Euler(rotation);
            var filter = shopitem.AddComponent<MeshFilter>();
            filter.mesh = go.GetComponent<MeshFilter>().mesh;
            shopitem.AddComponent<MeshRenderer>();
            var itemSpawner = shopitem.AddComponent<ShopItemSpawner>();
            itemSpawner.itemPrefab = go;
        }
    }
}
