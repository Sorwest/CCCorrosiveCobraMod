using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Sorwest.CorrosiveCobra.Artifacts;

public class SlimeCatArtifact : Artifact, IModdedArtifact
{
    public static void Register(IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact("SlimeCatArtifact", new()
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                owner = ModEntry.Instance.DuoArtifactsApi!.DuoArtifactVanillaDeck,
                pools = [ArtifactPool.Common]
            },
            Sprite = ModEntry.Instance.Sprites["SlimeCatArtifactSprite"].Sprite,
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "SlimeCatArtifact", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "SlimeCatArtifact", "description"]).Localize
        });
        ModEntry.Instance.DuoArtifactsApi!.RegisterDuoArtifact(typeof(SlimeCatArtifact), new[] { ModEntry.Instance.SlimeDeck.Deck, Deck.catartifact });
    }
    public bool triggered;
    public override Spr GetSprite()
    {
        Spr sprite = new Spr();
        if (triggered)
            sprite = ModEntry.Instance.Sprites["SlimeCatArtifactSprite_Off"].Sprite;
        else
            sprite = ModEntry.Instance.Sprites["SlimeCatArtifactSprite"].Sprite;
        return sprite;
    }
    public override void OnTurnEnd(State state, Combat combat)
    {
        if (state.ship.hull == 1 && !triggered)
        {
            AStatus aStatus1 = new AStatus()
            {
                status = Status.perfectShield,
                statusAmount = 1,
                targetPlayer = true,
            };
            combat.QueueImmediate(aStatus1);
            AStatus aStatus2 = new AStatus()
            {
                status = Status.corrode,
                statusAmount = 1,
                targetPlayer = false,
            };
            combat.QueueImmediate(aStatus2);
            triggered = true;
            this.Pulse();
        }
    }
    public override List<Tooltip>? GetExtraTooltips()
    {
        var tooltips = new List<Tooltip>()
        {
            new TTGlossary("status.perfectShield", 1),
            new TTGlossary("status.corrodeAlt")
        };
        return tooltips;
    }
}