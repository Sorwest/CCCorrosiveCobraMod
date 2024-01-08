namespace Sorwest.CorrosiveCobra.Cards;

[CardMeta(dontOffer = true, rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
public class CobraCardCorrosionStarter : Card
{
    public override string Name() => "Corrosive Fuelshot";
    public override CardData GetData(State state)
    {
        CardData result = new CardData();
        result.exhaust = true;
        result.artTint = "45e0ab";
        switch (upgrade)
        {
            case Upgrade.None:
                result.cost = 2;
                result.art = new Spr?((Spr)Manifest.CorrosiveCobra_CannonCardSprite!.Id!);
                break;
            case Upgrade.A:
                result.cost = 2;
                result.art = new Spr?((Spr)Manifest.CorrosiveCobra_CannonCardSprite!.Id!);
                break;
            case Upgrade.B:
                result.cost = 1;
                result.art = new Spr?((Spr)Manifest.CorrosiveCobra_FumeCannonSprite!.Id!);
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
                AAttack aattack1 = new AAttack();
                aattack1.damage = GetDmg(s, 0);
                aattack1.status = Status.corrode;
                aattack1.statusAmount = 1;
                aattack1.targetPlayer = false;
                cardActionList1.Add(aattack1);
                AStatus astatus1 = new AStatus();
                astatus1.status = Status.heat;
                astatus1.statusAmount = 1;
                astatus1.targetPlayer = true;
                cardActionList1.Add(astatus1);
                result = cardActionList1;
                break;
            case Upgrade.A:
                List<CardAction> cardActionList2 = new List<CardAction>();
                AAttack aattack2 = new AAttack();
                aattack2.damage = GetDmg(s, 0);
                aattack2.status = Status.corrode;
                aattack2.statusAmount = 2;
                aattack2.targetPlayer = false;
                cardActionList2.Add(aattack2);
                AStatus astatus2 = new AStatus();
                astatus2.status = Status.heat;
                astatus2.statusAmount = 1;
                astatus2.targetPlayer = true;
                cardActionList2.Add(astatus2);
                result = cardActionList2;
                break;
            case Upgrade.B:
                List<CardAction> cardActionList3 = new List<CardAction>();
                AAttack aattack3 = new AAttack();
                aattack3.damage = GetDmg(s, 5);
                cardActionList3.Add(aattack3);
                Actions.AStatus2 astatus3 = new Actions.AStatus2();
                astatus3.status = Status.corrode;
                astatus3.statusAmount = 1;
                astatus3.targetPlayer = true;
                astatus3.SelfInflict = true;
                cardActionList3.Add(astatus3);
                result = cardActionList3;
                break;
        }
        return result;
    }

};
