using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Artifacts;

public class SlimePeriArtifact : Artifact, IModdedArtifact
{
    public static void Register(IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact("SlimePeriArtifact", new()
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                owner = ModEntry.Instance.DuoArtifactsApi!.DuoArtifactVanillaDeck,
                pools = [ArtifactPool.Common]
            },
            Sprite = ModEntry.Instance.Sprites["SlimePeriArtifactSprite"].Sprite,
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "SlimePeriArtifact", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "SlimePeriArtifact", "description"]).Localize
        });
        ModEntry.Instance.DuoArtifactsApi!.RegisterDuoArtifact(typeof(SlimePeriArtifact), new[] { ModEntry.Instance.SlimeDeck.Deck, Deck.peri });
    }
    public override void OnReceiveArtifact(State state)
    {
        state.ship.baseDraw -= 1;
    }
    public override void OnRemoveArtifact(State state)
    {
        state.ship.baseDraw += 1;
    }
    public override void OnCombatStart(State state, Combat combat)
    {
        AStatus aStatus1 = new AStatus()
        {
            status = Status.powerdrive,
            statusAmount = 1,
            targetPlayer = true,
        };
        combat.QueueImmediate(aStatus1);
        Pulse();
    }
    public override List<Tooltip>? GetExtraTooltips()
    {
        var tooltips = new List<Tooltip>()
        {
            new TTGlossary("status.powerdriveAlt")
        };
        return tooltips;
    }
}