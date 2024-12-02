using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using UnityEngine;

namespace Mod_PandaFeatMod
{
    internal class FeatPatch
    {
        public static void OnStartCore()
        {
            SourceManager sources = Core.Instance.sources;
            foreach (SourceElement.Row row in sources.elements.rows)
            {
                string alias = row.alias;
                string text = alias;
                FeatPatch.FeatRewrite(row);
            }
        }
        public static void FeatRewrite(SourceElement.Row ele)
        {
            string[] array = new string[]
            {
                "Rapid"
            };

            foreach (string text in array)
            {
                if (ele.alias.Contains(text) && ele.alias.Contains("feat"))
                {
                    ele.categorySub = "special";
                }
            }

        }

    }
}
