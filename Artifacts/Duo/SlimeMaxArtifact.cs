using Nickel;
using System.Reflection;
using Sorwest.CorrosiveCobra.Cards;

namespace Sorwest.CorrosiveCobra.Artifacts;

public class SlimeMaxArtifact : Artifact, IModdedArtifact
{
    public static void Register(IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact("SlimeMaxArtifact", new()
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                owner = ModEntry.Instance.DuoArtifactsApi!.DuoArtifactVanillaDeck,
                pools = [ArtifactPool.Common]
            },
            Sprite = ModEntry.Instance.Sprites["SlimeMaxArtifactSprite"].Sprite,
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "SlimeMaxArtifact", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "SlimeMaxArtifact", "description"]).Localize
        });
        ModEntry.Instance.DuoArtifactsApi!.RegisterDuoArtifact(typeof(SlimeMaxArtifact), new[] { ModEntry.Instance.SlimeDeck.Deck, Deck.hacker });
    }
    public override void OnCombatStart(State state, Combat combat)
    {
        combat.QueueImmediate(new AAddCard()
        {
            card = new CobraCardSlimeMaxDuo1()
            {
                temporaryOverride = true,
            },
            amount = 1,
            destination = CardDestination.Hand,
        });
        Pulse();
    }
}