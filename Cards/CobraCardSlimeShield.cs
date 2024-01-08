namespace Sorwest.CorrosiveCobra.Cards;

[CardMeta(rarity = Rarity.uncommon, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
public class CobraCardSlimeShield : Card
{
    public override string Name() => "Slime Shield";
    public override CardData GetData(State state)
    {
        CardData result = new CardData();

        result.cost = 1;
        result.exhaust = true;
        result.artTint = "005555";
        switch (upgrade)
        {
            case Upgrade.None:
                result.description = Loc.GetLocString(Manifest.CobraCardSlimeShield?.DescLocKey ?? throw new Exception("Missing card"));

                break;
            case Upgrade.A:
                result.description = Loc.GetLocString(Manifest.CobraCardSlimeShield?.DescALocKey ?? throw new Exception("Missing card"));

                break;
            case Upgrade.B:
                result.description = Loc.GetLocString(Manifest.CobraCardSlimeShield?.DescBLocKey ?? throw new Exception("Missing card"));

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
                CobraCardSlimeHeal slimeHeal1 = new CobraCardSlimeHeal();
                slimeHeal1.upgrade = Upgrade.None;
                slimeHeal1.temporaryOverride = new bool?(true);
                slimeHeal1.singleUseOverride = new bool?(true);
                aaddCard1.card = (Card)slimeHeal1;
                aaddCard1.destination = CardDestination.Deck;
                cardActionList1.Add(aaddCard1);
                result = cardActionList1;
                break;
            case Upgrade.A:
                List<CardAction> cardActionList2 = new List<CardAction>();
                AStatus astatus2 = new AStatus();
                astatus2.status = Status.shield;
                astatus2.statusAmount = 1;
                astatus2.targetPlayer = true;
                cardActionList2.Add(astatus2);
                AAddCard aaddCard2 = new AAddCard();
                CobraCardSlimeHeal slimeHeal2 = new CobraCardSlimeHeal();
                slimeHeal2.upgrade = Upgrade.A;
                slimeHeal2.temporaryOverride = new bool?(true);
                slimeHeal2.singleUseOverride = new bool?(true);
                aaddCard2.card = (Card)slimeHeal2;
                aaddCard2.destination = CardDestination.Deck;
                cardActionList2.Add(aaddCard2);
                result = cardActionList2;
                break;
            case Upgrade.B:
                List<CardAction> cardActionList3 = new List<CardAction>();
                AStatus astatus3 = new AStatus();
                astatus3.status = Status.shield;
                astatus3.statusAmount = 1;
                astatus3.targetPlayer = true;
                cardActionList3.Add(astatus3);
                AAddCard aaddCard3 = new AAddCard();
                CobraCardSlimeHeal slimeHeal3 = new CobraCardSlimeHeal();
                slimeHeal3.upgrade = Upgrade.B;
                slimeHeal3.temporaryOverride = new bool?(true);
                slimeHeal3.singleUseOverride = new bool?(true);
                aaddCard3.card = (Card)slimeHeal3;
                aaddCard3.destination = CardDestination.Deck;
                cardActionList3.Add(aaddCard3);
                result = cardActionList3;
                break;
        }
        return result;
    }
}
