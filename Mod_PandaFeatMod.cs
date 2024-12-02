using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace Mod_PandaFeatMod
{

    [BepInPlugin("panda.feat.mod", "Panda's Feat Mod", "1.0.0.0")]
    public class Mod_PandaFeatMod : BaseUnityPlugin
    {
        private void Start()
        {
            var harmony = new Harmony("Panda's Feat Mod");
            harmony.PatchAll();
        }
        public void OnStartCore()
        {
            FeatPatch.OnStartCore();
        }
    }
}