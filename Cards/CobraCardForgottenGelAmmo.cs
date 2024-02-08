using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;
public class CobraCardForgottenGelAmmo : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("ForgottenGelAmmo", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.common,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "ForgottenGelAmmo", "name"]).Localize
        });
    }
    public override string Name() => "Forgotten Gel-Ammo";
    public override CardData GetData(State state)
    {
        return new()
        {
            cost = 1,
            exhaust = upgrade == Upgrade.B ? true : false
        };
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        int num = 0;
        Status status = Status.corrode;
        int num2 = 0;
        switch (upgrade)
        {
            case Upgrade.None:
                num = 1;
                status = ModEntry.Instance.OxidationStatus.Status;
                num2 = 2;
                break;
            case Upgrade.A:
                num = 2;
                status = ModEntry.Instance.OxidationStatus.Status;
                num2 = 3;
                break;
            case Upgrade.B:
                num = 0;
                status = Status.corrode;
                num2 = 1;
                break;
        }
        return new()
        {
            new AAttack()
            {
                damage = GetDmg(s, num),
                status = status,
                statusAmount = 2
            },
            new AStatus()
            {
                status = status,
                statusAmount = num2,
                targetPlayer = true
            }
        };
    }
}
