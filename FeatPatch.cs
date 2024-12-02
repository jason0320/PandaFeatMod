using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using HarmonyLib;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;
using static Gross;

namespace Mod_PandaFeatMod
{
    internal class FeatPatch
    {
        public static void OnStartCore()
        {
            SourceManager sources = Core.Instance.sources;
            foreach (SourceElement.Row row in sources.elements.rows)
            {
                FeatPatch.FeatRewrite(row);
            }
        }
        public static void FeatRewrite(SourceElement.Row ele)
        {
            if (ele.group == "FEAT" && ele.categorySub.IsEmpty())
            {
                ele.categorySub = "special";
            }
        }
    }
}
