using Nickel;
using System.Collections.Generic;
using System.Reflection;
using Sorwest.CorrosiveCobra.Cards;

namespace Sorwest.CorrosiveCobra.Artifacts;

public class CobraArtifactUnstableTanks : Artifact, IModdedArtifact
{
    public static void Register(IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact("UnstableTanks", new()
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                owner = Deck.colorless,
                pools = [ArtifactPool.EventOnly],
                unremovable = true
            },
            Sprite = ModEntry.Instance.Sprites["UnstableTanksSprite"].Sprite,
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "UnstableTanks", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "UnstableTanks", "description"]).Localize
        });
    }
    public override string Name() => "UNSTABLE FUELTANKS";
    public override void OnTurnStart(State state, Combat combat)
    {
        combat.QueueImmediate(new AStatus()
        {
            status = ModEntry.Instance.OxidationStatus.Status,
            statusAmount = 1,
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
                card = new CobraCardLeakingContainer(),
                showCardTraitTooltips = false
            }
        };
        return tooltips;
    }
}
