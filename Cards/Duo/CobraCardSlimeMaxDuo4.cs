﻿namespace Sorwest.CorrosiveCobra.Cards;

[CardMeta(unreleased = true, dontOffer = true)]
public class CobraCardSlimeMaxDuo4 : Card
{
    public override CardData GetData(State state)
    {
        CardData result = new CardData
        {
            cost = 1,
            exhaust = true,
            retain = true,
        };
        return result;
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        var nextCard = new CobraCardSlimeMaxDuo5()
        {
            temporaryOverride = true,
        };
        List<CardAction> result = new List<CardAction>
        {
            new AStatus()
            {
                status = Status.shield,
                statusAmount = 2,
                targetPlayer = true,
            },
            new AAddCard()
            {
                card = nextCard,
                amount = 1,
                destination = CardDestination.Deck,
                omitFromTooltips = true,
            },
            new ADrawCard()
            {
                count = 1,
            },
            new AShuffleHand(),
        };
        return result;
    }
}