using Sorwest.CorrosiveCobra.Cards;
namespace Sorwest.CorrosiveCobra.Actions;
public class ASlimeBooksDuoDelay : CardAction
{
    public override void Begin(G g, State s, Combat c)
    {
        this.timer = 0.0;
        bool flag = false;
        foreach (Card card in c.hand)
        {
            if (card is CobraCardSlimeBooksDuo)
                flag = true;
        }
        if (flag)
            return;
        c.QueueImmediate((CardAction)new AAddCard()
        {
            card = (Card)new CobraCardSlimeBooksDuo(),
            destination = CardDestination.Hand
        });
    }
}
