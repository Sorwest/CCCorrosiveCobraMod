﻿using FMOD;
using HarmonyLib;

namespace Sorwest.CorrosiveCobra;
internal sealed class StatusMetaPatchesManager
{
    private static ModEntry Instance => ModEntry.Instance;
    public StatusMetaPatchesManager()
    {
        Instance.Harmony.Patch(
            original: AccessTools.DeclaredMethod(typeof(StatusMeta), nameof(StatusMeta.GetSound)),
            postfix: new HarmonyMethod(GetType(), nameof(StatusMeta_GetSound_PostFix))
        );
    }
    private static void StatusMeta_GetSound_PostFix(
        Status status,
        bool isIncrease,
        ref GUID __result)
    {
        if (status == Instance.EvolveStatus.Status || status == Instance.CrystalTapStatus.Status)
        {
            __result = isIncrease ? FSPRO.Event.Status_EvadeUp : FSPRO.Event.Status_EvadeDown;
        }
        else if (status == Instance.HeatControlStatus.Status)
        {
            __result = isIncrease ? FSPRO.Event.Status_TempshieldUp : FSPRO.Event.Status_TempshieldDown;
        }
        else if (status == Instance.HeatOutbreakStatus.Status)
        {
            __result = isIncrease ? FSPRO.Event.Status_ShieldDown : FSPRO.Event.Status_ShieldUp;
        }
    }
}