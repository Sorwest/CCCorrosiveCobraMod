using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Cards;

public class CobraCardCorrosionIgnition﻿ : Card, IModdedCard
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Cards.RegisterCard("CorrosionIgnition", new()
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                deck = ModEntry.Instance.SlimeDeck.Deck,
                rarity = Rarity.rare,
                upgradesTo = [Upgrade.A, Upgrade.B]
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "CorrosionIgnition", "name"]).Localize
        });
    }
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
        return new()
        {
            cost = upgrade == Upgrade.None ? 1 : 0,
            art = ModEntry.Instance.Sprites["CorrosionIgnitionSprite"].Sprite
        };
    }
    public override List<CardAction> GetActions(State s, Combat c)
    {
        int num = 0;
        switch (upgrade)
        {
            case Upgrade.None:
                num = GetHeatAmt(s) + GetCorrodeAmt(s);
                break;
            case Upgrade.A:
                num = GetHeatAmt(s);
                break;
            case Upgrade.B:
                num = 3 * GetCorrodeAmt(s);
                break;
        };
        return new()
        {
            new AVariableHint()
            {
                status = upgrade == Upgrade.B ? Status.corrode : Status.heat,
                secondStatus = upgrade == Upgrade.None ? Status.corrode : null
            },
            new AAttack()
            {
                damage = GetDmg(s, num),
                xHint = upgrade == Upgrade.B ? 3 : 1
            },
            new AStatus()
            {
                status = upgrade == Upgrade.A ? Status.heat : Status.corrode,
                statusAmount = upgrade == Upgrade.B ? 3 : 0,
                mode = AStatusMode.Set,
                targetPlayer = true
            }
        };
    }
}
