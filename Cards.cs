namespace CorrosiveCobra.Cards
{
    // BOOKS CARDS
    [CardMeta(deck = Deck.shard, rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class BooksCorrosiveCrystal : Card
    {
        public override string Name() => "Corrosive Crystal";
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            switch (upgrade)
            {
                case Upgrade.None:
                    List<CardAction> cardActionList1 = new List<CardAction>();
                    AAttack aattack1 = new AAttack();
                    aattack1.damage = GetDmg(s, 0);
                    aattack1.status = new Status?(Status.corrode);
                    aattack1.statusAmount = 1;
                    aattack1.shardcost = new int?(2);
                    cardActionList1.Add(aattack1);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    AAttack aattack2 = new AAttack();
                    aattack2.damage = GetDmg(s, 0);
                    aattack2.status = new Status?(Status.corrode);
                    aattack2.statusAmount = 1;
                    aattack2.shardcost = new int?(1);
                    cardActionList2.Add(aattack2);
                    AStatus astatus1 = new AStatus();
                    astatus1.status = Status.heat;
                    astatus1.statusAmount = 1;
                    astatus1.targetPlayer = true;
                    cardActionList2.Add(astatus1);
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    AAttack aattack3 = new AAttack();
                    aattack3.damage = GetDmg(s, 3);
                    aattack3.status = new Status?(Status.corrode);
                    aattack3.statusAmount = 1;
                    aattack3.shardcost = new int?(2);
                    cardActionList3.Add(aattack3);
                    AStatus astatus2 = new AStatus();
                    astatus2.status = Status.heat;
                    astatus2.statusAmount = 1;
                    astatus2.targetPlayer = true;
                    cardActionList3.Add(astatus2);
                    result = cardActionList3;
                    break;
            }
            return result;
        }
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            result.art = new Spr?((Spr)Manifest.CorrosiveCobra_CorrodeSprite!.Id);
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
    }

    [CardMeta(deck = Deck.shard, rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class BooksGainCrystal : Card
    {
        public override string Name() => "Fuel Freezing";
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            switch (upgrade)
            {
                case Upgrade.None:
                    List<CardAction> cardActionList1 = new List<CardAction>();
                    AAttack aattack1 = new AAttack();
                    aattack1.damage = GetDmg(s, 0);
                    aattack1.status = Status.heat;
                    aattack1.statusAmount = 1;
                    cardActionList1.Add(aattack1);
                    AStatus astatus1 = new AStatus();
                    astatus1.status = Status.heat;
                    astatus1.statusAmount = -1;
                    astatus1.targetPlayer = true;
                    cardActionList1.Add(astatus1);
                    AStatus astatus2 = new AStatus();
                    astatus2.status = Status.shard;
                    astatus2.statusAmount = 1;
                    astatus2.targetPlayer = true;
                    cardActionList1.Add(astatus2);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    AAttack aattack2 = new AAttack();
                    aattack2.damage = GetDmg(s, 0);
                    aattack2.status = Status.heat;
                    aattack2.statusAmount = -1;
                    cardActionList2.Add(aattack2);
                    AStatus astatus3 = new AStatus();
                    astatus3.status = Status.heat;
                    astatus3.statusAmount = 1;
                    astatus3.targetPlayer = true;
                    cardActionList2.Add(astatus3);
                    AStatus astatus4 = new AStatus();
                    astatus4.status = Status.shard;
                    astatus4.statusAmount = 2;
                    astatus4.targetPlayer = true;
                    cardActionList2.Add(astatus4);
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    AAttack aattack3 = new AAttack();
                    aattack3.damage = GetDmg(s, 2);
                    cardActionList3.Add(aattack3);
                    AStatus astatus5 = new AStatus();
                    astatus5.status = Status.heat;
                    astatus5.statusAmount = 1;
                    astatus5.targetPlayer = true;
                    cardActionList3.Add(astatus5);
                    AStatus astatus6 = new AStatus();
                    astatus6.status = Status.shard;
                    astatus6.statusAmount = 1;
                    astatus6.targetPlayer = true;
                    cardActionList3.Add(astatus6);
                    result = cardActionList3;
                    break;
            }
            return result;
        }
        public override CardData GetData(State state) => new CardData()
        {
            cost = 1,
            art = new Spr?((Spr)Manifest.CorrosiveCobra_CardBackgroud!.Id),
        };
    }

    // CAT CARDS
    [CardMeta(deck = Deck.colorless, rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class ColorlessSlimeSummon : Card
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
            result.art = new Spr?((Spr)Manifest.CorrosiveCobra_CardBackgroud!.Id);
            result.exhaust = true;
            result.artTint = "45e0ab";
            State s = state;
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
            result.description = string.Format(Loc.GetLocString(Manifest.ColorlessSlimeSummon?.DescLocKey ?? throw new Exception("Card ColorlessSlimeSummon not found")), count, Manifest.CobraDeck!.DeckDefReference, "Dizzy?");
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
                    acardOffering1.limitDeck = new Deck?((Deck)Manifest.CobraDeck!.Id);
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
                    acardOffering2.limitDeck = new Deck?((Deck)Manifest.CobraDeck!.Id);
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
                    acardOffering3.limitDeck = new Deck?((Deck)Manifest.CobraDeck!.Id);
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
    [CardMeta(deck = Deck.colorless, dontOffer = true, rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class AbsorbArtifact : Card
    {
        public override string Name() => "Absorb Artifact";

        public string GetRandomArtifact(State state)
        {
            var random1 = new Random();
            List<string> artifactList1 = new List<string>();
            string randomArtifact1 = "";
            if (state.route is Combat)
            {
                foreach (Artifact currentartifact in state.artifacts)
                {
                    if (!(currentartifact.GetMeta().unremovable))
                        artifactList1.Add(currentartifact.Key());
                }
                int index = random1.Next(artifactList1.Count);
                if (index < 0)
                    return randomArtifact1;
                if (artifactList1.Count > 0)
                    randomArtifact1 = artifactList1[index];
            }
            return randomArtifact1;
        }
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            result.description = Loc.GetLocString(Manifest.AbsorbArtifact?.DescLocKey ?? throw new Exception("Missing card"));
            switch (upgrade)
            {
                case Upgrade.None:
                    result.cost = 3;
                    result.singleUse = true;
                    break;
                case Upgrade.A:
                    result.cost = 2;
                    result.singleUse = true;
                    break;
                case Upgrade.B:
                    result.cost = 5;
                    result.exhaust = true;
                    break;
            }
            return result;
        }
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            List<CardAction> cardActionList1 = new List<CardAction>();
            ALoseArtifact aaloseArtifact1 = new ALoseArtifact();
            aaloseArtifact1.artifactType = GetRandomArtifact(s);
            cardActionList1.Add(aaloseArtifact1);
            AHeal aaheal1 = new AHeal();
            aaheal1.healAmount = 10;
            aaheal1.targetPlayer = true;
            cardActionList1.Add(aaheal1);
            result = cardActionList1;
            return result;
        }
    }

    // CORROSIVE COBRA CARDS
    [CardMeta(dontOffer = true, rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class CorrosionStarter : Card
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
                    result.art = new Spr?((Spr)Manifest.CorrosiveCobra_CannonCardSprite!.Id);
                    break;
                case Upgrade.A:
                    result.cost = 2;
                    result.art = new Spr?((Spr)Manifest.CorrosiveCobra_CannonCardSprite!.Id);
                    break;
                case Upgrade.B:
                    result.cost = 1;
                    result.art = new Spr?((Spr)Manifest.CorrosiveCobra_FumeCannonSprite!.Id);
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
    [CardMeta(dontOffer = true, rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class CorrosionBlockStarter : Card
    {
        public override string Name() => "Basic Heat Protection";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            result.art = new Spr?((Spr)Manifest.CorrosiveCobra_CorrosionBlockStarter!.Id);
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
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    AStatus astatus5 = new AStatus();
                    astatus5.status = Status.shield;
                    astatus5.statusAmount = 1;
                    astatus5.targetPlayer = true;
                    cardActionList3.Add(astatus5);
                    AStatus astatus6 = new AStatus();
                    astatus6.status = Status.tempShield;
                    astatus6.statusAmount = 1;
                    astatus6.targetPlayer = true;
                    cardActionList3.Add(astatus6);
                    AStatus astatus7 = new AStatus();
                    astatus7.status = Status.heat;
                    astatus7.statusAmount = -1;
                    astatus7.targetPlayer = true;
                    cardActionList3.Add(astatus7);
                    result = cardActionList3;
                    break;
            }
            return result;
        }

    };

    // DIZZY SLIME CARDS
    [CardMeta(rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class HeatedEvade : Card
    {
        public override string Name() => "Heated Evade";
        public override CardData GetData(State state)
        {
            return new CardData
            {
                cost = upgrade == Upgrade.A ? 0 : 1,
                art = new Spr?((Spr)Manifest.CorrosiveCobra_BoxHeatSprite!.Id),
            };
        }
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            switch (upgrade)
            {

                case Upgrade.None:
                    result.Add(new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = 1,
                        targetPlayer = true
                    });
                    result.Add(new AStatus()
                    {
                        status = Status.evade,
                        statusAmount = 1,
                        targetPlayer = true
                    });
                    result.Add(new AMove()
                    {
                        dir = 1,
                        targetPlayer = true
                    });
                    break;
                case Upgrade.A:
                    result.Add(new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = 1,
                        targetPlayer = true
                    });
                    result.Add(new AStatus()
                    {
                        status = Status.evade,
                        statusAmount = 1,
                        targetPlayer = true
                    });
                    result.Add(new AMove()
                    {
                        dir = 1,
                        targetPlayer = true
                    });
                    break;
                case Upgrade.B:
                    result.Add(new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = 2,
                        targetPlayer = true
                    });
                    result.Add(new AStatus()
                    {
                        status = Status.evade,
                        statusAmount = 2,
                        targetPlayer = true
                    });
                    result.Add(new AMove()
                    {
                        dir = 3,
                        isRandom = true,
                        targetPlayer = true
                    });
                    break;
            }
            return result;
        }
    }

    [CardMeta(rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class HurriedDefense : Card
    {
        public override string Name() => "Hurried Defense";
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            switch (upgrade)
            {
                case Upgrade.None:
                    result.Add(new AStatus()
                    {
                        status = Status.tempShield,
                        statusAmount = 2,
                        targetPlayer = true
                    });
                    result.Add(new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = -1,
                        targetPlayer = true
                    });
                    break;
                case Upgrade.A:
                    result.Add(new AAttack()
                    {
                        damage = GetDmg(s, 1),
                    });
                    result.Add(new AStatus()
                    {
                        status = Status.shield,
                        statusAmount = 2,
                        targetPlayer = true
                    });
                    break;
                case Upgrade.B:
                    result.Add(new AStatus()
                    {
                        status = Status.tempShield,
                        statusAmount = 5,
                        targetPlayer = true
                    });
                    result.Add(new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = 1,
                        targetPlayer = true
                    });
                    break;
            }
            return result;
        }
        public override CardData GetData(State state)
        {
            return new CardData
            {
                cost = 1,
                art = new Spr?((Spr)Manifest.CorrosiveCobra_BlockShotSprite!.Id),
                artTint = upgrade == Upgrade.A ? "40a4fc" : "e20fc2",
            };
        }
    }

    [CardMeta(dontOffer = true, rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class LeakingContainer : Card
    {
        public override string Name() => "Leaking Container";
        private int GetHandTotal(State s)
        {
            int handTotal = 0;
            if (s.route is Combat route)
                handTotal = route.hand.Count - 1;
            if (upgrade == Upgrade.A)
                ++handTotal;
            return handTotal;
        }
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            result.floppable = true;
            result.retain = true;
            result.art = new Spr?(!flipped ? (Spr)Manifest.CorrosiveCobra_SplitTopSprite!.Id : (Spr)Manifest.CorrosiveCobra_SplitBottomSprite!.Id);
            switch (upgrade)
            {
                case Upgrade.None:
                    {
                        result.cost = 2;
                        result.exhaust = true;
                        break;
                    }
                case Upgrade.A:
                    {
                        result.cost = 2;
                        result.exhaust = true;
                        break;
                    }
                case Upgrade.B:
                    {
                        result.cost = 2;
                        result.exhaust = false;
                        break;
                    }
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
                    cardActionList1.Add(new AVariableHint()
                    {
                        hand = true,
                        handAmount = GetHandTotal(s),
                        disabled = flipped,
                    });
                    AHurt ahurt1 = new AHurt();
                    ahurt1.hurtAmount = 3;
                    ahurt1.targetPlayer = true;
                    ahurt1.disabled = flipped;
                    cardActionList1.Add(ahurt1);
                    AStatus astatus1 = new AStatus();
                    astatus1.status = Status.corrode;
                    astatus1.statusAmount = GetHandTotal(s);
                    astatus1.xHint = new int?(1);
                    astatus1.disabled = flipped;
                    astatus1.omitFromTooltips = true;
                    cardActionList1.Add(astatus1);
                    AStatus astatus2 = new AStatus();
                    astatus2.status = Status.heat;
                    astatus2.statusAmount = 1;
                    astatus2.targetPlayer = true;
                    astatus2.disabled = !flipped;
                    cardActionList1.Add(astatus2);
                    AAttack aattack1 = new AAttack();
                    aattack1.damage = GetDmg(s, 3);
                    aattack1.disabled = !flipped;
                    cardActionList1.Add(aattack1);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    cardActionList2.Add(new AVariableHint()
                    {
                        hand = true,
                        handAmount = GetHandTotal(s),
                        disabled = flipped,
                    });
                    AHurt ahurt3 = new AHurt();
                    ahurt3.hurtAmount = 3;
                    ahurt3.targetPlayer = true;
                    ahurt3.disabled = flipped;
                    cardActionList2.Add(ahurt3);
                    AStatus astatus3 = new AStatus();
                    astatus3.status = Status.corrode;
                    astatus3.statusAmount = GetHandTotal(s);
                    astatus3.omitFromTooltips = true;
                    astatus3.xHint = new int?(1);
                    astatus3.disabled = flipped;
                    cardActionList2.Add(astatus3);
                    AStatus astatus4 = new AStatus();
                    AHurt ahurt4 = new AHurt();
                    ahurt4.hurtAmount = 2;
                    ahurt4.targetPlayer = true;
                    ahurt4.disabled = !flipped;
                    cardActionList2.Add(ahurt4);
                    AAttack aattack2 = new AAttack();
                    aattack2.damage = GetDmg(s, 6);
                    aattack2.disabled = !flipped;
                    cardActionList2.Add(aattack2);
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    AStatus astatus5 = new AStatus();
                    astatus5.status = Status.heat;
                    astatus5.statusAmount = 10;
                    astatus5.targetPlayer = true;
                    astatus5.omitFromTooltips = true;
                    astatus5.disabled = flipped;
                    cardActionList3.Add(astatus5);
                    AStunShip astunship1 = new AStunShip();
                    astunship1.disabled = flipped;
                    cardActionList3.Add(astunship1);
                    AEndTurn aendturn1 = new AEndTurn();
                    aendturn1.disabled = flipped;
                    cardActionList3.Add(aendturn1);
                    AStatus astatus6 = new AStatus();
                    astatus6.status = Status.heat;
                    astatus6.statusAmount = 1;
                    astatus6.targetPlayer = true;
                    astatus6.disabled = !flipped;
                    cardActionList3.Add(astatus6);
                    AAttack aattack3 = new AAttack();
                    aattack3.damage = GetDmg(s, 3);
                    aattack3.disabled = !flipped;
                    cardActionList3.Add(aattack3);
                    result = cardActionList3;
                    break;
                default:
                    break;
            }
            return result;
        }
    }

    [CardMeta(rarity = Rarity.uncommon, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class FuelEjection : Card
    {
        public override string Name() => "Fuel Ejection";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            switch (upgrade)
            {
                case Upgrade.None:
                    {
                        result.cost = 2;
                        result.exhaust = true;
                        result.art = new Spr?((Spr)Manifest.CorrosiveCobra_CorrodeSprite!.Id);
                        break;
                    }
                case Upgrade.A:
                    {
                        result.cost = 2;
                        result.exhaust = false;
                        result.art = new Spr?((Spr)Manifest.CorrosiveCobra_HeatSprite!.Id);
                        break;
                    }
                case Upgrade.B:
                    {
                        result.cost = 3;
                        result.exhaust = true;
                        result.art = new Spr?((Spr)Manifest.CorrosiveCobra_CorrodeSprite!.Id);
                        break;
                    }
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
                    aattack1.status = Status.heat;
                    aattack1.statusAmount = 1;
                    cardActionList1.Add(aattack1);
                    AAttack aattack2 = new AAttack();
                    aattack2.damage = GetDmg(s, 0);
                    aattack2.status = Status.corrode;
                    aattack2.statusAmount = 1;
                    cardActionList1.Add(aattack2);
                    AStatus astatus1 = new AStatus();
                    astatus1.status = Status.heat;
                    astatus1.statusAmount = -1;
                    astatus1.targetPlayer = true;
                    cardActionList1.Add(astatus1);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    AAttack aattack3 = new AAttack();
                    aattack3.damage = GetDmg(s, 0);
                    aattack3.status = Status.heat;
                    aattack3.statusAmount = 3;
                    cardActionList2.Add(aattack3);
                    AAttack aattack4 = new AAttack();
                    aattack4.damage = GetDmg(s, 0);
                    aattack4.status = Status.corrode;
                    aattack4.statusAmount = 1;
                    cardActionList2.Add(aattack4);
                    AStatus astatus2 = new AStatus();
                    astatus2.status = Status.heat;
                    astatus2.statusAmount = -3;
                    astatus2.targetPlayer = true;
                    cardActionList2.Add(astatus2);
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    AAttack aattack5 = new AAttack();
                    aattack5.damage = GetDmg(s, 0);
                    aattack5.status = Status.heat;
                    aattack5.statusAmount = 3;
                    cardActionList3.Add(aattack5);
                    AAttack aattack6 = new AAttack();
                    aattack6.damage = GetDmg(s, 0);
                    aattack6.status = Status.corrode;
                    aattack6.statusAmount = 3;
                    cardActionList3.Add(aattack6);
                    AStatus astatus3 = new AStatus();
                    astatus3.status = Status.heat;
                    astatus3.statusAmount = 2;
                    astatus3.targetPlayer = true;
                    cardActionList3.Add(astatus3);
                    result = cardActionList3;
                    break;
            }
            return result;
        }
    }

    [CardMeta(rarity = Rarity.uncommon, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class TankThrow : Card
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
                    result.art = new Spr?((Spr)Manifest.CorrosiveCobra_CorrodeSprite!.Id);
                    break;
                case Upgrade.A:
                    result.cost = 1;
                    result.exhaust = false;
                    result.art = new Spr?((Spr)Manifest.CorrosiveCobra_SeekerCobraSprite!.Id);
                    break;
                case Upgrade.B:
                    result.cost = 3;
                    result.exhaust = true;
                    result.art = new Spr?((Spr)Manifest.CorrosiveCobra_GoatDroneSprite!.Id);
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
                    cardActionList1.Add(new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = 1,
                        targetPlayer = true
                    });
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    ASpawn aspawn3 = new ASpawn();
                    Missile missile3 = new Missile();
                    missile3.yAnimation = 0.0;
                    missile3.missileType = MissileType.seeker;
                    aspawn3.thing = missile3;
                    cardActionList2.Add(aspawn3);
                    cardActionList2.Add(new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = -1,
                        targetPlayer = true
                    });
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    ASpawn aspawn4 = new ASpawn();
                    Missile missile4 = new Missile();
                    missile4.yAnimation = 0.0;
                    missile4.missileType = MissileType.corrode;
                    aspawn4.thing = missile4;
                    aspawn4.thing = missile4;
                    aspawn4.offset = -3;
                    cardActionList3.Add(aspawn4);
                    ASpawn aspawn5 = new ASpawn();
                    Missile missile5 = new Missile();
                    missile5.yAnimation = 0.0;
                    missile5.missileType = MissileType.corrode;
                    aspawn5.thing = missile5;
                    aspawn5.thing = missile5;
                    aspawn5.offset = -2;
                    cardActionList3.Add(aspawn5);
                    ASpawn aspawn6 = new ASpawn();
                    Missile missile6 = new Missile();
                    missile6.yAnimation = 0.0;
                    missile6.missileType = MissileType.corrode;
                    aspawn6.thing = missile6;
                    aspawn6.thing = missile6;
                    aspawn6.offset = -1;
                    cardActionList3.Add(aspawn6);
                    ASpawn aspawn7 = new ASpawn();
                    Missile missile7 = new Missile();
                    missile7.yAnimation = 0.0;
                    missile7.missileType = MissileType.corrode;
                    aspawn7.thing = missile7;
                    aspawn7.thing = missile7;
                    cardActionList3.Add(aspawn7);
                    cardActionList3.Add(new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = 3,
                        targetPlayer = true
                    });
                    result = cardActionList3;
                    break;
            };
            return result;
        }
    };

    [CardMeta(rarity = Rarity.uncommon, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class SlimeShield : Card
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
                    result.description = Loc.GetLocString(Manifest.SlimeShield?.DescLocKey ?? throw new Exception("Missing card"));

                    break;
                case Upgrade.A:
                    result.description = Loc.GetLocString(Manifest.SlimeShield?.DescALocKey ?? throw new Exception("Missing card"));

                    break;
                case Upgrade.B:
                    result.description = Loc.GetLocString(Manifest.SlimeShield?.DescBLocKey ?? throw new Exception("Missing card"));

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
                    SlimeHeal slimeHeal1 = new SlimeHeal();
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
                    SlimeHeal slimeHeal2 = new SlimeHeal();
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
                    SlimeHeal slimeHeal3 = new SlimeHeal();
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

    [CardMeta(dontOffer = true, rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class SlimeHeal : Card
    {
        public override string Name() => "Slime Heal";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();

            result.exhaust = true;
            result.art = new Spr?((Spr)Manifest.CorrosiveCobra_RepairsSprite!.Id);
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

    [CardMeta(rarity = Rarity.uncommon, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class TinkerWithTheTanks : Card
    {
        public override string Name() => "Tinker With The Tanks";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();

            result.cost = 1;
            result.exhaust = true;
            result.art = new Spr?((Spr)Manifest.CorrosiveCobra_RepairsSprite!.Id);
            switch (upgrade)
            {
                case Upgrade.None:
                    result.description = Loc.GetLocString(Manifest.TinkerWithTheTanks?.DescLocKey ?? throw new Exception("Missing card"));
                    break;
                case Upgrade.A:
                    result.description = Loc.GetLocString(Manifest.TinkerWithTheTanks?.DescALocKey ?? throw new Exception("Missing card"));
                    break;
                case Upgrade.B:
                    result.description = Loc.GetLocString(Manifest.TinkerWithTheTanks?.DescBLocKey ?? throw new Exception("Missing card"));
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
                    cardActionList1.Add(aheal1);
                    AAddCard aaddCard1 = new AAddCard();
                    LeakingContainer leakingContainer1 = new LeakingContainer();
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
                    cardActionList2.Add(aheal2);
                    AAddCard aaddCard2 = new AAddCard();
                    LeakingContainer leakingContainer2 = new LeakingContainer();
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
                    cardActionList3.Add(aheal3);
                    AAddCard aaddCard3 = new AAddCard();
                    LeakingContainer leakingContainer3 = new LeakingContainer();
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

    [CardMeta(rarity = Rarity.rare, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class CorrosionIgnition﻿ : Card
    {
        public override string Name() => "Corrosion Ignition﻿";
        private int GetHeatAmt(State s)
        {
            int heatAmt = 0;
            if (s.route is Combat)
                heatAmt = s.ship.Get(Status.heat);
            return heatAmt;
        }
        private int GetCorrodeAmt(State s)
        {
            int corrodeAmt = 0;
            if (s.route is Combat)
                corrodeAmt = s.ship.Get(Status.corrode);
            return corrodeAmt;
        }
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            switch (upgrade)
            {
                case Upgrade.None:
                    {
                        result.cost = 3;
                        break;
                    }
                case Upgrade.A:
                    {
                        result.cost = 0;
                        break;
                    }
                case Upgrade.B:
                    {
                        result.cost = 0;
                        break;
                    }
            }
            result.art = new Spr?((Spr)Manifest.CorrosiveCobra_CorrosionIgnition﻿Sprite!.Id);
            return result;
        }
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            switch (upgrade)
            {
                case Upgrade.None:
                    List<CardAction> cardActionList1 = new List<CardAction>();
                    cardActionList1.Add(new AVariableHint()
                    {
                        status = Status.heat,
                        secondStatus = Status.corrode,
                    });
                    AAttack aattack1 = new AAttack();
                    aattack1.damage = GetDmg(s, GetHeatAmt(s) + GetCorrodeAmt(s));
                    aattack1.xHint = new int?(1);
                    cardActionList1.Add(aattack1);
                    AStatus astatus1 = new AStatus();
                    astatus1.status = Status.corrode;
                    astatus1.statusAmount = 0;
                    astatus1.mode = AStatusMode.Set;
                    astatus1.targetPlayer = true;
                    cardActionList1.Add(astatus1);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    cardActionList2.Add(new AVariableHint()
                    {
                        status = Status.heat,
                    });
                    AAttack aattack2 = new AAttack();
                    aattack2.damage = GetDmg(s, GetHeatAmt(s));
                    aattack2.xHint = new int?(1);
                    cardActionList2.Add(aattack2);
                    AStatus astatus2 = new AStatus();
                    astatus2.status = Status.heat;
                    astatus2.statusAmount = 0;
                    astatus2.mode = AStatusMode.Set;
                    astatus2.targetPlayer = true;
                    cardActionList2.Add(astatus2);
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    cardActionList3.Add(new AVariableHint()
                    {
                        status = Status.corrode,
                    });
                    AAttack aattack3 = new AAttack();
                    aattack3.damage = GetDmg(s, 3 * GetHeatAmt(s));
                    aattack3.xHint = new int?(3);
                    cardActionList3.Add(aattack3);
                    AStatus astatus3 = new AStatus();
                    astatus3.status = Status.corrode;
                    astatus3.statusAmount = 3;
                    astatus3.mode = AStatusMode.Set;
                    astatus3.targetPlayer = true;
                    cardActionList3.Add(astatus3);
                    result = cardActionList3;
                    break;
            }
            return result;
        }
    }

    [CardMeta(rarity = Rarity.rare, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class TimestreamLeak : Card
    {
        public int value = 1;
        public int playedtwo = 0;
        public string goal = "";
        public override string Name() => "Timestream Leak";

        public override void AfterWasPlayed(State state, Combat c)
        {
            if (this.upgrade == Upgrade.B)
                return;
            if (this.playedtwo == 0)
            {
                this.playedtwo = 1;
                return;
            }
            playedtwo = 0;
            ++this.value;
        }
        public override CardData GetData(State state)
        {
            CardData result = new CardData();

            result.exhaust = true;
            if (!(state.route is Combat route2))
            {
                goal = "";
            }
            else
            {
                goal = "{0}/1";
                if (this.playedtwo == 1)
                    goal = string.Format("{0}{1}{2}", "<c=healing>", goal, "</c>");
                goal = string.Format(goal, this.playedtwo);
            }
            switch (upgrade)
            {
                case Upgrade.None:
                    result.cost = 4;
                    result.description = string.Format(Loc.GetLocString(Manifest.TimestreamLeak?.DescLocKey ?? throw new Exception("Missing card")), this.value, this.goal);
                    break;
                case Upgrade.A:
                    result.cost = 3;
                    result.description = string.Format(Loc.GetLocString(Manifest.TimestreamLeak?.DescLocKey ?? throw new Exception("Missing card")), this.value, this.goal);
                    break;
                case Upgrade.B:
                    result.cost = 1;
                    result.description = string.Format(Loc.GetLocString(Manifest.TimestreamLeak?.DescBLocKey ?? throw new Exception("Missing card")), this.value);
                    break;
            }
            return result;
        }
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            List<CardAction> cardActionList1 = new List<CardAction>();
            AStatus astatus1 = new AStatus();
            astatus1.status = Status.corrode;
            astatus1.statusAmount = this.value;
            astatus1.targetPlayer = false;
            cardActionList1.Add(astatus1);
            result = cardActionList1;
            return result;
        }
    }

    [CardMeta(rarity = Rarity.uncommon, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class CorrosiveMultishot : Card
    {
        public override string Name() => "Corrosive Multishot﻿";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            result.cost = 2;
            result.art = new Spr?((Spr)Manifest.CorrosiveCobra_CorrosiveMultishotSprite!.Id);
            switch (upgrade)
            {
                case Upgrade.None:
                    result.exhaust = true;
                    break;
                case Upgrade.A:
                    result.exhaust = true;
                    break;
                case Upgrade.B:
                    result.exhaust = false;
                    result.infinite = true;
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
                    AAttack aattack2 = new AAttack();
                    aattack2.damage = GetDmg(s, 0);
                    aattack2.status = Status.corrode;
                    aattack2.statusAmount = 1;
                    aattack2.targetPlayer = false;
                    cardActionList1.Add(aattack2);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    AAttack aattack3 = new AAttack();
                    aattack3.damage = GetDmg(s, 2);
                    aattack3.status = Status.corrode;
                    aattack3.statusAmount = 1;
                    aattack3.targetPlayer = false;
                    cardActionList2.Add(aattack3);
                    AAttack aattack4 = new AAttack();
                    aattack4.damage = GetDmg(s, 0);
                    aattack4.status = Status.corrode;
                    aattack4.statusAmount = 1;
                    aattack4.targetPlayer = false;
                    cardActionList2.Add(aattack4);
                    AAttack aattack5 = new AAttack();
                    aattack5.damage = GetDmg(s, 0);
                    aattack5.status = Status.corrode;
                    aattack5.statusAmount = 1;
                    aattack5.targetPlayer = false;
                    cardActionList2.Add(aattack5);
                    Actions.AStatus2 astatus1 = new Actions.AStatus2();
                    astatus1.status = Status.corrode;
                    astatus1.statusAmount = 1;
                    astatus1.targetPlayer = true;
                    astatus1.SelfInflict = true;
                    cardActionList2.Add(astatus1);
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    AAttack aattack6 = new AAttack();
                    aattack6.damage = GetDmg(s, 1);
                    aattack6.status = Status.corrode;
                    aattack6.statusAmount = 1;
                    aattack6.targetPlayer = false;
                    cardActionList3.Add(aattack6);
                    result = cardActionList3;
                    break;
            }
            return result;
        }
    }

    [CardMeta(rarity = Rarity.rare, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class SlimeEvolution : Card
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
                    result.description = Loc.GetLocString(Manifest.SlimeEvolution?.DescLocKey ?? throw new Exception("Missing card"));
                    break;
                case Upgrade.A:
                    result.description = Loc.GetLocString(Manifest.SlimeEvolution?.DescLocKey ?? throw new Exception("Missing card"));
                    result.buoyant = true;
                    break;
                case Upgrade.B:
                    result.description = Loc.GetLocString(Manifest.SlimeEvolution?.DescBLocKey ?? throw new Exception("Missing card"));
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
                    SlimeMutation slimeMutation1 = new SlimeMutation();
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
                    SlimeMutation slimeMutation2 = new SlimeMutation();
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
                    SlimeMutation slimeMutation3 = new SlimeMutation();
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

    [CardMeta(dontOffer = true, rarity = Rarity.common)]
    public class SlimeMutation : Card
    {
        public override string Name() => "Slime Mutation";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();

            result.cost = 2;
            result.exhaust = true;
            result.description = Loc.GetLocString(Manifest.SlimeMutation?.DescLocKey ?? throw new Exception("Missing card"));
            return result;
        }
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            List<CardAction> cardActionList1 = new List<CardAction>();
            AAddCard aaddCard1 = new AAddCard();
            SlimeBLAST slimeBlast = new SlimeBLAST();
            slimeBlast.upgrade = Upgrade.None;
            slimeBlast.temporaryOverride = new bool?(true);
            aaddCard1.card = (Card)slimeBlast;
            aaddCard1.destination = CardDestination.Discard;
            cardActionList1.Add(aaddCard1);
            result = cardActionList1;
            return result;
        }
    }

    [CardMeta(dontOffer = true, rarity = Rarity.common)]
    public class SlimeBLAST : Card
    {
        public override string Name() => "SLIME BLAST!!";
        private int GetStatusAmount(State state)
        {
            int allStatusAmount = 0;
            if (state.route is Combat)
            {
                foreach (KeyValuePair<Status, int> currentStatus in state.ship.statusEffects)
                    if (currentStatus.Key != Status.shield && currentStatus.Key != Status.tempShield)
                        allStatusAmount += currentStatus.Value;
            }
            return allStatusAmount;
        }
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            string str1;

            result.cost = 3;
            result.exhaust = true;
            result.art = new Spr?((Spr)Manifest.CorrosiveCobra_SlimeBlastSprite!.Id);
            if (!(state.route is Combat))
                str1 = "";
            else
                str1 = string.Format("{0}{1}{2}", " (<c=keyword>", this.GetDmg(state, 2 * GetStatusAmount(state)), "</c>)");
            result.description = string.Format(Loc.GetLocString(Manifest.SlimeBLAST?.DescLocKey ?? throw new Exception("Missing card")), str1);
            return result;
        }
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            List<CardAction> cardActionList1 = new List<CardAction>();
            AAttack aattack1 = new AAttack();
            aattack1.damage = GetDmg(s, 2 * GetStatusAmount(s));
            aattack1.targetPlayer = false;
            cardActionList1.Add(aattack1);
            result = cardActionList1;

            return result;
        }
    }

    [CardMeta(rarity = Rarity.rare, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class SlimeHug : Card
    {
        public override string Name() => "Slime Hug";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            result.exhaust = true;
            result.art = new Spr?((Spr)Manifest.CorrosiveCobra_EvolveBackgroundSprite!.Id);
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
            var evolve_status = (Status)(Manifest.EvolveStatus?.Id ?? throw new Exception("Missing EvolveStatus"));

            switch (upgrade)
            {
                case Upgrade.None:
                    List<CardAction> cardActionList1 = new List<CardAction>();
                    AStatus astatus1 = new AStatus();
                    astatus1.status = evolve_status;
                    astatus1.statusAmount = 1;
                    astatus1.targetPlayer = true;
                    cardActionList1.Add(astatus1);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    AStatus astatus2 = new AStatus();
                    astatus2.status = evolve_status;
                    astatus2.statusAmount = 1;
                    astatus2.targetPlayer = true;
                    cardActionList2.Add(astatus2);
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    AStatus astatus3 = new AStatus();
                    astatus3.status = evolve_status;
                    astatus3.statusAmount = 2;
                    astatus3.targetPlayer = true;
                    cardActionList3.Add(astatus3);
                    result = cardActionList3;
                    break;
            }
            return result;
        }
    }

    [CardMeta(rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class RecklessFuelshot : Card
    {
        public override string Name() => "Reckless Fuelshot";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            result.cost = 1;
            result.art = new Spr?((Spr)Manifest.CorrosiveCobra_RecklessFuelshotSprite!.Id);
            switch (upgrade)
            {
                case Upgrade.None:
                    result.description = string.Format(Loc.GetLocString(Manifest.RecklessFuelshot?.DescLocKey ?? throw new Exception("Missing card")), this.GetDmg(state, 3), 1);
                    break;
                case Upgrade.A:
                    result.description = string.Format(Loc.GetLocString(Manifest.RecklessFuelshot?.DescALocKey ?? throw new Exception("Missing card")), this.GetDmg(state, 3), 1);
                    break;
                case Upgrade.B:
                    result.description = string.Format(Loc.GetLocString(Manifest.RecklessFuelshot?.DescLocKey ?? throw new Exception("Missing card")), this.GetDmg(state, 6), 2);
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
                    aattack1.damage = GetDmg(s, 3);
                    cardActionList1.Add(aattack1);
                    AAddCard aaddCard1 = new AAddCard();
                    Toxic toxic1 = new Toxic();
                    aaddCard1.card = toxic1;
                    aaddCard1.amount = 1;
                    aaddCard1.destination = CardDestination.Deck;
                    cardActionList1.Add(aaddCard1);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    AAttack aattack2 = new AAttack();
                    aattack2.damage = GetDmg(s, 3);
                    cardActionList2.Add(aattack2);
                    AAddCard aaddCard2 = new AAddCard();
                    Toxic toxic2 = new Toxic();
                    aaddCard2.card = toxic2;
                    aaddCard2.amount = 1;
                    aaddCard2.destination = CardDestination.Discard;
                    cardActionList2.Add(aaddCard2);
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    AAttack aattack3 = new AAttack();
                    aattack3.damage = GetDmg(s, 6);
                    cardActionList3.Add(aattack3);
                    AAddCard aaddCard3 = new AAddCard();
                    Toxic toxic3 = new Toxic();
                    aaddCard3.card = toxic3;
                    aaddCard3.amount = 2;
                    aaddCard3.destination = CardDestination.Deck;
                    cardActionList3.Add(aaddCard3);
                    result = cardActionList3;
                    break;
            }
            return result;
        }
    }

    [CardMeta(rarity = Rarity.rare, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class EnginesOnFire : Card
    {
        public override string Name() => "Engines! On Fire!";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            result.exhaust = true;
            result.art = new Spr?((Spr)Manifest.CorrosiveCobra_HeatSprite!.Id);
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

    [CardMeta(rarity = Rarity.rare, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class HeatHoarder : Card
    {
        public override string Name() => "Heat Hoarder";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            result.singleUse = true;
            switch (upgrade)
            {
                case Upgrade.None:
                    result.cost = 3;
                    result.description = string.Format(Loc.GetLocString(Manifest.HeatHoarder?.DescLocKey ?? throw new Exception("Missing card")), 1, 2);
                    break;
                case Upgrade.A:
                    result.cost = 1;
                    result.description = string.Format(Loc.GetLocString(Manifest.HeatHoarder?.DescLocKey ?? throw new Exception("Missing card")), 1, 2);
                    break;
                case Upgrade.B:
                    result.cost = 3;
                    result.description = string.Format(Loc.GetLocString(Manifest.HeatHoarder?.DescLocKey ?? throw new Exception("Missing card")), 3, 3);
                    break;
            }
            return result;
        }
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            var heatcontrol_status = (Status)(Manifest.HeatControlStatus?.Id ?? throw new Exception("Missing HeatOutbreakStatus"));
            switch (upgrade)
            {
                case Upgrade.None:
                    List<CardAction> cardActionList1 = new List<CardAction>();
                    AStatus astatus1 = new AStatus();
                    astatus1.status = heatcontrol_status;
                    astatus1.statusAmount = 1;
                    astatus1.targetPlayer = true;
                    cardActionList1.Add(astatus1);
                    AAddCard aaddCard1 = new AAddCard();
                    TrashMiasma trashMiasma1 = new TrashMiasma();
                    trashMiasma1.temporaryOverride = false;
                    aaddCard1.card = trashMiasma1;
                    aaddCard1.amount = 2;
                    aaddCard1.destination = CardDestination.Deck;
                    cardActionList1.Add(aaddCard1);
                    result = cardActionList1;
                    break;
                case Upgrade.A:
                    List<CardAction> cardActionList2 = new List<CardAction>();
                    AStatus astatus2 = new AStatus();
                    astatus2.status = heatcontrol_status;
                    astatus2.statusAmount = 1;
                    astatus2.targetPlayer = true;
                    cardActionList2.Add(astatus2);
                    AAddCard aaddCard2 = new AAddCard();
                    TrashMiasma trashMiasma2 = new TrashMiasma();
                    trashMiasma2.temporaryOverride = false;
                    aaddCard2.card = trashMiasma2;
                    aaddCard2.amount = 2;
                    aaddCard2.destination = CardDestination.Deck;
                    cardActionList2.Add(aaddCard2);
                    result = cardActionList2;
                    break;
                case Upgrade.B:
                    List<CardAction> cardActionList3 = new List<CardAction>();
                    AStatus astatus3 = new AStatus();
                    astatus3.status = heatcontrol_status;
                    astatus3.statusAmount = 2;
                    astatus3.targetPlayer = true;
                    cardActionList3.Add(astatus3);
                    AAddCard aaddCard3 = new AAddCard();
                    TrashMiasma trashMiasma3 = new TrashMiasma();
                    trashMiasma3.temporaryOverride = false;
                    aaddCard3.card = trashMiasma3;
                    aaddCard3.amount = 3;
                    aaddCard3.destination = CardDestination.Deck;
                    cardActionList3.Add(aaddCard3);
                    result = cardActionList3;
                    break;
            }
            return result;
        }
    }

    [CardMeta(rarity = Rarity.common, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class ShieldAlternatorA : Card
    {
        public override string Name() => "Shield Replica";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            result.artTint = "005555";
            switch (upgrade)
            {
                case Upgrade.None:
                    result.cost = 1;
                    result.exhaust = true;
                    result.description = Loc.GetLocString(Manifest.ShieldAlternatorA?.DescLocKey ?? throw new Exception("Missing card"));
                    break;
                case Upgrade.A:
                    result.cost = 0;
                    result.exhaust = true;
                    result.description = Loc.GetLocString(Manifest.ShieldAlternatorA?.DescLocKey ?? throw new Exception("Missing card"));
                    break;
                case Upgrade.B:
                    result.cost = 1;
                    result.exhaust = false;
                    result.description = Loc.GetLocString(Manifest.ShieldAlternatorA?.DescLocKey ?? throw new Exception("Missing card"));
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
                    AAddCard aaddCard1 = new AAddCard();
                    ShieldAlternatorB shieldAlternatorB1 = new ShieldAlternatorB();
                    shieldAlternatorB1.temporaryOverride = new bool?(true);
                    aaddCard1.card = (Card)shieldAlternatorB1;
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
                    ShieldAlternatorB shieldAlternatorB2 = new ShieldAlternatorB();
                    shieldAlternatorB2.temporaryOverride = new bool?(true);
                    aaddCard2.card = (Card)shieldAlternatorB2;
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
                    ShieldAlternatorB shieldAlternatorB3 = new ShieldAlternatorB();
                    shieldAlternatorB3.temporaryOverride = new bool?(true);
                    aaddCard3.card = (Card)shieldAlternatorB3;
                    aaddCard3.destination = CardDestination.Hand;
                    cardActionList3.Add(aaddCard3);
                    result = cardActionList3;
                    break;
            }
            return result;
        }
    }

    [CardMeta(rarity = Rarity.common)]
    public class ShieldAlternatorB : Card
    {
        public override string Name() => "Temp Shield Replica";
        public override CardData GetData(State state)
        {
            CardData result = new CardData();
            result.cost = 1;
            result.exhaust = true;
            result.artTint = "e20fc2";
            result.description = Loc.GetLocString(Manifest.ShieldAlternatorB?.DescLocKey ?? throw new Exception("Missing card"));
            return result;
        }
        public override List<CardAction> GetActions(State s, Combat c)
        {
            var result = new List<CardAction>();
            List<CardAction> cardActionList1 = new List<CardAction>();
            AStatus astatus1 = new AStatus();
            astatus1.status = Status.tempShield;
            astatus1.statusAmount = 2;
            astatus1.targetPlayer = true;
            cardActionList1.Add(astatus1);
            AAddCard aaddCard1 = new AAddCard();
            ShieldAlternatorA shieldAlternatorA1 = new ShieldAlternatorA();
            shieldAlternatorA1.upgrade = Upgrade.None;
            shieldAlternatorA1.temporaryOverride = new bool?(true);
            shieldAlternatorA1.singleUseOverride = new bool?(true);
            aaddCard1.card = (Card)shieldAlternatorA1;
            aaddCard1.destination = CardDestination.Hand;
            cardActionList1.Add(aaddCard1);
            result = cardActionList1;
            return result;
        }
    }

    [CardMeta(rarity = Rarity.uncommon, upgradesTo = new Upgrade[] { Upgrade.A, Upgrade.B })]
    public class AcidicFlare : Card
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
                    result.description = Loc.GetLocString(Manifest.AcidicFlare?.DescLocKey ?? throw new Exception("Missing card"));
                    break;
                case Upgrade.A:
                    result.description = Loc.GetLocString(Manifest.AcidicFlare?.DescALocKey ?? throw new Exception("Missing card"));
                    break;
                case Upgrade.B:
                    result.description = Loc.GetLocString(Manifest.AcidicFlare?.DescBLocKey ?? throw new Exception("Missing card"));
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
                    cardActionList1.Add(astatus1);
                    AStatus astatus2 = new AStatus();
                    astatus2.status = Status.heat;
                    astatus2.statusAmount = 0;
                    astatus2.mode = AStatusMode.Set;
                    astatus2.targetPlayer = false;
                    cardActionList1.Add(astatus2);
                    astatus2.omitFromTooltips = true;
                    AStatus astatus3 = new AStatus();
                    astatus3.status = Status.corrode;
                    astatus3.statusAmount = shipStatusAmount;
                    astatus3.mode = AStatusMode.Set;
                    astatus3.targetPlayer = true;
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
                    cardActionList2.Add(astatus7);
                    AStatus astatus8 = new AStatus();
                    astatus8.status = Status.heat;
                    astatus8.statusAmount = otherShipStatusAmount;
                    astatus8.mode = AStatusMode.Set;
                    astatus8.targetPlayer = false;
                    astatus8.omitFromTooltips = true;
                    cardActionList2.Add(astatus8);
                    AAddCard aaddCard1 = new AAddCard();
                    CorrosionIgnition corrosionIgnition1 = new CorrosionIgnition();
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
                    cardActionList3.Add(astatus11);
                    AStatus astatus12 = new AStatus();
                    astatus12.status = Status.corrode;
                    astatus12.statusAmount = otherShipStatusAmount;
                    astatus12.mode = AStatusMode.Set;
                    astatus12.targetPlayer = false;
                    astatus12.omitFromTooltips = true;
                    cardActionList3.Add(astatus12);
                    AAddCard aaddCard2 = new AAddCard();
                    CorrosionIgnition corrosionIgnition2 = new CorrosionIgnition();
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