namespace Sorwest.CorrosiveCobra.Cards;

[CardMeta(rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
public class CobraCardShieldAlternatorA : Card
{
    public override string Name() => "Shield Replica";
    public override CardData GetData(State state)
    {
        CardData result = new CardData();
        result.artTint = "005555";
        switch (upgrade)
        {
            case Upgrade.None:
                result.cost = 1;
                result.exhaust = true;
                result.description = Loc.GetLocString(Manifest.CobraCardShieldAlternatorA?.DescLocKey ?? throw new Exception("Missing card"));
                break;
            case Upgrade.A:
                result.cost = 0;
                result.exhaust = true;
                result.description = Loc.GetLocString(Manifest.CobraCardShieldAlternatorA?.DescLocKey ?? throw new Exception("Missing card"));
                break;
            case Upgrade.B:
                result.cost = 1;
                result.exhaust = false;
                result.description = Loc.GetLocString(Manifest.CobraCardShieldAlternatorA?.DescBLocKey ?? throw new Exception("Missing card"));
                break;
        }
        return result;
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        var result = new List<CardAction>();
        switch (upgrade)
        {
            case Upgrade.None:
                List<CardAction> cardActionList1 = new List<CardAction>();
                AStatus astatus1 = new AStatus();
                astatus1.status = Status.shield;
                astatus1.statusAmount = 2;
                astatus1.targetPlayer = true;
                cardActionList1.Add(astatus1);
                AAddCard aaddCard1 = new AAddCard();
                CobraCardShieldAlternatorB shieldAlternatorB1 = new CobraCardShieldAlternatorB();
                shieldAlternatorB1.temporaryOverride = new bool?(true);
                aaddCard1.card = (Card)shieldAlternatorB1;
                aaddCard1.destination = CardDestination.Deck;
                cardActionList1.Add(aaddCard1);
                result = cardActionList1;
                break;
            case Upgrade.A:
                List<CardAction> cardActionList2 = new List<CardAction>();
                AStatus astatus2 = new AStatus();
                astatus2.status = Status.shield;
                astatus2.statusAmount = 2;
                astatus2.targetPlayer = true;
                cardActionList2.Add(astatus2);
                AAddCard aaddCard2 = new AAddCard();
                CobraCardShieldAlternatorB shieldAlternatorB2 = new CobraCardShieldAlternatorB();
                shieldAlternatorB2.temporaryOverride = new bool?(true);
                aaddCard2.card = (Card)shieldAlternatorB2;
                aaddCard2.destination = CardDestination.Deck;
                cardActionList2.Add(aaddCard2);
                result = cardActionList2;
                break;
            case Upgrade.B:
                List<CardAction> cardActionList3 = new List<CardAction>();
                AStatus astatus3 = new AStatus();
                astatus3.status = Status.shield;
                astatus3.statusAmount = 2;
                astatus3.targetPlayer = true;
                cardActionList3.Add(astatus3);
                AAddCard aaddCard3 = new AAddCard();
                CobraCardShieldAlternatorB shieldAlternatorB3 = new CobraCardShieldAlternatorB();
                shieldAlternatorB3.temporaryOverride = new bool?(true);
                aaddCard3.card = (Card)shieldAlternatorB3;
                aaddCard3.destination = CardDestination.Hand;
                cardActionList3.Add(aaddCard3);
                result = cardActionList3;
                break;
        }
        return result;
    }
}
