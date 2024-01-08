namespace Sorwest.CorrosiveCobra.Cards;

[CardMeta(rarity = Rarity.uncommon, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
public class CobraCardTinkerWithTheTanks : Card
{
    public override string Name() => "Tinker With The Tanks";
    public override CardData GetData(State state)
    {
        CardData result = new CardData();

        result.cost = 1;
        result.exhaust = true;
        result.art = new Spr?((Spr)Manifest.CorrosiveCobra_RepairsSprite!.Id!);
        switch (upgrade)
        {
            case Upgrade.None:
                result.description = Loc.GetLocString(Manifest.CobraCardTinkerWithTheTanks?.DescLocKey ?? throw new Exception("Missing card"));
                break;
            case Upgrade.A:
                result.description = Loc.GetLocString(Manifest.CobraCardTinkerWithTheTanks?.DescALocKey ?? throw new Exception("Missing card"));
                break;
            case Upgrade.B:
                result.description = Loc.GetLocString(Manifest.CobraCardTinkerWithTheTanks?.DescBLocKey ?? throw new Exception("Missing card"));
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
                AHeal aheal1 = new AHeal();
                aheal1.healAmount = 1;
                aheal1.targetPlayer = true;
                aheal1.canRunAfterKill = true;
                cardActionList1.Add(aheal1);
                AAddCard aaddCard1 = new AAddCard();
                CobraCardLeakingContainer leakingContainer1 = new CobraCardLeakingContainer();
                leakingContainer1.temporaryOverride = true;
                aaddCard1.card = (Card)leakingContainer1;
                aaddCard1.destination = CardDestination.Hand;
                cardActionList1.Add(aaddCard1);
                result = cardActionList1;
                break;
            case Upgrade.A:
                List<CardAction> cardActionList2 = new List<CardAction>();
                AHeal aheal2 = new AHeal();
                aheal2.healAmount = 2;
                aheal2.targetPlayer = true;
                aheal2.canRunAfterKill = true;
                cardActionList2.Add(aheal2);
                AAddCard aaddCard2 = new AAddCard();
                CobraCardLeakingContainer leakingContainer2 = new CobraCardLeakingContainer();
                leakingContainer2.temporaryOverride = true;
                leakingContainer2.upgrade = Upgrade.A;
                aaddCard2.card = (Card)leakingContainer2;
                aaddCard2.destination = CardDestination.Hand;
                cardActionList2.Add(aaddCard2);
                result = cardActionList2;
                break;
            case Upgrade.B:
                List<CardAction> cardActionList3 = new List<CardAction>();
                AHeal aheal3 = new AHeal();
                aheal3.healAmount = 3;
                aheal3.targetPlayer = true;
                aheal3.canRunAfterKill = true;
                cardActionList3.Add(aheal3);
                AAddCard aaddCard3 = new AAddCard();
                CobraCardLeakingContainer leakingContainer3 = new CobraCardLeakingContainer();
                leakingContainer3.temporaryOverride = true;
                leakingContainer3.upgrade = Upgrade.B;
                aaddCard3.card = (Card)leakingContainer3;
                aaddCard3.destination = CardDestination.Hand;
                cardActionList3.Add(aaddCard3);
                result = cardActionList3;
                break;
        }
        return result;
    }
}
