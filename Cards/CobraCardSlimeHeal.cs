namespace CorrosiveCobra.Cards
{
    [CardMeta(dontOffer = true, rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class CobraCardSlimeHeal : Card
    {
        public override string Name() => "Slime Heal";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();

            result.exhaust = true;
            result.art = new Spr?((Spr)Manifest.CorrosiveCobra_RepairsSprite!.Id!);
            switch (upgrade)
            {
                case Upgrade.None:
                    result.cost = 1;
                    break;
                case Upgrade.A:
                    result.cost = 2;
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
                    AHeal aheal1 = new AHeal();
                    aheal1.healAmount = 1;
                    aheal1.targetPlayer = true;
                    aheal1.canRunAfterKill = true;
                    cardActionList1.Add(aheal1);
                    ADrawCard adraw1 = new ADrawCard();
                    adraw1.count = 1;
                    cardActionList1.Add(adraw1);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    AHeal aheal2 = new AHeal();
                    aheal2.healAmount = 2;
                    aheal2.targetPlayer = true;
                    aheal2.canRunAfterKill = true;
                    cardActionList2.Add(aheal2);
                    ADrawCard adraw2 = new ADrawCard();
                    adraw2.count = 1;
                    cardActionList2.Add(adraw2);
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    AHeal aheal3 = new AHeal();
                    aheal3.healAmount = 1;
                    aheal3.targetPlayer = true;
                    aheal3.canRunAfterKill = true;
                    cardActionList3.Add(aheal3);
                    ADrawCard adraw3 = new ADrawCard();
                    adraw3.count = 4;
                    cardActionList3.Add(adraw3);
                    result = cardActionList3;
                    break;
            }
            return result;
        }
    }
}
