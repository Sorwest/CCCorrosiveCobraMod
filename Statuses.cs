using CobaltCoreModding.Definitions.ExternalItems;
using CobaltCoreModding.Definitions.ModContactPoints;

namespace Sorwest.CorrosiveCobra;
public partial class Manifest
{
    public static ExternalStatus? EvolveStatus { get; private set; }
    public static ExternalStatus? HeatOutbreakStatus { get; private set; }
    public static ExternalStatus? HeatControlStatus { get; private set; }
    public void LoadManifest(IStatusRegistry statusRegistry)
    {
        {
            EvolveStatus = new ExternalStatus("Sorwest.CorrosiveCobra.Status.EvolveStatus", true, CorrosiveCobraColor, null, EvolveStatusSprite ?? throw new Exception("MissingSprite"), true);
            EvolveStatus.AddLocalisation("Evolve", "Whenever you draw a <c=trash>Trash</c> card, <c=keyword>draw {0}</c>.");
            statusRegistry.RegisterStatus(EvolveStatus);
        }
        {
            HeatOutbreakStatus = new ExternalStatus("Sorwest.CorrosiveCobra.Status.HeatOutbreakStatus", false, CorrosiveCobraColor, null, HeatOutbreakStatusSprite ?? throw new Exception("MissingSprite"), true);
            HeatOutbreakStatus.AddLocalisation("Heat Outbreak", "At the end of turn, this ship is dealt {0} damage per <c=status>heat</c> it has.");
            statusRegistry.RegisterStatus(HeatOutbreakStatus);
        }
        {
            HeatControlStatus = new ExternalStatus("Sorwest.CorrosiveCobra.Status.HeatControlStatus", true, CorrosiveCobraColor, null, HeatControlStatusSprite ?? throw new Exception("MissingSprite"), true);
            HeatControlStatus.AddLocalisation("Heat Control", "At the end of turn, your overheat trigger increases by <c=keyword>1<c/> <c=healing>permanently</c>, <c=hurt>then decrease this by 1</c>.");
            statusRegistry.RegisterStatus(HeatControlStatus);
        }
    }
    private static void EvolveOnDraw(Card __instance, State s, Combat c)
    {
        if (Manifest.EvolveStatus?.Id != null)
        {
            var status = (Status)Manifest.EvolveStatus.Id;
            var amount = s.ship.Get(status);
            if (amount != 0)
            {
                var deck = __instance.GetMeta().deck;
                if (deck == Deck.trash || deck == Deck.corrupted)
                {
                    s.ship.PulseStatus(status);
                    ADrawCard adrawCard1 = new ADrawCard();
                    adrawCard1.count = amount;
                    c.Queue(adrawCard1);
                }
            }
        }
        return;
    }
    private static void HeatOutbreakTurnEnd(Ship __instance, State s, Combat c)
    {
        if (Manifest.HeatOutbreakStatus?.Id != null)
        {
            var heatOutbreak_status = (Status)Manifest.HeatOutbreakStatus.Id;
            var heatOutbreak_amount = __instance.Get(heatOutbreak_status);
            if (heatOutbreak_amount > 0)
            {
                var isPlayer = __instance.isPlayerShip;
                if (__instance.Get(Status.heat) > 0)
                {
                    AHurt ahurt1 = new AHurt();
                    ahurt1.hurtAmount = heatOutbreak_amount * (__instance.Get(Status.heat));
                    ahurt1.targetPlayer = isPlayer;
                    ahurt1.hurtShieldsFirst = true;
                    c.QueueImmediate(ahurt1);
                    __instance.PulseStatus(heatOutbreak_status);
                }
            }
        }
        return;
    }
    private static void HeatControlTurnEnd(Ship __instance, State s, Combat c)
    {
        if (Manifest.HeatControlStatus?.Id != null)
        {
            var heatControl_status = (Status)Manifest.HeatControlStatus.Id;
            var heatControl_amount = __instance.Get(heatControl_status);
            if (heatControl_amount > 0)
            {
                __instance.PulseStatus(heatControl_status);
                __instance.heatTrigger += 1;
                if (__instance.Get(Status.timeStop) <= 0)
                    __instance.Set(heatControl_status, heatControl_amount - 1);
            }
        }
        return;
    }
}
