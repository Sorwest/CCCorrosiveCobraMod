using Nickel;
using System.Collections.Generic;
using System.Reflection;
using Sorwest.CorrosiveCobra.Cards;

namespace Sorwest.CorrosiveCobra.Artifacts;

public class CobraArtifactOverdriveTanks : Artifact, IModdedArtifact
{
    public static void Register(IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact("OverdriveTanks", new()
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                owner = Deck.colorless,
                pools = [ArtifactPool.Boss],
                unremovable = true
            },
            Sprite = ModEntry.Instance.Sprites["OverdriveTanksSprite"].Sprite,
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "OverdriveTanks", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "OverdriveTanks", "description"]).Localize
        });
    }
    public override string Name() => "OVERDRIVETANKS";
    public override void OnReceiveArtifact(State state)
    {
        state.ship.baseEnergy += 1;
        foreach (Artifact artifact in state.artifacts)
        {
            if (artifact.Name() == "UNSTABLE FUELTANKS")
                artifact.OnRemoveArtifact(state);
        }
        state.artifacts.RemoveAll(r => r.GetType() == typeof(CobraArtifactUnstableTanks));
    }
    public override void OnRemoveArtifact(State state)
    {
        state.ship.baseEnergy -= 1;
    }
    public override void OnTurnStart(State state, Combat combat)
    {
        combat.QueueImmediate(new AStatus()
        {
            status = ModEntry.Instance.OxidationStatus.Status,
            statusAmount = 2,
            targetPlayer = true
        });
        if (combat.turn == 1)
            combat.QueueImmediate(new AAddCard()
            {
                card = new CobraCardLeakingContainer()
                {
                    temporaryOverride = true
                }
            });
    }

    public override List<Tooltip>? GetExtraTooltips()
    {
        var tooltips = new List<Tooltip>()
        {
            new TTCard()
            {
                card = new CobraCardLeakingContainer()
            }
        };
        return tooltips;
    }
}
