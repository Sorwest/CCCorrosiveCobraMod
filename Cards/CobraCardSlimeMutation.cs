using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardSlimeMutation : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("SlimeMutation", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.common,
                dontOffer = true,
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "SlimeMutation", "name"]).Localize
        });
    }
    public override string Name() => "Slime Mutation";
    public override CardData GetData(State state)
    {
        CardData result = new CardData();

        result.cost = 2;
        result.exhaust = true;
        result.description = ModEntry.Instance.Localizations.Localize(["card", "SlimeMutation", "description"]);
        return result;
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        var result = new List<CardAction>();
        List<CardAction> cardActionList1 = new List<CardAction>();
        AAddCard aaddCard1 = new AAddCard();
        aaddCard1.dialogueSelector = ".addedSlimeBLAST";
        CobraCardSlimeBLAST slimeBlast = new CobraCardSlimeBLAST();
        slimeBlast.upgrade = Upgrade.None;
        slimeBlast.temporaryOverride = new bool?(true);
        aaddCard1.card = (Card)slimeBlast;
        aaddCard1.destination = CardDestination.Discard;
        cardActionList1.Add(aaddCard1);
        result = cardActionList1;
        return result;
    }
}
