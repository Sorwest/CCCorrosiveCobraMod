namespace Sorwest.CorrosiveCobra.Cards;

[CardMeta(dontOffer = true, rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
public class CobraCardFuelWall : Card
{
    public override string Name() => "Adv. Heat Protection";
    public override CardData GetData(State state)
    {
        CardData result = new CardData();
        result.art = new Spr?((Spr)Manifest.CorrosiveCobra_CorrosionBlockStarter!.Id!);
        result.artTint = "45e0ab";
        switch (upgrade)
        {
            case Upgrade.None:
                result.cost = 1;
                break;
            case Upgrade.A:
                result.cost = 0;
                break;
            case Upgrade.B:
                result.cost = 1;
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
                astatus1.statusAmount = 1;
                astatus1.targetPlayer = true;
                cardActionList1.Add(astatus1);
                AStatus astatus2 = new AStatus();
                astatus2.status = Status.heat;
                astatus2.statusAmount = -1;
                astatus2.targetPlayer = true;
                cardActionList1.Add(astatus2);
                ADrawCard aadrawCard1 = new ADrawCard();
                aadrawCard1.count = 1;
                cardActionList1.Add(aadrawCard1);
                result = cardActionList1;
                break;
            case Upgrade.A:
                List<CardAction> cardActionList2 = new List<CardAction>();
                AStatus astatus3 = new AStatus();
                astatus3.status = Status.shield;
                astatus3.statusAmount = 1;
                astatus3.targetPlayer = true;
                cardActionList2.Add(astatus3);
                AStatus astatus4 = new AStatus();
                astatus4.status = Status.heat;
                astatus4.statusAmount = -1;
                astatus4.targetPlayer = true;
                cardActionList2.Add(astatus4);
                ADrawCard aadrawCard2 = new ADrawCard();
                aadrawCard2.count = 1;
                cardActionList2.Add(aadrawCard2);
                result = cardActionList2;
                break;
            case Upgrade.B:
                List<CardAction> cardActionList3 = new List<CardAction>();
                AStatus astatus5 = new AStatus();
                astatus5.status = Status.shield;
                astatus5.statusAmount = 2;
                astatus5.targetPlayer = true;
                cardActionList3.Add(astatus5);
                AStatus astatus6 = new AStatus();
                astatus6.status = Status.heat;
                astatus6.statusAmount = -1;
                astatus6.targetPlayer = true;
                cardActionList3.Add(astatus6);
                ADrawCard aadrawCard3 = new ADrawCard();
                aadrawCard3.count = 1;
                cardActionList3.Add(aadrawCard3);
                result = cardActionList3;
                break;
        }
        return result;
    }

};
