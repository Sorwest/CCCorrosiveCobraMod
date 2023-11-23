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
            StatusPatchLogic(new Harmony("Sorwest.CorrosiveCobra.harmonyStatus"));

            {
                EvolveStatus = new ExternalStatus("CorrosiveCobra.Status.EvolveStatus", true, CorrosiveCobra_Primary_Color, null, EvolveStatusSprite ?? throw new Exception("MissingSprite"), true);
                EvolveStatus.AddLocalisation("Evolve", "Whenever you draw a <c=trash>Trash</c> card, <c=keyword>draw {0}</c>.");
                statusRegistry.RegisterStatus(EvolveStatus);
            }
            {
                HeatOutbreakStatus = new ExternalStatus("CorrosiveCobra.Status.HeatOutbreakStatus", true, CorrosiveCobra_Primary_Color, null, HeatOutbreakStatusSprite ?? throw new Exception("MissingSprite"), true);
                HeatOutbreakStatus.AddLocalisation("Heat Outbreak", "At the end of turn, the enemy is dealt {0} damage per <c=status>heat</c> stack.");
                statusRegistry.RegisterStatus(HeatOutbreakStatus);
            }
            {
                HeatControlStatus = new ExternalStatus("CorrosiveCobra.Status.HeatControlStatus", true, CorrosiveCobra_Primary_Color, null, HeatControlStatusSprite ?? throw new Exception("MissingSprite"), true);
                HeatControlStatus.AddLocalisation("Heat Control", "At the end of turn, your overheat limit increases by <c=keyword>1<c/> <c=healing>permanently</c>, <c=hurt>then decrease this by 1</c>.");
                statusRegistry.RegisterStatus(HeatControlStatus);
            }
        }
        private void StatusPatchLogic(Harmony harmony)
        {
            {
                MethodInfo method1 = typeof(Card).GetMethod("OnDraw") ?? throw new Exception("Couldn't find Card.OnDraw method");
                MethodInfo method2 = typeof(Manifest).GetMethod("EvolveOnDraw", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic) ?? throw new Exception("Couldn't find Manifest.EvolveOnDraw method");
                harmony.Patch(method1, postfix: new HarmonyMethod(method2));
            }
            {
                MethodInfo method3 = typeof(Ship).GetMethod("OnAfterTurn") ?? throw new Exception("Couldn't find Ship.OnAfterTurn method");
                MethodInfo method4 = typeof(Manifest).GetMethod("TurnEnd", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic) ?? throw new Exception("Couldn't find Manifest.TurnEnd method");
                harmony.Patch(method3, postfix: new HarmonyMethod(method4));
            }
        }
        private static void EvolveOnDraw(State s, Combat c)
        {
            if (Manifest.EvolveStatus?.Id == null)
                return;
            var status = (Status)Manifest.EvolveStatus.Id;
            var amount = s.ship.Get(status);
            int index = c.hand.Count - 1;
            if (index < 0)
                return;
            if (c.hand[index].GetMeta().deck == Deck.trash)
            {
                ADrawCard adrawCard1 = new ADrawCard();
                adrawCard1.count = amount;
                c.QueueImmediate(adrawCard1);
                return;
            }
            if (c.hand[index].GetMeta().deck == Deck.corrupted)
            {
                ADrawCard adrawCard1 = new ADrawCard();
                adrawCard1.count = amount;
                c.QueueImmediate(adrawCard1);
                return;
            }
        }
        private static void TurnEnd(Ship __instance, State s, Combat c)
        {
            if (Manifest.HeatOutbreakStatus?.Id != null)
            {
                var status = (Status)Manifest.HeatOutbreakStatus.Id;
                var amount = s.ship.Get(status);
                if (__instance.Get((Status)Manifest.HeatOutbreakStatus.Id.Value) > 0 && c.otherShip.Get(Status.heat) > 0)
                {
                    AHurt ahurt1 = new AHurt();
                    ahurt1.hurtAmount = amount * c.otherShip.Get(Status.heat);
                    ahurt1.targetPlayer = false;
                    ahurt1.hurtShieldsFirst = true;
                    c.QueueImmediate(ahurt1);
                    s.ship.PulseStatus(status);
                }
            }
            if (Manifest.HeatControlStatus?.Id != null)
            {
                var status = (Status)Manifest.HeatControlStatus.Id;
                var amount = s.ship.Get(status);
                if (__instance.Get((Status)Manifest.HeatControlStatus.Id.Value) > 0)
                {
                    s.ship.PulseStatus(status);
                    s.ship.heatTrigger += 1;
                    __instance.Set(status, amount - 1);
                }
            }
        }
    }
}
