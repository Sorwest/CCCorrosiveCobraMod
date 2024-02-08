using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardSlimeBLAST : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("SlimeBLAST", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.common,
                dontOffer = true,
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "SlimeBLAST", "name"]).Localize
        });
    }
    public override string Name() => "SLIME BLAST!!";
    private int GetStatusAmount(State state)
    {
        int allStatusAmount = 0;
        if (state.route is Combat)
        {
            foreach (KeyValuePair<Status, int> currentStatus in state.ship.statusEffects)
                if (currentStatus.Key != Status.shield && currentStatus.Key != Status.tempShield)
                    allStatusAmount += currentStatus.Value;
        }
        return allStatusAmount;
    }
    public override CardData GetData(State state)
    {
        CardData result = new CardData();
        result.cost = 3;
        result.exhaust = true;
        result.art = ModEntry.Instance.Sprites["SlimeBlastSprite"].Sprite;
        result.description = ModEntry.Instance.Localizations.Localize(["card", "SlimeBLAST", "description"], new { Amount = state.route is Combat ? GetDmg(state, 2 * GetStatusAmount(state)).ToString() : ""});
        return result;
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        var result = new List<CardAction>();
        List<CardAction> cardActionList1 = new List<CardAction>();
        AAttack aattack1 = new AAttack();
        aattack1.dialogueSelector = ".playedSlimeBLAST";
        aattack1.damage = GetDmg(s, 2 * GetStatusAmount(s));
        aattack1.targetPlayer = false;
        cardActionList1.Add(aattack1);
        result = cardActionList1;

        return result;
    }
}
