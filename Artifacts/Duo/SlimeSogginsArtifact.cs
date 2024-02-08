using Nickel;
using System.Collections.Generic;
using System.Reflection;
using Sorwest.CorrosiveCobra.Cards;

namespace Sorwest.CorrosiveCobra.Artifacts;

public class SlimeSogginsArtifact : Artifact , ISmugHook, IModdedArtifact
{
    public static void Register(IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact("SlimeSogginsArtifact", new()
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new()
            {
                owner = ModEntry.Instance.DuoArtifactsApi!.DuoArtifactVanillaDeck,
                pools = [ArtifactPool.Common]
            },
            Sprite = ModEntry.Instance.Sprites["SlimeSogginsArtifactSprite"].Sprite,
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "SlimeSogginsArtifact", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "SlimeSogginsArtifact", "description"]).Localize
        });
        ModEntry.Instance.DuoArtifactsApi!.RegisterDuoArtifact(typeof(SlimeSogginsArtifact), new[] { ModEntry.Instance.SlimeDeck.Deck, helper.Content.Decks.LookupByUniqueName("Shockah.Soggins::Shockah.Soggins.Deck.Soggins")!.Deck });
    }
    public int counter;
    public int TRIGGER = 4;
    public override Spr GetSprite()
    {
        if (counter <= 0)
            return ModEntry.Instance.Sprites["SlimeSogginsArtifactSprite"].Sprite;
        else
            return ModEntry.Instance.Sprites["SlimeSogginsArtifactSprite_Off"].Sprite;
    }
    public override void OnReceiveArtifact(State state)
    {
        counter = 0;
    }
    public void OnCardBotchedBySmug(State state, Combat combat, Card card)
    {
        if (counter > 0)
        {
            counter = 0;
            Pulse();
        }
        else if (counter <= 0)
        {
            counter -= 1;
            if (counter == (-1 * TRIGGER))
            {
                combat.QueueImmediate(new AAddCard()
                {
                    card = new CobraCardSlimeSogginsDuoBotch()
                    {
                        temporaryOverride = true,
                        discount = -1
                    },
                    amount = 1,
                });
                Pulse();
                counter = 0;
            }
        }
    }
    public void OnCardDoubledBySmug(State state, Combat combat, Card card)
    {
        if (counter < 0)
        {
            counter = 0;
            Pulse();
        }
        else if (counter >= 0)
        {
            counter += 1;
            if (counter == TRIGGER)
            {
                combat.QueueImmediate(new AAddCard()
                {
                    card = new CobraCardSlimeSogginsDuoDouble()
                    {
                        temporaryOverride = true,
                        discount = -1
                    },
                    amount = 1,
                });
                Pulse();
                counter = 0;
            }
        }
    }
    public override int? GetDisplayNumber(State s)
    {
        if (counter == 0)
            return null;
        return counter > 0 ? counter : -1 * counter;
    }
    public override List<Tooltip>? GetExtraTooltips()
    {
        if (counter != 0)
        {
            var tooltips = new List<Tooltip>();
            var textSmug = "Will gain a card after {0} <c=boldPink>{1} more times</c>.";
            if (counter < 0)
                textSmug = string.Format(textSmug, "botching", counter + TRIGGER);
            if (counter > 0)
                textSmug = string.Format(textSmug, "doubling", TRIGGER - counter);
            tooltips.Add(new TTText()
            {
                text = textSmug
            });
            return tooltips;
        };
        return null;
    }
}