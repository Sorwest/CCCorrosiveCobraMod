using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardCorrosionShotStarter : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("CorrosionShotStarter", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = Deck.colorless,
                rarity = Rarity.common,
                upgradesTo = [Upgrade.A, Upgrade.B],
                dontOffer = true,
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "CorrosionShotStarter", "name"]).Localize
        });
    }
    public override string Name() => "Corrosive Fuelshot";
    public override CardData GetData(State state)
    {
        int num = upgrade == Upgrade.B ? 2 : 1;
        return new CardData()
        {
            art = ModEntry.Instance.Sprites["FumeCannonSprite"].Sprite,
            artTint = "45e0ab",
            exhaust = true,
            cost = upgrade == Upgrade.A ? 1 : 2,
            description = ModEntry.Instance.Localizations.Localize(["card", "CorrosionShotStarter", "description"], new { Damage = GetDmg(state, 0), Amount = num})
        };
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        return new()
        {
            new AAttack()
            {
                damage = GetDmg(s, 0),
                status = Status.corrode,
                statusAmount = upgrade == Upgrade.B ? 2 : 1
            },
            new AStatus()
            {
                status = Status.heat,
                statusAmount = upgrade == Upgrade.B ? 2 : 1,
                targetPlayer = true
            },
            new AAddCard()
            {
                card = new Toxic(),
                destination = CardDestination.Deck
            }
        };
    }

};
