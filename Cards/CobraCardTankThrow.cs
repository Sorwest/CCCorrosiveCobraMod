using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardTankThrow : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("TankThrow", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.uncommon,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "TankThrow", "name"]).Localize
        });
    }
    public override string Name() => "Tank Throw";
    public override CardData GetData(State state)
    {
        return new()
        {
            cost = upgrade == Upgrade.A ? 1 : upgrade == Upgrade.B ? 3 : 2,
            art = ModEntry.Instance.Sprites["SeekerCobraSprite"].Sprite
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
                    new ASpawn()
                    {
                        thing = new Missile()
                        {
                            missileType = MissileType.corrode,
                            targetPlayer = false
                        },
                        dialogueSelector = $".TankThrow{upgrade}"
                    },
                    new AMove()
                    {
                        dir = 1,
                        targetPlayer = true
                    },
                    new AStatus()
                    {
                        status = ModEntry.Instance.OxidationStatus.Status,
                        statusAmount = 3,
                        targetPlayer = true
                    }
                };
                break;
            case Upgrade.A:
                result = new()
                {
                    new ASpawn()
                    {
                        thing = new Missile()
                        {
                            missileType = MissileType.corrode,
                            targetPlayer = false
                        },
                        dialogueSelector = $".TankThrow{upgrade}"
                    },
                    new AStatus()
                    {
                        status = ModEntry.Instance.OxidationStatus.Status,
                        statusAmount = 3,
                        targetPlayer = true
                    }
                };
                break;
            case Upgrade.B:
                result = new()
                {
                    new ASpawn()
                    {
                        thing = new Missile()
                        {
                            missileType = MissileType.corrode,
                            targetPlayer = false
                        },
                        dialogueSelector = $".TankThrow{upgrade}"
                    },
                    new AMove()
                    {
                        dir = 1,
                        targetPlayer = true
                    },
                    new ASpawn()
                    {
                        thing = new Missile()
                        {
                            missileType = MissileType.corrode,
                            targetPlayer = false
                        }
                    },
                    new AStatus()
                    {
                        status = ModEntry.Instance.OxidationStatus.Status,
                        statusAmount = 4,
                        targetPlayer = true
                    }
                };
                break;
        };
        return result;
    }
};
