namespace Sorwest.CorrosiveCobra.Cards;

[CardMeta(rarity = Rarity.rare, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
public class CobraCardSlimeEvolution : Card
{
    public override string Name() => "Slime Evolution";
    public override CardData GetData(State state)
    {
        CardData result = new CardData();

        result.cost = 2;
        result.exhaust = true;
        switch (upgrade)
        {
            case Upgrade.None:
                result.description = Loc.GetLocString(Manifest.CobraCardSlimeEvolution?.DescLocKey ?? throw new Exception("Missing card"));
                break;
            case Upgrade.A:
                result.description = Loc.GetLocString(Manifest.CobraCardSlimeEvolution?.DescLocKey ?? throw new Exception("Missing card"));
                result.buoyant = true;
                break;
            case Upgrade.B:
                result.description = Loc.GetLocString(Manifest.CobraCardSlimeEvolution?.DescBLocKey ?? throw new Exception("Missing card"));
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
                AAddCard aaddCard1 = new AAddCard();
                aaddCard1.dialogueSelector = ".addedSlimeMutation";
                CobraCardSlimeMutation slimeMutation1 = new CobraCardSlimeMutation();
                slimeMutation1.upgrade = Upgrade.None;
                slimeMutation1.temporaryOverride = new bool?(true);
                aaddCard1.card = (Card)slimeMutation1;
                aaddCard1.destination = CardDestination.Discard;
                cardActionList1.Add(aaddCard1);
                ADrawCard adrawCard1 = new ADrawCard();
                adrawCard1.count = 1;
                cardActionList1.Add(adrawCard1);
                result = cardActionList1;
                break;
            case Upgrade.A:
                List<CardAction> cardActionList2 = new List<CardAction>();
                AAddCard aaddCard2 = new AAddCard();
                aaddCard2.dialogueSelector = ".addedSlimeMutation";
                CobraCardSlimeMutation slimeMutation2 = new CobraCardSlimeMutation();
                slimeMutation2.upgrade = Upgrade.None;
                slimeMutation2.temporaryOverride = new bool?(true);
                aaddCard2.card = (Card)slimeMutation2;
                aaddCard2.destination = CardDestination.Discard;
                cardActionList2.Add(aaddCard2);
                ADrawCard adrawCard2 = new ADrawCard();
                adrawCard2.count = 1;
                cardActionList2.Add(adrawCard2);
                result = cardActionList2;
                break;
            case Upgrade.B:
                List<CardAction> cardActionList3 = new List<CardAction>();
                AAddCard aaddCard3 = new AAddCard();
                aaddCard3.dialogueSelector = ".addedSlimeMutation";
                CobraCardSlimeMutation slimeMutation3 = new CobraCardSlimeMutation();
                slimeMutation3.upgrade = Upgrade.None;
                slimeMutation3.temporaryOverride = new bool?(true);
                aaddCard3.card = (Card)slimeMutation3;
                aaddCard3.destination = CardDestination.Hand;
                cardActionList3.Add(aaddCard3);
                ADrawCard adrawCard3 = new ADrawCard();
                adrawCard3.count = 1;
                cardActionList3.Add(adrawCard3);
                result = cardActionList3;
                break;
        }
        return result;
    }
}
