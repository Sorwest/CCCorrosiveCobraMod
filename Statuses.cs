using System.Reflection;
using CobaltCoreModding.Definitions.ExternalItems;
using CobaltCoreModding.Definitions.ModContactPoints;

using HarmonyLib;

namespace CorrosiveCobra
{
    public partial class Manifest
    {
        public static ExternalStatus? EvolveStatus { get; private set; }
        public static ExternalStatus? HeatOutbreakStatus { get; private set; }
        public static ExternalStatus? HeatControlStatus { get; private set; }
        public void LoadManifest(IStatusRegistry statusRegistry)
        {
            //patch in logic for our statuses
            var harmony = new Harmony("Sorwest.CorrosiveCobra.harmonyStatus");
            EvolveOnDrawLogic(harmony);
            HeatOutbreakLogic(harmony);
            HeatControlLogic(harmony);

            {
                EvolveStatus = new ExternalStatus("CorrosiveCobra.Status.EvolveStatus", true, CorrosiveCobra_Primary_Color, null, EvolveStatusSprite ?? throw new Exception("MissingSprite"), true);
                EvolveStatus.AddLocalisation("Evolve", "Whenever you draw a <c=trash>Trash</c> card, <c=keyword>draw {0}</c>.");
                statusRegistry.RegisterStatus(EvolveStatus);
            }
            {
                HeatOutbreakStatus = new ExternalStatus("CorrosiveCobra.Status.HeatOutbreakStatus", true, CorrosiveCobra_Primary_Color, null, HeatOutbreakStatusSprite ?? throw new Exception("MissingSprite"), true);
                HeatOutbreakStatus.AddLocalisation("Heat Outbreak", "At the end of turn, the enemy is dealt {0} damage per <c=status>heat</c> stack you both have.");
                statusRegistry.RegisterStatus(HeatOutbreakStatus);
            }
            {
                HeatControlStatus = new ExternalStatus("CorrosiveCobra.Status.HeatControlStatus", true, CorrosiveCobra_Primary_Color, null, HeatControlStatusSprite ?? throw new Exception("MissingSprite"), true);
                HeatControlStatus.AddLocalisation("Heat Control", "At the end of turn, your overheat limit increases by <c=keyword>1<c/> <c=healing>permanently</c>, <c=hurt>then decrease this by 1</c>.");
                statusRegistry.RegisterStatus(HeatControlStatus);
            }
        }
        private void EvolveOnDrawLogic(Harmony harmony)
        {
            {
                MethodInfo method1 = typeof(Card).GetMethod("OnDraw") ?? throw new Exception("Couldn't find Card.OnDraw method");
                MethodInfo method2 = typeof(Manifest).GetMethod("EvolveOnDraw", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic) ?? throw new Exception("Couldn't find Manifest.PatchedOnDraw method");
                harmony.Patch(method1, postfix: new HarmonyMethod(method2));
            }
        }
        private void HeatOutbreakLogic(Harmony harmony)
        {
            {
                MethodInfo method1 = typeof(Ship).GetMethod("OnAfterTurn") ?? throw new Exception("Couldn't find Ship.OnAfterTurn method");
                MethodInfo method2 = typeof(Manifest).GetMethod("HeatOutbreakTurnEnd", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic) ?? throw new Exception("Couldn't find Manifest.HeatOutbreakTurnEnd method");
                harmony.Patch(method1, postfix: new HarmonyMethod(method2));
            }
        }
        private void HeatControlLogic(Harmony harmony)
        {
            {
                MethodInfo method1 = typeof(Ship).GetMethod("OnAfterTurn") ?? throw new Exception("Couldn't find Ship.OnAfterTurn method");
                MethodInfo method2 = typeof(Manifest).GetMethod("HeatControlTurnEnd", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic) ?? throw new Exception("Couldn't find Manifest.HeatControlTurnEnd method");
                harmony.Patch(method1, prefix: new HarmonyMethod(method2));
            }
        }
        private static void EvolveOnDraw(State s, Combat c)
        {
            if (Manifest.EvolveStatus?.Id == null)
                return;
            var status = (Status)Manifest.EvolveStatus.Id;
            var amount = s.ship.Get(status);
            if (amount != 0)
            {
                int index = c.hand.Count - 1;
                if (index < 0)
                    return;
                var deck = c.hand[index].GetMeta().deck;
                if (deck == Deck.trash || deck == Deck.corrupted)
                {
                    s.ship.PulseStatus(status);
                    ADrawCard adrawCard1 = new ADrawCard();
                    adrawCard1.count = amount;
                    c.Queue(adrawCard1);
                    return;
                }
            }
        }
        private static void HeatOutbreakTurnEnd(Ship __instance, State s, Combat c)
        {
            if (Manifest.HeatOutbreakStatus?.Id == null)
                return;
            var status = (Status)Manifest.HeatOutbreakStatus.Id;
            var amount = s.ship.Get(status);
            if (amount <= 0)
                return;
            if (!(__instance.isPlayerShip))
                return;
            if (c.otherShip.Get(Status.heat) > 0 || s.ship.Get(Status.heat) > 0)
            {
                AHurt ahurt1 = new AHurt();
                ahurt1.hurtAmount = amount * (c.otherShip.Get(Status.heat) + s.ship.Get(Status.heat));
                ahurt1.targetPlayer = false;
                ahurt1.hurtShieldsFirst = true;
                c.QueueImmediate(ahurt1);
                s.ship.PulseStatus(status);
            }
        }
        private static void HeatControlTurnEnd(Ship __instance, State s, Combat c)
        {
            if (Manifest.HeatControlStatus?.Id == null)
                return;
            var status = (Status)Manifest.HeatControlStatus.Id;
            var amount = s.ship.Get(status);
            if (amount <= 0)
                return;
            s.ship.PulseStatus(status);
            s.ship.heatTrigger += 1;
            if (__instance.Get(Status.timeStop) <= 0)
                __instance.Set(status, amount - 1);
        }
    }
}
