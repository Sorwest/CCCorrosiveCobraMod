using Nickel;
using System.Collections.Generic;
using System.Reflection;
using Sorwest.CorrosiveCobra.Cards;

namespace Sorwest.CorrosiveCobra.Artifacts;

public class SlimeMaxArtifactReward : Artifact, IModdedArtifact
{
    public static void Register(IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact("SlimeMaxArtifactReward", new()
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                owner = ModEntry.Instance.DuoArtifactsApi!.DuoArtifactVanillaDeck,
                pools = [ArtifactPool.EventOnly]
            },
            Sprite = ModEntry.Instance.Sprites["SlimeMaxArtifactRewardSprite"].Sprite,
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "SlimeMaxArtifactReward", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "SlimeMaxArtifactReward", "description"]).Localize
        });
        ModEntry.Instance.DuoArtifactsApi!.RegisterDuoArtifact(typeof(SlimeMaxArtifactReward), new[] { ModEntry.Instance.SlimeDeck.Deck, Deck.hacker });
    }
    public override void OnReceiveArtifact(State state)
    {
        foreach (Artifact artifact in state.artifacts)
        {
            if (artifact.GetType() == typeof(SlimeMaxArtifact))
                artifact.OnRemoveArtifact(state);
        }
        state.artifacts.RemoveAll(r => r.GetType() == typeof(SlimeMaxArtifact));
        this.Pulse();
    }
    public override void OnCombatStart(State state, Combat combat)
    {
        combat.QueueImmediate(new AAddCard()
        {
            card = new CobraCardSlimeMaxDuoReward()
            {
                temporaryOverride = true
            },
            amount = 1,
            destination = CardDestination.Hand,
        });
        Pulse();
    }
    public override List<Tooltip>? GetExtraTooltips()
    {
        var tooltips = new List<Tooltip>()
        {
            new TTCard()
            {
                card =  new CobraCardSlimeMaxDuoReward(),
                showCardTraitTooltips = false,
            },
        };
        return tooltips;
    }
}