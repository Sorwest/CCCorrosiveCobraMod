using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;
public class CobraCardCorrosiveMultishot : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("CorrosiveMultishot", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.uncommon,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "CorrosiveMultishot", "name"]).Localize
        });
    }
    public override string Name() => "Corrosive Multishot﻿";
    public override CardData GetData(State state)
    {
        return new()
        {
            art = ModEntry.Instance.Sprites["CorrosiveMultishotSprite"].Sprite,
            cost = upgrade == Upgrade.B ? 3 : 2,
            exhaust = upgrade == Upgrade.B ? false : true,
            recycle = upgrade == Upgrade.B ? true : false
        };
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        List<CardAction> result = new();
        switch (upgrade)
        {
            case Upgrade.None:
                result = new()
                {
                    new AAttack()
                    {
                        damage = GetDmg(s, 1),
                        status = ModEntry.Instance.OxidationStatus.Status,
                        statusAmount = 3
                    },
                    new AAttack()
                    {
                        damage = GetDmg(s, 1),
                        status = ModEntry.Instance.OxidationStatus.Status,
                        statusAmount = 3
                    },
                };
                break;
            case Upgrade.A:
                result = new()
                {
                    new AAttack()
                    {
                        damage = GetDmg(s, 1),
                        status = ModEntry.Instance.OxidationStatus.Status,
                        statusAmount = 3
                    },
                    new AAttack()
                    {
                        damage = GetDmg(s, 1),
                        status = ModEntry.Instance.OxidationStatus.Status,
                        statusAmount = 3
                    },
                    new AAttack()
                    {
                        damage = GetDmg(s, 1),
                        status = ModEntry.Instance.OxidationStatus.Status,
                        statusAmount = 1
                    }
                };
                break;
            case Upgrade.B:
                result = new()
                {
                    new AAttack()
                    {
                        damage = GetDmg(s, 0),
                        status = ModEntry.Instance.OxidationStatus.Status,
                        statusAmount = 1
                    },
                    new AAttack()
                    {
                        damage = GetDmg(s, 0),
                        status = Status.heat,
                        statusAmount = 1
                    },
                    new AAttack()
                    {
                        damage = GetDmg(s, 0),
                        status = ModEntry.Instance.OxidationStatus.Status,
                        statusAmount = 1
                    },
                    new AAttack()
                    {
                        damage = GetDmg(s, 0),
                        status = Status.heat,
                        statusAmount = 1
                    },
                    new AAttack()
                    {
                        damage = GetDmg(s, 0),
                        status = ModEntry.Instance.OxidationStatus.Status,
                        statusAmount = 1
                    }
                };
                break;
        }
        return result;
    }
}
