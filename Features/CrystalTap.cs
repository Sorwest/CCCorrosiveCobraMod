
using HarmonyLib;

namespace Sorwest.CorrosiveCobra;

internal sealed class CrystalTapManager : IStatusLogicHook
{
    public CrystalTapManager()
    {
        ModEntry.Instance.KokoroApi.RegisterStatusLogicHook(this, 0);
        ModEntry.Instance.Harmony.Patch(
            original: AccessTools.DeclaredMethod(typeof(Combat), nameof(Combat.TryPlayCard)),
            postfix: new HarmonyMethod(GetType(), nameof(Combat_TryPlayCard_Postfix))
        );
    }

    private static void Combat_TryPlayCard_Postfix(
        Combat __instance,
        State s,
        Card card,
        ref bool __result)
    {
        if (__result && s.ship.Get(ModEntry.Instance.CrystalTapStatus.Status) > 0)
        {
            var status = ModEntry.Instance.CrystalTapStatus.Status;
            var amount = s.ship.Get(status);
            foreach (CardAction cardAction in card.GetActionsOverridden(s, __instance))
            {
                if (cardAction is not AEndTurn)
                    __instance.Queue(Mutil.DeepCopy(cardAction));
            }
            s.ship.Set(status, amount - 1);
    }
        return;
    }
}