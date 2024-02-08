using Sorwest.CorrosiveCobra.Cards;

namespace Sorwest.CorrosiveCobra;
public class ASlimeBooksDuoDelay : CardAction
{
    public override void Begin(G g, State s, Combat c)
    {
        timer = 0.0;
        bool flag = false;
        foreach (Card card in c.hand)
        {
            if (card is CobraCardSlimeBooksDuo)
                flag = true;
        }
        if (flag)
            return;
        c.QueueImmediate(new AAddCard()
        {
            card = new CobraCardSlimeBooksDuo(),
            destination = CardDestination.Hand
        });
    }
}