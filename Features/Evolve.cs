using HarmonyLib;

namespace Sorwest.CorrosiveCobra;

internal sealed class EvolveManager : IStatusLogicHook
{
    public EvolveManager()
    {
        ModEntry.Instance.KokoroApi.RegisterStatusLogicHook(this, 0);
        ModEntry.Instance.Harmony.Patch(
            original: AccessTools.DeclaredMethod(typeof(Card), nameof(Card.OnDraw)),
            postfix: new HarmonyMethod(GetType(), nameof(Card_OnDraw_Postfix))
        );
    }

    private static void Card_OnDraw_Postfix(
        Card __instance,
        State s,
        Combat c)
    {
        if (s.ship.Get(ModEntry.Instance.EvolveStatus.Status) > 0)
        {
            var deck = __instance.GetMeta().deck;
            if (deck == Deck.trash || deck == Deck.corrupted)
            {
                var status = ModEntry.Instance.EvolveStatus.Status;
                var amount = s.ship.Get(status);
                s.ship.PulseStatus(status);
                c.Queue(new ADrawCard()
                {
                    count = amount
                });
            }
        }
        return;
    }
}