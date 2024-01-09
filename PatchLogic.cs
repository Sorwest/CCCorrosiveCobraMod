using Microsoft.Extensions.Logging.Abstractions;
using Sorwest.CorrosiveCobra.Artifacts;

namespace Sorwest.CorrosiveCobra;

public static class PatchLogic
{
    private static Manifest Instance => Manifest.Instance;
    private static bool CobraLookupColor(ref uint? __result, string key)
    {
        if (key == "Sorwest.CorrosiveCobra.CobraDeck")
        {
            __result = ToInt(Manifest.CorrosiveCobraColor);
            return false;
        }
        return true;
    }

    private static uint ToInt(System.Drawing.Color color)
    {
        return (uint)((Mutil.Clamp((int)(color.A), 0, 255) << 24) | (Mutil.Clamp((int)(color.R), 0, 255) << 16) | (Mutil.Clamp((int)(color.G), 0, 255) << 8) | Mutil.Clamp((int)(color.B), 0, 255));
    }

    private static void EvolveOnDraw(Card __instance, State s, Combat c)
    {
        if (Manifest.EvolveStatus?.Id != null)
        {
            var status = (Status)Manifest.EvolveStatus.Id;
            var amount = s.ship.Get(status);
            if (amount > 0)
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
    private static void SlimeDrakeArtifactPatch(AStatus __instance, G g, State s, Combat c)
    {
        var slimedrakeArtifact = s.EnumerateAllArtifacts().OfType<SlimeDrakeArtifact>().FirstOrDefault();
        if (slimedrakeArtifact != null)
        {
            if (__instance.status == Status.heat && __instance.targetPlayer == true)
            {
                if (s.ship.heatTrigger == s.ship.Get(Status.heat) && !slimedrakeArtifact.overheating)
                {
                    slimedrakeArtifact.overheating = true;
                    slimedrakeArtifact.Pulse();
                }
                else if (s.ship.heatTrigger < s.ship.Get(Status.heat))
                {
                    AAttack aAttack1 = new AAttack()
                    {
                        damage = 0,
                        status = Status.corrode,
                        statusAmount = 1,
                    };
                    c.QueueImmediate(aAttack1);
                    slimedrakeArtifact.Pulse();
                }
            }
        }
        return;
    }
    private static void CrystalTapStatusPatch(
        Combat __instance,
        State s,
        Card card,
        ref bool __result,
        bool playNoMatterWhatForFree,
        bool exhaustNoMatterWhat)
    {
        if (__result && Manifest.CrystalTapStatus?.Id != null)
        {
            var status = (Status)Manifest.CrystalTapStatus.Id;
            var amount = s.ship.Get(status);
            if (amount > 0)
            {
                foreach (CardAction cardAction in card.GetActionsOverridden(s, __instance))
                {
                    if (!(cardAction is AEndTurn))
                        __instance.Queue(Mutil.DeepCopy<CardAction>(cardAction));
                }
                s.ship.Set(status, amount - 1);
            }
        }
        return;
    }
}
