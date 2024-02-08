using Nickel;
using System.Collections.Generic;
using System.Reflection;
using Sorwest.CorrosiveCobra.Cards;

namespace Sorwest.CorrosiveCobra.Artifacts;

public class SlimeRiggsArtifact : Artifact, IModdedArtifact
{
    public static void Register(IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact("SlimeRiggsArtifact", new()
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                owner = ModEntry.Instance.DuoArtifactsApi!.DuoArtifactVanillaDeck,
                pools = [ArtifactPool.Common]
            },
            Sprite = ModEntry.Instance.Sprites["SlimeRiggsArtifactSprite"].Sprite,
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "SlimeRiggsArtifact", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "SlimeRiggsArtifact", "description"]).Localize
        });
        ModEntry.Instance.DuoArtifactsApi!.RegisterDuoArtifact(typeof(SlimeRiggsArtifact), new[] { ModEntry.Instance.SlimeDeck.Deck, Deck.riggs });
    }
    public override void OnPlayerDeckShuffle(State state, Combat combat)
    {
        combat.QueueImmediate(new AAddCard()
        {
            amount = 1,
            card = new CobraCardSlimeRiggsDuo()
            {
                temporaryOverride = true
            },
            destination = CardDestination.Deck,
        });
        Pulse();
    }
    public override List<Tooltip>? GetExtraTooltips()
    {
        var tooltips = new List<Tooltip>()
        {
            new TTCard()
            {
                card = new CobraCardSlimeRiggsDuo()
            }
        };
        return tooltips;
    }
}