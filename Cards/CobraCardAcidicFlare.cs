using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardAcidicFlare : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("AcidicFlare", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.uncommon,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "AcidicFlare", "name"]).Localize
        });
    }
    public override string Name() => "Acidic Flare﻿";
    public override CardData GetData(State state)
    {
        CardData result = new CardData()
        {
            cost = 2,
            exhaust = true,
            description = ModEntry.Instance.Localizations.Localize(["card", "AcidicFlare", "description", upgrade.ToString()]),
        };
        return result;
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        List<CardAction> result = new();
        switch (upgrade)
        {
            case Upgrade.None:
                if (s.ship.Get(Status.heat) > 0)
                {
                    result.Add(new AStatus()
                    {
                        status = Status.corrode,
                        statusAmount = s.ship.Get(Status.heat),
                        targetPlayer = true,
                        timer = 0
                    });
                    result.Add(new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = 0,
                        mode = AStatusMode.Set,
                        targetPlayer = true,
                        omitFromTooltips = true
                    });
                };
                if (c.otherShip.Get(Status.heat) > 0)
                {
                    result.Add(new AStatus()
                    {
                        status = Status.corrode,
                        statusAmount = c.otherShip.Get(Status.heat),
                        targetPlayer = false,
                        omitFromTooltips = true,
                        timer = 0
                    });
                    result.Add(new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = 0,
                        mode = AStatusMode.Set,
                        targetPlayer = false,
                        omitFromTooltips = true
                    });
                }
                break;
            case Upgrade.A:
                if (s.ship.Get(Status.corrode) > 0)
                {
                    result.Add(new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = s.ship.Get(Status.corrode),
                        targetPlayer = true,
                        omitFromTooltips = true,
                        timer = 0
                    });
                    result.Add(new AStatus()
                    {
                        status = Status.corrode,
                        statusAmount = 0,
                        mode = AStatusMode.Set,
                        targetPlayer = true,
                        omitFromTooltips = true
                    });
                };
                if (c.otherShip.Get(Status.corrode) > 0)
                {
                    result.Add(new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = s.ship.Get(Status.corrode),
                        targetPlayer = false,
                        omitFromTooltips = true,
                        timer = 0
                    });
                    result.Add(new AStatus()
                    {
                        status = Status.corrode,
                        statusAmount = 0,
                        mode = AStatusMode.Set,
                        targetPlayer = false,
                        omitFromTooltips = true
                    });
                }
                result.Add(new AAddCard()
                {
                    card = new CobraCardCorrosionIgnition()
                    {
                        upgrade = Upgrade.A,
                        temporaryOverride = true
                    },
                    destination = CardDestination.Hand
                });
                break;
            case Upgrade.B:
                if (s.ship.Get(Status.heat) > 0)
                {
                    result.Add(new AStatus()
                    {
                        status = Status.corrode,
                        statusAmount = s.ship.Get(Status.heat),
                        targetPlayer = true,
                        omitFromTooltips = true,
                        timer = 0
                    });
                    result.Add(new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = 0,
                        mode = AStatusMode.Set,
                        targetPlayer = true,
                        omitFromTooltips = true
                    });
                };
                if (c.otherShip.Get(Status.heat) > 0)
                {
                    result.Add(new AStatus()
                    {
                        status = Status.corrode,
                        statusAmount = c.otherShip.Get(Status.heat),
                        targetPlayer = false,
                        omitFromTooltips = true,
                        timer = 0
                    });
                    result.Add(new AStatus()
                    {
                        status = Status.heat,
                        statusAmount = 0,
                        mode = AStatusMode.Set,
                        targetPlayer = false,
                        omitFromTooltips = true
                    });
                }
                result.Add(new AAddCard()
                {
                    card = new CobraCardCorrosionIgnition()
                    {
                        upgrade = Upgrade.B,
                        temporaryOverride = true
                    },
                    destination = CardDestination.Hand
                });
                break;
        }
        return result;
    }
}
