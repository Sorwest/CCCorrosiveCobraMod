using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Sorwest.CorrosiveCobra;

[JsonConverter(typeof(StringEnumConverter))]
public enum FromSource
{
    Hand,
    Deck,
    Discard,
    Exhaust
}
public class APlayRandomCard : CardAction
{
    public FromSource fromSource;
    public override void Begin(G g, State s, Combat c)
    {
        var num = s.rngActions.NextInt();
        var num2 = c.hand.Count - 1;
        if (fromSource == FromSource.Hand)
        {
            num2 = num % c.hand.Count;
        }
        else if (fromSource == FromSource.Deck)
        {
            c.QueueImmediate(new ADrawCard() { count = 1});
            num2 = c.hand.Count;
        }
        else if (fromSource == FromSource.Discard && c.discard.Count > 0)
        {
            var card = c.discard[num % c.discard.Count];
            s.RemoveCardFromWhereverItIs(card.uuid);
            s.SendCardToDeck(card);
            c.QueueImmediate(new ADrawCard() { count = 1 });
            num2 = c.hand.Count;
        }
        else if (fromSource == FromSource.Exhaust && c.exhausted.Count > 0)
        {
            c.QueueImmediate(new PutDiscardedCardOnTopOfDrawPile() { selectedCard = c.exhausted[num % c.exhausted.Count]});
            c.QueueImmediate(new ADrawCard() { count = 1 });
            num2 = c.hand.Count;
        }
        if (c.hand.Count > 0)
            c.Queue(new APlayOtherCard() { handPosition = num2 });
    }

    public override List<Tooltip> GetTooltips(State s)
    {
        return new()
        {
            new CustomTTGlossary(
                CustomTTGlossary.GlossaryType.action,
                () => ModEntry.Instance.Sprites[$"PlayRandomCard{fromSource}"].Sprite,
                () => ModEntry.Instance.Localizations.Localize(["action", $"PlayRandomCard{fromSource}", "name"]),
                () => ModEntry.Instance.Localizations.Localize(["action", $"PlayRandomCard{fromSource}", "description"]),
                key: $"{ModEntry.Instance.Package.Manifest.UniqueName}::PlayRandomCard{fromSource}"
            )
        };
    }
}