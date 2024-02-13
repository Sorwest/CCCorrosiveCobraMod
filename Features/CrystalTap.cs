
using HarmonyLib;

namespace Sorwest.CorrosiveCobra;

internal sealed class CrystalTapManager : IStatusLogicHook
{
    private static ModEntry Instance => ModEntry.Instance;
    public CrystalTapManager()
    {
        Instance.KokoroApi.RegisterStatusLogicHook(this, 0);
        Instance.Harmony.Patch(
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
        if (__result && s.ship.Get(Instance.CrystalTapStatus.Status) > 0)
        {
            var status = Instance.CrystalTapStatus.Status;
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