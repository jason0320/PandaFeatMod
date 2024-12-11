using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HarmonyLib;
using static ActPlan;

[HarmonyPatch]
class CharaListAvailabeFeatsPatch
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(Chara), nameof(Chara.ListAvailabeFeats))]
    internal static void Postfix(ref List<Element> __result)
    {
        foreach (SourceElement.Row item in EClass.sources.elements.rows.Where((SourceElement.Row a) => a.group == "FEAT" && a.cost[0] != -1 && !a.categorySub.IsEmpty()))
        {
            Feat feat = Act.CC.elements.GetOrCreateElement(item.id) as Feat;
            int num = ((feat.ValueWithoutLink <= 0) ? 1 : (feat.ValueWithoutLink + 1));
            if (num <= feat.source.max && (feat.HasTag("class") || feat.HasTag("innate")) && feat.IsAvailable(Act.CC.elements, feat.Value))
            {
                __result.Add(Element.Create(feat.id, num) as Feat);
            }
        }
    }
}

