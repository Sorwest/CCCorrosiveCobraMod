namespace Sorwest.CorrosiveCobra.Cards;

[CardMeta(deck = Deck.colorless, rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
public class CobraCardColorlessSlimeSummon : Card
{
    public override string Name() => "Dizzy?.EXE";

    public override CardData GetData(State state)
    {
        CardData result = new CardData();

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
        result.art = new Spr?((Spr)Manifest.CorrosiveCobra_CardBackgroud!.Id!);
        result.exhaust = true;
        result.artTint = "45e0ab";
        int count = 0;
        switch (upgrade)
        {
            case Upgrade.None:
                count = 2;
                break;
            case Upgrade.A:
                count = 2;
                break;
            case Upgrade.B:
                count = 3;
                break;
        }
        result.description = string.Format(
            Loc.GetLocString(Manifest.CobraCardColorlessSlimeSummon?.DescLocKey ?? throw new Exception("Card ColorlessSlimeSummon not found")),
            count,
            Manifest.CobraColor);
        return result;
    }

    public override List<CardAction> GetActions(State s, Combat c)
    {

        var result = new List<CardAction>();
        switch (upgrade)
        {
            case Upgrade.None:
                List<CardAction> cardActionList1 = new List<CardAction>();
                ACardOffering acardOffering1 = new ACardOffering();
                acardOffering1.amount = 2;
                acardOffering1.limitDeck = new Deck?((Deck)Manifest.CobraDeck!.Id!);
                acardOffering1.makeAllCardsTemporary = true;
                acardOffering1.overrideUpgradeChances = new bool?(false);
                acardOffering1.canSkip = false;
                acardOffering1.inCombat = true;
                acardOffering1.discount = -1;
                //acardOffering1.dialogueSelector = ".summonSlime";
                cardActionList1.Add(acardOffering1);
                result = cardActionList1;
                break;
            case Upgrade.A:
                List<CardAction> cardActionList2 = new List<CardAction>();
                ACardOffering acardOffering2 = new ACardOffering();
                acardOffering2.amount = 2;
                acardOffering2.limitDeck = new Deck?((Deck)Manifest.CobraDeck!.Id!);
                acardOffering2.makeAllCardsTemporary = true;
                acardOffering2.overrideUpgradeChances = new bool?(false);
                acardOffering2.canSkip = false;
                acardOffering2.inCombat = true;
                acardOffering2.discount = -1;
                //acardOffering2.dialogueSelector = ".summonSlime";
                cardActionList2.Add(acardOffering2);
                result = cardActionList2;
                break;
            case Upgrade.B:
                List<CardAction> cardActionList3 = new List<CardAction>();
                ACardOffering acardOffering3 = new ACardOffering();
                acardOffering3.amount = 3;
                acardOffering3.limitDeck = new Deck?((Deck)Manifest.CobraDeck!.Id!);
                acardOffering3.makeAllCardsTemporary = true;
                acardOffering3.overrideUpgradeChances = new bool?(false);
                acardOffering3.canSkip = false;
                acardOffering3.inCombat = true;
                acardOffering3.discount = -1;
                //acardOffering3.dialogueSelector = ".summonSlime";
                cardActionList3.Add(acardOffering3);
                result = cardActionList3;
                break;
        }
        return result;
    }
}
