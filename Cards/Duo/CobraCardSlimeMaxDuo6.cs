using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardSlimeMaxDuo6 : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("SlimeMaxDuo6", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                rarity = Rarity.common,
                deck = ModEntry.Instance.DuoArtifactsApi!.DuoArtifactVanillaDeck,
                unreleased = true,
                dontOffer = true
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "SlimeMaxDuo", "6", "name"]).Localize
        });
    }
    public override CardData GetData(State state)
    {
        CardData result = new CardData
        {
            cost = 2,
            exhaust = true,
            retain = true,
        };
        return result;
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        var nextCard = new CobraCardSlimeMaxDuo7()
        {
            temporaryOverride = true,
        };
        List<CardAction> result = new List<CardAction>
        {
            new AMove()
            {
                dir = 2,
                targetPlayer = true,
            },
            new AAddCard()
            {
                card = nextCard,
                amount = 1,
                destination = CardDestination.Deck,
                omitFromTooltips = true,
            },
            new ADrawCard()
            {
                count = 1,
            }
        };
        return result;
    }
}