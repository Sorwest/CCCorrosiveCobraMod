namespace CorrosiveCobra.Cards
{
    [CardMeta(rarity = Rarity.rare, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class CobraCardEnginesOnFire : Card
    {
        public override string Name() => "Engines! On Fire!";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            result.exhaust = true;
            result.art = new Spr?((Spr)Manifest.CorrosiveCobra_HeatSprite!.Id!);
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
                    result.buoyant = true;
                    break;
            }
            return result;
        }
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            var heatoutbreak_status = (Status)(Manifest.HeatOutbreakStatus?.Id ?? throw new Exception("Missing HeatOutbreakStatus"));

            switch (upgrade)
            {
                case Upgrade.None:
                    List<CardAction> cardActionList1 = new List<CardAction>();
                    AStatus astatus1 = new AStatus();
                    astatus1.status = heatoutbreak_status;
                    astatus1.statusAmount = 1;
                    astatus1.targetPlayer = true;
                    cardActionList1.Add(astatus1);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    AStatus astatus2 = new AStatus();
                    astatus2.status = heatoutbreak_status;
                    astatus2.statusAmount = 1;
                    astatus2.targetPlayer = true;
                    cardActionList2.Add(astatus2);
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    AStatus astatus3 = new AStatus();
                    astatus3.status = heatoutbreak_status;
                    astatus3.statusAmount = 1;
                    astatus3.targetPlayer = true;
                    cardActionList3.Add(astatus3);
                    result = cardActionList3;
                    break;
            }
            return result;
        }
    }
}
