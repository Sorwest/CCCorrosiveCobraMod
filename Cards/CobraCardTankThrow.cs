namespace CorrosiveCobra.Cards
{
    [CardMeta(rarity = Rarity.uncommon, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class CobraCardTankThrow : Card
    {
        public override string Name() => "Tank Throw";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();

            switch (upgrade)
            {
                case Upgrade.None:
                    result.cost = 2;
                    result.exhaust = true;
                    result.art = new Spr?((Spr)Manifest.CorrosiveCobra_CorrodeSprite!.Id!);
                    break;
                case Upgrade.A:
                    result.cost = 2;
                    result.exhaust = false;
                    result.art = new Spr?((Spr)Manifest.CorrosiveCobra_SeekerCobraSprite!.Id!);
                    break;
                case Upgrade.B:
                    result.cost = 3;
                    result.exhaust = true;
                    result.art = new Spr?((Spr)Manifest.CorrosiveCobra_GoatDroneSprite!.Id!);
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
                    ASpawn aspawn1 = new ASpawn();
                    Missile missile1 = new Missile();
                    missile1.yAnimation = 0.0;
                    missile1.missileType = MissileType.corrode;
                    aspawn1.dialogueSelector = ".playedTankThrowNone";
                    aspawn1.thing = missile1;
                    cardActionList1.Add(aspawn1);
                    AMove amove1 = new AMove();
                    amove1.dir = 2;
                    amove1.targetPlayer = true;
                    cardActionList1.Add(amove1);
                    ASpawn aspawn2 = new ASpawn();
                    Missile missile2 = new Missile();
                    missile2.yAnimation = 0.0;
                    missile2.missileType = MissileType.corrode;
                    aspawn2.thing = missile2;
                    cardActionList1.Add(aspawn2);
                    AMove amove2 = new AMove();
                    amove2.dir = -1;
                    amove2.targetPlayer = true;
                    cardActionList1.Add(amove2);
                    AStatus astatus1 = new AStatus();
                    astatus1.status = Status.heat;
                    astatus1.statusAmount = 1;
                    astatus1.targetPlayer = true;
                    cardActionList1.Add(astatus1);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    ASpawn aspawn3 = new ASpawn();
                    Missile missile3 = new Missile();
                    missile3.yAnimation = 0.0;
                    missile3.missileType = MissileType.seeker;
                    aspawn3.dialogueSelector = ".playedTankThrowA";
                    aspawn3.thing = missile3;
                    cardActionList2.Add(aspawn3);
                    AMove amove3 = new AMove();
                    amove3.dir = 1;
                    amove3.targetPlayer = true;
                    cardActionList2.Add(amove3);
                    AStatus astatus2 = new AStatus();
                    astatus2.status = Status.heat;
                    astatus2.statusAmount = -1;
                    astatus2.targetPlayer = true;
                    cardActionList2.Add(astatus2);
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    ASpawn aspawn4 = new ASpawn();
                    Missile missile4 = new Missile();
                    missile4.yAnimation = 0.0;
                    missile4.missileType = MissileType.corrode;
                    aspawn4.thing = missile4;
                    aspawn4.dialogueSelector = ".playedTankThrowB";
                    aspawn4.offset = -3;
                    cardActionList3.Add(aspawn4);
                    ASpawn aspawn5 = new ASpawn();
                    Missile missile5 = new Missile();
                    missile5.yAnimation = 0.0;
                    missile5.missileType = MissileType.corrode;
                    aspawn5.thing = missile5;
                    aspawn5.offset = -2;
                    cardActionList3.Add(aspawn5);
                    ASpawn aspawn6 = new ASpawn();
                    Missile missile6 = new Missile();
                    missile6.yAnimation = 0.0;
                    missile6.missileType = MissileType.corrode;
                    aspawn6.thing = missile6;
                    aspawn6.offset = -1;
                    cardActionList3.Add(aspawn6);
                    ASpawn aspawn7 = new ASpawn();
                    Missile missile7 = new Missile();
                    missile7.yAnimation = 0.0;
                    missile7.missileType = MissileType.corrode;
                    aspawn7.thing = missile7;
                    cardActionList3.Add(aspawn7);
                    Actions.AStatus2 astatus3 = new Actions.AStatus2();
                    astatus3.status = Status.corrode;
                    astatus3.statusAmount = 1;
                    astatus3.targetPlayer = true;
                    astatus3.SelfInflict = true;
                    cardActionList3.Add(astatus3);
                    result = cardActionList3;
                    break;
            };
            return result;
        }
    };
}
