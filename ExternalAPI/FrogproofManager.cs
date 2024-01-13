using Sorwest.CorrosiveCobra.Cards;

namespace Sorwest.CorrosiveCobra;

internal sealed class FrogproofManager : IFrogproofHook
{
    public FrogproofManager()
    {
        Manifest.Instance.SogginsApi?.RegisterFrogproofHook(this, 0);
    }

    public FrogproofType? GetFrogproofType(State state, Combat? combat, Card card, FrogproofHookContext context)
    {
        if (card is CobraCardSlimeSogginsDuoBotch || card is CobraCardSlimeSogginsDuoDouble)
            return FrogproofType.Innate;
        return null;
    }

    public void PayForFrogproof(State state, Combat? combat, Card card)
    {
    }
}
