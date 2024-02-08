using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Artifacts;

public class CobraArtifactDummyHeat : Artifact, IModdedArtifact
{
    public static void Register(IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact("DummyHeat", new()
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                owner = ModEntry.Instance.SlimeDeck.Deck,
                pools = [ArtifactPool.Unreleased],
                unremovable = true
            },
            Sprite = ModEntry.Instance.Sprites["DummyHeatSprite"].Sprite,
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "DummyHeat", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "DummyHeat", "description"]).Localize
        });
    }
    public override string Name() => "COBRA MISC OVERHEAT";
    public int overheatTrigger;
    public override int? GetDisplayNumber(State s)
    {
        overheatTrigger = s.ship.heatTrigger;
        return overheatTrigger;
    }
    public override List<Tooltip>? GetExtraTooltips()
    {
        var tooltips = new List<Tooltip>()
        {
            new TTText("CURRENT OVERHEAT TRIGGER : " + overheatTrigger),
        };
        return tooltips;
    }
}
