namespace CorrosiveCobra.Cards
{
    [CardMeta(rarity = Rarity.uncommon, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class CobraCardAcidicFlare : Card
    {
        public override string Name() => "Acidic Flare﻿";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            result.cost = 2;
            result.exhaust = true;
            switch (upgrade)
            {
                case Upgrade.None:
                    result.description = Loc.GetLocString(Manifest.CobraCardAcidicFlare?.DescLocKey ?? throw new Exception("Missing card"));
                    break;
                case Upgrade.A:
                    result.description = Loc.GetLocString(Manifest.CobraCardAcidicFlare?.DescALocKey ?? throw new Exception("Missing card"));
                    break;
                case Upgrade.B:
                    result.description = Loc.GetLocString(Manifest.CobraCardAcidicFlare?.DescBLocKey ?? throw new Exception("Missing card"));
                    break;
            }
            return result;
        }
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            var shipStatusAmount = 0;
            var otherShipStatusAmount = 0;
            switch (upgrade)
            {
                case Upgrade.None:
                    shipStatusAmount = s.ship.Get(Status.heat);
                    otherShipStatusAmount = c.otherShip.Get(Status.heat);
                    List<CardAction> cardActionList1 = new List<CardAction>();
                    AStatus astatus1 = new AStatus();
                    astatus1.status = Status.heat;
                    astatus1.statusAmount = 0;
                    astatus1.mode = AStatusMode.Set;
                    astatus1.targetPlayer = true;
                    astatus1.omitFromTooltips = true;
                    cardActionList1.Add(astatus1);
                    AStatus astatus2 = new AStatus();
                    astatus2.status = Status.heat;
                    astatus2.statusAmount = 0;
                    astatus2.mode = AStatusMode.Set;
                    astatus2.targetPlayer = false;
                    astatus2.omitFromTooltips = true;
                    cardActionList1.Add(astatus2);
                    AStatus astatus3 = new AStatus();
                    astatus3.status = Status.corrode;
                    astatus3.statusAmount = shipStatusAmount;
                    astatus3.mode = AStatusMode.Set;
                    astatus3.targetPlayer = true;
                    astatus3.omitFromTooltips = true;
                    cardActionList1.Add(astatus3);
                    AStatus astatus4 = new AStatus();
                    astatus4.status = Status.corrode;
                    astatus4.statusAmount = otherShipStatusAmount;
                    astatus4.mode = AStatusMode.Set;
                    astatus4.targetPlayer = false;
                    astatus4.omitFromTooltips = true;
                    cardActionList1.Add(astatus4);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    shipStatusAmount = s.ship.Get(Status.corrode);
                    otherShipStatusAmount = c.otherShip.Get(Status.corrode);
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    AStatus astatus5 = new AStatus();
                    astatus5.status = Status.corrode;
                    astatus5.statusAmount = 0;
                    astatus5.mode = AStatusMode.Set;
                    astatus5.targetPlayer = true;
                    astatus5.omitFromTooltips = true;
                    cardActionList2.Add(astatus5);
                    AStatus astatus6 = new AStatus();
                    astatus6.status = Status.corrode;
                    astatus6.statusAmount = 0;
                    astatus6.mode = AStatusMode.Set;
                    astatus6.targetPlayer = false;
                    astatus6.omitFromTooltips = true;
                    cardActionList2.Add(astatus6);
                    AStatus astatus7 = new AStatus();
                    astatus7.status = Status.heat;
                    astatus7.statusAmount = shipStatusAmount;
                    astatus7.mode = AStatusMode.Set;
                    astatus7.targetPlayer = true;
                    astatus7.omitFromTooltips = true;
                    cardActionList2.Add(astatus7);
                    AStatus astatus8 = new AStatus();
                    astatus8.status = Status.heat;
                    astatus8.statusAmount = otherShipStatusAmount;
                    astatus8.mode = AStatusMode.Set;
                    astatus8.targetPlayer = false;
                    astatus8.omitFromTooltips = true;
                    cardActionList2.Add(astatus8);
                    AAddCard aaddCard1 = new AAddCard();
                    CobraCardCorrosionIgnition corrosionIgnition1 = new CobraCardCorrosionIgnition();
                    corrosionIgnition1.upgrade = Upgrade.A;
                    corrosionIgnition1.temporaryOverride = true;
                    aaddCard1.card = corrosionIgnition1;
                    aaddCard1.destination = CardDestination.Hand;
                    cardActionList2.Add(aaddCard1);
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    shipStatusAmount = s.ship.Get(Status.heat);
                    otherShipStatusAmount = c.otherShip.Get(Status.heat);
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    AStatus astatus9 = new AStatus();
                    astatus9.status = Status.heat;
                    astatus9.statusAmount = 0;
                    astatus9.mode = AStatusMode.Set;
                    astatus9.targetPlayer = true;
                    astatus9.omitFromTooltips = true;
                    cardActionList3.Add(astatus9);
                    AStatus astatus10 = new AStatus();
                    astatus10.status = Status.heat;
                    astatus10.statusAmount = 0;
                    astatus10.mode = AStatusMode.Set;
                    astatus10.targetPlayer = false;
                    astatus10.omitFromTooltips = true;
                    cardActionList3.Add(astatus10);
                    AStatus astatus11 = new AStatus();
                    astatus11.status = Status.corrode;
                    astatus11.statusAmount = shipStatusAmount;
                    astatus11.mode = AStatusMode.Set;
                    astatus11.targetPlayer = true;
                    astatus11.omitFromTooltips = true;
                    cardActionList3.Add(astatus11);
                    AStatus astatus12 = new AStatus();
                    astatus12.status = Status.corrode;
                    astatus12.statusAmount = otherShipStatusAmount;
                    astatus12.mode = AStatusMode.Set;
                    astatus12.targetPlayer = false;
                    astatus12.omitFromTooltips = true;
                    cardActionList3.Add(astatus12);
                    AAddCard aaddCard2 = new AAddCard();
                    CobraCardCorrosionIgnition corrosionIgnition2 = new CobraCardCorrosionIgnition();
                    corrosionIgnition2.upgrade = Upgrade.B;
                    corrosionIgnition2.temporaryOverride = true;
                    aaddCard2.card = corrosionIgnition2;
                    aaddCard2.destination = CardDestination.Hand;
                    cardActionList3.Add(aaddCard2);
                    result = cardActionList3;
                    break;
            }
            return result;
        }
    }
}
